using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace oldSolutions
{
    public class Core
    {
        /// <summary>
        /// Expresiones regulares
        /// </summary>
        public string expresionRegularTelefono = @"^[+-]?\d+(\.\d+)?$";
        public string expresionRegularNombre = @"^[a-zA-Z]+$";
        public string expresionRegularDNI = @"^(([A - Z]\d{8})|\d{8}|(\d{8}[A-Z])|([A - Z]\d{8}[A-Z]))$";
        public string expresionRegularNumero = " @^[0-9]+$)";


        public string logoEmpresa = "https://i.imgur.com/eJtSNae.png";

        public string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }//Fin de hash
    }
}
