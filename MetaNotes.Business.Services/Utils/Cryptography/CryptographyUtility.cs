using System;
using System.Security.Cryptography;
using System.Text;

namespace MetaNotes.Business.Services
{
    public class CryptographyUtility : ICryptographyUtility
    {
        public string GetHash(string originalString)
        {
            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.UTF8.GetBytes(originalString);
            var encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", String.Empty);
        }
    }
}
