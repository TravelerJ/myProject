using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 模板消息的数据项类型
    /// </summary>
    public class TemplateDataItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="v"></param>
        /// <param name="c"></param>
        public TemplateDataItem(string v, string c = "#173177")
        {
            value = v;
            color = c;
        }

        /// <summary>
        /// 项目值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 16进制颜色代码，如：#FF0000
        /// </summary>
        public string color { get; set; }
    }
}
