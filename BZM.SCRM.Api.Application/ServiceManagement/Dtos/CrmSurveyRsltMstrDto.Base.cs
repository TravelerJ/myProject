﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CrmSurveyRsltMstrDto : EntityDto<string> {    

        /// <summary>
        /// 问卷ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "问卷ID输入过长，不能超过50位" )]         
        [Display( Name = "问卷ID" )]        
        public string SURVEY_ID { get; set; }
        /// <summary>
        /// 问卷标题
        /// </summary>
        [StringLength( 200, ErrorMessage = "问卷标题输入过长，不能超过200位" )]         
        [Display( Name = "问卷标题" )]        
        public string SURVEY_TITLE { get; set; }
        /// <summary>
        /// 答案描述
        /// </summary>
        [StringLength( 4000, ErrorMessage = "答案描述输入过长，不能超过4000位" )]         
        [Display( Name = "答案描述" )]        
        public string ANSWER_JSON { get; set; }
        /// <summary>
        /// 答案分值
        /// </summary>
        [Display( Name = "答案分值" )]        
        public double? ANSWER_SCORE { get; set; }
        /// <summary>
        /// 答题者ID
        /// </summary>
                 
        [Display( Name = "答题者ID" )]        
        public decimal REPORT_PSN { get; set; }
        /// <summary>
        /// 答题者名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "答题者名称输入过长，不能超过50位" )]         
        [Display( Name = "答题者名称" )]        
        public string REPORT_NAME { get; set; }
        /// <summary>
        /// 答题者的微信OpenID
        /// </summary>
        [StringLength( 50, ErrorMessage = "答题者的微信OpenID输入过长，不能超过50位" )]         
        [Display( Name = "答题者的微信OpenID" )]        
        public string REPORT_OPENID { get; set; }
        /// <summary>
        /// 答题时间
        /// </summary>
                 
        [Display( Name = "答题时间" )]        
        public DateTime REPORT_DATE { get; set; }
        /// <summary>
        /// 答题者IP
        /// </summary>
        [StringLength( 50, ErrorMessage = "答题者IP输入过长，不能超过50位" )]         
        [Display( Name = "答题者IP" )]        
        public string REPORT_IP { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
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