using System;

namespace Dominio
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public int Estado { get; set; }
        
    }
}