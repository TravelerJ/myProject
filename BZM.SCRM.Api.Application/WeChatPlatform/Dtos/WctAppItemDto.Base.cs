using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctAppItemDto : EntityDto<string> {    

        /// <summary>
        /// 主应用id
        /// </summary>
        [StringLength( 50, ErrorMessage = "主应用id输入过长，不能超过50位" )]         
        [Display( Name = "主应用id" )]        
        public string MSTR_ID { get; set; }
        /// <summary>
        /// 子应用名称
        /// </summary>
        [StringLength( 20, ErrorMessage = "子应用名称输入过长，不能超过20位" )]         
        [Display( Name = "子应用名称" )]        
        public string ITEM_NAME { get; set; }
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
        public long DEL_FLAG { get; set; }
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
        /// 关联模块id
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联模块id输入过长，不能超过50位" )]         
        [Display( Name = "关联模块id" )]        
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
        /// 子应用序列
        /// </summary>
        [Display( Name = "子应用序列" )]        
        public long? ITEM_SORT { get; set; }
        
    }
}