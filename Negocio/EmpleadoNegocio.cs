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

        //     public List<Empleado> ListarEmpleados()
        //     {
        //try
        //{
        //	AccesoDatos Datos = new AccesoDatos();
        //	List<Empleado> lista = new List<Empleado>();
        //	Datos.SetearProcedimiento("ListarEmpleados");
        //	Datos.EjecutarLectura();
        //	while (Datos.Lector.Read())
        //	{
        //		Empleado Empleado = new Empleado();
        //		Empleado.EmpleadoId = (int)Datos.Lector["EmpleadoID"];
        //		Empleado.Nombre = (string)Datos.Lector["NombreEmpleado"];
        //		Empleado.Cuil = (string)Datos.Lector["Cuil"];
        //		//Empleado.Calle = (string)Datos.Lector["Calle"];
        //		//Empleado.Numero = (string)Datos.Lector["Numero"];
        //		Empleado.Estado = (bool)Datos.Lector["Estado"];
        //		Empleado.Localidad = new Localidad();
        //		Empleado.Localidad.LocalidadId = (int)Datos.Lector["IdLocalidad"];
        //		Empleado.Localidad.Nombre = (string)Datos.Lector["Nombre"];
        //                 Empleado.Cargo = new Cargo();
        //		Empleado.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
        //		Empleado.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
        //		Empleado.Telefono = (string)Datos.Lector["Telefono"];
        //		Empleado.Email = (string)Datos.Lector["Email"];
        //		Empleado.Sucursal = new Sucursal();
        //		Empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
        //		Empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];
        //		Empleado.FechaAlta = (DateTime)Datos.Lector["FechaAlta"];
        //		lista.Add(Empleado);
        //             }

        //	return lista;
        //}
        //catch (Exception ex)
        //{

        //	throw ex;
        //}
        //     }

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
                    Empleado empleado = new Empleado();
                    empleado.EmpleadoId = (int)Datos.Lector["EmpleadoID"];
                    empleado.Nombre = (string)Datos.Lector["NombreEmpleado"];
                    empleado.Cuil = (string)Datos.Lector["Cuil"];
                    empleado.Telefono = (string)Datos.Lector["Telefono"];
                    empleado.Email = (string)Datos.Lector["Email"];
                    empleado.FechaAlta = (DateTime)Datos.Lector["FechaAlta"];
                    empleado.Estado = (bool)Datos.Lector["Estado"];

                    // 🔹 Dirección
                    empleado.Direccion = new Direccion();
                    empleado.Direccion.Calle = (string)Datos.Lector["Calle"];
                    empleado.Direccion.Numero = Datos.Lector["Numero"].ToString();

                    // 🔹 Localidad
                    empleado.Direccion.Localidad = new Localidad();
                    empleado.Direccion.Localidad.LocalidadId = (int)Datos.Lector["IdLocalidad"];
                    empleado.Direccion.Localidad.Nombre = (string)Datos.Lector["NombreLocalidad"];

                    // 🔹 Provincia
                    empleado.Direccion.Localidad.Provincia = new Provincia();
                    empleado.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["IdProvincia"];
                    empleado.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["NombreProvincia"];

                    // 🔹 Cargo
                    empleado.Cargo = new Cargo();
                    empleado.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    empleado.Cargo.Descripcion = (string)Datos.Lector["Cargo"];

                    // 🔹 Sucursal
                    empleado.Sucursal = new Sucursal();
                    empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
                    empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];

                    lista.Add(empleado);
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
                Datos.SetearConsulta("    SELECT \r\n        E.Empleado_Id AS EmpleadoID,\r\n        E.Nombre AS NombreEmpleado,\r\n        E.Cuil,\r\n        D.Calle,\r\n        D.Numero,\r\n        L.Localidad_Id AS IdLocalidad,\r\n        L.Nombre AS NombreLocalidad,\r\n        P.Provincia_Id AS IdProvincia,\r\n        P.Nombre AS NombreProvincia,\r\n        C.Descripcion AS Cargo,\r\n        C.IdCargo AS IdCargo,\r\n        E.Telefono,\r\n        E.Email,\r\n        S.Sucursal_Id AS IdSucursal,\r\n        S.Nombre AS Sucursal,\r\n        E.Fecha_Alta AS FechaAlta,\r\n        E.Estado\r\n    FROM Empleado E\r\n        INNER JOIN Cargo C ON C.IdCargo = E.IdCargo\r\n        INNER JOIN Sucursal S ON S.Sucursal_Id = E.Sucursal_Id\r\n        INNER JOIN Direccion D ON D.Direccion_Id = E.Direccion_Id\r\n        INNER JOIN Localidad L ON L.Localidad_Id = D.Localidad_Id\r\n        INNER JOIN Provincia P ON P.Provincia_Id = L.Provincia_Id\r\n    WHERE E.Estado = 0");
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.EmpleadoId = (int)Datos.Lector["EmpleadoID"];
                    empleado.Nombre = (string)Datos.Lector["NombreEmpleado"];
                    empleado.Cuil = (string)Datos.Lector["Cuil"];
                    empleado.Telefono = (string)Datos.Lector["Telefono"];
                    empleado.Email = (string)Datos.Lector["Email"];
                    empleado.FechaAlta = (DateTime)Datos.Lector["FechaAlta"];
                    empleado.Estado = (bool)Datos.Lector["Estado"];

                    // 🔹 Dirección
                    empleado.Direccion = new Direccion();
                    empleado.Direccion.Calle = (string)Datos.Lector["Calle"];
                    empleado.Direccion.Numero = Datos.Lector["Numero"].ToString();

                    // 🔹 Localidad
                    empleado.Direccion.Localidad = new Localidad();
                    empleado.Direccion.Localidad.LocalidadId = (int)Datos.Lector["IdLocalidad"];
                    empleado.Direccion.Localidad.Nombre = (string)Datos.Lector["NombreLocalidad"];

                    // 🔹 Provincia
                    empleado.Direccion.Localidad.Provincia = new Provincia();
                    empleado.Direccion.Localidad.Provincia.ProvinciaId = (int)Datos.Lector["IdProvincia"];
                    empleado.Direccion.Localidad.Provincia.Nombre = (string)Datos.Lector["NombreProvincia"];

                    // 🔹 Cargo
                    empleado.Cargo = new Cargo();
                    empleado.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    empleado.Cargo.Descripcion = (string)Datos.Lector["Cargo"];

                    // 🔹 Sucursal
                    empleado.Sucursal = new Sucursal();
                    empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
                    empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];

                    lista.Add(empleado);
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

                Datos.SetearParametros("@Nombre", empleado.Nombre);
                Datos.SetearParametros("@Cuil", empleado.Cuil);
                Datos.SetearParametros("@Calle", empleado.Direccion.Calle);
                Datos.SetearParametros("@Numero", empleado.Direccion.Numero);
                Datos.SetearParametros("@Localidad_Id", empleado.Direccion.Localidad.LocalidadId);
                Datos.SetearParametros("@Telefono", empleado.Telefono);
                Datos.SetearParametros("@Email", empleado.Email);
                Datos.SetearParametros("@Sucursal_Id", empleado.Sucursal.SucursalId);
                Datos.SetearParametros("@IdCargo", empleado.Cargo.IdCargo);

                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Datos.SetearParametros("@Calle", empleado.Direccion.Calle);
                Datos.SetearParametros("@Numero", empleado.Direccion.Numero);
                Datos.SetearParametros("@Localidad_Id", empleado.Direccion.Localidad.LocalidadId);
                Datos.SetearParametros("@Telefono", empleado.Telefono);
                Datos.SetearParametros("@Email", empleado.Email);
                Datos.SetearParametros("@Sucursal_Id", empleado.Sucursal.SucursalId);
                Datos.SetearParametros("@IdCargo", empleado.Cargo.IdCargo);

                Datos.SetearParametroSalida("@Resultado", SqlDbType.NVarChar, 100);

                Datos.EjecutarAccion();

                string mensaje = Datos.ObtenerParametroSalida("@Resultado").ToString();
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
