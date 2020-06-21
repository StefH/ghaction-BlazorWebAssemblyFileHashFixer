using System;
using System.IO;

namespace BlazorWebAssemblyFileHashFixer
{
    public static class HashUtils
    {
        public static string CreateSHA256FromFile(string path)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            byte[] crypto = crypt.ComputeHash(File.ReadAllBytes(path));

            return Convert.ToBase64String(crypto);
        }
    }
}
