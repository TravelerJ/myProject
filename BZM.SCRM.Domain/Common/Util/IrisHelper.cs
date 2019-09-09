using BT.BPMLIVE.Common._IO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// iris
    /// </summary>
    public class IrisHelper
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptString">加密字符串</param>
        /// <param name="encryptKey">iris加密key</param>
        /// <returns></returns>
        public static string AESEncode(string encryptString, string encryptKey = "1lFejqVU0vKSWDPD")
        {
            if (string.IsNullOrEmpty(encryptString)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(encryptString);
            byte[] arr = Encoding.UTF8.GetBytes(encryptKey);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = arr, //Convert.FromBase64String(encryptKey),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///  AES解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <param name="key">iris解密key</param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key = "1lFejqVU0vKSWDPD")
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 获取header签名sign
        /// </summary>
        /// <param name="url">iris获取sign接口路径</param>
        /// <param name="log">获取签名时头部可以为空</param>
        /// <returns></returns>
        public static string GetSign(string url, Log log)
        {
            string result = PostToIris(url, "", "sys_sign:sign", log);
            if (!string.IsNullOrEmpty(result))
            {
                var obj = JObject.Parse(result);
                if (obj["code"] + "" == "success")
                {
                    string header = obj["obj"].ToString();
                    if (!string.IsNullOrEmpty(header))
                    {
                        log.Write("签名sign:" + header);
                        return "sys_sign:" + header;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// post请求iris接口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <param name="sign"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string PostToIris(string url, string postdata, string sign, Log log)
        {
            try
            {
                string responseContent;
                var memStream = new MemoryStream();
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                // 边界符  
                var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                // 边界符  
                var beginBoundary = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
                // 最后的结束符  
                var endBoundary = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
                // 设置属性  
                webRequest.Method = "POST";
                webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                webRequest.Headers.Add(sign);
                //var buffer = new byte[1024];

                // 写入字符串的Key  
                var stringKeyHeader = string.Format("\r\n--" + boundary +
                                       "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                       "\r\n\r\n{1}\r\n", "jsonStrParam", postdata);

                var data = Encoding.UTF8.GetBytes(stringKeyHeader);
                memStream.Write(data, 0, data.Length);

                // 写入最后的结束边界符  
                memStream.Write(endBoundary, 0, endBoundary.Length);

                webRequest.ContentLength = memStream.Length;

                var requestStream = webRequest.GetRequestStream();

                memStream.Position = 0;
                var tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();

                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();

                var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

                using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),Encoding.GetEncoding("utf-8")))
                {
                    responseContent = httpStreamReader.ReadToEnd();
                }

                httpWebResponse.Close();
                webRequest.Abort();

                return responseContent;
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    if (response == null)
                    {
                        return ex.ToString();
                    }
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        return text;
                    }
                }
            }
        }

        /// <summary>
        /// 请求iris接口
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <param name="signUrl">iris获取sign接口路径</param>
        /// <param name="jsonStr">请求数据</param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string RequestIrisApi(string url, string signUrl, string jsonStr, Log log)
        {
            string encrypData = AESEncode(jsonStr);
            string sign = GetSign(signUrl,log);
            string result = PostToIris(url, encrypData, sign, log);
            return result;
        }
    }
}
