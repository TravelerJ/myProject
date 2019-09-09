using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 标签主表
    /// </summary>
    public partial class TagMstr : Entity<string> {       

        /// <summary>
        /// 标签码说明
        /// </summary>
        [StringLength( 200, ErrorMessage = "标签码说明输入过长，不能超过200位" )]
        public virtual string TAG_MSTR_DESC { get; set; }
        /// <summary>
        /// 标签分类
        /// </summary>
        [Required(ErrorMessage = "标签分类不能为空")]
        [StringLength( 20, ErrorMessage = "标签分类输入过长，不能超过20位" )]
        public virtual string TAG_TYPE { get; set; }
        /// <summary>
        /// 标签关联数据库
        /// </summary>
        [Required(ErrorMessage = "标签关联数据库不能为空")]
        [StringLength( 50, ErrorMessage = "标签关联数据库输入过长，不能超过50位" )]
        public virtual string TAG_REF_DB_ID { get; set; }
        /// <summary>
        /// 标签关联表
        /// </summary>
        [Required(ErrorMessage = "标签关联表不能为空")]
        [StringLength( 100, ErrorMessage = "标签关联表输入过长，不能超过100位" )]
        public virtual string TAG_REF_TABLE_ID { get; set; }
        /// <summary>
        /// 标签关联字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签关联字段输入过长，不能超过100位" )]
        public virtual string TAG_REF_FIELD_ID { get; set; }
        /// <summary>
        /// 标签状态
        /// </summary>
        [Required(ErrorMessage = "标签状态不能为空")]
        public virtual decimal TAG_STATUS { get; set; }
        /// <summary>
        /// 工作流流水号
        /// </summary>
        [StringLength( 20, ErrorMessage = "工作流流水号输入过长，不能超过20位" )]
        public virtual string WORKFLOW_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public virtual decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public virtual DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签名称输入过长，不能超过100位" )]
        public virtual string TAG_NAME { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}