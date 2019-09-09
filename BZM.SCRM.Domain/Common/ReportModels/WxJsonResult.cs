using BZM.SCRM.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 微信json
    /// </summary>
    public class WxJsonResult
    {
        /// <summary>
        /// code
        /// </summary>
        public ReturnCode errcode { get; set; }
        /// <summary>
        /// msg
        /// </summary>
        public string errmsg { get; set; }
    }
}
