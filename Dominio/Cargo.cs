using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cargo
    {
        public int IdCargo { get; set; }

        public string Descripcion { get; set; }


        public override string ToString()
        {
            return Descripcion;
        }
    }
}
