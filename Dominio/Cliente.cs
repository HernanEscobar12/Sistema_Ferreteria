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
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Dni { get; set; }

        public string Cuit  { get; set; }

        public string Calle { get; set; }

        public string Numero { get; set; }
        
        public Localidad Localidad { get; set; }

        public Provincia Provincia { get; set; }

        public bool Estado { get; set; }
    }
}
