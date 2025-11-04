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
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string Ubicacion { get; set; }
        public Sucursal Sucursal { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        // 🔹 Propiedad calculada: no se asigna manualmente
        public bool EsCritico { get; set; }

    }
}
