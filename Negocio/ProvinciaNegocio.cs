using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> ListarProvincias()
		{
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				List<Provincia> ListaProvincias = new List<Provincia>();
				Datos.SetearConsulta("select Provincia_Id, Nombre from Provincia");
				Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					Provincia Aux = new Provincia();
					Aux.ProvinciaId = (int)Datos.Lector["Provincia_Id"];
					Aux.Nombre = (string)Datos.Lector["Nombre"];
					ListaProvincias.Add(Aux);
				}
				return ListaProvincias;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
