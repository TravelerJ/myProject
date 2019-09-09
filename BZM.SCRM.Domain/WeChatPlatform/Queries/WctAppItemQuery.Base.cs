using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class WctAppItemQuery : Pager {     

        /// <summary>
        /// 子应用主键ID
        /// </summary>
        [Display(Name="子应用主键ID")]
        public string ITEM_ID { get; set; }
        /// <summary>
        /// 主应用id
        /// </summary>
        [Display(Name="主应用id")]
        public string MSTR_ID { get; set; }
        /// <summary>
        /// 子应用名称
        /// </summary>
        [Display(Name="子应用名称")]
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name="修改人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name="修改时间")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display(Name="是否已删除")]
        public long DEL_FLAG { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Display(Name="门店编码")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        [Display(Name="跳转链接")]
        public string WCT_APP_URL { get; set; }
        /// <summary>
        /// 关联模块id
        /// </summary>
        [Display(Name="关联模块id")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [Display(Name="备用字段2")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [Display(Name="备用字段3")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [Display(Name="备用字段4")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [Display(Name="备用字段5")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 子应用序列
        /// </summary>
        [Display(Name="子应用序列")]
        public long? ITEM_SORT { get; set; }
    }
}