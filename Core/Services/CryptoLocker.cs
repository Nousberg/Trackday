using System;
using System.Security.Cryptography;
using System.Text;

namespace Assets.Scripts.Core.Services
{
    public static class CryptoLocker
    {
        public static string Encrypt(string data, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] input = Encoding.UTF8.GetBytes(data);
                byte[] encrypted = encryptor.TransformFinalBlock(input, 0, input.Length);
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string encryptedData, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
                byte[] decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}