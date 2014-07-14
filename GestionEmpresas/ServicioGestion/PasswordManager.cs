using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ServicioGestion
{
    public static class PasswordManager
    {
        /// <summary>
        /// Devuelve el valor MD5 de una cadena de texto, normalmente una contraseña
        /// </summary>
        /// <param name="datos">La cadena de texto a cifrar</param>
        /// <returns>La cadena de texto cifrada</returns>
        public static string getMD5(string datos)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding enco = new ASCIIEncoding();
            byte[] cadena = null;
            StringBuilder sb = new StringBuilder();

            cadena = md5.ComputeHash(enco.GetBytes(datos));
            for (int i = 0; i < cadena.Length; i++)
            {
                sb.AppendFormat("{0:x2}", cadena[i]);
            }
            return sb.ToString();
        }
    }
}