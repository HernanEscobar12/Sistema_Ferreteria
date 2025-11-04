using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class MovimientoCaja
    {
        public int IdMovimiento { get; set; }
        public Caja Caja { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public char TipoMovimiento { get; set; } // 'I' = Ingreso, 'E' = Egreso
        public int? ReferenciaId { get; set; } // ID de compra o venta
        public int? UsuarioId { get; set; }
    }


}
