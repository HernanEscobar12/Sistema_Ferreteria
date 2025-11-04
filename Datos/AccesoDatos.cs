using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlCommand cmd;
        private SqlConnection conexion;
        private SqlDataReader lector;
        private SqlTransaction transaccion;

        public SqlDataReader Lector => lector;
        public SqlTransaction Transaccion => transaccion;

        public AccesoDatos()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            cmd = new SqlCommand();
        }

        // =========================================================
        // 🔹 CONFIGURACIÓN DE COMANDOS
        // =========================================================
        public void SetearConsulta(string consulta)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
        }

        public void SetearProcedimiento(string sp)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
        }

        public void SetearParametros(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public void SetearParametroSalida(string nombre, SqlDbType tipo, int tamaño)
        {
            SqlParameter parametroSalida = new SqlParameter(nombre, tipo, tamaño);
            parametroSalida.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parametroSalida);
        }

        public object ObtenerParametroSalida(string nombre)
        {
            return cmd.Parameters[nombre].Value;
        }

        public void LimpiarParametros()
        {
            cmd.Parameters.Clear();
        }

        // =========================================================
        // 🔹 EJECUCIONES SIN TRANSACCIÓN
        // =========================================================
        public object EjecutarEscalar()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar escalar: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EjecutarLectura()
        {
            try
            {
                cmd.Connection = conexion;
                conexion.Open();
                lector = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar lectura: " + ex.Message);
            }
        }

        public void EjecutarAccion()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar acción: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        // =========================================================
        // 🔹 BLOQUE DE TRANSACCIONES
        // =========================================================
        public void IniciarTransaccion()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            transaccion = conexion.BeginTransaction();
            cmd.Connection = conexion;      // ✅ conexión asignada
            cmd.Transaction = transaccion;  // ✅ transacción activa
        }

        public void ConfirmarTransaccion()
        {
            transaccion?.Commit();
            conexion.Close();
        }

        public void RevertirTransaccion()
        {
            transaccion?.Rollback();
            conexion.Close();
        }

        public void EjecutarAccionTransaccion()
        {
            try
            {
                cmd.Connection = conexion;      // ✅ conexión asegurada
                cmd.Transaction = transaccion;  // ✅ transacción asegurada
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar acción con transacción: " + ex.Message);
            }
            finally
            {
                LimpiarParametros();
            }
        }

        public object EjecutarEscalarTransaccion()
        {
            try
            {
                cmd.Connection = conexion;      // ✅ conexión asegurada
                cmd.Transaction = transaccion;  // ✅ transacción asegurada
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar escalar con transacción: " + ex.Message);
            }
            finally
            {
                LimpiarParametros();
            }
        }

        // ✅ NUEVO MÉTODO agregado para CajaNegocio
        public SqlDataReader EjecutarLecturaTransaccion()
        {
            try
            {
                cmd.Connection = conexion;      // ✅ usar conexión activa
                cmd.Transaction = transaccion;  // ✅ usar transacción activa
                lector = cmd.ExecuteReader();
                return lector;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar lectura con transacción: " + ex.Message);
            }
            finally
            {
                LimpiarParametros();
            }
        }

        // =========================================================
        // 🔹 UTILIDADES
        // =========================================================
        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion?.Close();
        }
    }
}
