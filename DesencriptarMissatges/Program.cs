using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DesencriptarMissatges
{

    class Program
    {
        static void Main()
        {
            // Clave y vector de inicialización (IV)
            string clave = "12345678901234567890123456789012";
            string iv = "1234567890123456";

            // Texto cifrado
            string textoCifrado = "GnuZNjGyiyT9piquG/BlXEdtO2OyKy/cR/8fA7j2bIw=";

            // Desencriptar
            string mensajeOriginal = DesencriptarAES(textoCifrado, clave, iv);

            // Mostrar resultado
            Console.WriteLine("Mensaje Original: " + mensajeOriginal);
            Console.ReadLine();
        }

        static string DesencriptarAES(string textoCifrado, string clave, string iv)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                // Crea un descifrador que usa el modo CBC
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Descifrar el texto
                byte[] textoCifradoBytes = Convert.FromBase64String(textoCifrado);
                byte[] mensajeDesencriptadoBytes = decryptor.TransformFinalBlock(textoCifradoBytes, 0, textoCifradoBytes.Length);

                // Convertir a cadena
                string mensajeDesencriptado = Encoding.UTF8.GetString(mensajeDesencriptadoBytes);

                return mensajeDesencriptado;
            }
        }
    }
}
