using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        // 🔹 Listar todas las ventas
        public List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
             SELECT 
    v.Pedido_Id, 
    v.Fecha_Pedido AS FechaVenta, 
    v.Total,
	ev.IdEstado IdEstado ,
    ev.Descripcion AS EstadoDescripcion,
    c.IdCliente, 
    c.Nombre, 
    c.Apellido
FROM Pedido v
INNER JOIN Cliente c ON c.IdCliente = v.IdCliente
INNER JOIN PedidoEstado ev ON ev.IdEstado = v.EstadoVenta
ORDER BY v.Fecha_Pedido DESC;");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.IdVenta = (int)datos.Lector["Pedido_Id"];
                    venta.FechaVenta = (DateTime)datos.Lector["FechaVenta"];
                    venta.Total = Convert.ToDecimal(datos.Lector["Total"]);
                    venta.EstadoVenta = new EstadoVenta
                    {
                        IdEstadoVenta = Convert.ToInt32(datos.Lector["IdEstado"]),
                        Descripcion = datos.Lector["EstadoDescripcion"].ToString()
                    };
                    venta.Cliente = new Cliente
                    {
                        IdCliente = (int)datos.Lector["IdCliente"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                    };

                    lista.Add(venta);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las ventas: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🔹 Registrar nueva venta
        public void RegistrarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // ✅ Verificar que haya una caja abierta antes de registrar la venta
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de registrar una venta.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Insertar cabecera y recuperar ID (⚙️ corregido: sin OUTPUT)
                datos.SetearConsulta(@"
            INSERT INTO Pedido (IdCliente, Fecha_Pedido, Total, EstadoVenta)
            VALUES (@Cliente_Id, @FechaVenta, @Total, @EstadoVenta);
            SELECT CAST(SCOPE_IDENTITY() AS INT);");  // ✅ SCOPE_IDENTITY() reemplaza OUTPUT

                datos.SetearParametros("@Cliente_Id", venta.Cliente.IdCliente);
                datos.SetearParametros("@FechaVenta", venta.FechaVenta);
                datos.SetearParametros("@Total", venta.Total);
                datos.SetearParametros("@EstadoVenta", 3); // Pagada

                int idVenta = Convert.ToInt32(datos.EjecutarEscalarTransaccion());

                // 2️⃣ Insertar detalle y movimiento de stock
                foreach (var detalle in venta.Detalles)
                {
                    // Detalle de la venta
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
                INSERT INTO DetallePedido (Pedido_Id, Producto_Id, Cantidad, PrecioUnitario)
                VALUES (@Pedido_Id, @Producto_Id, @Cantidad, @PrecioUnitario)");

                    datos.SetearParametros("@Pedido_Id", idVenta);
                    datos.SetearParametros("@Producto_Id", detalle.Producto.ProductoId);
                    datos.SetearParametros("@Cantidad", detalle.Cantidad);
                    datos.SetearParametros("@PrecioUnitario", detalle.PrecioUnitario);
                    datos.EjecutarAccionTransaccion();
                    
                    // MovimientoInventario (salida)
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
INSERT INTO MovimientoInventario 
(Producto_Id, Tipo, Cantidad, Origen, Referencia_Id, Sucursal_Id, Usuario_Id )
VALUES (@Producto_Id, 'S', @Cantidad, 'Venta', @Referencia_Id, @Sucursal_Id, @Usuario_Id)");

                    datos.SetearParametros("@Producto_Id", detalle.Producto.ProductoId);
                    datos.SetearParametros("@Cantidad", detalle.Cantidad);
                    datos.SetearParametros("@Referencia_Id", idVenta);
                    datos.SetearParametros("@Sucursal_Id", SessionActual.Sucursal.SucursalId); // ✅ agregado
                    datos.SetearParametros("@Usuario_Id", SessionActual.Usuario.IdUsuario); // ✅ agregado
                    datos.EjecutarAccionTransaccion();
                }

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al registrar venta: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🔹 Modificar venta existente
        public void ModificarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // ✅ Verificar caja abierta
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de modificar una venta.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Actualizar cabecera
                datos.SetearConsulta(@"
            UPDATE Pedido 
            SET IdCliente = @Cliente_Id, 
                Fecha_Pedido = @FechaVenta, 
                Total = @Total
            WHERE Pedido_Id = @IdVenta");

                datos.SetearParametros("@Cliente_Id", venta.Cliente.IdCliente);
                datos.SetearParametros("@FechaVenta", venta.FechaVenta);
                datos.SetearParametros("@Total", venta.Total);
                datos.SetearParametros("@IdVenta", venta.IdVenta);
                datos.EjecutarAccionTransaccion();

                // 2️⃣ Eliminar detalles antiguos y volver a insertar
                datos.LimpiarParametros();
                datos.SetearConsulta("DELETE FROM DetallePedido WHERE Pedido_Id = @IdVenta");
                datos.SetearParametros("@IdVenta", venta.IdVenta);
                datos.EjecutarAccionTransaccion();

                foreach (var d in venta.Detalles)
                {
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
                INSERT INTO DetallePedido (Pedido_Id, Producto_Id, Cantidad, PrecioUnitario)
                VALUES (@Pedido_Id, @Producto_Id, @Cantidad, @PrecioUnitario)");

                    datos.SetearParametros("@Pedido_Id", venta.IdVenta);
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
                throw new Exception("Error al modificar venta: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🔹 Anular venta
        public void AnularVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // ✅ Verificar caja abierta
                CajaNegocio cajaNegocio = new CajaNegocio();
                if (!cajaNegocio.HayCajaAbierta())
                {
                    throw new Exception("No hay una caja abierta. Debe abrir la caja antes de anular una venta.");
                }

                datos.IniciarTransaccion();

                // 1️⃣ Cambiar estado
                datos.SetearConsulta("UPDATE Pedido SET EstadoVenta = 5 WHERE Pedido_Id = @Id");
                datos.SetearParametros("@Id", idVenta);
                datos.EjecutarAccionTransaccion();

                // 2️⃣ Obtener productos para reponer stock
                datos.LimpiarParametros();
                datos.SetearConsulta("SELECT Producto_Id, Cantidad FROM DetallePedido WHERE Pedido_Id = @Id");
                datos.SetearParametros("@Id", idVenta);
                datos.EjecutarLectura();

                List<(int productoId, int cantidad)> productos = new List<(int, int)>();
                while (datos.Lector.Read())
                {
                    int productoId = Convert.ToInt32(datos.Lector["Producto_Id"]);
                    int cantidad = Convert.ToInt32(datos.Lector["Cantidad"]);
                    productos.Add((productoId, cantidad));
                }
                datos.Lector.Close(); // ✅ muy importante

                // 3️⃣ Registrar entradas al inventario
                foreach (var (productoId, cantidad) in productos)
                {
                    datos.LimpiarParametros();
                    datos.SetearConsulta(@"
                INSERT INTO MovimientoInventario 
(Producto_Id, Tipo, Cantidad, Origen, Referencia_Id, Sucursal_Id)
VALUES (@Producto_Id, 'E', @Cantidad, 'Compra', @Referencia_Id, @Sucursal_Id , @Usuario_Id);
");

                    datos.SetearParametros("@Producto_Id", productoId);
                    datos.SetearParametros("@Cantidad", cantidad);
                    datos.SetearParametros("@Referencia_Id", idVenta);
                    datos.SetearParametros("@Sucursal_Id", SessionActual.Sucursal.SucursalId);
                    datos.SetearParametros("@Usuario_Id", SessionActual.Sucursal.SucursalId);
                    datos.EjecutarAccionTransaccion();
                }

                datos.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw new Exception("Error al anular la venta: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🔹 Obtener venta con detalles
        public Venta ObtenerVentaConDetalles(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            Venta venta = null;

            try
            {
                // Cabecera
                datos.SetearConsulta(@"
                    SELECT 
                        v.Pedido_Id, v.Fecha_Pedido, v.Total, v.EstadoVenta,
                        ev.Descripcion AS EstadoDescripcion,
                        c.IdCliente, c.Nombre, c.Apellido, c.Cuit
                    FROM Pedido v
                    INNER JOIN Cliente c ON c.IdCliente = v.IdCliente
                    INNER JOIN PedidoEstado ev ON ev.IdEstado = v.EstadoVenta
                    WHERE v.Pedido_Id = @IdVenta");
                datos.SetearParametros("@IdVenta", idVenta);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    venta = new Venta
                    {
                        IdVenta = (int)datos.Lector["Pedido_Id"],
                        FechaVenta = (DateTime)datos.Lector["Fecha_Pedido"],
                        Total = Convert.ToDecimal(datos.Lector["Total"]),
                        EstadoVenta = new EstadoVenta
                        {
                            IdEstadoVenta = Convert.ToInt32(datos.Lector["EstadoVenta"]),
                            Descripcion = datos.Lector["EstadoDescripcion"].ToString()
                        },
                        Cliente = new Cliente
                        {
                            IdCliente = (int)datos.Lector["IdCliente"],
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString(),
                            Cuit = datos.Lector["Cuit"].ToString()
                        },
                        Detalles = new List<DetalleVenta>()
                    };
                }

                datos.CerrarConexion();

                // Detalles
                if (venta != null)
                {
                    datos = new AccesoDatos();
                    datos.SetearConsulta(@"
                        SELECT 
              d.Detalle_Id, d.Pedido_Id, d.Producto_Id, d.Cantidad, d.PrecioUnitario,
              p.Nombre, p.Descripcion
          FROM DetallePedido d
          INNER JOIN Producto p ON p.Producto_Id = d.Producto_Id
          WHERE d.Pedido_Id = @IdVenta");
                    datos.SetearParametros("@IdVenta", idVenta);
                    datos.EjecutarLectura();

                    while (datos.Lector.Read())
                    {
                        DetalleVenta det = new DetalleVenta
                        {
                            IdDetalleVenta = (int)datos.Lector["Detalle_Id"],
                            Producto = new Producto
                            {
                                ProductoId = (int)datos.Lector["Producto_Id"],
                                Nombre = datos.Lector["Nombre"].ToString(),
                                Descripcion = datos.Lector["Descripcion"].ToString()
                            },
                            Cantidad = Convert.ToInt32(datos.Lector["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(datos.Lector["PrecioUnitario"])
                        };

                        venta.Detalles.Add(det);
                    }
                }

                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalles de la venta: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // 🔹 Filtrar ventas según criterios
        public List<Venta> FiltrarVentas(int? idVenta, int? idCliente, int? idEstado, DateTime? desde, DateTime? hasta)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
            SELECT 
                v.Pedido_Id,
                v.Fecha_Pedido,
                v.Total,
                v.EstadoVenta,
                c.IdCliente,
                c.Nombre,
                c.Apellido,
                ev.Descripcion AS EstadoDescripcion
            FROM Pedido v
            INNER JOIN Cliente c ON c.IdCliente = v.IdCliente
            INNER JOIN PedidoEstado ev ON ev.IdEstado = v.EstadoVenta
            WHERE 1 = 1";

                // 🔹 Filtros dinámicos
                if (idVenta.HasValue)
                    consulta += " AND v.Pedido_Id = @IdVenta";

                if (idCliente.HasValue)
                    consulta += " AND v.IdCliente = @ClienteId";

                if (idEstado.HasValue)
                    consulta += " AND v.EstadoVenta = @Estado";

                if (desde.HasValue)
                    consulta += " AND v.Fecha_Pedido >= @Desde";

                if (hasta.HasValue)
                    consulta += " AND v.Fecha_Pedido <= @Hasta";

                consulta += " ORDER BY v.Fecha_Pedido DESC";

                // 🔹 Asignar parámetros
                datos.SetearConsulta(consulta);

                if (idVenta.HasValue)
                    datos.SetearParametros("@IdVenta", idVenta.Value);

                if (idCliente.HasValue)
                    datos.SetearParametros("@ClienteId", idCliente.Value);

                if (idEstado.HasValue)
                    datos.SetearParametros("@Estado", idEstado.Value);

                if (desde.HasValue)
                    datos.SetearParametros("@Desde", desde.Value);

                if (hasta.HasValue)
                    datos.SetearParametros("@Hasta", hasta.Value);

                // 🔹 Leer resultados
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta venta = new Venta
                    {
                        IdVenta = (int)datos.Lector["Pedido_Id"],
                        FechaVenta = (DateTime)datos.Lector["Fecha_Pedido"],
                        Total = Convert.ToDecimal(datos.Lector["Total"]),
                        EstadoVenta = new EstadoVenta
                        {
                            IdEstadoVenta = Convert.ToInt32(datos.Lector["EstadoVenta"]),
                            Descripcion = datos.Lector["EstadoDescripcion"].ToString()
                        },
                        Cliente = new Cliente
                        {
                            IdCliente = (int)datos.Lector["IdCliente"],
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString()
                        }
                    };

                    lista.Add(venta);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar las ventas: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}

