using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace IldarsWebApplication.Helper
{
    public static class SymmetricEncryptionUtility
    {

        public static string AlgorithmName { get; set; }

        public static bool ProtectKey { get; set; }

        public static void GenerateKey(string targetFile)
        {
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.GenerateKey();

            byte[] Key = Algorithm.Key;

            if (ProtectKey)
            {
                Key = ProtectedData.Protect(Key, null, DataProtectionScope.LocalMachine);
            }

            using (FileStream fs = new FileStream(targetFile, FileMode.Create))
            {
                fs.Write(Key, 0, Key.Length);
            }
        }

        public static void ReadKey(SymmetricAlgorithm algorithm, string keyFile)
        {
            byte[] Key;

            using (FileStream fs = new FileStream(keyFile, FileMode.Open))
            {
                Key = new byte[fs.Length];
                fs.Read(Key, 0, (int)fs.Length);
            }

            if (ProtectKey)
                algorithm.Key = ProtectedData.Unprotect(Key, null, DataProtectionScope.LocalMachine);
            else
                algorithm.Key = Key;
        }

        public static byte[] EncryptData(string data, string keyFile)
        {
            byte[] ClearData = Encoding.UTF8.GetBytes(data);

            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            ReadKey(Algorithm, keyFile);

            MemoryStream Target = new MemoryStream();

            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData, 0, ClearData.Length);
            cs.FlushFinalBlock();

            return Target.ToArray();

        }

        public static string DecryptData(byte[] data, string keyFile)
        {
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            ReadKey(Algorithm, keyFile);

            MemoryStream Target = new MemoryStream();

            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(data, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(),
                CryptoStreamMode.Write);
            cs.Write(data, ReadPos, data.Length - ReadPos);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(Target.ToArray());

        }
    }
}