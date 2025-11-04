using System.Security.Cryptography;

namespace Dominio
{
    public class Producto
    {
        public int ProductoId { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string UrlImagen { get; set; }

        public Categoria Categoria { get; set; }

        public bool Estado { get; set; }
        public int StockMinimo { get ; set; }
        public int StockActual { get ; set; }
        public string EstadoStock { get ; set; }
        public decimal PrecioCosto { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}