namespace Dominio
{
    public class Localidad
    {
        public int LocalidadId { get; set; }

        public Provincia Provincia { get; set; }

        public string Nombre { get; set; }
    }
}