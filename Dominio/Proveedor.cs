namespace Dominio
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }

        public string RazonSocial { get; set; }

        public string Cuit { get; set; }

        public Direccion Direccion { get; set; }    

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int Estado { get; set; }
    }
}