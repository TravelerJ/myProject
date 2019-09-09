using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Application.Common.Contracts;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BZM.SCRM.Api.Controllers.Common
{
    /// <summary>
    /// 微信授权
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class WeChatAuthController : SCRMControllerBase
    {
        /// <summary>
        /// 微信helper
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 公共服务
        /// </summary>
        private readonly ICommonService _commonService;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="wxHelper"></param>
        /// <param name="commonService"></param>
        public WeChatAuthController(WxHelper wxHelper,
            ICommonService commonService)
        {
            _wxHelper = wxHelper;
            _commonService = commonService;
        }
        /// <summary>
        /// 统一网页授权
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("WeChatAuth/WxAuthorization"), MapToApiVersion("1.0")]
        public ActionResult WxAuthorization(WxAuthorization authorization)
        {
            Log log = new Log("WxAuthorization");
            List<string> codeList = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(authorization.code))
                {
                    #region 获取跳转地址转译集合，合成授权过的网址并跳转
                    if (authorization.state.Contains("?"))
                    {
                        authorization.state += "&";
                    }
                    else
                    {
                        authorization.state += "?";
                    }
                    var url = _commonService.GetWeChatUrl(authorization.state, authorization.appId, authorization.code, log);
                    Logger.Warn("url:" + url);
                    return Redirect(url);
                    #endregion                   
                }
            }
            catch (Exception ex)
            {
                log.Write("error:" + ex.Message + "");
            }
           return Content("");
        }

        /// <summary>
        /// 轩宇券统一网页授权
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("WeChatAuth/CardAuthorization"), MapToApiVersion("1.0")]
        public ActionResult CardAuthorization(WxAuthorization authorization)
        {

            Log log = new Log("CardAuthorization");
            List<string> codeList = new List<string>();
            try
            {
                #region 获取跳转地址转译集合，合成授权过的网址并跳转
                if (authorization.state.Contains("?"))
                {
                    authorization.state += "&";
                }
                else
                {
                    authorization.state += "?";
                }
                var bgNo = "";
                var openId = _wxHelper.GetOpenIdByAppId(authorization.appId, authorization.code, log,ref bgNo);
                authorization.state += "appId=" + authorization.appId + "&bgNo=" + bgNo + "" + "&openId=" + openId + "";
                log.Write("url:" + authorization.state);
                return Redirect(authorization.state);
                #endregion

            }
            catch (Exception ex)
            {
                log.Write("error:" + ex.Message + "");
            }
            return View();
        }

        /// <summary>
        /// odm领券码统一网页授权
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("WeChatAuth/QRCodeAuthorization"), MapToApiVersion("1.0")]
        public ActionResult QRCodeAuthorization(WxAuthorization authorization)
        {
            string appId = "";
            string bgNo = "";
            Log log = new Log("QRCodeAuthorization");
            List<string> codeList = new List<string>();
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == authorization.orgNo);
            if (paInfo == null)
            {
                log.Write("该机构未绑定公众号");
            }
            try
            {

                #region 获取跳转地址转译集合，合成授权过的网址并跳转
                if (authorization.state.Contains("?"))
                {
                    authorization.state += "&";
                }
                else
                {
                    authorization.state += "?";
                }
                var openId =_wxHelper.GetOpenIdByOrgNo(authorization.orgNo, authorization.code,log,ref bgNo);
                authorization.state += "appId=" + appId + "&bgNo=" + bgNo + "" + "&openId=" + openId + "&orgNo=" + authorization.orgNo + "";
                log.Write("url:" + authorization.state);
                return Redirect(authorization.state);
                #endregion

            }
            catch (Exception ex)
            {
                log.Write("error:" + ex.Message + "");
            }
            return View();
        }
    }
}