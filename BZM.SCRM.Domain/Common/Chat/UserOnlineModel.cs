using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 用户及消息状态model
    /// </summary>
    public class UserOnlineModel
    {

        /// <summary>
        /// openId
        /// </summary>
        public string OPEN_ID { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        public string BG_NO { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NICKNAME { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string WX_AVATAR_URL { get; set; }
        /// <summary>
        /// 最近消息
        /// </summary>
        public string LASTMESSAGE { get; set; }
        /// <summary>
        /// 最近消息时间
        /// </summary>
        public string LASTMESSAGEDATE { get; set; }
        /// <summary>
        /// 未读条数
        /// </summary>
        public int UNREADCOUNT { get; set; }
        /// <summary>
        /// 在线状态
        /// </summary>
        public bool ONLINESTATUS { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string USER_ID { get; set; }
    }
    /// <summary>
    /// 在线用户信息
    /// </summary>
    public class UserOnLineInfo
    {
        /// <summary>
        /// 未读消息总数
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 消息集合
        /// </summary>
        public List<UserOnlineModel> MessageList { get; set; }
    }
}
