using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WindowsFormsApp1
{
    class Rsa
    {
        public static (RSAParameters, RSAParameters) generate_RSA_key()
        {
            using (RSA rsa = RSA.Create())
            {
                RSAParameters public_key = rsa.ExportParameters(false);
                RSAParameters private_key = rsa.ExportParameters(true);

                return (public_key, private_key);
            }
        }

        public static byte[] encrypt_RSA(byte[] plaintext, RSAParameters public_key)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(public_key);
                byte[] ciphertext = rsa.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);
                return ciphertext;
            }
        }

        public static byte[] decrypt_RSA(byte[] ciphertext, RSAParameters private_key)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(private_key);
                byte[] plaintext = rsa.Decrypt(ciphertext, RSAEncryptionPadding.Pkcs1);
                return plaintext;
            }
        }
    }
}
