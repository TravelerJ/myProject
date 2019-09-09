using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.InformationActivitie.Entitys
{
    /// <summary>
    /// 微信评论表
    /// </summary>
    public partial class WctCommentMstr : Entity<string> {       

        /// <summary>
        /// 资讯id
        /// </summary>
        [Required(ErrorMessage = "资讯id不能为空")]
        [StringLength( 50, ErrorMessage = "资讯id输入过长，不能超过50位" )]
        public virtual string MATERIAL_ID { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [StringLength( 50, ErrorMessage = "评论人输入过长，不能超过50位" )]
        public virtual string COMMENT_OPENID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [StringLength( 1000, ErrorMessage = "评论内容输入过长，不能超过1000位" )]
        public virtual string COMMENT_CONTENT { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public virtual DateTime? COMMENT_DATE { get; set; }
        /// <summary>
        /// 上级评论id
        /// </summary>
        [StringLength( 50, ErrorMessage = "上级评论id输入过长，不能超过50位" )]
        public virtual string COMMENT_PARENTID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual decimal? USER_ID { get; set; }
        /// <summary>
        /// 是否已读(0.未读,1.已读)
        /// </summary>
        public virtual decimal? IS_READ { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "集团编码输入过长，不能超过20位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段1输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段2输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段3输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段4输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段5输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 评论点赞数
        /// </summary>
        public virtual decimal? SUPPORT_COUNT { get; set; }
        /// <summary>
        /// 主评论id
        /// </summary>
        [StringLength( 50, ErrorMessage = "主评论id输入过长，不能超过50位" )]
        public virtual string MAIN_COMMENT_ID { get; set; }
    }
}