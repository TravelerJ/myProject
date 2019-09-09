using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TagMstrDto : EntityDto<string> {    

        /// <summary>
        /// 标签码说明
        /// </summary>
        [StringLength( 200, ErrorMessage = "标签码说明输入过长，不能超过200位" )]         
        [Display( Name = "标签码说明" )]        
        public string TAG_MSTR_DESC { get; set; }
        /// <summary>
        /// 标签分类
        /// </summary>
        [StringLength( 20, ErrorMessage = "标签分类输入过长，不能超过20位" )]         
        [Display( Name = "标签分类" )]        
        public string TAG_TYPE { get; set; }
        /// <summary>
        /// 标签关联数据库
        /// </summary>
        [StringLength( 50, ErrorMessage = "标签关联数据库输入过长，不能超过50位" )]         
        [Display( Name = "标签关联数据库" )]        
        public string TAG_REF_DB_ID { get; set; }
        /// <summary>
        /// 标签关联表
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签关联表输入过长，不能超过100位" )]         
        [Display( Name = "标签关联表" )]        
        public string TAG_REF_TABLE_ID { get; set; }
        /// <summary>
        /// 标签关联字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签关联字段输入过长，不能超过100位" )]         
        [Display( Name = "标签关联字段" )]        
        public string TAG_REF_FIELD_ID { get; set; }
        /// <summary>
        /// 标签状态
        /// </summary>
                 
        [Display( Name = "标签状态" )]        
        public decimal TAG_STATUS { get; set; }
        /// <summary>
        /// 工作流流水号
        /// </summary>
        [StringLength( 20, ErrorMessage = "工作流流水号输入过长，不能超过20位" )]         
        [Display( Name = "工作流流水号" )]        
        public string WORKFLOW_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构代码" )]        
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display( Name = "创建人" )]        
        public decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display( Name = "创建日期" )]        
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display( Name = "更新人" )]        
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display( Name = "更新日期" )]        
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "标签名称输入过长，不能超过100位" )]         
        [Display( Name = "标签名称" )]        
        public string TAG_NAME { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        
    }
}