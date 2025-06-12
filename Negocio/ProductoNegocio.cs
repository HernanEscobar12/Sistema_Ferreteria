using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class ProductoNegocio
    {

        // Listar Productos Inactivos
        public List<Producto> ListarProductosInactivos()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Producto> ListadoInactivos = new List<Producto>();

                Datos.SetearConsulta("select Producto_Id, Codigo, P.Nombre  ,Descripcion, PrecioUnitario, ImagenProducto, C.Categoria_Id, C.Nombre Categoria, P.Estado Estado from Producto P\r\ninner join Categoria C on  C.Categoria_Id = P.Categoria_Id \r\nwhere Estado = 0");
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
                    producto.Estado = (bool)Datos.Lector["Estado"];
                    ListadoInactivos.Add(producto);

                }

                return ListadoInactivos;
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
                    producto.Estado = (bool)Datos.Lector["Estado"];
                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Agregar Producto

        public void AgregarProducto(Producto producto)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearProcedimiento("AgregarProducto");
                Datos.SetearParametros("@Codigo", producto.Codigo);
                Datos.SetearParametros("@Nombre", producto.Nombre);
                Datos.SetearParametros("@Descripcion", producto.Descripcion);
                Datos.SetearParametros("@Precio", producto.PrecioUnitario);
                Datos.SetearParametros("@Img", producto.UrlImagen);
                Datos.SetearParametros("@Categoria_Id", producto.Categoria.IdCategoria);
                // Parámetro de salida
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        // Modificar Producto

        public void Modificar(Producto producto)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearProcedimiento("ModificarProducto");
                Datos.SetearParametros("@Codigo", producto.Codigo);
                Datos.SetearParametros("@Nombre", producto.Nombre);
                Datos.SetearParametros("@Descripcion", producto.Descripcion);
                Datos.SetearParametros("@Precio", producto.PrecioUnitario);
                Datos.SetearParametros("@Img", producto.UrlImagen);
                Datos.SetearParametros("@Categoria_Id", producto.Categoria.IdCategoria);
                // Parámetro de salida
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        // Inactivar Producto

        public void Inactivar(int Id)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();

                Datos.SetearProcedimiento("InactivarProductoLogico");
                Datos.SetearParametros("@Producto_Id", Id);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        // Activar Producto
        public void Activar(int Id)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();

                Datos.SetearProcedimiento("ActivarProducto");
                Datos.SetearParametros("@Producto_Id", Id);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }
}