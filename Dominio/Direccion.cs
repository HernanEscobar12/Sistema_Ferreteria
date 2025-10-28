namespace Dominio
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }

        public Localidad Localidad { get; set; }

        public override string ToString()
        {
            return Calle + Numero;
        }
    }
  
}