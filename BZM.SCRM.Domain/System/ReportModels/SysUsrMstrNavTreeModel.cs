using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.System.ReportModels
{
    /// <summary>
    /// 菜单列表
    /// </summary>
    public class SysUsrMstrNavTreeModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string NAV_NO { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string NAV_NAME { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string NAV_URL { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string NAV_IMG_URL { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public string NAV_PARENT_NO { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string NAV_SORT_NO { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public int NAV_EXPAND { get; set; }
    }

    /// <summary>
    /// 父级菜单
    /// </summary>
    public class SysUsrMstrParentNavTree
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string NAV_NO { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string NAV_NAME { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>

        public  List<SysUsrMstrNavTreeModel> ChildTree { get; set; }
    }
}
