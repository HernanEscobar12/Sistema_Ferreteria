using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EstadoVenta
    {
        public int IdEstadoVenta { get; set; }
        public string Descripcion {  get; set; }


        public override string ToString()
        {
            return Descripcion;
        }

    }
}
