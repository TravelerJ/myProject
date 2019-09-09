using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FinanceTagConfigDto : EntityDto<string> {    

        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 20, ErrorMessage = "标签名称输入过长，不能超过20位" )]         
        [Display( Name = "标签名称" )]        
        public string TAG_NAME { get; set; }
        /// <summary>
        /// 标签详情
        /// </summary>
        [StringLength( 500, ErrorMessage = "标签详情输入过长，不能超过500位" )]         
        [Display( Name = "标签详情" )]        
        public string TAG_DESCRIBE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
                 
        [Display( Name = "序号" )]        
        public long SORT_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display( Name = "创建人" )]        
        public decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]        
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display( Name = "修改人" )]        
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display( Name = "修改时间" )]        
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        [Display( Name = "删除标识" )]        
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
        /// 
        /// </summary>
        [StringLength( 20, ErrorMessage = "输入过长，不能超过20位" )]         
        [Display( Name = "Udf1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 20, ErrorMessage = "输入过长，不能超过20位" )]         
        [Display( Name = "Udf2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf3" )]        
        public string UDF3 { get; set; }
        
    }
}