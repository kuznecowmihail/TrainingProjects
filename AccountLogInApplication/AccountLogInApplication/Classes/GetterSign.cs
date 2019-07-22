using System;
using System.Security.Cryptography;
using System.Text;

namespace AccountLogInApplication
{
    public static class GetterSign
    {
        public static string GetSign(string s)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();

            byte[] hash = provider.ComputeHash(Encoding.Default.GetBytes(s + "bytepp"));

            return BitConverter.ToString(hash).ToLower().Replace("-", "");
        }
    }
}