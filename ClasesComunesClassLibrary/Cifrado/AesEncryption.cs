using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.Cifrado
{
    public static class AesEncryption
    {



        private static bool ValidateKey(string value)
        {


            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (value.Length != 32)
            {
                return false;
            }

            return true;

        }



        private static bool ValidateInitialVector(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (value.Length != 16)
            {
                return false;
            }

            return true;
        }




        public static string Encrypt(string plainText, string Key, string InitialVector)
        {

            if (!ValidateKey(Key))
            {
                throw new ArgumentException("La llave debe contener 32 caracteres"); 
            }

            if (!ValidateInitialVector(InitialVector))
            {
                throw new ArgumentException("El vector inicial debe contener 16 caracteres");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(InitialVector);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string Key, string InitialVector)
        {
            if (!ValidateKey(Key))
            {
                throw new ArgumentException("La llave debe contener 32 caracteres");
            }

            if (!ValidateInitialVector(InitialVector))
            {
                throw new ArgumentException("El vector inicial debe contener 16 caracteres");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(InitialVector);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipherText);
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.FlushFinalBlock();

                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
    }
}
