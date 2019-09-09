using System.Collections.Concurrent;
using System;
using System.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using SCRM.Domain.ServiceManagement.Entitys;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BT.BPMLIVE.Common._IO;
using System.Linq;
using BZM.SCRM.Domain.Common.Chat;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;

namespace BZM.SCRM.Api.Startup
{
    /// <summary>
    /// 集线器
    /// </summary>
    public class SignalRHub : Hub
    {
        /// <summary>
        /// 用户集合
        /// </summary>
        public static List<OnlineUserInfo> UserList = new List<OnlineUserInfo>();
        /// <summary>
        /// 消息集合
        /// </summary>
        public static List<CrmEvaMstrModel> MessageList = new List<CrmEvaMstrModel>();
        /// <summary>
        /// 聊天helper
        /// </summary>
        private readonly ChatHelper _chatHelper;
        /// <summary>
        /// 消息仓储
        /// </summary>
        private readonly ICrmEvaMstrRepository _crmEvaMstrRepository;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="chatHelper">聊天helper</param>
        /// <param name="crmEvaMstrRepository">消息仓储</param>
        public SignalRHub(ChatHelper chatHelper,
            ICrmEvaMstrRepository crmEvaMstrRepository)
        {
            _chatHelper = chatHelper;
            _crmEvaMstrRepository = crmEvaMstrRepository;
        }

        ///// <summary>
        ///// 发送全部
        ///// </summary>
        ///// <param name="message"></param>
        //[HubMethodName("send")]
        //public void Send(string message)
        //{
        //    string clientName = UserList.Where(c=>c.ConnectionId==Context.ConnectionId).FirstOrDefault().UserNickName;
        //    message = HttpUtility.HtmlEncode(message).Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        //    Clients.All.receiveMessage(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), clientName, message);
        //}

        /// <summary>
        /// 客户发送消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <param name="bgNo"></param>
        [HubMethodName("sendOne")]
        public void Send(string receiveMessage, string bgNo)
        {
            var log = new Log("Chat/sendOne/" + bgNo + "");
            log.Write(receiveMessage);
            log.Write("uesr:" + JsonConvert.SerializeObject(UserList) + "");
            var messageInfo = JsonConvert.DeserializeObject<ReceiveMessage>(receiveMessage);
            var returnMessage = new ReturnMessage();
            string toConnectionId = "";
            string clientName = "";
            string clientId = Context.GetHttpContext().Request.Query["clientId"].ToString();
            var user = UserList.Where(c => c.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (user != null)
            {
                clientName = user.UserNickName;
                //messageInfo.message = HttpUtility.HtmlEncode(messageInfo.message).Replace("\r\n", "<br/>").Replace("\n", "<br/>");
                var toUser = UserList.Where(c => c.UserId == messageInfo.toUserId).FirstOrDefault();
                if (toUser != null)
                {
                    returnMessage.userId = messageInfo.userId;
                    returnMessage.userName = clientName;
                    returnMessage.userUrl = user.Url;
                    returnMessage.message = messageInfo.message;
                    returnMessage.messageDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    returnMessage.toUserId = messageInfo.toUserId;
                    var json = JsonConvert.SerializeObject(returnMessage);
                    toConnectionId = toUser.ConnectionId;
                    Clients.Client(toConnectionId).SendAsync("receiveMessage", json);
                }
                var ManageUser = UserList.Where(c => c.UserType != 0 && c.BgNo == bgNo).ToList();
                if (ManageUser.Count > 0)
                {
                    returnMessage.userId = messageInfo.userId;
                    returnMessage.userName = clientName;
                    returnMessage.userUrl = user.Url;
                    returnMessage.message = messageInfo.message;
                    returnMessage.messageDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    returnMessage.toUserId = messageInfo.toUserId;
                    var json = JsonConvert.SerializeObject(returnMessage);
                    var list = ManageUser.Select(c => c.ConnectionId).ToList();
                    log.Write("connects:" + JsonConvert.SerializeObject(list) + "");
                    Clients.Clients(list).SendAsync("receiveMessage",json);

                }
                else
                {
                    var clientInfo = UserList.Where(c => c.UserId == clientId).FirstOrDefault();
                    if (_chatHelper.IsToIris(clientInfo.BgNo))
                    {
                        var openId = "o5QuWws4RNxB7rZCYPzh0Qyw89AU";
                        if (messageInfo.toUserId.Length != openId.Length)
                        {
                           _chatHelper.ChatMessageToIris(messageInfo.toUserId, messageInfo.toUserName, clientId, clientName, messageInfo.message, bgNo, log);
                        }
                    }

                }
                _chatHelper.AddChatMessage(messageInfo, log);
                if (messageInfo.userId.IndexOf("o") > -1)
                {
                    _chatHelper.AddBehavviorInfo(messageInfo, log);
                }

            }
        }

        /// <summary>
        /// 后台给发送客户消息
        /// </summary>
        /// <param name="receiveMessage"></param>
        /// <param name="bgNo"></param>
        [HubMethodName("sendCus")]
        public void SendCus(string receiveMessage, string bgNo)
        {
            var log = new Log("Chat/SendCus/" + bgNo + "");
            log.Write(receiveMessage);
            var returnMessage = new ReturnMessage();
            var messageInfo = JsonConvert.DeserializeObject<ReceiveMessage>(receiveMessage);
            string toConnectionId = "";
            string clientName = "";
            string clientId = Context.GetHttpContext().Request.Query["clientId"].ToString();
            var user = GetUserInfo(messageInfo.userId);
            if (user != null)
            {
                clientName = user.USR_REAL_NAME;
                //messageInfo.message = HttpUtility.HtmlEncode(messageInfo.message).Replace("\r\n", "<br/>").Replace("\n", "<br/>");
                var toUser = UserList.Where(c => c.UserId == messageInfo.toUserId).FirstOrDefault();
                if (toUser != null)
                {
                    returnMessage.userId = messageInfo.userId;
                    returnMessage.userName = clientName;
                    returnMessage.userUrl = user.USR_AVATAR_PATH;
                    returnMessage.message = messageInfo.message;
                    returnMessage.messageDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    var json = JsonConvert.SerializeObject(returnMessage);
                    toConnectionId = toUser.ConnectionId;
                    Clients.Client(toConnectionId).SendAsync("receiveMessage", json);
                }
                var ManageUser = UserList.Where(c => c.UserId==messageInfo.userId).ToList();
                if (ManageUser.Count > 0)
                {
                    returnMessage.userId = clientId;
                    returnMessage.userName = clientName;
                    returnMessage.userUrl = user.USR_AVATAR_PATH;
                    returnMessage.message = messageInfo.message;
                    returnMessage.messageDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    returnMessage.toUserId = messageInfo.toUserId;
                    returnMessage.messageType = 1;
                    var json = JsonConvert.SerializeObject(returnMessage);
                    var list = ManageUser.Select(c => c.ConnectionId).ToList();
                    log.Write("connects:" + JsonConvert.SerializeObject(list) + "");
                    Clients.Clients(list).SendAsync("receiveMessage", json);

                }
                _chatHelper.AddChatMessage(messageInfo, log);
            }
        }

        /// <summary>
        /// 网页端更新消息状态
        /// </summary>
        /// <param name="userId"></param>
        public void UpdateMessageStatus(string userId)
        {
            var clientId = Context.GetHttpContext().Request.Query["clientId"].ToString();
            var user = UserList.Where(c => c.UserId == clientId).FirstOrDefault();
            var log = new Log("Chat/UpdateMessage/" + user.BgNo + "");
            log.Write("userId:" + userId + ",clientId:" + clientId + "");
            _crmEvaMstrRepository.UpdateMessageStatus(clientId, userId);
        }

        /// <summary>
        /// 后台系统更新消息状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        public void UpdateOnlineMessageStatus(string userId, string toUserId)
        {
            var clientId = Context.GetHttpContext().Request.Query["clientId"].ToString();
            var user = UserList.Where(c => c.UserId == clientId).FirstOrDefault();
            var log = new Log("Chat/UpdateMessage/" + user.BgNo + "");
            log.Write("userId:" + userId + ",clientId:" + clientId + ",toUserId:" + toUserId + "");
            _crmEvaMstrRepository.UpdateMessageStatus(toUserId, userId);
        }
        /// <summary>
        /// 获取客户消息列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserOnlineModel> GetOnlineList(string userId)
        {

            var user =_chatHelper.GetUserInfo(userId);
            var log = new Log("Chat/GetOnlineList/" + user.BG_NO + "");
            var list = new List<UserOnlineModel>();
            if (!string.IsNullOrEmpty(userId))
            {
                list =_crmEvaMstrRepository.GetUserOnlineList(userId);
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        var model = UserList.Where(c => c.UserId == item.OPEN_ID).FirstOrDefault();
                        item.ONLINESTATUS = model != null ? true : false;
                    }
                }

            }
            return list;

        }

        /// <summary>
        /// 获取在线用户消息分页
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public UserOnLineInfo GetOnlineListByPage(string userId, int pageIndex, int pageSize)
        {
            var online = new UserOnLineInfo();
            try
            {
                var user = _chatHelper.GetUserInfo(userId);
                var list = new List<UserOnlineModel>();
                if (!string.IsNullOrEmpty(userId))
                {
                    online.MessageList = _crmEvaMstrRepository.GetUserOnlineListByPage(user.USR_TYPE, user.ORG_NO, user.BG_NO, pageIndex, pageSize).Data;
                    if (online.MessageList.Count > 0)
                    {
                        foreach (var item in online.MessageList)
                        {
                            var model = UserList.Where(c => c.UserId == item.OPEN_ID).FirstOrDefault();
                            item.ONLINESTATUS = model != null ? true : false;
                        }
                        online.totalCount = online.MessageList.Select(c => c.UNREADCOUNT).ToList().Sum();
                    }

                }
            }
            catch (Exception ex)
            {

            }

            return online;

        }
        //public override System.Threading.Tasks.Task OnConnected()
        //{
        //    string clientName = Context.QueryString["clientName"].ToString();
        //    string clientId = Context.QueryString["clientId"].ToString();
        //    OnLineUsers.AddOrUpdate(clientId, clientName, (key, value) => clientName);
        //    Clients.All.userChange(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Format("{0} 加入了。", clientName), OnLineUsers.ToArray());
        //    return base.OnConnected();
        //}

        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{
        //    string clientName = Context.QueryString["clientName"].ToString();
        //    string clientId = Context.QueryString["clientId"].ToString();
        //    Clients.All.userChange(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Format("{0} 离开了。", clientName), OnLineUsers.ToArray());
        //    OnLineUsers.TryRemove(clientId, out clientName);
        //    return base.OnDisconnected(stopCalled);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            var orgNo = "";
            var bgNo = "";
            var result = 0;
            var user = new SysUsrMstr();
            string clientId = Context.GetHttpContext().Request.Query["clientId"].ToString();
            string clientName = Context.GetHttpContext().Request.Query["clientName"];
            if (string.IsNullOrEmpty(clientName))
            {
                user =_chatHelper.GetUserInfo(clientId);
                clientName = user.USR_REAL_NAME;
            }

            _chatHelper.GetStoreNo(clientId, ref orgNo, ref bgNo);
            var log = new Log("Chat/Connect/" + bgNo + "");
            log.Write("connect:" + Context.ConnectionId + "");
            try
            {

                UserList = UserList.Where(c => c.BgNo == bgNo).ToList();
                var onlineUser = UserList.Where(p => p.ConnectionId == Context.ConnectionId && p.BgNo == bgNo).FirstOrDefault();
                log.Write("onlineUser:" + JsonConvert.SerializeObject(onlineUser) + "");
                if (user != null)
                {
                    UserList.Remove(onlineUser);
                }
                // RemoveMessage(clientId);
                var newUser = new OnlineUserInfo();
                if (int.TryParse(clientId, out result))
                {
                    newUser.UserType = int.Parse(user.USR_TYPE);
                }
                newUser.UserId = clientId;
                newUser.ConnectionId = Context.ConnectionId;
                newUser.UserNickName = clientName;
                newUser.Url =_chatHelper.GetWxUrl(clientId);
                newUser.BgNo = bgNo;
                UserList.Add(newUser);
                Clients.Clients(GetUserConnectionIds()).SendAsync("userChange", clientId, true);


            }
            catch (Exception ex)
            {
                log.Write(ex.Message);
            }

            return base.OnConnectedAsync();
        }

            
        

        /// <summary>
        /// 获取顾问信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SysUsrMstr GetUserInfo(string userId)
        {

            var model = new SysUsrMstr();
            if (!string.IsNullOrEmpty(userId))
            {
                model = _chatHelper.GetUserInfo(userId);
            }
            return model;
        }
        /// <summary>
        /// 获取在线用户连接id
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserConnectionIds()
        {
            var list = new List<string>();
            foreach (var item in UserList)
            {
                list.Add(item.ConnectionId);
            }
            return list;
        }

        /// <summary>
        /// 微信端获取消息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        /// <param name="iDisplayStart"></param>
        /// <param name="iDisplayLength"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<MessageList> GetMessageList(string userId, string toUserId, int iDisplayStart, int iDisplayLength, DateTime? time)
        {
            var messageList = _chatHelper.GetMeaasgeList(userId, toUserId, iDisplayStart, iDisplayLength, time);
            return messageList;
        }

        /// <summary>
        /// 获取用户消息(顾问)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        /// <param name="iDisplayStart"></param>
        /// <param name="iDisplayLength"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public OnlineMessageInfo GetMessageListForEmployee(string userId, string toUserId, int iDisplayStart, int iDisplayLength, DateTime? time)
        {
            var model = new OnlineMessageInfo();
            model.intentionCarInfo = new IntentionCarInfo();
            model.messageList =_chatHelper.GetMeaasgeList(userId, toUserId, iDisplayStart, iDisplayLength, time);
            if (model.messageList.Count > 0)
            {
                var lastCusMessage = model.messageList.Where(c => c.userId == toUserId).OrderByDescending(c => c.MessageDate).FirstOrDefault();
                if (lastCusMessage != null)
                {
                    model.intentionCarInfo.cusName = lastCusMessage.userName;
                    model.intentionCarInfo.brandName = lastCusMessage.brandName;
                    model.intentionCarInfo.className = lastCusMessage.className;
                    model.intentionCarInfo.carTypeName = lastCusMessage.carTypeName;
                }
            }
            return model;
        }

        /// <summary>
        /// 获取消息记录
        /// </summary>
        /// <param name="toUserId"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public List<OnlineUserInfo> GetMessageHistory(string toUserId, List<OnlineUserInfo> userList)
        {
            var ids = "";
            if (userList.Count > 0)
            {
                var str = string.Join(",", userList.Select(c => c.UserId).ToList());
                ids = "'" + str.Replace(",", "','") + "'";
            }
            MessageList = _crmEvaMstrRepository.GetChatMeaasgeList(ids);
            foreach (var item in userList)
            {
                var list = MessageList.Where(c => c.EVA_OBJ_NO == item.UserId || c.EVA_REF_NO == item.UserId).OrderBy(c => c.EVA_DATE).ToList();
                item.MessageList = list.Count > 0 ? list : new List<CrmEvaMstrModel>();
            }
            return userList;
        }

        /// <summary>
        /// 断线
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            //string clientName = Context.QueryString["clientName"].ToString();
            //string clientId = Context.QueryString["clientId"].ToString();
            var UserInfo = UserList.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
            //string usernickname = UserInfo.UserNickName;
            if (UserInfo != null)
            {
                Clients.Clients(GetUserConnectionIds()).SendAsync("userChange", UserInfo.UserId, false);
                UserList.Remove(UserInfo);
            }
            //Clients.All.userChange(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Format("{0} 离开了。", clientName), OnLineUsers.ToArray());
            // OnLineUsers.TryRemove(clientId, out clientName);
            return base.OnDisconnectedAsync(exception);
        }
        ///// <summary>
        ///// 连接前执行
        ///// </summary>
        ///// <returns></returns>
        //public override System.Threading.Tasks.Task OnConnected()
        //{
        //    //Clients.All.sayHello("连接成功");
        //    Clients.Caller.sayHello("连接成功");//当前请求的用户
        //    return base.OnConnected();
        //}

        ///// <summary>
        ///// 断开链接时执行
        ///// </summary>
        ///// <param name="stopCalled"></param>
        ///// <returns></returns>
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{
        //    return base.OnDisconnected(stopCalled);
        //}

        /// <summary>
        /// 重新建立连接 如服务器重启的时候，或者前台获取超时仍在等待，重连上时
        /// </summary>
        /// <returns></returns>
        //public override System.Threading.Tasks.Task OnReconnected()
        //{
        //    string clientName = Context.QueryString["clientName"].ToString();
        //    var UserInfo = UserList.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
        //    if (UserInfo != null)
        //    {
        //        Clients.Clients(GetUserConnectionIds()).userChange(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Format("{0} 重连了。", clientName), UserList.ToArray());
        //    }
        //    return base.OnReconnected();
        //}



        
        

    }
}