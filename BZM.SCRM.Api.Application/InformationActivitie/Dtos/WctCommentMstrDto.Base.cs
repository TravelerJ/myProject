using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.InformationActivitie.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctCommentMstrDto : EntityDto<string> {    

        /// <summary>
        /// 资讯id
        /// </summary>
        [StringLength( 50, ErrorMessage = "资讯id输入过长，不能超过50位" )]         
        [Display( Name = "资讯id" )]        
        public string MATERIAL_ID { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [StringLength( 50, ErrorMessage = "评论人输入过长，不能超过50位" )]         
        [Display( Name = "评论人" )]        
        public string COMMENT_OPENID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [StringLength( 1000, ErrorMessage = "评论内容输入过长，不能超过1000位" )]         
        [Display( Name = "评论内容" )]        
        public string COMMENT_CONTENT { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        [Display( Name = "评论时间" )]        
        public DateTime? COMMENT_DATE { get; set; }
        /// <summary>
        /// 上级评论id
        /// </summary>
        [StringLength( 50, ErrorMessage = "上级评论id输入过长，不能超过50位" )]         
        [Display( Name = "上级评论id" )]        
        public string COMMENT_PARENTID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Display( Name = "用户id" )]        
        public decimal? USER_ID { get; set; }
        /// <summary>
        /// 是否已读(0.未读,1.已读)
        /// </summary>
        [Display( Name = "是否已读(0.未读,1.已读)" )]        
        public decimal? IS_READ { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display( Name = "是否已删除" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]         
        [Display( Name = "门店编码" )]        
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "集团编码输入过长，不能超过20位" )]         
        [Display( Name = "集团编码" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段1输入过长，不能超过50位" )]         
        [Display( Name = "备用字段1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段2输入过长，不能超过50位" )]         
        [Display( Name = "备用字段2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段3输入过长，不能超过50位" )]         
        [Display( Name = "备用字段3" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段4输入过长，不能超过50位" )]         
        [Display( Name = "备用字段4" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段5输入过长，不能超过50位" )]         
        [Display( Name = "备用字段5" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 评论点赞数
        /// </summary>
        [Display( Name = "评论点赞数" )]        
        public decimal? SUPPORT_COUNT { get; set; }
        /// <summary>
        /// 主评论id
        /// </summary>
        [StringLength( 50, ErrorMessage = "主评论id输入过长，不能超过50位" )]         
        [Display( Name = "主评论id" )]        
        public string MAIN_COMMENT_ID { get; set; }
        
    }
}