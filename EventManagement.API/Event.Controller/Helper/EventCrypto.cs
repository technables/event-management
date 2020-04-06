﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Event.Controller.Helper
{
    public class EventCrypto
    {
        private const string initVector = "xOuMeiRPe9ZCwPqv";
        private const string EncryptionKey = "YTd_jU9y4";
        private const int keysize = 256;

        #region "Encrypt"

        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string EncryptRandom()
        {
            return Encrypt(System.DateTime.Now.ToString("yyyyMMddHHmmss").ToString(), "");
        }
        public static string Encrypt(string Text, string Key)
        {
            try
            {
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
                PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] Encrypted = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                return Convert.ToBase64String(Encrypted);
            }
            catch (Exception)
            {

                return "Something went wrong";
            }

        }
        public static string OneWayEncryter(string textToBeEncrypted)
        {
            if (!String.IsNullOrEmpty(textToBeEncrypted))
            {
                MD5 md5 = MD5.Create();
                byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(textToBeEncrypted);
                byte[] hash = md5.ComputeHash(bytes);

                StringBuilder sbPassword = new StringBuilder();
                for (int b = 0; b < hash.Length; b++)
                {
                    sbPassword.Append(hash[b].ToString("X2"));
                }

                return sbPassword.ToString();
            }
            else
            {
                return string.Empty;

            }
        }

        public static string EncryptAPIPassword(string password, string key)
        {
            return EncryptRandom() + Encrypt(password, key);
        }

        #endregion


        #region "Decrypt"
        public static string Decrypt(string cipherText)
        {
            try
            {
                cipherText = cipherText.Replace(" ", "+");
                int mod4 = cipherText.Length % 4;
                if (mod4 > 0)
                {
                    cipherText += new string('=', 4 - mod4);
                }
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch
            {
                return String.Empty;
            }


        }

        public static string Decrypt(string EncryptedText, string Key)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] DeEncryptedText = Convert.FromBase64String(EncryptedText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(DeEncryptedText);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[DeEncryptedText.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception ex)
            {
                return "Something went wrong with encrypted string";
            }

        }

        public static string DecryptAPIPassword(string password, string key)
        {
            string encryptedPassword = password.Remove(0, 24);
            return Decrypt(password, key);
        }

        #endregion
    }
}
