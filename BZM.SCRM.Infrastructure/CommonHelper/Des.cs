using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BZM.SCRM.Infrastructure.CommonHelper
{    /// <summary>
     /// DES加解密
     /// </summary>
    public class Des
    {
        private const string DesKey = "SCRMKEYS";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static async Task<string> Encrypt(string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;
            var d = new DESCryptoServiceProvider
            {
                IV = Encoding.UTF8.GetBytes(DesKey),
                Key = Encoding.UTF8.GetBytes(DesKey)
            };
            var ct = d.CreateEncryptor(d.Key, d.IV);
            var temp = Encoding.UTF8.GetBytes(val);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            await cs.WriteAsync(temp, 0, temp.Length);
            await cs.FlushAsync();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static async Task<string> Decrypt(string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;
            var d = new DESCryptoServiceProvider
            {
                IV = Encoding.UTF8.GetBytes(DesKey),
                Key = Encoding.UTF8.GetBytes(DesKey)
            };
            var ct = d.CreateDecryptor(d.Key, d.IV);
            val = WebUtility.UrlDecode(val);
            var temp = Convert.FromBase64String(val);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            await cs.WriteAsync(temp, 0, temp.Length);
            await cs.FlushAsync();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
