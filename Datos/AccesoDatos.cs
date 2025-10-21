using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlCommand cmd;

        private SqlConnection conexion;

        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            cmd = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }

        public void SetearParametros(string Nombre, object Valor)
        {
            cmd.Parameters.AddWithValue(Nombre, Valor);
        }

        public void SetearProcedimiento(string Sp)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Sp;
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
                throw ex;
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

                throw ex;
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

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
                conexion?.Close();
            }
        }


    }
}
