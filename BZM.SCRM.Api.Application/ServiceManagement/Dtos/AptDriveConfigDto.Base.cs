using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos {
    /// <summary>
    /// 
    /// </summary>
    public partial class AptDriveConfigDto : EntityDto<string> {    

        /// <summary>
        /// 品牌ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "品牌ID输入过长，不能超过50位" )]         
        [Display( Name = "品牌ID" )]        
        public string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [StringLength( 20, ErrorMessage = "品牌名称输入过长，不能超过20位" )]         
        [Display( Name = "品牌名称" )]        
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "车系ID输入过长，不能超过50位" )]         
        [Display( Name = "车系ID" )]        
        public string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "车系名称输入过长，不能超过50位" )]         
        [Display( Name = "车系名称" )]        
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型ID输入过长，不能超过50位" )]         
        [Display( Name = "车型ID" )]        
        public string TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型名称输入过长，不能超过50位" )]         
        [Display( Name = "车型名称" )]        
        public string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型细分ID输入过长，不能超过50位" )]         
        [Display( Name = "车型细分ID" )]        
        public string SUBTYPE_ID { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型细分名称输入过长，不能超过100位" )]         
        [Display( Name = "车型细分名称" )]        
        public string SUBTYPE_NAME { get; set; }
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
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 100, ErrorMessage = "输入过长，不能超过100位" )]         
        [Display( Name = "Udf3" )]        
        public string UDF3 { get; set; }
        
    }
}