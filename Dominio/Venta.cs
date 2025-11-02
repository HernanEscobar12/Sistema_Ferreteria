using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        
        public Decimal Total {  get; set; }

        public List<DetalleVenta> Detalles { get; set; }

        public EstadoVenta EstadoVenta { get; set; }

    }
}