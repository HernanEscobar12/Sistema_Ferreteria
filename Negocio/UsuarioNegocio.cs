using Dominio;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario usuario)
        {
			try
			{
				AccesoDatos Datos = new AccesoDatos();

				Datos.SetearConsulta("select IdUsuario ,NombreUsuario ,Clave from Usuario where NombreUsuario = @User and Clave =  @Pass");
				Datos.SetearParametros("@User" , usuario.User);
				Datos.SetearParametros("@Pass", usuario.Clave);
                Datos.EjecutarLectura();

				while (Datos.Lector.Read())
				{
					usuario.User =	Datos.Lector["NombreUsuario"].ToString().ToUpper();
                    usuario.Clave = Datos.Lector["Clave"].ToString().ToUpper();
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


    }
}
