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
    public partial class SysRoleMenuPermissionQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string RMP_ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Display(Name="角色ID")]
        public long ROLE_ID { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [Display(Name="权限")]
        public string PERMISSION { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
    }
}