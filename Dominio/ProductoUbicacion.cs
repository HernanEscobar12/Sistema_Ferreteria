using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoUbicacion
    {
        public int ProductoUbicacionId { get; set; }

        public Producto Producto { get; set; }

        public UbicacionSucursal  Ubicacion { get; set; }

        public int Cantidad { get; set; }

    }
}
