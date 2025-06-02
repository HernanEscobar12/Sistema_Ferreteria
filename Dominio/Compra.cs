using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Proveedor Proveedor { get; set; }

        public DateTime FechaCompra { get; set; }

        public Decimal Total { get; set; }

        public List<DetalleCompra> Detalles { get; set; }
        public int Estado { get; set; }


    }
}
