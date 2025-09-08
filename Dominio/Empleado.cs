using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Cuit { get; set; }

        public string Calle { get; set; }
        public string Numero { get; set; }

        public Usuario Usuario { get; set; }

        public Localidad Localidad { get; set; }

        public Cargo Cargo { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public Sucursal Sucursal { get; set; }

        public DateTime FechaAlta { get; set; }

        public bool Estado { get; set; }
    }
}
