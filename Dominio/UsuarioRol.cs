using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioRol
    {
        public int IdUsuario {  get; set; }

        public override string ToString()
        {
            return IdUsuario.ToString();
        }
    }
}
