using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CargoNegocio
    {

        public List<Cargo> ListarCargos()
        {
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				List<Cargo> Cargos = new List<Cargo>();

				Datos.SetearConsulta("select IdCargo, Descripcion from Cargo");
				Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					Cargo cargo = new Cargo();
					cargo.IdCargo = (int)Datos.Lector["IdCargo"];
					cargo.Descripcion = (string)Datos.Lector["Descripcion"];
                    Cargos.Add(cargo);
                }

				return Cargos;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
