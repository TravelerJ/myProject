using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using SCRM.Domain.ServiceManagement.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 在线用户model
    /// </summary>
    public class OnlineUserInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 连接id
        /// </summary>
        public string ConnectionId { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        public string BgNo { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 消息集合
        /// </summary>
        public List<CrmEvaMstrModel> MessageList { get; set; }
    }
}
