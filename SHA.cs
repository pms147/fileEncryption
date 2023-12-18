using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WindowsFormsApp1
{
    class SHA
    {
        public static byte[] SHA_1(byte[] plaintext)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] digest = sha1.ComputeHash(plaintext);
                return digest;
            }
        }

        public static byte[] SHA_256(byte[] plaintext)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] digest = sha256.ComputeHash(plaintext);
                return digest;
            }
        }
    }
}
