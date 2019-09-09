using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.WeChatPlatform.ReportModels
{
    /// <summary>
    /// 主应用信息
    /// </summary>
    public class WctAppInfoModel
    {
        /// <summary>
        /// 主应用id(关联二级应用)
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public decimal? sort { get; set; }
        /// <summary>
        /// 主应用名称
        /// </summary>
        public string appName { get; set; }
        /// <summary>
        /// 关联模块id
        /// </summary> 
        public string moduleId { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string appUrl { get; set; }
        /// <summary>
        /// 模块类型
        /// </summary>
        public string moduleType { get; set; }
        /// <summary>
        /// 模块KEY
        /// </summary>
        public string moduleKey { get; set; }
        /// <summary>
        /// 子模块组
        /// </summary>
        public string moduleIds { get; set; }
        /// <summary>
        /// 模块图标
        /// </summary>
        public string module_icon { get; set; }
        /// <summary>
        /// 子应用集合
        /// </summary>
        public List<WctAppItemModel> itemList { get; set; }
    }

    /// <summary>
    /// 子应用信息
    /// </summary>
    public class WctAppItemModel
    {
        /// <summary>
        /// 主应用id
        /// </summary>
        public string appId{ get; set; }
        /// <summary>
        /// 子应用名称
        /// </summary>
        public string itemName { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string itemUrl { get; set; }
        /// <summary>
        /// 子应用关联的模块id
        /// </summary>
        public string moduleId { get; set; }
        /// <summary>
        /// 子模块图标
        /// </summary>
        public string module_icon { get; set; }
    }
}
