using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
   public class TokenReturn
    {
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// token类型
        /// </summary>
        public string token_type { get; set; }
    }
}
