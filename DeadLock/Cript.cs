using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DeadLock
{
    static class Cript
    {

        public static string HashSHA512(this string toEncrypt)
        {
            byte[] toEncryptBytes = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] encryptedBytes;

            using (SHA512 shaManaged = new SHA512Managed())
                encryptedBytes = shaManaged.ComputeHash(toEncryptBytes);

            return Convert.ToBase64String(encryptedBytes);
        }
    }

}
