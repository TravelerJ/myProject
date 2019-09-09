using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 规则菜单权限表
    /// </summary>
    public partial class SysRoleMenuPermission : Entity<string> {       

        /// <summary>
        /// 角色ID
        /// </summary>
        [Required(ErrorMessage = "角色ID不能为空")]
        public virtual long ROLE_ID { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [Required(ErrorMessage = "权限不能为空")]
        [StringLength( 100, ErrorMessage = "权限输入过长，不能超过100位" )]
        public virtual string PERMISSION { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
    }
}