using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InventarioNegocio
    {
        public List<Inventario> ListarInventario(int? sucursalId = null)
        {
            List<Inventario> lista = new List<Inventario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = @"
                SELECT 
                    Producto_Id, 
                    NombreProducto, 
                    Sucursal_Id, 
                    NombreSucursal, 
                    StockActual, 
                    StockMinimo, 
                    UltimaActualizacion
                FROM vw_InventarioGeneral";

                if (sucursalId.HasValue)
                    query += " WHERE Sucursal_Id = @Sucursal_Id";

                datos.SetearConsulta(query);

                if (sucursalId.HasValue)
                    datos.SetearParametros("@Sucursal_Id", sucursalId.Value);

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Inventario inv = new Inventario
                    {
                        Producto = new Producto
                        {
                            ProductoId = (int)datos.Lector["Producto_Id"],
                            Nombre = datos.Lector["NombreProducto"].ToString()
                        },
                        Sucursal = new Sucursal
                        {
                            SucursalId = datos.Lector["Sucursal_Id"] != DBNull.Value ? (int)datos.Lector["Sucursal_Id"] : 0,
                            Nombre = datos.Lector["NombreSucursal"] != DBNull.Value ? datos.Lector["NombreSucursal"].ToString() : "(Sin Sucursal)"
                        },
                        StockActual = Convert.ToInt32(datos.Lector["StockActual"]),
                        StockMinimo = Convert.ToInt32(datos.Lector["StockMinimo"]),
                        UltimaActualizacion = datos.Lector["UltimaActualizacion"] != DBNull.Value
                            ? Convert.ToDateTime(datos.Lector["UltimaActualizacion"])
                            : DateTime.MinValue
                    };

                    lista.Add(inv);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener inventario: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Inventario> ListarInventarioConUbicacion(int? sucursalId = null)
        {
            List<Inventario> lista = new List<Inventario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = @"
            SELECT 
                Producto_Id, 
                NombreProducto, 
                Sucursal_Id,
                Sucursal, 
                Ubicacion, 
                Estanteria, 
                Nivel, 
                StockActual, 
                StockMinimo, 
                UltimaActualizacion
            FROM vw_InventarioConUbicacion";

                if (sucursalId.HasValue)
                {
                    query += " WHERE Sucursal_Id = @Sucursal_Id"; // ✅ filtra por sucursal correctamente
                    datos.SetearConsulta(query);
                    datos.SetearParametros("@Sucursal_Id", sucursalId.Value);
                }
                else
                {
                    datos.SetearConsulta(query);
                }

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Inventario inv = new Inventario
                    {
                        Producto = new Producto
                        {
                            Nombre = datos.Lector["NombreProducto"].ToString()
                        },
                        Sucursal = new Sucursal
                        {
                            Nombre = datos.Lector["Sucursal"].ToString()
                        },
                        StockActual = Convert.ToInt32(datos.Lector["StockActual"]),
                        StockMinimo = Convert.ToInt32(datos.Lector["StockMinimo"]),
                        UltimaActualizacion = Convert.ToDateTime(datos.Lector["UltimaActualizacion"]),
                        Ubicacion = datos.Lector["Ubicacion"].ToString()
                    };

                    // ✅ Leer columnas adicionales si existen
                    if (datos.Lector["Estanteria"] != DBNull.Value)
                        inv.Ubicacion += $" - Estante {datos.Lector["Estanteria"]}";

                    if (datos.Lector["Nivel"] != DBNull.Value)
                        inv.Ubicacion += $" Nivel {datos.Lector["Nivel"]}";

                    lista.Add(inv);
                }
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

    }

}
