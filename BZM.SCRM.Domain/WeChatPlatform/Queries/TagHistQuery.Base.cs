using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class TagHistQuery : Pager {     

        /// <summary>
        /// 标签历史PK
        /// </summary>
        [Display(Name="标签历史PK")]
        public string TAG_HIST_ID { get; set; }
        /// <summary>
        /// 标签值码
        /// </summary>
        [Display(Name="标签值码")]
        public string TAG_CODE { get; set; }
        /// <summary>
        /// 标签码
        /// </summary>
        [Display(Name="标签码")]
        public string TAG_MSTR_ID { get; set; }
        /// <summary>
        /// 标签版本
        /// </summary>
        [Display(Name="标签版本")]
        public string TAG_VERSION { get; set; }
        /// <summary>
        /// 标签值
        /// </summary>
        [Display(Name="标签值")]
        public string TAG_VALUE { get; set; }
        /// <summary>
        /// 标签值描述
        /// </summary>
        [Display(Name="标签值描述")]
        public string TAG_VALUE_DESC { get; set; }
        /// <summary>
        /// 标签数据库名
        /// </summary>
        [Display(Name="标签数据库名")]
        public string TAG_REF_DB_ID { get; set; }
        /// <summary>
        /// 标签表名
        /// </summary>
        [Display(Name="标签表名")]
        public string TAG_REF_TABLE_ID { get; set; }
        /// <summary>
        /// 标签字段名
        /// </summary>
        [Display(Name="标签字段名")]
        public string TAG_REF_FIELD_ID { get; set; }
        /// <summary>
        /// 关联记录号
        /// </summary>
        [Display(Name="关联记录号")]
        public string TAG_REF_ROW_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 创建机构
        /// </summary>
        [Display(Name="创建机构")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        [Display(Name="生效日期")]
        public DateTime TAG_SDATE { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        [Display(Name="失效日期")]
        public DateTime TAG_EDATE { get; set; }
        /// <summary>
        /// 标签来源(系统/手工)
        /// </summary>
        [Display(Name="标签来源(系统/手工)")]
        public string TAG_FROM { get; set; }
        /// <summary>
        /// 规则ID
        /// </summary>
        [Display(Name="规则ID")]
        public string TAG_RULE_ID { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}