using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    cliente.Calle = (string)Datos.Lector["Calle"];
                    cliente.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Localidad = new Localidad();
                    cliente.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Provincia = new Provincia();
                    cliente.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    cliente.Estado = (bool)Datos.Lector["Estado"];
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
                Datos.SetearConsulta("select IdCliente,\r\n\t\t\tC.Nombre as Cliente,\r\n\t\t\tC.Apellido as Apellido, \r\n\t\t\tC.Dni as Dni,\r\n\t\t\tc.Cuit as Cuit,\r\n\t\t\tc.Calle as Calle,\r\n\t\t\tc.Numero as Numero,\r\n\t\t\tC.Estado as Estado,\r\n\t\t\tL.Localidad_Id as LocalidadId,\r\n\t\t\tL.Nombre as Localidad,\r\n\t\t\tP.Provincia_Id as ProvinciaId,\r\n\t\t\tP.Nombre as Provincia\r\n\tfrom Cliente C \r\n\tinner join Localidad L on L.Localidad_Id = c.Localidad_Id\r\n\tinner join Provincia P on P.Provincia_Id = L.Provincia_Id\r\n\twhere C.Estado = 0");
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
                    cliente.Calle = (string)Datos.Lector["Calle"];
                    cliente.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Localidad = new Localidad();
                    cliente.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Provincia = new Provincia();
                    cliente.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    cliente.Estado = (bool)Datos.Lector["Estado"];
                    ListadoClientes.Add(cliente);
                }
                return ListadoClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AgregarCliente (Cliente Cliente)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("AgregarCliente");
                Datos.SetearParametros("@Apellido" , Cliente.Apellido);
                Datos.SetearParametros("@Nombre", Cliente.Nombre);
                Datos.SetearParametros("@Dni", Cliente.Dni);
                Datos.SetearParametros("@Cuit", Cliente.Cuit);
                Datos.SetearParametros("@Calle", Cliente.Calle);
                Datos.SetearParametros("@Numero", Cliente.Numero);
                Datos.SetearParametros("@LocalidadID", Cliente.Localidad.LocalidadId);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(Mensaje);
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

        public void ModificarCliente(Cliente Cliente)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("ModificarCliente");
                Datos.SetearParametros("@ClienteID" , Cliente.IdCliente);
                Datos.SetearParametros("@Apellido", Cliente.Apellido);
                Datos.SetearParametros("@Nombre", Cliente.Nombre);
                Datos.SetearParametros("@Dni", Cliente.Dni);
                Datos.SetearParametros("@Cuit", Cliente.Cuit);
                Datos.SetearParametros("@Calle", Cliente.Calle);
                Datos.SetearParametros("@Numero", Cliente.Numero);
                Datos.SetearParametros("@LocalidadID", Cliente.Localidad.LocalidadId);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(Mensaje);
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

        public void InactivarCliente(int Id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearProcedimiento("InactivarCliente");
                Datos.SetearParametros("@ClienteId", Id);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);
                Datos.EjecutarAccion();

                string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(Mensaje);
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

        public void ActivarCliente(int Id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearProcedimiento("ActivarCliente");
                Datos.SetearParametros("@ClienteId", Id);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);
                Datos.EjecutarAccion();

                string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(Mensaje);
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
