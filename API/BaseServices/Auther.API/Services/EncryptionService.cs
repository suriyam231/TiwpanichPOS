using Auther.API.DTOs;
using Auther.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace Auther.API.Services
{
    public class EncryptionService : IEncryptionService
    {
        public EncryptionDTO StandardMD5Encryption(string PlainText)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    EncryptionDTO result = new EncryptionDTO();
                    result.Key = MD5Property.StandardMD5Key;
                    result.PlainText = PlainText;

                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(result.Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(result.PlainText);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        result.CipherText = Convert.ToBase64String(bytes, 0, bytes.Length);
                        return result;
                    }
                }
            }
        }

        public EncryptionDTO StandardMD5Decryption(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    EncryptionDTO result = new EncryptionDTO();
                    result.Key = MD5Property.StandardMD5Key;
                    result.CipherText = cipher;

                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(result.Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(result.CipherText);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        result.PlainText = UTF8Encoding.UTF8.GetString(bytes);
                        return result;
                    }
                }
            }
        }


        public string GeneratePasswordSalt()
        {
            Random random = new Random();
            int leng = 15;
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+=-]}[{/?'.><,";
            StringBuilder result = new StringBuilder(leng);
            for (int i = 0; i < leng; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            //string path = Path.GetRandomFileName();
            //path = path.Replace(".", "");
            //string randomNumber = new Random().Next(0, 10000000).ToString(MD5Property.StringMD5);
            //string randomPasswordsalt = path + randomNumber; 
            return result.ToString();
        }

        public string HashToMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                string tmp = data[i].ToString("x2");
                sBuilder.Append(tmp);
            }

            return sBuilder.ToString();
        }
    }
}
