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
    public partial class AptTimeperiodConfigQuery : Pager {     

        /// <summary>
        /// 预约时间段id
        /// </summary>
        [Display(Name="预约时间段id")]
        public string PERIOD_ID { get; set; }
        /// <summary>
        /// 预约类型(1.预约试驾,2.预约维保)
        /// </summary>
        [Display(Name="预约类型(1.预约试驾,2.预约维保)")]
        public decimal? APT_TYPE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Display(Name="序号")]
        public decimal? SORT_NO { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name="开始时间")]
        public string PERIOD_STIME { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name="结束时间")]
        public string PERIOD_ETIME { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display(Name="是否已删除")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        [Display(Name="机构编码")]
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
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF5 { get; set; }
    }
}