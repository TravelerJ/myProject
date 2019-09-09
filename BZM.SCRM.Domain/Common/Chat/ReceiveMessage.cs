using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Chat
{
    /// <summary>
    /// 接收消息
    /// </summary>
    public class ReceiveMessage
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
        /// 接收人id
        /// </summary>
        public string toUserId { get; set; }
        /// <summary>
        /// 接收人名称
        /// </summary>
        public string toUserName { get; set; }
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
        /// <summary>
        /// 1新车2二手车
        /// </summary>
        public int carType { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// vin
        /// </summary>
        public string vin { get; set; }

    }
}
