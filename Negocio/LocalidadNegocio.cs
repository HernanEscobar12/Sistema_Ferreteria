using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LocalidadNegocio
    {
        public List<Localidad> ListarLocalidades(int ProvinciaId)
		{
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				List<Localidad> Localidades = new List<Localidad>();
				Datos.SetearConsulta("select Localidad_Id, Nombre from Localidad where Provincia_Id = @ProvinciaId");
				Datos.SetearParametros("@ProvinciaId" , ProvinciaId);
				Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					Localidad aux = new Localidad();
					aux.LocalidadId = Datos.Lector.GetInt32(0);
					aux.Nombre = Datos.Lector.GetString(1);

					Localidades.Add(aux);

				}
				return Localidades;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }


		public List<Localidad> Listado()
		{
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				List<Localidad> Listado = new List<Localidad>();

				Datos.SetearConsulta("select Localidad_Id, Provincia_Id, Nombre from Localidad");
				Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					Localidad Aux = new Localidad();
					Aux.LocalidadId = (int)Datos.Lector["Localidad_Id"];
					Aux.Provincia = new Provincia();
					Aux.Provincia.ProvinciaId = (int)Datos.Lector["Provincia_Id"];
					Aux.LocalidadId = (int)Datos.Lector["Localidad_Id"];
					Aux.Nombre = (string)Datos.Lector["Nombre"];

					Listado.Add(Aux);
                }

				return Listado;

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}



    }
}
