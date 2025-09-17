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
    public class EmpleadoNegocio
    {

        public List<Empleado> ListarEmpleados()
        {
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				List<Empleado> lista = new List<Empleado>();
				Datos.SetearProcedimiento("ListarEmpleados");
				Datos.EjecutarLectura();
				while (Datos.Lector.Read())
				{
					Empleado Empleado = new Empleado();

					Empleado.EmpleadoId = (int)Datos.Lector["EmpleadoID"];
					Empleado.Nombre = (string)Datos.Lector["NombreEmpleado"];
					Empleado.Cuil = (string)Datos.Lector["Cuil"];
					Empleado.Calle = (string)Datos.Lector["Calle"];
					Empleado.Numero = (string)Datos.Lector["Numero"];
					Empleado.Estado = (bool)Datos.Lector["Estado"];
					Empleado.Localidad = new Localidad();
					Empleado.Localidad.LocalidadId = (int)Datos.Lector["IdLocalidad"];
					Empleado.Localidad.Nombre = (string)Datos.Lector["Nombre"];
                    Empleado.Cargo = new Cargo();
					Empleado.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
					Empleado.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
					Empleado.Telefono = (string)Datos.Lector["Telefono"];
					Empleado.Email = (string)Datos.Lector["Email"];
					Empleado.Sucursal = new Sucursal();
					Empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
					Empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];
					Empleado.FechaAlta = (DateTime)Datos.Lector["FechaAlta"];
					lista.Add(Empleado);
                }

				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

		public List<Empleado> ListarInactivos()
		{
			try
			{
                AccesoDatos Datos = new AccesoDatos();

                List<Empleado> lista = new List<Empleado>();
                Datos.SetearConsulta("select Empleado_Id as EmpleadoID, \r\nE.Nombre As NombreEmpleado, \r\nCuil, \r\nCalle , \r\nNumero,\r\nE.Localidad_Id as IdLocalidad,\r\nL.Nombre as Nombre,\r\nC.Descripcion as Cargo ,\r\nC.IdCargo As IdCargo  , \r\nE.Telefono as Telefono ,\r\nEmail,\r\nS.Sucursal_Id as IdSucursal,\r\nS.Nombre as Sucursal,\r\nFecha_Alta as FechaAlta,\r\nE.Estado as Estado\r\nfrom Empleado E \r\ninner join Cargo C on C.IdCargo = e.IdCargo\r\ninner join Sucursal S on S.Sucursal_Id = E.Sucursal_Id\r\ninner join Localidad L on L.Localidad_Id = E.Localidad_Id\r\nwhere E.Estado = 0");
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Empleado Empleado = new Empleado();

                    Empleado.EmpleadoId = (int)Datos.Lector["EmpleadoID"];
                    Empleado.Nombre = (string)Datos.Lector["NombreEmpleado"];
                    Empleado.Cuil = (string)Datos.Lector["Cuil"];
                    Empleado.Calle = (string)Datos.Lector["Calle"];
                    Empleado.Numero = (string)Datos.Lector["Numero"];
                    Empleado.Estado = (bool)Datos.Lector["Estado"];
                    Empleado.Localidad = new Localidad();
                    Empleado.Localidad.LocalidadId = (int)Datos.Lector["IdLocalidad"];
                    Empleado.Localidad.Nombre = (string)Datos.Lector["Nombre"];
                    Empleado.Cargo = new Cargo();
                    Empleado.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    Empleado.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
                    Empleado.Telefono = (string)Datos.Lector["Telefono"];
                    Empleado.Email = (string)Datos.Lector["Email"];
                    Empleado.Sucursal = new Sucursal();
                    Empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
                    Empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];
                    Empleado.FechaAlta = (DateTime)Datos.Lector["FechaAlta"];
                    
					lista.Add(Empleado);
                }

                return lista;
            }
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public void Agregar(Empleado empleado)
		{
			try
			{
				AccesoDatos Datos = new AccesoDatos();

				Datos.SetearProcedimiento("AgregarEmpleado");
				Datos.SetearParametros("@Nombre" , empleado.Nombre);
				Datos.SetearParametros("@Cuil" , empleado.Cuil);
				Datos.SetearParametros("@Calle" , empleado.Calle);
				Datos.SetearParametros("@Numero" , empleado.Numero);
				Datos.SetearParametros("@Localidad_Id" , empleado.Localidad.LocalidadId);
				Datos.SetearParametros("@Telefono" , empleado.Telefono);
				Datos.SetearParametros("@Email" , empleado.Email);
				Datos.SetearParametros("@Sucursal_Id" , empleado.Sucursal.SucursalId);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

				Datos.EjecutarAccion();

				string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();

				MessageBox.Show(Mensaje);

			}
			catch (SqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
            }
        }

		public void Modificar(Empleado empleado)
		{
            try
            {
                AccesoDatos Datos = new AccesoDatos();

                Datos.SetearProcedimiento("ModificarEmpleado");
				Datos.SetearParametros("@Empleado_Id", empleado.EmpleadoId);
                Datos.SetearParametros("@Nombre", empleado.Nombre);
                Datos.SetearParametros("@Cuil", empleado.Cuil);
                Datos.SetearParametros("@Calle", empleado.Calle);
                Datos.SetearParametros("@Numero", empleado.Numero);
                Datos.SetearParametros("@Localidad_Id", empleado.Localidad.LocalidadId);
                Datos.SetearParametros("@Telefono", empleado.Telefono);
                Datos.SetearParametros("@Email", empleado.Email);
                Datos.SetearParametros("@Sucursal_Id", empleado.Sucursal.SucursalId);
                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string Mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();

                MessageBox.Show(Mensaje);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		public void Inactivar(int id)
		{
			try
			{
				AccesoDatos Datos = new AccesoDatos();
				Datos.SetearConsulta("update Empleado set Estado = 0 where Empleado_Id = @IdEmpleado");
				Datos.SetearParametros("@IdEmpleado", id);
				Datos.EjecutarAccion();

			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public void Activar(int id)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                Datos.SetearConsulta("update Empleado set Estado = 1 where Empleado_Id = @IdEmpleado");
                Datos.SetearParametros("@IdEmpleado", id);
                Datos.EjecutarAccion();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
