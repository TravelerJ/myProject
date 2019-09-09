using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.System.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class MdmBasRegionQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string REGION_ID { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        [Display(Name="区域编号")]
        public string REGION_NO { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [Display(Name="区域名称")]
        public string REGION_NAME { get; set; }
        /// <summary>
        /// 区域层级(0-省/1-市/2-区)
        /// </summary>
        [Display(Name="区域层级(0-省/1-市/2-区)")]
        public long REGION_LEVEL { get; set; }
        /// <summary>
        /// 父区域编号(顶级为00)
        /// </summary>
        [Display(Name="父区域编号(顶级为00)")]
        public string PARENT_REGION_NO { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        [Display(Name="区域标示1")]
        public long? REGION_FLAG1 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        [Display(Name="区域标示1")]
        public long? REGION_FLAG2 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        [Display(Name="区域标示1")]
        public long? REGION_FLAG3 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        [Display(Name="区域标示1")]
        public long? REGION_FLAG4 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        [Display(Name="区域标示1")]
        public long? REGION_FLAG5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name="创建日期")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name="更新日期")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal DEL_FLAG { get; set; }
    }
}