using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{

    /// <summary>
    /// 预约模版
    /// </summary>
    public class AptTemplateData
    {
        /// <summary>
        /// 预约
        /// </summary>
        public TemplateDataItem name { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public TemplateDataItem time { get; set; }
        /// <summary>
        /// 预约结果
        /// </summary>
        public TemplateDataItem result { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public TemplateDataItem remark { get; set; }
    }

    // <summary>
    /// 预约成功模板
    /// </summary>
    public class AptSuccessTemplateData
    {
        /// <summary>
        /// 头部
        /// </summary>
        public TemplateDataItem first { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public TemplateDataItem keyword1 { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public TemplateDataItem keyword2 { get; set; }
        /// <summary>
        /// 预约人
        /// </summary>
        public TemplateDataItem keyword3 { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public TemplateDataItem keyword4 { get; set; }
        /// <summary>
        /// 预约机构
        /// </summary>
        public TemplateDataItem keyword5 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public TemplateDataItem remark { get; set; }
    }
}
