using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategorias()
        {

            try
            {
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearConsulta("select Categoria_Id, Nombre from Categoria\r\n");
                List<Categoria> lista = new List<Categoria>();
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = (int)Datos.Lector["Categoria_Id"];
                    categoria.Nombre = Datos.Lector["Nombre"].ToString();
                    lista.Add(categoria);  // Agregar la categoría a la lista
                    // Agregar la categoría a la lista 
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
