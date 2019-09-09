using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 授权入参
    /// </summary>
    public class WxAuthorization
    {
        /// <summary>
        /// appId
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 微信code
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 跳转url
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 二维码投放批次号
        /// </summary>
        public string batchNo { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string orgNo { get; set; }
    }
}
