

using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Application.Common.Contracts;
using BZM.SCRM.Domain.Common.Util;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Qiniu.IO.Model;
using Qiniu.Util;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BZM.SCRM.Application.Common.Impl
{
    /// <summary>
    /// 公共服务
    /// </summary>
    public class CommonService : SCRMAppServiceBase, ICommonService
    {
        /// <summary>
        /// 配置管理器
        /// </summary>
        public IConfiguration _configuration { get; }
        /// <summary>
        /// 开放平台token仓储
        /// </summary>
        private readonly IWctOpTokenRepository _wctOpTokenRepository;
        /// <summary>
        /// 微信helper
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CommonService(IConfiguration configuration,
            WxHelper wxHelper,
            IWctOpTokenRepository wctOpTokenRepository)
        {
            _configuration = configuration;
            _wxHelper = wxHelper;
            _wctOpTokenRepository = wctOpTokenRepository;
        }
        /// <summary>
        /// 获取七牛token
        /// </summary>
        /// <returns></returns>
        public string GetQiNiuToken()
        {
            var accessKey = _configuration["QiNiu:accessKey"];
            var secretKey = _configuration["QiNiu:secretKey"];
            var bucket = _configuration["QiNiu:bucket"];
            Mac mac = new Mac(accessKey, secretKey);

            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = bucket;
            putPolicy.SetExpires(43200);

            string jsonStr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jsonStr);

            return token;
        }

        /// <summary>
        /// 获取微信跳转链接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="appId"></param>
        /// <param name="code"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public string GetWeChatUrl(string url,string appId, string code,Log log)
        {
            string openId = "";
            string secret = "";
            string accessUrl = "";
            #region 获取openId
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_APPID == appId && c.DEL_FLAG == 1);
            if (paInfo == null)
            {
                log.Write("未找到公众号信息," + appId + "");
                return url;
            }
            var config = _wxHelper.GetBasConfig(paInfo.BG_NO);
            if (config == null)
            {
                log.Write("请先维护微信基础配置");
                return openId;
            }
            if (config.OPEN_IS_ENABLED == 0)
            {
                secret = paInfo.PA_APPSECRET;
                accessUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appId="
           + appId + "&secret="
           + secret + "&code="
           + code + "&grant_type=authorization_code";
            }
            else
            {
                var componentAppId= _configuration["AppSettings:ComponentWeixinAppID"];
                var comToken = _wctOpTokenRepository.FirstOrDefault(c => c.DEL_FLAG == 1);
                accessUrl = string.Format(
                "https://api.weixin.qq.com/sns/oauth2/component/access_token?appid={0}&code={1}&grant_type={2}&component_appid={3}&component_access_token={4}",
                appId, code, "authorization_code", componentAppId, comToken.COMPONENT_ACCESS_TOKEN);
            }

            string accessRet =_wxHelper.GetUrl(accessUrl);
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

                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                int TimestampNow = (int)ts.TotalSeconds;
                url += "appId=" + appId + "&unitId=" + paInfo.PA_ID_NO + "&bgNo=" + paInfo.BG_NO + "" + "&openId=" + openId + "&vs=" + TimestampNow + "";
            }
            catch (Exception ex)
            {
                log.Write("Exception:" + ex.Message);
            }
            #endregion
            return url;
        }

       

    }
}
