using BZM.SCRM.Domain.Common.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BZM.SCRM.Domain.Common.Request
{
    /// <summary>
    /// http请求
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="url">请求地址</param>
        public static string Get(string url, Dictionary<string, string> header = null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";

            //头部参数
            if (header != null)
            {
                foreach (var item in header)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            return result;
        }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="requestData">请求参数</param>
        public static string Post(string url, string requestData, Dictionary<string, string> header = null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.Timeout = 10000;
            request.ContentType = "application/json;charset=UTF-8";

            //头部参数
            if (header != null)
            {
                foreach (var item in header)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            if (!string.IsNullOrEmpty(requestData))
            {
                byte[] bt = Encoding.UTF8.GetBytes(requestData);
                request.ContentLength = bt.Length;

                Stream writer = request.GetRequestStream();
                writer.Write(bt, 0, bt.Length);
                writer.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            return result;
        }

        /// <summary>
        /// 获取erp接口请求签名
        /// </summary>
        /// <param name="param"></param>
        /// <param name="orgNo"></param>
        /// <param name="prefAuthorization"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getSign(string param, string orgNo, string prefAuthorization = "BTBPM ")
        {
            //待拼接未处理的字符串
            string strConcat = "";
            //待生成的签名
            string strSign = "";

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            int Timestamp = (int)ts.TotalSeconds;

            //&*lapi-didi^%
            string AppSecret = "";
            string Authorization = "";
            string AppKey = "";
            var config = new WxHelper().GetBasConfig("", orgNo);
            AppKey = config.ERP_APP_KEY;
            AppSecret = config.ERP_APP_SECRET;
            Authorization = config.ERP_APP_ID;
            string SignMethod = "md5";

            #region 根据参数名称的ASCII码表的顺序排序。
            //Dictionary<string, string> headers = new Dictionary<string, string>();
            //headers.Add("Authorization", Authorization);
            //headers.Add("App-Key", AppKey);
            //headers.Add("Timestamp", Timestamp.ToString());
            //headers.Add("Sign-Method", SignMethod);
            //headers.Add("param", param);

            //var retHeaders = (from entry in headers
            //                  orderby entry.Key ascending
            //                  select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            SortedDictionary<string, string> retHeaders = new SortedDictionary<string, string>();
            retHeaders.Add("Authorization", Authorization);
            retHeaders.Add("App-Key", AppKey);
            retHeaders.Add("Timestamp", Timestamp.ToString());
            retHeaders.Add("Sign-Method", SignMethod);
            retHeaders.Add("param", param);
            #endregion

            #region 拼接的字符串
            //concat($AppSecret,"App-Key",$App-Key,"Authorization",$Authorization,"Sign-Method",$Sign-Method,"Timestamp",$ Timestamp,"param",$param,$AppSecret)
            foreach (KeyValuePair<string, string> k in retHeaders)
            {
                strConcat += k.Key + k.Value;
            }
            strConcat = AppSecret + strConcat + AppSecret;
            #endregion

            #region 将字符串用md5加密后，再生成大写的十六进制
            //解析AppKey
            //string strOri = BT.BPMLIVE.Common._Security.Encrypt.DecryptSES

            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(strConcat.ToString()));

            // 将MD5输出的二进制结果转换为大写的十六进制
            StringBuilder result = new StringBuilder();

            string _md5 = BitConverter.ToString(bytes).Replace("-", "");

            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X2");
                if (hex.Length == 1)
                {
                    result.Append("0");
                }
                result.Append(hex);
            }

            strSign = result.ToString();
            #endregion

            Dictionary<string, string> header = new Dictionary<string, string>();

            header.Add("Authorization", Authorization);
            header.Add("App-Key", AppKey);
            header.Add("Timestamp", Timestamp.ToString());
            header.Add("Sign-Method", SignMethod);
            header.Add("Sign", strSign);

            return header;
        }

        /// <summary>
        /// 请求erp接口
        /// </summary>
        /// <param name="jsonParam"></param>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="orgNo"></param>
        /// <returns></returns>
        public static string ErpRequestApi(string jsonParam, string method, string url, string orgNo)
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header = getSign(jsonParam, orgNo);

            var obj = new { jsonStr = jsonParam };
            url += method;
            string json = JsonConvert.SerializeObject(obj);

            return Post(url, json, header);
        }
    }
}
