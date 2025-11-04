using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {
        // 🔹 Método para listar todas las compras
        public List<Compra> ListarCompras()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
                                        SELECT c.Compra_Id, c.Fecha_Compra FechaCompra, c.Total, c.EstadoCompra,
      ec.Descripcion,p.Proveedor_Id ProveedorID , p.RazonSocial
FROM Compra c
INNER JOIN Proveedor p ON p.Proveedor_Id = c.Proveedor_Id
INNER JOIN CompraEstado ec ON ec.IdEstado = c.EstadoCompra
ORDER BY c.Fecha_Compra DESC
");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra compra = new Compra();
                    compra.IdCompra = (int)datos.Lector["Compra_Id"];
                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    compra.Total = Convert.ToDecimal(datos.Lector["Total"]);
                    compra.EstadoCompra = new EstadoCompra();
                    compra.EstadoCompra.IdEstadoCompra = Convert.ToInt32(datos.Lector["EstadoCompra"]);
                    compra.EstadoCompra.Descripcion = (string)datos.Lector["Descripcion"];
                    compra.Proveedor = new Proveedor
                    {
                        ProveedorId = (int)datos.Lector["ProveedorID"],
                        RazonSocial = datos.Lector["RazonSocial"].ToString()
                    };

                    lista.Add(compra);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las compras: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void RegistrarCompra(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // ✅ Verificar que haya una caja abierta antes de registrar la compra
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de registrar una compra.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Insertar cabecera y recuperar ID (⚙️ corregido: usamos SCOPE_IDENTITY())
                datos.SetearConsulta(@"
            INSERT INTO Compra (Proveedor_Id, Fecha_Compra, Total, EstadoCompra)
            VALUES (@Proveedor_Id, @FechaCompra, @Total, @EstadoCompra);
            SELECT CAST(SCOPE_IDENTITY() AS INT);");   // ✅ reemplaza el OUTPUT INSERTED.Compra_Id

                datos.SetearParametros("@Proveedor_Id", compra.Proveedor.ProveedorId);
                datos.SetearParametros("@FechaCompra", compra.FechaCompra);
                datos.SetearParametros("@Total", compra.Total);
                datos.SetearParametros("@EstadoCompra", 2); // Recibida

                int idCompra = Convert.ToInt32(datos.EjecutarEscalarTransaccion());

                // 2️⃣ Insertar detalles y movimientos de inventario
                foreach (var detalle in compra.Detalles)
                {
                    // DetalleCompra
                    datos.SetearConsulta(@"
                INSERT INTO DetalleCompra (Compra_Id, Producto_Id, Cantidad, PrecioUnitario)
                VALUES (@Compra_Id, @Producto_Id, @Cantidad, @PrecioUnitario)");

                    datos.SetearParametros("@Compra_Id", idCompra);
                    datos.SetearParametros("@Producto_Id", detalle.Producto.ProductoId);
                    datos.SetearParametros("@Cantidad", detalle.Cantidad);
                    datos.SetearParametros("@PrecioUnitario", detalle.PrecioUnitario);
                    datos.EjecutarAccionTransaccion();

                    // MovimientoInventario (entrada)
                    datos.SetearConsulta(@"
                INSERT INTO MovimientoInventario 
(Producto_Id, Tipo, Cantidad, Origen, Referencia_Id, Sucursal_Id)
VALUES (@Producto_Id, 'E', @Cantidad, 'Compra', @Referencia_Id, @Sucursal_Id);
");

                    datos.SetearParametros("@Producto_Id", detalle.Producto.ProductoId);
                    datos.SetearParametros("@Cantidad", detalle.Cantidad);
                    datos.SetearParametros("@Referencia_Id", idCompra);
                    datos.EjecutarAccionTransaccion();
                }

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al registrar compra: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
       
        public void ModificarCompra(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // ✅ Verificar que haya una caja abierta antes de modificar la compra
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de modificar una compra.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Actualizar cabecera
                datos.SetearConsulta(@"
            UPDATE Compra 
            SET Proveedor_Id = @Proveedor_Id, 
                Fecha_Compra = @FechaCompra, 
                Total = @Total
            WHERE Compra_Id = @IdCompra");

                datos.SetearParametros("@Proveedor_Id", compra.Proveedor.ProveedorId);
                datos.SetearParametros("@FechaCompra", compra.FechaCompra);
                datos.SetearParametros("@Total", compra.Total);
                datos.SetearParametros("@IdCompra", compra.IdCompra);
                datos.EjecutarAccionTransaccion();

                // 2️⃣ Eliminar detalles antiguos y volver a insertar
                datos.LimpiarParametros();
                datos.SetearConsulta("DELETE FROM DetalleCompra WHERE Compra_Id = @IdCompra");
                datos.SetearParametros("@IdCompra", compra.IdCompra);
                datos.EjecutarAccionTransaccion();

                foreach (var d in compra.Detalles)
                {
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
                INSERT INTO DetalleCompra (Compra_Id, Producto_Id, Cantidad, PrecioUnitario)
                VALUES (@Compra_Id, @Producto_Id, @Cantidad, @PrecioUnitario)");

                    datos.SetearParametros("@Compra_Id", compra.IdCompra);
                    datos.SetearParametros("@Producto_Id", d.Producto.ProductoId);
                    datos.SetearParametros("@Cantidad", d.Cantidad);
                    datos.SetearParametros("@PrecioUnitario", d.PrecioUnitario);
                    datos.EjecutarAccionTransaccion();
                }

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al modificar compra: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion(); // ✅ asegura cierre de conexión
            }
        }

        public void AnularCompra(int idCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // ✅ Validar caja abierta
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de anular una compra.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Cambiar estado
                datos.SetearConsulta("UPDATE Compra SET EstadoCompra = 4 WHERE Compra_Id = @Id");
                datos.SetearParametros("@Id", idCompra);
                datos.EjecutarAccionTransaccion();

                // 2️⃣ Obtener productos para restar stock
                List<(int productoId, int cantidad)> productos = new List<(int, int)>();

                datos.LimpiarParametros();
                datos.SetearConsulta("SELECT Producto_Id, Cantidad FROM DetalleCompra WHERE Compra_Id = @Id");
                datos.SetearParametros("@Id", idCompra);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int productoId = Convert.ToInt32(datos.Lector["Producto_Id"]);
                    int cantidad = Convert.ToInt32(datos.Lector["Cantidad"]);
                    productos.Add((productoId, cantidad));
                }

                datos.Lector.Close();

                // 3️⃣ Registrar movimiento inverso
                foreach (var (productoId, cantidad) in productos)
                {
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
                        INSERT INTO MovimientoInventario 
(Producto_Id, Tipo, Cantidad, Origen, Referencia_Id, Sucursal_Id)
VALUES (@Producto_Id, 'E', @Cantidad, 'Compra', @Referencia_Id, @Sucursal_Id);
");

                    datos.SetearParametros("@Producto_Id", productoId);
                    datos.SetearParametros("@Cantidad", cantidad);
                    datos.SetearParametros("@Referencia_Id", idCompra);
                    datos.EjecutarAccionTransaccion();
                }

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al anular compra: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    


        public void CambiarEstadoCompra(int idCompra, int nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Compra SET EstadoCompra = @Estado WHERE Compra_Id = @IdCompra");
                datos.SetearParametros("@Estado", nuevoEstado);
                datos.SetearParametros("@IdCompra", idCompra);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar estado de la compra: " + ex.Message);
            }
        }

        public List<Compra> FiltrarCompras(int? idCompra, int? idProveedor, int? idEstado, DateTime? desde, DateTime? hasta)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
            SELECT 
                c.Compra_Id, 
                c.Fecha_Compra, 
                c.Total, 
                c.EstadoCompra,
                p.Proveedor_Id, 
                p.RazonSocial, 
                ec.Descripcion AS EstadoDescripcion
            FROM Compra c
            INNER JOIN Proveedor p ON p.Proveedor_Id = c.Proveedor_Id
            INNER JOIN CompraEstado ec ON ec.IdEstado = c.EstadoCompra
            WHERE 1=1";

                // =====================================================
                // 🔹 Filtros dinámicos: se agregan solo si tienen valor
                // =====================================================
                if (idCompra.HasValue)
                    consulta += " AND c.Compra_Id = @IdCompra";

                if (idProveedor.HasValue)
                    consulta += " AND c.Proveedor_Id = @ProveedorId";

                if (idEstado.HasValue)
                    consulta += " AND c.EstadoCompra = @Estado";

                if (desde.HasValue)
                    consulta += " AND c.Fecha_Compra >= @Desde";

                if (hasta.HasValue)
                    consulta += " AND c.Fecha_Compra <= @Hasta";

                consulta += " ORDER BY c.Fecha_Compra DESC";

                // =====================================================
                // 🔹 Configuración de parámetros
                // =====================================================
                datos.SetearConsulta(consulta);

                if (idCompra.HasValue)
                    datos.SetearParametros("@IdCompra", idCompra.Value);

                if (idProveedor.HasValue)
                    datos.SetearParametros("@ProveedorId", idProveedor.Value);

                if (idEstado.HasValue)
                    datos.SetearParametros("@Estado", idEstado.Value);

                if (desde.HasValue)
                    datos.SetearParametros("@Desde", desde.Value);

                if (hasta.HasValue)
                    datos.SetearParametros("@Hasta", hasta.Value);

                // =====================================================
                // 🔹 Ejecución y lectura
                // =====================================================
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra compra = new Compra();

                    compra.IdCompra = (int)datos.Lector["Compra_Id"];
                    compra.FechaCompra = (DateTime)datos.Lector["Fecha_Compra"];
                    compra.Total = Convert.ToDecimal(datos.Lector["Total"]);

                    // Estado
                    compra.EstadoCompra = new EstadoCompra
                    {
                        IdEstadoCompra = Convert.ToInt32(datos.Lector["EstadoCompra"]),
                        Descripcion = datos.Lector["EstadoDescripcion"].ToString()
                    };

                    // Proveedor
                    compra.Proveedor = new Proveedor
                    {
                        ProveedorId = (int)datos.Lector["Proveedor_Id"],
                        RazonSocial = datos.Lector["RazonSocial"].ToString()
                    };

                    lista.Add(compra);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar las compras: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Compra ObtenerCompraConDetalles(int idCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            Compra compra = null;

            try
            {
                // 1️⃣ Traer datos principales de la compra
                datos.SetearConsulta(@"
            SELECT 
                c.Compra_Id, 
                c.Fecha_Compra, 
                c.Total, 
                c.EstadoCompra,
                ec.Descripcion AS EstadoDescripcion,
                p.Proveedor_Id, 
                p.RazonSocial, 
                p.Cuit, 
                p.Telefono, 
                p.Email
            FROM Compra c
            INNER JOIN Proveedor p ON p.Proveedor_Id = c.Proveedor_Id
            INNER JOIN CompraEstado ec ON ec.IdEstado = c.EstadoCompra
            WHERE c.Compra_Id = @IdCompra");

                datos.SetearParametros("@IdCompra", idCompra);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    compra = new Compra
                    {
                        IdCompra = (int)datos.Lector["Compra_Id"],
                        FechaCompra = (DateTime)datos.Lector["Fecha_Compra"],
                        Total = Convert.ToDecimal(datos.Lector["Total"]),
                        EstadoCompra = new EstadoCompra
                        {
                            IdEstadoCompra = Convert.ToInt32(datos.Lector["EstadoCompra"]),
                            Descripcion = datos.Lector["EstadoDescripcion"].ToString()
                        },
                        Proveedor = new Proveedor
                        {
                            ProveedorId = (int)datos.Lector["Proveedor_Id"],
                            RazonSocial = datos.Lector["RazonSocial"].ToString(),
                            Cuit = datos.Lector["Cuit"].ToString(),
                            Telefono = datos.Lector["Telefono"].ToString(),
                            Email = datos.Lector["Email"].ToString()
                        },
                        Detalles = new List<DetalleCompra>() // inicializamos lista vacía
                    };
                }

                datos.CerrarConexion();

                // 2️⃣ Si la compra existe, traer sus detalles
                if (compra != null)
                {
                    datos = new AccesoDatos();
                    datos.SetearConsulta(@"
                SELECT 
                    d.DetalleCompra_Id, 
                    d.Compra_Id, 
                    d.Producto_Id, 
                    d.Cantidad, 
                    d.PrecioUnitario,
                    p.Nombre, 
                    p.Descripcion
                FROM DetalleCompra d
                INNER JOIN Producto p ON p.Producto_Id = d.Producto_Id
                WHERE d.Compra_Id = @IdCompra");

                    datos.SetearParametros("@IdCompra", idCompra);
                    datos.EjecutarLectura();

                    while (datos.Lector.Read())
                    {
                        DetalleCompra detalle = new DetalleCompra
                        {
                            IdDetalleCompra = (int)datos.Lector["DetalleCompra_Id"],
                            IdCompra = (int)datos.Lector["Compra_Id"],
                            Producto = new Producto
                            {
                                ProductoId = (int)datos.Lector["Producto_Id"],
                                Nombre = datos.Lector["Nombre"].ToString(),
                                Descripcion = datos.Lector["Descripcion"].ToString()
                            },
                            Cantidad = Convert.ToInt32(datos.Lector["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(datos.Lector["PrecioUnitario"])
                        };

                        compra.Detalles.Add(detalle);
                    }
                }

                return compra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la compra: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }



    }
}

