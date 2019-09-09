using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class SysRoleMstr : Entity<decimal> {       

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength( 50, ErrorMessage = "角色名称输入过长，不能超过50位" )]
        public virtual string ROLE_NAME { get; set; }
        /// <summary>
        /// 角色范围
        /// </summary>
        [StringLength( 100, ErrorMessage = "角色范围输入过长，不能超过100位" )]
        public virtual string ROLE_SCOPE { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        [Required(ErrorMessage = "角色状态不能为空")]
        public virtual decimal ROLE_STATUS { get; set; }
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
        /// 角色描述
        /// </summary>
        [StringLength( 100, ErrorMessage = "角色描述输入过长，不能超过100位" )]
        public virtual string ROLE_DESC { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}