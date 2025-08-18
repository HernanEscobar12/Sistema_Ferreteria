namespace Dominio
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}