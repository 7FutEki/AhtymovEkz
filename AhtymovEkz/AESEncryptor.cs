using AhtymovEkz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AhtymovEkz
{
    public class AESEncryptor : IEncryptor
    {
        private readonly byte[] _salt = Encoding.UTF8.GetBytes("KekLolCheburek");
        public string Encrypt(string value)
        {
            using (var aes = Aes.Create())
            {
                (var key, var iv) = GenerateKeyFromSalt(32, 16);
                aes.Key = key;
                aes.IV = iv;

                using(var memoryStream = new MemoryStream())
                using(var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryptoStream))
                    {
                        sw.Write(value);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }    
        }

        private (byte[] key, byte[] iv) GenerateKeyFromSalt(int keySize, int ivSize)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(_salt, _salt, 1000))
            {
                byte[] key = pbkdf2.GetBytes(keySize);
                byte[] iv = pbkdf2.GetBytes(ivSize); 

                return (key, iv);
            }
        }
    }
}
