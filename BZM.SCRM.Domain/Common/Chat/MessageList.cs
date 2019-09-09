using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 消息集合
    /// </summary>
    public class MessageList
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
        /// 接收人名称
        /// </summary>
        public string toUserName { get; set; }
        /// <summary>
        /// 接收人头像
        /// </summary>
        public string toUserUrl { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageContent { get; set; }
        /// <summary>
        /// 消息时间
        /// </summary>
        public string MessageDate { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public string brandId { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string brandName { get; set; }
        /// <summary>
        /// 车系id
        /// </summary>
        public string classId { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        public string className { get; set; }
        /// <summary>
        /// 车型id
        /// </summary>
        public string carTypeId { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string carTypeName { get; set; }


    }
}
