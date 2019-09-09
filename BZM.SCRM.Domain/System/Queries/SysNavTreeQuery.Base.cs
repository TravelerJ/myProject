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
    public partial class SysNavTreeQuery : Pager {     

        /// <summary>
        /// 导航编号
        /// </summary>
        [Display(Name="导航编号")]
        public string NAV_NO { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        [Display(Name="导航名称")]
        public string NAV_NAME { get; set; }
        /// <summary>
        /// 导航备注
        /// </summary>
        [Display(Name="导航备注")]
        public string NAV_RMK { get; set; }
        /// <summary>
        /// 导航链接
        /// </summary>
        [Display(Name="导航链接")]
        public string NAV_URL { get; set; }
        /// <summary>
        /// 导航图标链接
        /// </summary>
        [Display(Name="导航图标链接")]
        public string NAV_IMG_URL { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        [Display(Name="是否展开")]
        public decimal? NAV_EXPAND { get; set; }
        /// <summary>
        /// 导航排序号
        /// </summary>
        [Display(Name="导航排序号")]
        public string NAV_SORT_NO { get; set; }
        /// <summary>
        /// 父导航编号
        /// </summary>
        [Display(Name="父导航编号")]
        public string NAV_PARENT_NO { get; set; }
        /// <summary>
        /// 导航状态
        /// </summary>
        [Display(Name="导航状态")]
        public decimal NAV_STATUS { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 菜单属性
        /// </summary>
        [Display(Name="菜单属性")]
        public string NAV_ATTR { get; set; }
    }
}