using Abp.Dependency;
using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Request;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// 微信helper
    /// </summary>
    public class WxHelper
    {
        private readonly IWctBasConfigRepository _wctBasConfigRepository;
        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;
        private readonly IWctPaMstrRepository _wctPaMstrRepository;
        private readonly IWctOpTokenRepository _wctOpTokenRepository;
        /// <summary>
        /// 配置管理器
        /// </summary>
        public IConfiguration _configuration { get; }
        public WxHelper() { }

        public WxHelper(IWctBasConfigRepository wctBasConfigRepository, 
            IMdmBuMstrRepository mdmBuMstrRepository, 
            IWctPaMstrRepository wctPaMstrRepository,
            IConfiguration configuration)
        {
            _wctBasConfigRepository = wctBasConfigRepository;
            _mdmBuMstrRepository = mdmBuMstrRepository;
            _wctPaMstrRepository = wctPaMstrRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns></returns>
        public string CreatePK(string prefix)
        {
            string PK = "";
            var NoSuffixLength = 8;
            Random rd = new Random();
            string num = rd.Next(8).ToString();
            string haveDate = "yyMMddHHmmss";
            PK = prefix + DateTime.Now.ToString(haveDate) + num.PadLeft(NoSuffixLength - num.Length, '0');

            return PK;
        }

        /// <summary>
        /// 获取基础配置信息
        /// </summary>
        /// <param name="bgNo"></param>
        /// <param name="orgNo"></param>
        /// <returns></returns>
        public WctBasConfig GetBasConfig(string bgNo, string orgNo = "")
        {
            if (!string.IsNullOrEmpty(orgNo) && string.IsNullOrEmpty(bgNo))
            {
                var buInfo =IocManager.Instance.IocContainer.Resolve<IMdmBuMstrRepository>().Get(orgNo);
                if (string.IsNullOrEmpty(buInfo.Id))
                {
                    return null;
                }
                bgNo = buInfo.BG_NO;
            }

            var basConfig = IocManager.Instance.IocContainer.Resolve<IWctBasConfigRepository>().GetAllList(m => m.BG_NO == bgNo);

            return basConfig?.Count > 0 ? basConfig[0] : null;
        }

        /// <summary>
        /// erp接口请求地址
        /// </summary>
        /// <param name="bgNo"></param>
        /// <param name="url"></param>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool GetErpApiUrl(string bgNo, ref string url, ref string msg, string type = "")
        {
            if (string.IsNullOrEmpty(bgNo))
            {
                msg = "机构编码不可为空";
                return false;
            }

            var config = GetBasConfig(bgNo);
            if (config == null)
            {
                msg = "请维护微信基础配置!";
                return false;
            }
            if (type == "old" || type == "")
            {
                if (string.IsNullOrEmpty(config.ERP_API_OURL))
                {
                    msg = "Erp接口路径为空,请先维护该配置";
                    return false;
                }
                url = config.ERP_API_OURL;
            }
            else if (type == "new")
            {
                if (string.IsNullOrEmpty(config.ERP_API_NURL))
                {
                    msg = "Erp备用接口路径为空,请先维护该配置";
                    return false;
                }
                url = config.ERP_API_NURL;
            }
            return true;
        }

        /// <summary>
        /// 获取开放平台token
        /// </summary>
        /// <returns></returns>
        public string GetOpenToken()
        {
            string access_token = "";
            var openInfo = _wctOpTokenRepository.GetAllList().FirstOrDefault();
            if (openInfo.COMPONENT_TOKEN_TIME!=null)
            {
                var time = (DateTime.Now - openInfo.COMPONENT_TOKEN_TIME).Value.TotalMinutes;
                if (time > 90)
                {
                    access_token = PostOpenToken(openInfo.COMPONENT_TICKET, openInfo.COMPONENT_APPID, openInfo.COMPONENT_APPSECRET);
                    openInfo.COMPONENT_ACCESS_TOKEN = access_token;
                    openInfo.COMPONENT_TOKEN_TIME = DateTime.Now;
                    _wctOpTokenRepository.Update(openInfo);
                }
                else
                {
                    access_token = openInfo.COMPONENT_ACCESS_TOKEN;
                }
            }
            return access_token;
        }

        /// <summary>
        /// 发起请求开放平台token
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public string PostOpenToken(string ticket, string appId, string appSecret)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("component_appid", appId);
            dic.Add("component_appsecret", appSecret);
            dic.Add("component_verify_ticket", ticket);
            string jsonStr = JsonConvert.SerializeObject(dic);
            string tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/component/api_component_token");
            var request = HttpRequest.Post(tokenUrl, jsonStr);
            var result = JsonConvert.DeserializeObject<TokenInfo>(request);
            return result.component_access_token;
        }

        /// <summary>
        /// 获取微信请求accesstoken
        /// </summary>
        /// <param name="paInfo">公众号信息</param>
        /// <param name="bgNo"></param>
        /// <returns></returns>
        public ReturnMsg GetAccessToken(WctPaMstr paInfo, string bgNo)
        {
            var rm = new ReturnMsg();
            var basConfig = GetBasConfig(bgNo);
            if (basConfig == null)
            {
                rm.IsSuccess = false;
                rm.msg = "请先维护微信基础信息配置";

                return rm;
            }

            //是否托管第三方
            if (basConfig.OPEN_IS_ENABLED == 1)
            {
                var token= GetOpenToken();
                if (string.IsNullOrEmpty(token))
                {
                    rm.IsSuccess = false;
                    rm.msg = "获取token失败";
                    return rm;
                }
                rm.IsSuccess = true;
                rm.result = token;

                return rm;
            }
            else
            {
                if (paInfo.PA_ACCESS_TOKEN_EXP_TIME != null)
                {
                    var expTime = (DateTime.Now - paInfo.PA_ACCESS_TOKEN_EXP_TIME).Value.TotalMinutes;
                    if (expTime <= 90)
                    {
                        rm.IsSuccess = true;
                        rm.result = paInfo.PA_ACCESS_TOKEN;
                        return rm;
                    }
                }

                string grant_type = "client_credential";
                string appid = paInfo.PA_APPID;
                string secret = paInfo.PA_APPSECRET;
                string tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", grant_type, appid, secret);
                var wc = new WebClient();
                var strReturn = wc.DownloadString(tokenUrl);
                var model = JsonConvert.DeserializeObject<AccessTokenInfo>(strReturn);
                if (string.IsNullOrEmpty(model.access_token))
                {
                    rm.IsSuccess = false;
                    rm.msg = "获取token失败";
                    return rm;
                }
                UpdateAccessToken(model.access_token, paInfo);
                rm.IsSuccess = true;
                rm.result = model.access_token;

                return rm;
            }
        }

        /// <summary>
        /// 更新token信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="paInfo"></param>
        public void UpdateAccessToken(string accessToken, WctPaMstr paInfo)
        {
            paInfo.PA_ACCESS_TOKEN = accessToken;
            paInfo.PA_ACCESS_TOKEN_EXP_TIME = DateTime.Now;
            paInfo.UPDATE_DATE = DateTime.Now;
            _wctPaMstrRepository.Update(paInfo);
            
        }

        /// <summary>
        /// 获取公众号信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="expression1"></param>
        /// <param name="bgNo"></param>
        /// <returns></returns>
        public WctPaMstr GetPaInfo(int type, Expression<Func<WctPaMstr,bool>> expression1,string bgNo="")
        {

            var paInfo = _wctPaMstrRepository.FirstOrDefault(expression1);
            if (paInfo == null&&!string.IsNullOrEmpty(bgNo))
            {
                paInfo = _wctPaMstrRepository.FirstOrDefault(c => c.PA_TYPE_ID == type && c.DEL_FLAG == 1 && c.BG_NO == bgNo);
            }           
            
            return paInfo;
        }

        /// <summary>
        /// 模版消息发送
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">微信openId</param>
        /// <param name="templateId">模版id</param>
        /// <param name="url">跳转路径</param>
        /// <param name="data">模版内容</param>
        /// <param name="data1">小程序相关</param>
        /// <returns></returns>
        public WxJsonResult SendTemplateMessage(string accessToken, string openId, string templateId, string url, object data,object data1)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("touser", openId);
            dic.Add("template_id", templateId);
            dic.Add("url", url);
            dic.Add("data", data);
            if (data1 != null)
            {
                dic.Add("miniprogram", data1);
            }
            var json = JsonConvert.SerializeObject(dic);
            var tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}",accessToken);
            var request = HttpRequest.Post(tokenUrl, json);
            var result = JsonConvert.DeserializeObject<WxJsonResult>(request);

            return result;
        }

        /// <summary>
        /// 获取openId
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="code"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public string GetOpenIdByAppId(string appId, string code, Log log, ref string bgNo)
        {
            var openId = "";
            var accessUrl = "";
            var paInfo =GetPaInfo(1, c => c.PA_APPID == appId && c.DEL_FLAG == 1);
            if (paInfo == null)
            {
                log.Write("未找到公众号信息," + appId + "");
                return openId;
            }
            bgNo = paInfo.BG_NO;
            var config =GetBasConfig(paInfo.BG_NO);
            if (config == null)
            {
                log.Write("请先维护微信基础配置");
                return openId;
            }
            if (config.OPEN_IS_ENABLED == 0)
            {
                accessUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appId="
           + appId + "&secret="
           + paInfo.PA_APPSECRET + "&code="
           + code + "&grant_type=authorization_code";
            }
            else
            {
                var componentAppId = _configuration["AppSettings:ComponentWeixinAppID"];
                var comToken = _wctOpTokenRepository.FirstOrDefault(c => c.DEL_FLAG == 1);
                accessUrl = string.Format(
                "https://api.weixin.qq.com/sns/oauth2/component/access_token?appid={0}&code={1}&grant_type={2}&component_appid={3}&component_access_token={4}",
                appId, code, "authorization_code", componentAppId, comToken.COMPONENT_ACCESS_TOKEN);
            }

            string accessRet = GetUrl(accessUrl);
            log.Write("accessUrl:" + accessUrl + ";accessRet:" + accessRet);
            Dictionary<string, object> dicRet = new Dictionary<string, object>();
            try
            {
                dicRet = JsonConvert.DeserializeObject<Dictionary<string, object>>(accessRet);
                object value;
                if (dicRet.TryGetValue("openid", out value))
                {
                    openId = value.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write("Exception:" + ex.Message);
            }

            return openId;
        }

        /// <summary>
        /// 获取openId
        /// </summary>
        /// <param name="orgNo"></param>
        /// <param name="code"></param>
        /// <param name="log"></param>
        /// <param name="bgNo"></param>
        /// <returns></returns>
        public string GetOpenIdByOrgNo(string orgNo, string code, Log log, ref string bgNo)
        {
            var openId = "";
            var accessUrl = "";
            var paInfo =GetPaInfo(1, c => c.PA_ID_NO == orgNo && c.DEL_FLAG == 1);
            if (paInfo == null)
            {
                log.Write("未找到公众号信息," + orgNo + "");
                return openId;
            }
            bgNo = paInfo.BG_NO;
            var config =GetBasConfig(paInfo.BG_NO);
            if (config == null)
            {
                log.Write("请先维护微信基础配置");
                return openId;
            }
            if (config.OPEN_IS_ENABLED == 0)
            {
                accessUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appId="
           + paInfo.PA_APPID + "&secret="
           + paInfo.PA_APPSECRET + "&code="
           + code + "&grant_type=authorization_code";
            }
            else
            {
                var componentAppId = _configuration["AppSettings:ComponentWeixinAppID"];
                var comToken = _wctOpTokenRepository.FirstOrDefault(c => c.DEL_FLAG == 1);
                accessUrl = string.Format(
                "https://api.weixin.qq.com/sns/oauth2/component/access_token?appid={0}&code={1}&grant_type={2}&component_appid={3}&component_access_token={4}",
                paInfo.PA_APPID, code, "authorization_code", componentAppId, comToken.COMPONENT_ACCESS_TOKEN);
            }

            string accessRet = GetUrl(accessUrl);
            log.Write("accessUrl:" + accessUrl + ";accessRet:" + accessRet);
            Dictionary<string, object> dicRet = new Dictionary<string, object>();
            try
            {
                dicRet = JsonConvert.DeserializeObject<Dictionary<string, object>>(accessRet);
                object value;
                if (dicRet.TryGetValue("openid", out value))
                {
                    openId = value.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write("Exception:" + ex.Message);
            }

            return openId;
        }


        /// <summary>
        /// 获取微信url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetUrl(string url)
        {
            string responseString = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();
                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
            return responseString;
        }


    }
}
