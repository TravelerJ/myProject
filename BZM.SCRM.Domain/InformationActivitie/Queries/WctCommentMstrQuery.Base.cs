using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.InformationActivitie.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class WctCommentMstrQuery : Pager {     

        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name="主键")]
        public string COMMENT_ID { get; set; }
        /// <summary>
        /// 资讯id
        /// </summary>
        [Display(Name="资讯id")]
        public string MATERIAL_ID { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [Display(Name="评论人")]
        public string COMMENT_OPENID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Display(Name="评论内容")]
        public string COMMENT_CONTENT { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        [Display(Name="评论时间")]
        public DateTime? COMMENT_DATE { get; set; }
        /// <summary>
        /// 上级评论id
        /// </summary>
        [Display(Name="上级评论id")]
        public string COMMENT_PARENTID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Display(Name="用户id")]
        public decimal? USER_ID { get; set; }
        /// <summary>
        /// 是否已读(0.未读,1.已读)
        /// </summary>
        [Display(Name="是否已读(0.未读,1.已读)")]
        public decimal? IS_READ { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display(Name="是否已删除")]
        public decimal? DEL_FLAG { get; set; }
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
        /// 备用字段1
        /// </summary>
        [Display(Name="备用字段1")]
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
        /// 评论点赞数
        /// </summary>
        [Display(Name="评论点赞数")]
        public decimal? SUPPORT_COUNT { get; set; }
        /// <summary>
        /// 主评论id
        /// </summary>
        [Display(Name="主评论id")]
        public string MAIN_COMMENT_ID { get; set; }
    }
}