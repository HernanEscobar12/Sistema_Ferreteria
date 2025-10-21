
using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SucursalNegocio
    {

        public List<Sucursal> Sucursales()
		{
			try
			{
				List<Sucursal> Listado = new List<Sucursal>();
				AccesoDatos Datos = new AccesoDatos();

				Datos.SetearConsulta("select Sucursal_Id, Nombre from Sucursal");
				Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					Sucursal Aux = new Sucursal();
					Aux.SucursalId = (int)Datos.Lector["Sucursal_Id"];
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
