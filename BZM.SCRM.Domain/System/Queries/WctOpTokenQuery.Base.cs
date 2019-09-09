using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.System.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "开放平台信息" )]
    public partial class WctOpTokenQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string TOKEN_ID { get; set; }
        /// <summary>
        /// 第三方Ticket
        /// </summary>
        [Display(Name="第三方Ticket")]
        public string COMPONENT_TICKET { get; set; }
        /// <summary>
        /// 第三方令牌
        /// </summary>
        [Display(Name="第三方令牌")]
        public string COMPONENT_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 第三方令牌获取时间
        /// </summary>
        [Display(Name="第三方令牌获取时间")]
        public DateTime? COMPONENT_TOKEN_TIME { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name="修改人")]
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name="修改时间")]
        public DateTime? UPDATE_DATE { get; set; }
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
        /// 开放平台AppId
        /// </summary>
        [Display(Name = "开放平台AppId")]
        public string COMPONENT_APPID { get; set; }
        /// <summary>
        /// 开放平台AppSecret
        /// </summary>
        [Display(Name = "开放平台AppSecret")]
        public string COMPONENT_APPSECRET { get; set; }
        /// <summary>
        /// 开放平台校验token
        /// </summary>
        [Display(Name = "开放平台校验token")]
        public string COMPONENT_TOKEN { get; set; }
        /// <summary>
        /// 开放平台加密Key
        /// </summary>
        [Display(Name = "开放平台加密Key")]
        public string COMPONENT_ENCODING_AESKEY { get; set; }
    }
}