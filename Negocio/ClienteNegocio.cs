using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    { 
        public List<Cliente> ListarClientes()
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("ListarClientes");
                List<Cliente> ListadoClientes = new List<Cliente>();

                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)Datos.Lector["IdCliente"];
                    cliente.Nombre = Datos.Lector["Cliente"].ToString();
                    cliente.Apellido = Datos.Lector["Apellido"].ToString();
                    cliente.Dni = Datos.Lector["Dni"].ToString();
                    cliente.Cuit = Datos.Lector["Cuit"].ToString();
                    cliente.Direccion = new Direccion();
                    cliente.Direccion.DireccionId = (int)Datos.Lector["DireccionID"];
                    cliente.Direccion.Calle = (string)Datos.Lector["Calle"].ToString();
                    cliente.Direccion.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Localidad = new Localidad();
                    cliente.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Localidad.Provincia = new Provincia();
                    cliente.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];             
                    ListadoClientes.Add(cliente);
                }
                return ListadoClientes;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public List<Cliente> ListadoClienteInactivos()
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Select IdCliente, Apellido, C.Nombre Cliente , Dni, Cuit, D.Direccion_Id DireccionID ,D.Calle Calle, D.Numero Numero , L.Localidad_Id LocalidadId , L.Nombre Localidad, P.Provincia_Id ProvinciaId , P.Nombre Provincia\r\nfrom Cliente c \r\ninner join Direccion D on C.Direccion_Id = D.Direccion_Id\r\ninner join Localidad L on  C.Localidad_Id = L.Localidad_Id\r\ninner join Provincia P on  L.Provincia_Id = P.Provincia_Id\r\nwhere C.Estado = 0");
                List<Cliente> ListadoClientes = new List<Cliente>();

                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)Datos.Lector["IdCliente"];
                    cliente.Nombre = Datos.Lector["Cliente"].ToString();
                    cliente.Apellido = Datos.Lector["Apellido"].ToString();
                    cliente.Dni = Datos.Lector["Dni"].ToString();
                    cliente.Cuit = Datos.Lector["Cuit"].ToString();
                    cliente.Direccion = new Direccion();
                    cliente.Direccion.DireccionId = (int)Datos.Lector["DireccionID"];
                    cliente.Direccion.Calle = (string)Datos.Lector["Calle"].ToString();
                    cliente.Direccion.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Localidad = new Localidad();
                    cliente.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Localidad.Provincia = new Provincia();
                    cliente.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    ListadoClientes.Add(cliente);
                }
                return ListadoClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
