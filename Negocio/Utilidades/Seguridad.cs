using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class Seguridad
    {
        public static string Encriptar(string texto)
        {
            SHA256 sHA256 = SHA256.Create();

            if(string.IsNullOrEmpty(texto))
                throw new ArgumentNullException(nameof(texto));

            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sHA256.ComputeHash(bytes);

            StringBuilder Sb = new StringBuilder();

            foreach (byte b in hash)
                Sb.Append(b.ToString("x2"));
            
            return Sb.ToString();

        }


    }
}
