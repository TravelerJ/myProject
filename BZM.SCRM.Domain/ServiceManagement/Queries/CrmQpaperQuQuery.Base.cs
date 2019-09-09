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
    public partial class CrmQpaperQuQuery : Pager {     

        /// <summary>
        /// 题目编号
        /// </summary>
        [Display(Name="题目编号")]
        public string QU_ID { get; set; }
        /// <summary>
        /// 题号
        /// </summary>
        [Display(Name="题号")]
        public decimal? QU_SN { get; set; }
        /// <summary>
        /// 题目类型(1.单选,2.多选)
        /// </summary>
        [Display(Name="题目类型(1.单选,2.多选)")]
        public decimal? QU_TYPE { get; set; }
        /// <summary>
        /// 题目名称
        /// </summary>
        [Display(Name="题目名称")]
        public string QU_NAME { get; set; }
        /// <summary>
        /// 是否启用：0.未启用，1.启用
        /// </summary>
        [Display(Name="是否启用：0.未启用，1.启用")]
        public decimal? QU_ENABLED { get; set; }
        /// <summary>
        /// 选项内容
        /// </summary>
        [Display(Name="选项内容")]
        public string QU_ANSWER { get; set; }
        /// <summary>
        /// 类型：1.问卷，2.投票
        /// </summary>
        [Display(Name="类型：1.问卷，2.投票")]
        public decimal? PAPER_TYPE { get; set; }
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
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF10 { get; set; }
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
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}