using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Domain.Common.ReportModels;
using jsms;
using jsms.common;
using jsms.sms;
using Newtonsoft.Json;
using SCRM.Domain.System.Entitys;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Utils.Jg.Model;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// 短信helper
    /// </summary>
    public class SmsHelper
    {

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="masterSecret"></param>
        /// <param name="mobile">手机</param>
        /// <param name="tempId">模版id</param>
        /// <param name="msgId">短信码id</param>
        /// <returns></returns>
        public static bool Send(string appKey, string masterSecret, string mobile, int tempId, ref string msgId)
        {
            bool retBool = false;
            JSMSClient client = new JSMSClient(appKey, masterSecret);

            SMSPayload codes = new SMSPayload(mobile, tempId);
            String codesjson = codes.ToJson(codes);

            ResponseWrapper ret = client._SMSClient.SendCodes(codesjson);
            retBool = ret.responseCode ==HttpStatusCode.OK;

            if (retBool)
            {
                SendSmsInfo info = JsonConvert.DeserializeObject<SendSmsInfo>(ret.ResponseContent);
                msgId = info.msg_id;
            }
            return retBool;
        }

        class SendSmsInfo
        {
            public string msg_id { get; set; }
        }


        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="masterSecret"></param>
        /// <param name="code"></param>
        /// <param name="msgId"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Validate(string appKey, string masterSecret, string code, string msgId, ref string errMsg)
        {
            bool retBool = false;
            JSMSClient client = new JSMSClient(appKey, masterSecret);

            string msg_id = msgId;
            ValidPayload codes = new ValidPayload(code);

            String codesjson = codes.ToJson(codes);
            ResponseWrapper ret = client._SMSClient.ValidCodes(codes, msg_id);

            retBool = ret.responseCode ==HttpStatusCode.OK;

            if (!retBool)
            {
                errMsg = ret.ResponseContent;
            }
            return retBool;
        }

        /// <summary>
        /// 发送短信通知
        /// </summary>
        /// <param name="apt"></param>
        /// <param name="mobile"></param>
        /// <param name="basConfig"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public  bool SendMessage(AptInfo apt, string mobile, WctBasConfig basConfig, Log log)
        {
            BaseConfig config = new BaseConfig()
            {
                AppKey = basConfig.SMS_APP_KEY,
                MasterSecret = basConfig.SMS_MASTER_SECRET
            };
            //发送营销类短信
            var cusInfo = "客户姓名:" + apt.NAME + "" + (apt.APT_TYPE == 2 ? ",车牌号:" + apt.CAR_ID + "" : "");
            Dictionary<string, string> extraParam = new Dictionary<string, string>();
            extraParam.Add("projectName", apt.APT_CLASS);
            extraParam.Add("cusInfo", cusInfo);
            extraParam.Add("timeSpan", apt.APT_DATE.ToString("yyyy-MM-dd") + " " + apt.APT_TIMESPAN);
            var ret = Utils.Jg.Sms.SmsHelper.SendMarketing(config, mobile, Convert.ToInt32(basConfig.SMS_MSG_CODE), extraParam, out Utils.Common.NetHelper.HttpHelper.Model.HttpResult result);
            if (!ret) { log.Write("发送短消息失败"); }
            return ret;

        }
    }
}
