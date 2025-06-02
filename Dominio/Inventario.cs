using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Inventario
    {
        public int InventarioId { get; set; }   

        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public DateTime UltimaActualizacion { get; set; }
    }
}
