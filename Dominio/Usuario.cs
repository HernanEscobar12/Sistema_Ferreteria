using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string User { get; set; }

        public string Clave { get; set; }

        public Cargo Cargo { get; set; }

        public int Estado { get; set; }
    }
}
