using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 部门表
    /// </summary>
    public partial class MdmDeptMstr : Entity<decimal> {       

        /// <summary>
        /// 部门编号
        /// </summary>
        [Required(ErrorMessage = "部门编号不能为空")]
        [StringLength( 50, ErrorMessage = "部门编号输入过长，不能超过50位" )]
        public virtual string DEPT_NO { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength( 200, ErrorMessage = "部门名称输入过长，不能超过200位" )]
        public virtual string DEPT_NAME { get; set; }
        /// <summary>
        /// 上级部门ID
        /// </summary>
        public virtual decimal? DEPT_PARENT_ID { get; set; }
        /// <summary>
        /// 业务单元编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "业务单元编号输入过长，不能超过50位" )]
        public virtual string ORG_NO { get; set; }
        /// <summary>
        /// 部门状态
        /// </summary>
        [Required(ErrorMessage = "部门状态不能为空")]
        public virtual decimal DEPT_STATUS { get; set; }
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
        [StringLength( 50, ErrorMessage = "集团编码输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}