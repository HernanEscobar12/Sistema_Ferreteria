using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pago
    {
        public int PagoId { get; set; } 

        public Pedido Pedido { get; set; }

        public TipoPago TipoPago { get; set; }

        public DateTime Fecha_Pago { get; set; }
        public decimal Monto { get; set; }
    }
}
