using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 职务表
    /// </summary>
    public partial class MdmDutyMstr : Entity<decimal> {       

        /// <summary>
        /// 职务编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "职务编号输入过长，不能超过50位" )]
        public virtual string DUTY_NO { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        [Required(ErrorMessage = "职务名称不能为空")]
        [StringLength( 100, ErrorMessage = "职务名称输入过长，不能超过100位" )]
        public virtual string DUTY_NAME { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public virtual decimal? DUTY_PARENT_ID { get; set; }
        /// <summary>
        /// 节点层级
        /// </summary>
        public virtual decimal? DUTY_LEVEL { get; set; }
        /// <summary>
        /// 职务状态
        /// </summary>
        [Required(ErrorMessage = "职务状态不能为空")]
        public virtual decimal DUTY_STATUS { get; set; }
        /// <summary>
        /// 机构代码
        /// </summary>
        [Required(ErrorMessage = "机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "机构代码输入过长，不能超过50位" )]
        public virtual string ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required(ErrorMessage = "创建日期不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Required(ErrorMessage = "更新人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Required(ErrorMessage = "更新日期不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Required(ErrorMessage = "集团编码不能为空")]
        [StringLength( 50, ErrorMessage = "集团编码输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}