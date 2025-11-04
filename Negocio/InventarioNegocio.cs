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
            Sucursal, 
            Ubicacion, 
            StockActual, 
            StockMinimo, 
            UltimaActualizacion,
            EsCritico
        FROM vw_InventarioConUbicacion";

                if (sucursalId.HasValue)
                {
                    query += " WHERE Sucursal_Id = @Sucursal_Id";
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
                        Ubicacion = datos.Lector["Ubicacion"].ToString(),
                        EsCritico = Convert.ToBoolean(datos.Lector["EsCritico"])
                    };

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



