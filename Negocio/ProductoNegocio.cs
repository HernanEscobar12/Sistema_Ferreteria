using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {

        // Listar Productos
        public List<Producto> ListarProductos()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Producto> lista = new List<Producto>();

                Datos.SetearConsulta("select Producto_Id, Codigo, Nombre, Descripcion, PrecioUnitario, ImagenProducto, Categoria_Id from Producto");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.ProductoId = (int)Datos.Lector["Producto_Id"];
                    producto.Codigo = Datos.Lector["Codigo"].ToString();
                    producto.Nombre = Datos.Lector["Nombre"].ToString();
                    producto.Descripcion = Datos.Lector["Descripcion"].ToString();
                    producto.PrecioUnitario = (decimal)Datos.Lector["PrecioUnitario"];
                    if (!(Datos.Lector["ImagenProducto"] is DBNull))
                    {
                        producto.UrlImagen = (string)Datos.Lector["ImagenProducto"];
                    }
                    producto.Categoria = new Categoria();
                    producto.Categoria.IdCategoria = (int)Datos.Lector["Categoria_Id"];
                    lista.Add(producto);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Producto> Listado()
        {
            AccesoDatos Datos = new AccesoDatos();

            List<Producto> lista = new List<Producto>();

            try
            {
               Datos.SetearProcedimiento("ListarProductos");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.ProductoId = (int)Datos.Lector["Producto_Id"];
                    producto.Codigo = Datos.Lector["Codigo"].ToString();
                    producto.Nombre = Datos.Lector["Nombre"].ToString();
                    producto.Descripcion = Datos.Lector["Descripcion"].ToString();
                    producto.PrecioUnitario = (decimal)Datos.Lector["PrecioUnitario"];
                    if (!(Datos.Lector["ImagenProducto"] is DBNull))
                    {
                        producto.UrlImagen = (string)Datos.Lector["ImagenProducto"];
                    }
                    producto.Categoria = new Categoria();
                    producto.Categoria.IdCategoria = (int)Datos.Lector["Categoria_Id"];
                    producto.Categoria.Nombre = (string)Datos.Lector["Categoria"];
                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}