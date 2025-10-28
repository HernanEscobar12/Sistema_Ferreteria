using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class Validaciones
    {
        public static string FormatearCuil(string cuil)
        {
            if (string.IsNullOrEmpty(cuil))
                return null;

            // Eliminamos todo lo que no sea número
            cuil = new string(cuil.Where(char.IsDigit).ToArray());

            if (cuil.Length != 11)
                throw new Exception("El cuil debe tener 11 digitos");

            // Retornamos en formato XX-XXXXXXXX-X
            return $"{cuil.Substring(0, 2)}{cuil.Substring(2, 8)}{cuil.Substring(10, 1)}";
        }

        public static bool EsSoloNumerico(string texto)
        {
            return texto.All(char.IsDigit);
        }



    }
}
