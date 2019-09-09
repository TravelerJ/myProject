using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using Newtonsoft.Json;
using SCRM.Domain.System.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// odm车型数据请求类
    /// </summary>
    public class OdmCarRequest
    {
        /// <summary>
        /// 车型等级
        /// </summary>
        public int CLASS_LEVEL { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        public int CLASS_STATUS { get; set; }

        /// <summary>
        /// 上级ids
        /// </summary>
        public List<string> parentids { get; set; }

        /// <summary>
        /// 主键ids
        /// </summary>
        public List<string> CarIds { get; set; }


        /// <summary>
        /// 获取ODM请求的token
        /// </summary>
        public static string GetToken(WctBasConfig basConfig, ref string msg, string method = "v1.0/Token")
        {

            if (basConfig.BZT_TOKEN_TIME != null)
            {
                var expTime = (DateTime.Now - basConfig.BZT_TOKEN_TIME).Value.TotalHours;
                if (expTime > 12 || string.IsNullOrEmpty(basConfig.BZT_TOKEN))
                {
                    var token = PostBztToken(basConfig, method, ref msg);
                    return token;
                }
                return basConfig.BZT_TOKEN;
            }
            else
            {
                var token = PostBztToken(basConfig, method, ref msg);
                return token;
            }
        }

        /// <summary>
        /// 请求token接口
        /// </summary>
        /// <param name="basConfig"></param>
        /// <param name="method"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string PostBztToken(WctBasConfig basConfig, string method, ref string msg)
        {
            string url = basConfig.IBZT_URL + method;
            //请求参数
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", basConfig.TOKEN_USR_NAME);
            dic.Add("password", basConfig.TOKEN_USR_PWD);
            dic.Add("grant_type", basConfig.GRANT_TYPE);
            dic.Add("client_id", basConfig.CLIENT_ID);
            dic.Add("client_secret", basConfig.CLIENT_SECRET);

            string param = JsonConvert.SerializeObject(dic);
            string result = HttpRequest.Post(url, param, null);

            var jobj = Newtonsoft.Json.Linq.JObject.Parse(result);
            var token = jobj["Data"]["access_token"].ToString();
            var type = jobj["Data"]["token_type"].ToString();

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(type))
            {
                basConfig.BZT_TOKEN_TIME = DateTime.Now;
                basConfig.BZT_TOKEN = type + " " + token;
                //new WCT_BAS_CONFIGBLL().UpdateWCT_BAS_CONFIG(basConfig);
                return type + " " + token;
            }
            else
            {
                msg = jobj["Message"] + "";
            }

            return "";
        }

        /// <summary>
        /// 获取ODM车辆信息
        /// </summary>
        /// <param name="level">车等级</param>
        /// <param name="parentids">父级id</param>
        /// <returns></returns>
        public List<CarInfoModel> GetODMCarInfo(WctBasConfig basConfig, int level, string parentids, ref string msg, string ids = "", string method = "v1.0/CarType/GetCarClassList")
        {
            //List<CarInfoModel> list = new List<CarInfoModel>();

            string token = GetToken(basConfig, ref msg);
            if (!string.IsNullOrEmpty(token))
            {
                string url = basConfig.IBZT_URL + method;

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("CLASS_LEVEL", level);
                dic.Add("CLASS_STATUS", 1);

                if (!string.IsNullOrEmpty(parentids))
                {
                    List<string> list = parentids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    dic.Add("parentids", list);
                }

                if (!string.IsNullOrEmpty(ids))
                {
                    List<string> list = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    dic.Add("CarIds", list);
                }

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", token);

                string result = HttpRequest.Post(url, JsonConvert.SerializeObject(dic), header);
                var data = Newtonsoft.Json.Linq.JObject.Parse(result)["Data"] + "";

                if (!string.IsNullOrEmpty(data))
                {
                    List<CarInfoModel> carlist = JsonConvert.DeserializeObject<List<CarInfoModel>>(data);
                    return carlist;
                }
                else
                {
                    msg = Newtonsoft.Json.Linq.JObject.Parse(result)["Message"] + "";
                }
            }
            return null;
        }


        /// <summary>
        /// 二手车库存信息
        /// </summary>
        /// <param name="basConfig"></param>
        /// <param name="msg"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public List<UseCarStockModel> GetUseCarStockInfo(WctBasConfig basConfig, string buNo, ref string msg, string method = "v1.0/InvStockMstr/GetUseCarListByPage")
        {
            List<UseCarStockModel> list = new List<UseCarStockModel>();

            string token = GetToken(basConfig, ref msg);
            if (!string.IsNullOrEmpty(token))
            {
                string url = basConfig.IBZT_URL + method + "?STOCK_STATUS=在库&GOODS_TYPE=4&BuSource=SCRM&BU_NO=" + buNo + "";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Authorization", token);
                string result = HttpRequest.Get(url, dic);
                var data = Newtonsoft.Json.Linq.JObject.Parse(result)["Data"]["Result"] + "";

                if (!string.IsNullOrEmpty(data) && data != "[]")
                {
                    list = JsonConvert.DeserializeObject<List<UseCarStockModel>>(data);
                    foreach (var item in list)
                    {
                        item.CarDisplay = item.GOODS_CLASS1_NAME + " " + item.GOODS_CLASS2_NAME + " " + item.GOODS_CLASS3_NAME + " " + item.GOODS_NAME + " " + item.VIN;
                    }
                }
                else
                {
                    msg = Newtonsoft.Json.Linq.JObject.Parse(result)["Message"] + "";
                }
            }

            return list;
        }
    }
}
