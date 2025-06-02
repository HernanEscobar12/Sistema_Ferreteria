using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        public string Cuit  { get; set; }

        public Direccion Direccion { get; set; }
        
        public Localidad Localidad { get; set; }

        public int Estado { get; set; }



    }
}
