using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 用户标签记录表
    /// </summary>
    public partial class TagHist : Entity<string> {       

        /// <summary>
        /// 标签值码
        /// </summary>
        [Required(ErrorMessage = "标签值码不能为空")]
        [StringLength( 50, ErrorMessage = "标签值码输入过长，不能超过50位" )]
        public virtual string TAG_CODE { get; set; }
        /// <summary>
        /// 标签码
        /// </summary>
        [Required(ErrorMessage = "标签码不能为空")]
        [StringLength( 5, ErrorMessage = "标签码输入过长，不能超过5位" )]
        public virtual string TAG_MSTR_ID { get; set; }
        /// <summary>
        /// 标签版本
        /// </summary>
        [Required(ErrorMessage = "标签版本不能为空")]
        [StringLength( 1, ErrorMessage = "标签版本输入过长，不能超过1位" )]
        public virtual string TAG_VERSION { get; set; }
        /// <summary>
        /// 标签值
        /// </summary>
        [Required(ErrorMessage = "标签值不能为空")]
        [StringLength( 16, ErrorMessage = "标签值输入过长，不能超过16位" )]
        public virtual string TAG_VALUE { get; set; }
        /// <summary>
        /// 标签值描述
        /// </summary>
        [Required(ErrorMessage = "标签值描述不能为空")]
        [StringLength( 1000, ErrorMessage = "标签值描述输入过长，不能超过1000位" )]
        public virtual string TAG_VALUE_DESC { get; set; }
        /// <summary>
        /// 标签数据库名
        /// </summary>
        [Required(ErrorMessage = "标签数据库名不能为空")]
        [StringLength( 50, ErrorMessage = "标签数据库名输入过长，不能超过50位" )]
        public virtual string TAG_REF_DB_ID { get; set; }
        /// <summary>
        /// 标签表名
        /// </summary>
        [Required(ErrorMessage = "标签表名不能为空")]
        [StringLength( 100, ErrorMessage = "标签表名输入过长，不能超过100位" )]
        public virtual string TAG_REF_TABLE_ID { get; set; }
        /// <summary>
        /// 标签字段名
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签字段名输入过长，不能超过100位" )]
        public virtual string TAG_REF_FIELD_ID { get; set; }
        /// <summary>
        /// 关联记录号
        /// </summary>
        [Required(ErrorMessage = "关联记录号不能为空")]
        [StringLength( 50, ErrorMessage = "关联记录号输入过长，不能超过50位" )]
        public virtual string TAG_REF_ROW_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        public virtual DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 创建机构
        /// </summary>
        [Required(ErrorMessage = "创建机构不能为空")]
        [StringLength( 20, ErrorMessage = "创建机构输入过长，不能超过20位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        [Required(ErrorMessage = "生效日期不能为空")]
        public virtual DateTime TAG_SDATE { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        [Required(ErrorMessage = "失效日期不能为空")]
        public virtual DateTime TAG_EDATE { get; set; }
        /// <summary>
        /// 标签来源(系统/手工)
        /// </summary>
        [Required(ErrorMessage = "标签来源(系统/手工)不能为空")]
        [StringLength( 50, ErrorMessage = "标签来源(系统/手工)输入过长，不能超过50位" )]
        public virtual string TAG_FROM { get; set; }
        /// <summary>
        /// 规则ID
        /// </summary>
        [StringLength( 36, ErrorMessage = "规则ID输入过长，不能超过36位" )]
        public virtual string TAG_RULE_ID { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}