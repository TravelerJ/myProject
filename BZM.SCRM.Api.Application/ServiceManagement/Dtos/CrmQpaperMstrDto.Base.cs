﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CrmQpaperMstrDto : EntityDto<string> {    

        /// <summary>
        /// 问卷名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "问卷名称输入过长，不能超过500位" )]         
        [Display( Name = "问卷名称" )]        
        public string PAPER_NAME { get; set; }
        /// <summary>
        /// 类型：1.问卷，2.投票
        /// </summary>
        [Display( Name = "类型：1.问卷，2.投票" )]        
        public decimal? PAPER_TYPE { get; set; }
        /// <summary>
        /// 包含题号
        /// </summary>
        [StringLength( 4000, ErrorMessage = "包含题号输入过长，不能超过4000位" )]         
        [Display( Name = "包含题号" )]        
        public string INCLUDE_QUESTION_IDS { get; set; }
        /// <summary>
        /// 开始生效日期
        /// </summary>
        [Display( Name = "开始生效日期" )]        
        public DateTime? PAPER_SDATE { get; set; }
        /// <summary>
        /// 结束生效日期
        /// </summary>
        [Display( Name = "结束生效日期" )]        
        public DateTime? PAPER_EDATE { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 1000, ErrorMessage = "描述输入过长，不能超过1000位" )]         
        [Display( Name = "描述" )]        
        public string PAPER_DESC { get; set; }
        /// <summary>
        /// 是否启用：0.未启用，1.启用
        /// </summary>
        [Display( Name = "是否启用：0.未启用，1.启用" )]        
        public decimal? PAPER_STATUS { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF10 { get; set; }
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
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
                 
        [Display( Name = "创建日期" )]        
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
                 
        [Display( Name = "更新人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
                 
        [Display( Name = "更新日期" )]        
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
                 
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        
    }
}