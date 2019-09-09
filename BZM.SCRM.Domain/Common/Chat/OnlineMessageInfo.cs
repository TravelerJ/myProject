using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 在线客户消息
    /// </summary>
    public class OnlineMessageInfo
    {
        /// <summary>
        /// 意向车型信息
        /// </summary>
        public IntentionCarInfo intentionCarInfo { get; set; }
        /// <summary>
        /// 消息集合
        /// </summary>
        public List<MessageList> messageList { get; set; }
    }
    /// <summary>
    /// 意向车型信息
    /// </summary>
    public class IntentionCarInfo
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string cusName { get; set; }
        /// <summary>
        /// 品牌名
        /// </summary>
        public string brandName { get; set; }
        /// <summary>
        /// 车系名
        /// </summary>
        public string className { get; set; }
        /// <summary>
        /// 车型名
        /// </summary>
        public string carTypeName { get; set; }
    }
}
