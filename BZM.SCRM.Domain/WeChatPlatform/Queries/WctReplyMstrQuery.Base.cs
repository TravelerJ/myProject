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
    public partial class WctReplyMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string REPLY_ID { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [Display(Name="关键字")]
        public string REPLY_KEYWORD { get; set; }
        /// <summary>
        /// 回复内容类型：1：文本，2：图文，3：图片
        /// </summary>
        [Display(Name= "回复内容类型：0：文本,1：图文(链接),2：图文(详情)3：图文(模块)")]
        public long REPLY_CONTENT_TYPE { get; set; }
        /// <summary>
        /// 文本回复
        /// </summary>
        [Display(Name="文本回复")]
        public string REPLY_TEXT { get; set; }
        /// <summary>
        /// 组织机构编号
        /// </summary>
        [Display(Name="组织机构编号")]
        public string REPLY_ID_NO { get; set; }
        /// <summary>
        /// 回复类型：1.关注，2.默认，3关键词，4新用户关注
        /// </summary>
        [Display(Name= "回复类型：1.关注，2.默认，3关键词，4新用户关注")]
        public long? REPLY_TYPE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Display(Name="序号")]
        public long? REPLY_DISPLAY_INDEX { get; set; }
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
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF10 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 图文素材主键集
        /// </summary>
        [Display(Name="图文素材主键集")]
        public string MATERIAL_IDS { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public string REPLY_STATUS { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [Display(Name="微信图文素材ID")]
        public string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}