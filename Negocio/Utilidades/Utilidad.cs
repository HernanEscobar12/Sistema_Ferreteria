using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class Utilidad
    {
        public List<Rol> ListadoDeRol()
        {
            try
            {
                List<Rol> Listado = new List<Rol>();
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearConsulta("select  IdRol, Nombre, Descripcion from Rol");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Rol Aux = new Rol();
                    Aux.IdRol = (int)Datos.Lector["IdRol"];
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Descripcion = (string)Datos.Lector["Descripcion"];

                    Listado.Add(Aux);
                }

                return Listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //--    Cargos -- 
        public List<Cargo> ListadoDeCargo()
        {
            try
            {
                List<Cargo> Listado = new List<Cargo>();
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearConsulta("select IdCargo, Descripcion  from Cargo");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Cargo Aux = new Cargo();
                    Aux.IdCargo = (int)Datos.Lector["IdCargo"];
                    Aux.Descripcion = (string)Datos.Lector["Descripcion"];

                    Listado.Add(Aux);
                }

                return Listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // Sucursales
        public List<Sucursal> ListadoSucursales()
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
