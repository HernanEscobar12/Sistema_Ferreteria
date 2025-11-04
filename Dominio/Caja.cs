using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Caja
    {
        public int IdCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public decimal SaldoInicial { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal? SaldoFinal { get; set; }
        public char Estado { get; set; } // 'A' = Abierta, 'C' = Cerrada

        // Referencias a objetos, no a IDs
        public Usuario UsuarioApertura { get; set; }
        public Usuario UsuarioCierre { get; set; }

        // Relación
        public List<MovimientoCaja> Movimientos { get; set; }

        public Caja()
        {
            Movimientos = new List<MovimientoCaja>();
        }
    }
}
