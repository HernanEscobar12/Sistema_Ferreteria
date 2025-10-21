using Dominio;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom;
using Negocio.Utilidades;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario usuario)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();

                string ClaveEncriptada = Seguridad.Encriptar(usuario.Clave);

                Datos.SetearConsulta("select IdUsuario ,NombreUsuario ,Clave from Usuario where NombreUsuario = @User and Clave =  @Pass");
                Datos.SetearParametros("@User", usuario.User);
                Datos.SetearParametros("@Pass", ClaveEncriptada);

                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    usuario.User = Datos.Lector["NombreUsuario"].ToString().ToUpper();
                    usuario.IdUsuario = (int)Datos.Lector["IdUsuario"];

                }

                if (usuario.IdUsuario != 0)
                {
                    return true; // Login exitoso
                }
                else
                {
                    return false; // Login fallido
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Usuario> ListaUsuarios = new List<Usuario>();
                Datos.SetearConsulta("select U.IdUsuario IdUsuario , U.NombreUsuario NombreUsuario, U.Clave Clave ,C.IdCargo IdCargo,C.Descripcion Cargo ,E.Empleado_Id IdEmpleado,E.Nombre Nombre, E.Telefono Telefono,E.Email Email,E.Cuil Cuil,r.IdRol IdRol,R.Nombre Rol,E.Sucursal_Id IdSucursal, S.Nombre Sucursal, U.Estado Estado From Usuario U inner join Cargo C on C.IdCargo = U.IdCargo inner join Empleado E on E.Empleado_Id = U.EmpleadoId inner join UsuarioRol Ur on Ur.IdUsuario = U.IdUsuario inner join Rol R on R.IdRol = Ur.IdRol inner join Sucursal S on S.Sucursal_Id = E.Sucursal_Id\r\n where U.estado = 1");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)Datos.Lector["IdUsuario"];
                    usuario.Estado = Convert.ToInt32(Datos.Lector["Estado"]);
                    usuario.User = (string)Datos.Lector["NombreUsuario"];
                    usuario.Clave = (string)Datos.Lector["Clave"];
                    usuario.Empleado = new Empleado();
                    usuario.Empleado.EmpleadoId = (int)Datos.Lector["IdEmpleado"];
                    usuario.Empleado.Nombre = (string)Datos.Lector["Nombre"];
                    usuario.Empleado.Cuil = (string)Datos.Lector["Cuil"];
                    usuario.Empleado.Telefono = (string)Datos.Lector["Telefono"];
                    usuario.Empleado.Email = (string)Datos.Lector["Email"];
                    usuario.Empleado.Sucursal = new Sucursal();
                    usuario.Empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
                    usuario.Empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];
                    usuario.Cargo = new Cargo();
                    usuario.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    usuario.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
                    usuario.UsuarioRol = new UsuarioRol();
                    usuario.UsuarioRol.IdUsuario = (int)Datos.Lector["IdUsuario"];
                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)Datos.Lector["IdRol"];
                    usuario.Rol.Nombre = (string)Datos.Lector["Rol"];
                    ListaUsuarios.Add(usuario);

                }

                return ListaUsuarios;
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

        public List<Usuario> ListarInactivosUsuarios()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Usuario> ListaUsuarios = new List<Usuario>();
                Datos.SetearConsulta("select U.IdUsuario IdUsuario , U.NombreUsuario NombreUsuario, C.IdCargo IdCargo,C.Descripcion Cargo ,E.Empleado_Id IdEmpleado,E.Nombre Nombre, E.Telefono Telefono,E.Email Email,E.Cuil Cuil,r.IdRol IdRol,R.Nombre Rol,E.Sucursal_Id IdSucursal, S.Nombre Sucursal, U.Estado Estado From Usuario U inner join Cargo C on C.IdCargo = U.IdCargo inner join Empleado E on E.Empleado_Id = U.EmpleadoId inner join UsuarioRol Ur on Ur.IdUsuario = U.IdUsuario inner join Rol R on R.IdRol = Ur.IdRol inner join Sucursal S on S.Sucursal_Id = E.Sucursal_Id\r\nwhere U.Estado = 0");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)Datos.Lector["IdUsuario"];
                    usuario.Estado = Convert.ToInt32(Datos.Lector["Estado"]);
                    usuario.User = (string)Datos.Lector["NombreUsuario"];
                    usuario.Empleado = new Empleado();
                    usuario.Empleado.EmpleadoId = (int)Datos.Lector["IdEmpleado"];
                    usuario.Empleado.Nombre = (string)Datos.Lector["Nombre"];
                    usuario.Empleado.Cuil = (string)Datos.Lector["Cuil"];
                    usuario.Empleado.Telefono = (string)Datos.Lector["Telefono"];
                    usuario.Empleado.Email = (string)Datos.Lector["Email"];
                    usuario.Empleado.Sucursal = new Sucursal();
                    usuario.Empleado.Sucursal.SucursalId = (int)Datos.Lector["IdSucursal"];
                    usuario.Empleado.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];
                    usuario.Cargo = new Cargo();
                    usuario.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    usuario.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
                    usuario.UsuarioRol = new UsuarioRol();
                    usuario.UsuarioRol.IdUsuario = (int)Datos.Lector["IdUsuario"];
                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)Datos.Lector["IdRol"];
                    usuario.Rol.Nombre = (string)Datos.Lector["Rol"];
                    ListaUsuarios.Add(usuario);

                }

                return ListaUsuarios;
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

        public List<Empleado> ListarEmpleadosSinUsuarios()
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();
                List<Empleado> empleados = new List<Empleado>();

                Datos.SetearConsulta("select e.Empleado_Id IdEmpleado, e.Cuil Cuil, e.Nombre Empleado , E.IdCargo IdCargo, C.Descripcion Cargo  ,e.Telefono Telefono, E.Email Email , E.Direccion_Id DireccionId , D.Calle Calle , D.Numero Numero ,E.Sucursal_Id IdSucusal, S.Nombre Sucursal, U.NombreUsuario from Usuario u\r\nright join Empleado E on U.EmpleadoId = E.Empleado_Id\r\ninner join Sucursal S on S.Sucursal_Id = E.Sucursal_Id\r\ninner join Cargo C on C.IdCargo = E.IdCargo\r\ninner join Direccion D on D.Direccion_Id = E.Direccion_Id\r\nwhere U.NombreUsuario is null and E.Estado = 1");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Empleado E = new Empleado();
                    E.EmpleadoId = (int)Datos.Lector["IdEmpleado"];
                    E.Cuil = (string)Datos.Lector["Cuil"];
                    E.Nombre = (string)Datos.Lector["Empleado"];
                    E.Cargo = new Cargo();
                    E.Cargo.IdCargo = (int)Datos.Lector["IdCargo"];
                    E.Cargo.Descripcion = (string)Datos.Lector["Cargo"];
                    E.Telefono = (string)Datos.Lector["Telefono"];
                    E.Email = (string)Datos.Lector["Email"];
                    E.Direccion = new Direccion();
                    E.Direccion.DireccionId = (int)Datos.Lector["DireccionId"];
                    E.Direccion.Calle = (string)Datos.Lector["Calle"];
                    E.Direccion.Numero = (string)Datos.Lector["Numero"];
                    E.Sucursal = new Sucursal();
                    E.Sucursal.SucursalId = (int)Datos.Lector["IdSucusal"];
                    E.Sucursal.Nombre = (string)Datos.Lector["Sucursal"];

                    empleados.Add(E);
                }

                return empleados;
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

        public void CrearUsuario(Usuario usuario)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                // Encriptar clave antes de guardar
                usuario.Clave = Seguridad.Encriptar(usuario.Clave);

                // 1️⃣ Inserto en Usuario y obtengo el Id generado
                Datos.SetearConsulta(@"
            INSERT INTO Usuario (NombreUsuario, Clave, IdCargo, EmpleadoId, Estado)
            OUTPUT INSERTED.IdUsuario
            VALUES (@User, @Pass, @IdCargo, @IdEmpleado, 1)");
                Datos.SetearParametros("@User", usuario.User);
                Datos.SetearParametros("@Pass", usuario.Clave);
                Datos.SetearParametros("@IdCargo", usuario.Cargo.IdCargo);
                Datos.SetearParametros("@IdEmpleado", usuario.Empleado.EmpleadoId);


                int idUsuarioNuevo = (int)Datos.EjecutarEscalar();

                Datos.LimpiarParametros();

                // 2️⃣ Inserto en UsuarioRol usando el IdUsuario recién generado
                Datos.SetearConsulta("INSERT INTO UsuarioRol (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)");
                Datos.SetearParametros("@IdUsuario", idUsuarioNuevo);
                Datos.SetearParametros("@IdRol", usuario.Rol.IdRol);

                Datos.EjecutarAccion();



                Datos.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al crear usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al crear usuario: " + ex.Message);
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                // Si se modificó la clave, la encriptamos antes de guardar
                if (!string.IsNullOrEmpty(usuario.Clave))
                    usuario.Clave = Seguridad.Encriptar(usuario.Clave);

                // 1️⃣ Actualizo los datos principales del usuario
                Datos.SetearConsulta(@"
            UPDATE Usuario
            SET 
                NombreUsuario = @User,
                Clave = @Pass,
                IdCargo = @IdCargo,
                EmpleadoId = @IdEmpleado,
                Estado = 1
            WHERE IdUsuario = @IdUsuario");

                Datos.SetearParametros("@User", usuario.User);
                Datos.SetearParametros("@Pass", usuario.Clave);
                Datos.SetearParametros("@IdCargo", usuario.Cargo.IdCargo);
                Datos.SetearParametros("@IdEmpleado", usuario.Empleado.EmpleadoId);
                Datos.SetearParametros("@IdUsuario", usuario.IdUsuario);

                Datos.EjecutarAccion();

                // 2️⃣ Actualizo el rol asignado (si corresponde)
                Datos.LimpiarParametros();
                Datos.SetearConsulta(@"
            UPDATE UsuarioRol 
            SET IdRol = @IdRol 
            WHERE IdUsuario = @IdUsuario");

                Datos.SetearParametros("@IdRol", usuario.Rol.IdRol);
                Datos.SetearParametros("@IdUsuario", usuario.IdUsuario);
                Datos.EjecutarAccion();

                Datos.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al modificar usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al modificar usuario: " + ex.Message);
            }
        }

        public void ReiniciarClave(int idUsuario)
        {
            try
            {
                AccesoDatos Datos = new AccesoDatos();

                // Nueva clave predeterminada
                string claveNueva = "123456";

                // Encriptar antes de guardar
                string claveEncriptada = Seguridad.Encriptar(claveNueva);

                Datos.SetearConsulta("UPDATE Usuario SET Clave = @Clave WHERE IdUsuario = @IdUsuario");
                Datos.SetearParametros("@Clave", claveEncriptada);
                Datos.SetearParametros("@IdUsuario", idUsuario);

                Datos.EjecutarAccion();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al reiniciar la contraseña: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al reiniciar la contraseña: " + ex.Message);
            }
        }

        public void CambiarEstadoUsuario(int idUsuario, int activo)
        {
                AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearConsulta("UPDATE Usuario SET Estado = @Estado WHERE IdUsuario = @IdUsuario");
                    Datos.SetearParametros("@Estado", activo == 0 ? 1 : 0);
                Datos.SetearParametros("@IdUsuario", idUsuario);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar estado del usuario: " + ex.Message);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

    }

}
