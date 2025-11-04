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

        public string Ubicacion { get; set; }  // 🔹 NUEVO
        public Sucursal Sucursal { get; set; }

        public bool EsCritico => StockActual <= StockMinimo;

        // 👇 Esta propiedad te deja mostrar el nombre del producto directo
        //public string NombreProducto => Producto?.Nombre ?? "(Sin nombre)";
        public DateTime UltimaActualizacion { get; set; }
    }
}
