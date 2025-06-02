namespace Dominio
{
    public class UbicacionSucursal
    {
        public int UbicacionSucursalId { get; set; }

        public Sucursal Sucursal { get; set; }

        public string Zona { get; set; }

        public string Estanteria { get; set; }

        public string Nivel { get; set; }
    }
}