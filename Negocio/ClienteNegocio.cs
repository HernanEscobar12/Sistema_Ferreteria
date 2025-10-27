using Datos;
using Dominio;
using Negocio.Utilidades;
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
                    cliente.Direccion = new Direccion();
                    cliente.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    cliente.Direccion.Calle = (string)Datos.Lector["Calle"];
                    cliente.Direccion.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Direccion.Localidad = new Localidad();
                    cliente.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Direccion.Localidad.Provincia = new Provincia();
                    cliente.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
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
                Datos.SetearConsulta("SELECT \r\n        C.IdCliente,\r\n        C.Nombre AS Cliente,\r\n        C.Apellido,\r\n        C.Dni,\r\n        C.Cuit,\r\n        D.Direccion_Id AS DireccionId,\r\n        D.Calle,\r\n        D.Numero,\r\n        L.Localidad_Id AS LocalidadId,\r\n        L.Nombre AS Localidad,\r\n        P.Provincia_Id AS ProvinciaId,\r\n        P.Nombre AS Provincia,\r\n        C.Estado\r\n    FROM Cliente C\r\n    INNER JOIN Direccion D ON C.Direccion_Id = D.Direccion_Id\r\n    INNER JOIN Localidad L ON D.Localidad_Id = L.Localidad_Id\r\n    INNER JOIN Provincia P ON L.Provincia_Id = P.Provincia_Id\r\n    WHERE C.Estado = 0");
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
                    cliente.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    cliente.Direccion.Calle = (string)Datos.Lector["Calle"];
                    cliente.Direccion.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Direccion.Localidad = new Localidad();
                    cliente.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Direccion.Localidad.Provincia = new Provincia();
                    cliente.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
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


        public List<Cliente> ListadoCompletoCliente()
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("SELECT \r\n        C.IdCliente,\r\n        C.Nombre AS Cliente,\r\n        C.Apellido,\r\n        C.Dni,\r\n        C.Cuit,\r\n        D.Direccion_Id AS DireccionId,\r\n        D.Calle,\r\n        D.Numero,\r\n        L.Localidad_Id AS LocalidadId,\r\n        L.Nombre AS Localidad,\r\n        P.Provincia_Id AS ProvinciaId,\r\n        P.Nombre AS Provincia,\r\n        C.Estado\r\n    FROM Cliente C\r\n    INNER JOIN Direccion D ON C.Direccion_Id = D.Direccion_Id\r\n    INNER JOIN Localidad L ON D.Localidad_Id = L.Localidad_Id\r\n    INNER JOIN Provincia P ON L.Provincia_Id = P.Provincia_Id\r\n ");
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
                    cliente.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    cliente.Direccion.Calle = (string)Datos.Lector["Calle"];
                    cliente.Direccion.Numero = (string)Datos.Lector["Numero"].ToString();
                    cliente.Direccion.Localidad = new Localidad();
                    cliente.Direccion.Localidad.LocalidadId = (int)Datos.Lector["LocalidadId"];
                    cliente.Direccion.Localidad.Nombre = (string)Datos.Lector["Localidad"].ToString();
                    cliente.Direccion.Localidad.Provincia = new Provincia();
                    cliente.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["ProvinciaId"];
                    cliente.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
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

        public void AgregarCliente(Cliente cliente)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                cliente.Cuit = Validaciones.FormatearCuil(cliente.Cuit);
                Datos.SetearProcedimiento("AgregarCliente");
                Datos.SetearParametros("@Apellido", cliente.Apellido);
                Datos.SetearParametros("@Nombre", cliente.Nombre);
                Datos.SetearParametros("@Dni", cliente.Dni);
                Datos.SetearParametros("@Cuit", cliente.Cuit);
                Datos.SetearParametros("@Calle", cliente.Direccion.Calle);
                Datos.SetearParametros("@Numero", cliente.Direccion.Numero);
                Datos.SetearParametros("@LocalidadID", cliente.Direccion.Localidad.LocalidadId);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 200);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
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
                Datos.SetearParametros("@Calle", Cliente.Direccion.Calle);
                Datos.SetearParametros("@Numero", Cliente.Direccion.Numero);
                Datos.SetearParametros("@LocalidadID", Cliente.Direccion.Localidad.LocalidadId);
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
