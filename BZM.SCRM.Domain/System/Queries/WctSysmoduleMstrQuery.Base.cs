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
    public partial class WctSysmoduleMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string SYSM_ID { get; set; }
        /// <summary>
        /// 模块Key
        /// </summary>
        [Display(Name="模块Key")]
        public string SYSM_KEY { get; set; }
        /// <summary>
        /// 模块标题
        /// </summary>
        [Display(Name="模块标题")]
        public string SYSM_TITLE { get; set; }
        /// <summary>
        /// 模版页面地址
        /// </summary>
        [Display(Name="模版页面地址")]
        public string SYSM_URL_TEMPLATE { get; set; }
        /// <summary>
        /// 模版配置内容
        /// </summary>
        [Display(Name="模版配置内容")]
        public string SYSM_JSON_VALUE { get; set; }
        /// <summary>
        /// 模块code
        /// </summary>
        [Display(Name="模块code")]
        public string SYSM_CODE { get; set; }
        /// <summary>
        /// 是否需要auth认证
        /// </summary>
        [Display(Name="是否需要auth认证")]
        public long? SYSM_IS_AUTH { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name="创建日期")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name="更新日期")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 模块类型(1.功能模块,2.普通模块)
        /// </summary>
        [Display(Name="模块类型(1.功能模块,2.普通模块)")]
        public long? SYSM_MODULE_TYPE { get; set; }
        /// <summary>
        /// 模块图标
        /// </summary>
        [Display(Name="模块图标")]
        public string SYSM_MODULE_LOGO { get; set; }
    }
}