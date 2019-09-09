using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    ///  用户角色关系表
    /// </summary>
    public partial class SysUsrAuth : Entity<string> {       

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required(ErrorMessage = "用户ID不能为空")]
        public virtual long USR_ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Required(ErrorMessage = "角色ID不能为空")]
        public virtual long ROLE_ID { get; set; }
        /// <summary>
        /// 私有菜单权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有菜单权限输入过长，不能超过2000位" )]
        public virtual string SP_MENU_RIGHT { get; set; }
        /// <summary>
        /// 私有数据权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有数据权限输入过长，不能超过2000位" )]
        public virtual string SP_DATA_RIGHT { get; set; }
        /// <summary>
        /// 私有系统权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有系统权限输入过长，不能超过2000位" )]
        public virtual string SP_SYS_RIGHT { get; set; }
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
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}