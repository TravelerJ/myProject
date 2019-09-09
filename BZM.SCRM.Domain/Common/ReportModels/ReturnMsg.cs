using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    public class ReturnMsg
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回是否有效
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 操作类型(select,insert,update,delete)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 错误提示
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 类型(info,list,count)
        /// </summary>
        public string result_type { get; set; }

        /// <summary>
        /// 返回的json结果
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 返回时间
        /// </summary>
        public string result_date { get; set; }
    }
}
