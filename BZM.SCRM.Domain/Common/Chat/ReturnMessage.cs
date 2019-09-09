using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 消息返回
    /// </summary>
    public class ReturnMessage
    {
        /// <summary>
        /// 发送人id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 发送人名称
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 发送人头像
        /// </summary>
        public string userUrl { get; set; }
        /// <summary>
        /// 接收人id
        /// </summary>
        public string toUserId { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 消息时间
        /// </summary>
        public string messageDate { get; set; }
        /// <summary>
        /// 消息类型0默认1后台
        /// </summary>
        public int messageType { get; set; }
    }

}
