namespace Dominio
{
    public class Sucursal
    {
        public int SucursalId { get; set; }

        public string Nombre { get; set; }

        public Direccion Direccion { get ; set; }   

        public string Telefono { get; set; }

        public Localidad Localidad { get; set; }

        public int Estado { get; set; }


        public override string ToString()
        {
            return Nombre;
        }

    }
}