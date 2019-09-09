using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctAppMstrDto : EntityDto<string> {    

        /// <summary>
        /// 主应用key
        /// </summary>
        [StringLength( 30, ErrorMessage = "主应用key输入过长，不能超过30位" )]         
        [Display( Name = "主应用key" )]        
        public string APP_KEY { get; set; }
        /// <summary>
        /// 主应用名称
        /// </summary>
        [StringLength( 20, ErrorMessage = "主应用名称输入过长，不能超过20位" )]         
        [Display( Name = "主应用名称" )]        
        public string APP_NAME { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "模块ID输入过长，不能超过50位" )]         
        [Display( Name = "模块ID" )]        
        public string WCT_MODULE_ID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
                 
        [Display( Name = "创建人" )]        
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
                 
        [Display( Name = "创建时间" )]        
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
                 
        [Display( Name = "修改人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
                 
        [Display( Name = "修改时间" )]        
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
                 
        [Display( Name = "是否已删除" )]        
        public decimal DEL_FLAG { get; set; }
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
        /// 跳转链接
        /// </summary>
        [StringLength( 100, ErrorMessage = "跳转链接输入过长，不能超过100位" )]         
        [Display( Name = "跳转链接" )]        
        public string WCT_APP_URL { get; set; }
        /// <summary>
        /// 模块功能类型(1.功能模块,2.普通模块)
        /// </summary>
        [StringLength( 20, ErrorMessage = "模块功能类型(1.功能模块,2.普通模块)输入过长，不能超过20位" )]         
        [Display( Name = "模块功能类型(1.功能模块,2.普通模块)" )]        
        public string WCT_MODULE_TYPE { get; set; }
        /// <summary>
        /// 子模块组
        /// </summary>
        [StringLength( 500, ErrorMessage = "子模块组输入过长，不能超过500位" )]         
        [Display( Name = "子模块组" )]        
        public string SYS_MODULE_IDS { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段1输入过长，不能超过50位" )]         
        [Display( Name = "备用字段1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 模块KEY
        /// </summary>
        [StringLength( 50, ErrorMessage = "模块KEY输入过长，不能超过50位" )]         
        [Display( Name = "模块KEY" )]        
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
        /// 排序应用
        /// </summary>
        [Display( Name = "排序应用" )]        
        public long? APP_SORT { get; set; }
        
    }
}