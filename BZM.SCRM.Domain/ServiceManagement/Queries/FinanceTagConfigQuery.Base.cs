using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class FinanceTagConfigQuery : Pager {     

        /// <summary>
        /// 标签政策ID
        /// </summary>
        [Display(Name="标签政策ID")]
        public string TAG_ID { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Display(Name="标签名称")]
        public string TAG_NAME { get; set; }
        /// <summary>
        /// 标签详情
        /// </summary>
        [Display(Name="标签详情")]
        public string TAG_DESCRIBE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Display(Name="序号")]
        public long SORT_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public long? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name="修改人")]
        public long? UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name="修改时间")]
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        [Display(Name="删除标识")]
        public byte? DEL_FLAG { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Display(Name="门店编码")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF3 { get; set; }
    }
}