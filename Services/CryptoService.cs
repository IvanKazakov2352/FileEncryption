using System.Security.Cryptography;
using FileEncryption.Models;

#pragma warning disable SYSLIB0023

namespace FileEncryption.Services
{
    public class CryptoService : ICryptoService
    {
        public byte[] GenerateRandomBytes(int length)
        {
            byte[] bytes = new byte[length];
            using RNGCryptoServiceProvider rng = new();
            rng.GetBytes(bytes);
            return bytes;
        }

        public byte[] EncryptData(byte[] data, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            using MemoryStream ms = new();
            using CryptoStream cryptoStream = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();
            return ms.ToArray();
        }

        public byte[] DecryptData(byte[] data, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream msDecrypt = new(data);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using MemoryStream ms = new();
            csDecrypt.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
