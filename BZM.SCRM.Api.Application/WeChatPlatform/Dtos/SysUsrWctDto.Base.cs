using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.WeChatPlatform.Dtos {
    /// <summary>
    /// 
    /// </summary>
    public partial class SysUsrWctDto : EntityDto<string> {    

        /// <summary>
        /// 商户号
        /// </summary>
        [StringLength( 50, ErrorMessage = "商户号输入过长，不能超过50位" )]         
        [Display( Name = "商户号" )]        
        public string BU_NO { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
                 
        [Display( Name = "用户ID" )]        
        public decimal USR_ID { get; set; }
        /// <summary>
        /// 微信openid
        /// </summary>
        [StringLength( 50, ErrorMessage = "微信openid输入过长，不能超过50位" )]         
        [Display( Name = "微信openid" )]        
        public string OPEN_ID { get; set; }
        /// <summary>
        /// 关联员工编号
        /// </summary>
        [StringLength( 1000, ErrorMessage = "关联员工编号输入过长，不能超过1000位" )]         
        [Display( Name = "关联员工编号" )]        
        public string CUS_SVC_CODE { get; set; }
        /// <summary>
        /// 关注状态(0-取消关注/1-已关注)
        /// </summary>
        [Display( Name = "关注状态(0-取消关注/1-已关注)" )]        
        public decimal? FOLLOW_STATUS { get; set; }
        /// <summary>
        /// 粉丝来源(1-微信/2-导入/3-手工添加)
        /// </summary>
        [Display( Name = "粉丝来源(1-微信/2-导入/3-手工添加)" )]        
        public decimal? USR_SOURCE { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        [Display( Name = "注册日期" )]        
        public DateTime? REG_DATE { get; set; }
        /// <summary>
        /// 推荐人用户ID
        /// </summary>
        [Display( Name = "推荐人用户ID" )]        
        public decimal? REFEREE_USR_ID { get; set; }
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
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构代码" )]        
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 取消关注时间
        /// </summary>
        [StringLength( 50, ErrorMessage = "取消关注时间输入过长，不能超过50位" )]         
        [Display( Name = "取消关注时间" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [StringLength( 50, ErrorMessage = "性别输入过长，不能超过50位" )]         
        [Display( Name = "性别" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength( 50, ErrorMessage = "昵称输入过长，不能超过50位" )]         
        [Display( Name = "昵称" )]        
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 用户微信图像
        /// </summary>
        [StringLength( 500, ErrorMessage = "用户微信图像输入过长，不能超过500位" )]         
        [Display( Name = "用户微信图像" )]        
        public string WX_AVATAR_URL { get; set; }
        /// <summary>
        /// 微信公众号ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "微信公众号ID输入过长，不能超过50位" )]         
        [Display( Name = "微信公众号ID" )]        
        public string APP_ID { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "标签名称输入过长，不能超过500位" )]         
        [Display( Name = "标签名称" )]        
        public string TAG_NAME { get; set; }
        /// <summary>
        /// 销售顾问专属Ticket
        /// </summary>
        [StringLength( 200, ErrorMessage = "销售顾问专属Ticket输入过长，不能超过200位" )]         
        [Display( Name = "销售顾问专属Ticket" )]        
        public string TICKET { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 售后预约code
        /// </summary>
        [StringLength( 50, ErrorMessage = "售后预约code输入过长，不能超过50位" )]         
        [Display( Name = "售后预约code" )]        
        public string AFTER_SALE_CODE { get; set; }
        
    }
}