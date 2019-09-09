using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 菜单栏表
    /// </summary>
    public partial class SysNavTree : Entity<string> {       

        /// <summary>
        /// 导航名称
        /// </summary>
        [Required(ErrorMessage = "导航名称不能为空")]
        [StringLength( 50, ErrorMessage = "导航名称输入过长，不能超过50位" )]
        public virtual string NAV_NAME { get; set; }
        /// <summary>
        /// 导航备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "导航备注输入过长，不能超过100位" )]
        public virtual string NAV_RMK { get; set; }
        /// <summary>
        /// 导航链接
        /// </summary>
        [StringLength( 200, ErrorMessage = "导航链接输入过长，不能超过200位" )]
        public virtual string NAV_URL { get; set; }
        /// <summary>
        /// 导航图标链接
        /// </summary>
        [StringLength( 200, ErrorMessage = "导航图标链接输入过长，不能超过200位" )]
        public virtual string NAV_IMG_URL { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public virtual decimal? NAV_EXPAND { get; set; }
        /// <summary>
        /// 导航排序号
        /// </summary>
        [Required(ErrorMessage = "导航排序号不能为空")]
        [StringLength( 20, ErrorMessage = "导航排序号输入过长，不能超过20位" )]
        public virtual string NAV_SORT_NO { get; set; }
        /// <summary>
        /// 父导航编号
        /// </summary>
        [Required(ErrorMessage = "父导航编号不能为空")]
        [StringLength( 10, ErrorMessage = "父导航编号输入过长，不能超过10位" )]
        public virtual string NAV_PARENT_NO { get; set; }
        /// <summary>
        /// 导航状态
        /// </summary>
        [Required(ErrorMessage = "导航状态不能为空")]
        public virtual decimal NAV_STATUS { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 菜单属性
        /// </summary>
        [StringLength( 10, ErrorMessage = "菜单属性输入过长，不能超过10位" )]
        public virtual string NAV_ATTR { get; set; }
    }
}