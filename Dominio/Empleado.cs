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
        public Direccion Direccion { get; set; }

        public Localidad Localidad { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public Sucursal Sucursal { get; set; }

        public DateTime FechaAlta { get; set; }

        public int Estado { get; set; } 
    }
}
