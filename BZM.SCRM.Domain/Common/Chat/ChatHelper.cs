using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Domain.Common.Util;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatApi.Entitys;
using SCRM.Domain.WeChatApi.Repositories;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{   
    /// <summary>
    /// 聊天helper
    /// </summary>
    public class ChatHelper
    {
        private static SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();
        /// <summary>
        /// 消息仓储
        /// </summary>
        private readonly ICrmEvaMstrRepository _crmEvaMstrRepository;
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly ISysUsrMstrRepository _sysUsrMstrRepository;
        /// <summary>
        /// 微信粉丝仓储
        /// </summary>
        private readonly ISysUsrWctRepository _sysUsrWctRepository;
        /// <summary>
        /// 客户行为记录仓储
        /// </summary>
        private readonly ICrmBehaviorRecordRepository _crmBehaviorRecordRepository;
        /// <summary>
        /// 微信helper
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 配置管理器
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// 初始化
        /// </summary>
        public ChatHelper(WxHelper wxHelper, ICrmEvaMstrRepository crmEvaMstrRepository,
            ISysUsrMstrRepository sysUsrMstrRepository,
            ISysUsrWctRepository sysUsrWctRepository,
            ICrmBehaviorRecordRepository crmBehaviorRecordRepository,
            IConfiguration configuration)
        {
            _wxHelper = wxHelper;
            _crmEvaMstrRepository = crmEvaMstrRepository;
            _sysUsrMstrRepository = sysUsrMstrRepository;
            _sysUsrWctRepository = sysUsrWctRepository;
            _crmBehaviorRecordRepository = crmBehaviorRecordRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// 验证是否对接iris
        /// </summary>
        /// <param name="bgNo"></param>
        /// <returns></returns>
        public  bool IsToIris(string bgNo)
        {
            var config = _wxHelper.GetBasConfig(bgNo);
            if (string.IsNullOrEmpty(config.Id))
            {
                return false;
            }
            if (config.IS_IRIS == 1)//是否推送iris
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 消息提醒至iris
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="toUserId"></param>
        /// <param name="toName"></param>
        /// <param name="message"></param>
        /// <param name="bgNo"></param>
        /// <param name="log"></param>
        public void ChatMessageToIris(string userId, string name, string toUserId, string toName, string message,string bgNo, Log log)
        {
            try
            {
                var config = _wxHelper.GetBasConfig(bgNo);
                if (string.IsNullOrEmpty(config.Id))
                {
                    log.Write("请先维护微信基础配置");
                    return;
                }
                var url = _configuration["Iris:irisUrl"];
                log.Write("接口url:" + url + "");
                var chatUrl = _configuration["Iris:chatUrl"];
                chatUrl = chatUrl + "id=" + userId + "||toId=" + toUserId + "||toName=" + toName + "";
                log.Write(chatUrl);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("appCode", "iris");
                dic.Add("empCode", userId);
                dic.Add("chatUrl", chatUrl);
                //var json = "appCode=iris&userCode=" + userId + "&chatUrl=" + chatUrl + "";
                //var result = PostToIris(url, json, log);

                //请求Iris接口
                string jsonStr = JsonConvert.SerializeObject(dic);
                string result = IrisHelper.RequestIrisApi(url, config.IRIS_CHAT_URL,jsonStr, log);

                DeserializeStringToDictionary(result);
                if (IsSet("code"))
                {
                    var errcode = GetValue("code");
                    if (errcode.ToString() != "success")
                    {
                        log.Write(GetValue("message").ToString());
                    }
                    else
                    {
                        log.Write(GetValue("message").ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message);
            }


        }
        /// <summary>
        /// 保存聊天信息
        /// </summary>
        /// <param name="receiveMessage">消息集合</param>
        /// <param name="log"></param>
        public void AddChatMessage(ReceiveMessage receiveMessage, Log log)
        {
            var orgNo = "";
            var bgNo = "";
            var id = "";//判定消息所属机构
            if (receiveMessage.userId.IndexOf("o") > -1)
            {
                id = receiveMessage.toUserId;
            }
            else
            {
                id = receiveMessage.userId;
            }
            GetStoreNo(id, ref orgNo, ref bgNo);
            log.Write("BU_NO:" + orgNo + ",BG_NO=" + bgNo + "");
            var eva = new CrmEvaMstr();
            eva.Id = Guid.NewGuid().ToString("N");
            eva.EVA_TYPE = "服务咨询";
            eva.EVA_OBJ_TYPE = "咨询";
            eva.EVA_DATE = DateTime.Now;
            eva.EVA_CONTENT = receiveMessage.message;
            eva.CREATE_ORG_NO = orgNo;
            eva.CREATE_PSN = 0;
            eva.CREATE_DATE = DateTime.Now;
            eva.UPDATE_PSN = 0;
            eva.UPDATE_DATE = DateTime.Now;
            eva.EVA_REF_NO = receiveMessage.userId;
            eva.UDF2 = receiveMessage.userName;
            eva.UDF1 = "未读";//消息是否已读
            eva.DEL_FLAG = 1;
            eva.EVA_OBJ_NO = receiveMessage.toUserId;
            eva.EVA_OBJ_NAME = receiveMessage.toUserName;
            eva.BG_NO = bgNo;
            eva.BRAND_ID = receiveMessage.brandId;
            eva.BRAND_NAME = receiveMessage.brandName;
            eva.CLASS_ID = receiveMessage.classId;
            eva.CLASS_NAME = receiveMessage.className;
            eva.CAR_TYPE_ID = receiveMessage.carTypeId;
            eva.CAR_TYPE_NAME = receiveMessage.carTypeName;
            _crmEvaMstrRepository.Insert(eva);
        }

        /// <summary>
        /// 新增用户行为
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <param name="log"></param>
        public void AddBehavviorInfo(ReceiveMessage receiveMessage, Log log)
        {
            var orgNo = "";
            var bgNo = "";
            GetStoreNo(receiveMessage.userId, ref orgNo, ref bgNo);
            var behaviorInfo = _crmBehaviorRecordRepository.FirstOrDefault(c => c.BEHAVIOR_TYPE == 6 && c.OPENID == receiveMessage.userId && c.IS_NEW_CAR == receiveMessage.carType && c.DEL_FLAG == 1);
            if (behaviorInfo == null)
            {
                var behavior = new CrmBehaviorRecord();
                behavior.Id = Guid.NewGuid().ToString("N");
                behavior.CUS_NAME = receiveMessage.userName;
                behavior.OPENID = receiveMessage.userId;
                behavior.BEHAVIOR_TYPE = 6;
                behavior.BEHAVIOR_NUM = 1;
                behavior.DEL_FLAG = 1;
                behavior.IS_READ = 0;
                behavior.CAR_BRANDCODE = receiveMessage.brandId;
                behavior.CAR_BRANDNAME = receiveMessage.brandName;
                behavior.CAR_CLASSCODE = receiveMessage.classId;
                behavior.CAR_CLASSNAME = receiveMessage.className;
                behavior.CAR_TYPECODE = receiveMessage.carTypeId;
                behavior.CAR_TYPE_NAME = receiveMessage.carTypeName;
                behavior.USR_ID = 0;
                behavior.IS_NEW_CAR = receiveMessage.carType;
                behavior.CREATE_PSN = 0;
                behavior.CREATE_DATE = DateTime.Now;
                behavior.UPDATE_PSN = 0;
                behavior.UPDATE_DATE = DateTime.Now;
                behavior.BU_NO = orgNo;
                behavior.BG_NO = bgNo;
                behavior.UDF1 = receiveMessage.vin;//vin
                _crmBehaviorRecordRepository.Insert(behavior);
            }
            else if ((DateTime.Now - behaviorInfo.UPDATE_DATE).Value.TotalHours > 24)
            {
                behaviorInfo.BEHAVIOR_NUM = behaviorInfo.BEHAVIOR_NUM == null ? 0 : behaviorInfo.BEHAVIOR_NUM;
                behaviorInfo.BEHAVIOR_NUM += 1;
                behaviorInfo.UPDATE_DATE = DateTime.Now;
                _crmBehaviorRecordRepository.Update(behaviorInfo);
            }

        }

        /// <summary>
        /// 获取机构和集团编码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        public  void GetStoreNo(string userId, ref string orgNo, ref string bgNo)
        {
            if (userId.IndexOf("o") > -1)
            {
                var wct = _sysUsrWctRepository.FirstOrDefault(c => c.OPEN_ID == userId && c.DEL_FLAG == 1);
                if (wct != null)
                {
                    orgNo = wct.BU_NO;
                    bgNo = wct.BG_NO;
                }
            }
            else
            {
                var user = GetUserInfo(userId);
                if (user != null)
                {
                    orgNo = user.ORG_NO;
                    bgNo = user.BG_NO;
                }
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SysUsrMstr GetUserInfo(string userId)
        {
            var user = new SysUsrMstr();
            if (decimal.TryParse(userId, out var result))
            {
                user = _sysUsrMstrRepository.FirstOrDefault(c => c.Id == result && c.DEL_FLAG == 1 && c.USR_STATUS == 1);
                if (user == null)
                {
                    user = _sysUsrMstrRepository.FirstOrDefault(c => c.ERP_EMP_ID == userId && c.DEL_FLAG == 1 && c.USR_STATUS == 1);
                }
            }
            else
            {
                user = _sysUsrMstrRepository.FirstOrDefault(c => c.ERP_EMP_ID == userId && c.DEL_FLAG == 1 && c.USR_STATUS == 1);
            }
            return user;
        }
        /// <summary>
        /// 获取消息分页信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        /// <param name="iDisplayStart"></param>
        /// <param name="iDisplayLength"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public  List<MessageList> GetMeaasgeList(string userId, string toUserId, int iDisplayStart, int iDisplayLength, DateTime? time)
        {
            var messageList = new List<MessageList>();
            var list = _crmEvaMstrRepository.GetMeaasegePagList(userId, toUserId, iDisplayStart, iDisplayLength, time).Data;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    messageList.Add(new MessageList
                    {
                        userId = item.EVA_REF_NO,
                        userName = item.UDF2,
                        userUrl = GetWxUrl(item.EVA_REF_NO),
                        toUserId = item.EVA_OBJ_NO,
                        toUserName = item.EVA_OBJ_NAME,
                        toUserUrl = GetWxUrl(item.EVA_OBJ_NO),
                        MessageContent = item.EVA_CONTENT,
                        MessageDate = Convert.ToDateTime(item.CREATE_DATE.ToString()).ToString("yyyy/MM/dd HH:mm:ss"),
                        brandId = item.BRAND_ID,
                        brandName = item.BRAND_NAME,
                        classId = item.CLASS_ID,
                        className = item.CLASS_NAME,
                        carTypeId = item.CAR_TYPE_ID,
                        carTypeName = item.CAR_TYPE_NAME
                    });
                }
            }
            return messageList;
        }
        /// <summary>
        /// 获取微信头像
        /// </summary>
        public string GetWxUrl(string userId)
        {
            var wxInfo = _sysUsrWctRepository.FirstOrDefault(c => c.OPEN_ID == userId && c.DEL_FLAG == 1);
            if (wxInfo == null)
            {
                var userInfo = _sysUsrMstrRepository.FirstOrDefault(c => c.ERP_EMP_ID == userId && c.DEL_FLAG == 1 && c.USR_STATUS == 1);
                return userInfo != null ? userInfo.USR_AVATAR_PATH : "";
            }
            return wxInfo.WX_AVATAR_URL;
        }
        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static SortedDictionary<string, object> DeserializeStringToDictionary(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new SortedDictionary<string, object>();

            m_values = JsonConvert.DeserializeObject<SortedDictionary<string, object>>(jsonStr);

            return m_values;

        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }

        /// <summary>
        /// 验证key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsSet(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            if (null != o)
                return true;
            else
                return false;
        }


    }
}
