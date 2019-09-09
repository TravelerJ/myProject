using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CarFinancePolicyDto : EntityDto<string> {    

        /// <summary>
        /// 品牌代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "品牌代码输入过长，不能超过50位" )]         
        [Display( Name = "品牌代码" )]        
        public string BRAND_CODE { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "品牌名称输入过长，不能超过100位" )]         
        [Display( Name = "品牌名称" )]        
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "车系代码输入过长，不能超过50位" )]         
        [Display( Name = "车系代码" )]        
        public string CLASS_CODE { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车系名称输入过长，不能超过100位" )]         
        [Display( Name = "车系名称" )]        
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型代码输入过长，不能超过50位" )]         
        [Display( Name = "车型代码" )]        
        public string TYPE_CODE { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型名称输入过长，不能超过100位" )]         
        [Display( Name = "车型名称" )]        
        public string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型细分代码输入过长，不能超过50位" )]         
        [Display( Name = "车型细分代码" )]        
        public string SUBTYPE_CODE { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型细分名称输入过长，不能超过100位" )]         
        [Display( Name = "车型细分名称" )]        
        public string SUBTYPE_NAME { get; set; }
        /// <summary>
        /// 标签级别(1.品牌，2.车系，3.车型，4.车型细分)
        /// </summary>
                 
        [Display( Name = "标签级别(1.品牌，2.车系，3.车型，4.车型细分)" )]        
        public byte TAG_LEVEL { get; set; }
        /// <summary>
        /// 车辆类型(新车(NC)，二手车(UC)，售后车(AC))
        /// </summary>
        [StringLength( 20, ErrorMessage = "车辆类型(新车(NC)，二手车(UC)，售后车(AC))输入过长，不能超过20位" )]         
        [Display( Name = "车辆类型(新车(NC)，二手车(UC)，售后车(AC))" )]        
        public string BIZ_TYPE { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        [StringLength( 500, ErrorMessage = "标签id输入过长，不能超过500位" )]         
        [Display( Name = "标签id" )]        
        public string TAG_IDS { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "标签名称输入过长，不能超过4000位" )]         
        [Display( Name = "标签名称" )]        
        public string TAG_JSON { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display( Name = "创建人" )]        
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]        
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display( Name = "修改人" )]        
        public decimal UPDATE_PSN { get; set; }
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
        /// 删除标识
        /// </summary>
        [Display( Name = "删除标识" )]        
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 二手车车架号
        /// </summary>
        [StringLength( 50, ErrorMessage = "二手车车架号输入过长，不能超过50位" )]         
        [Display( Name = "二手车车架号" )]        
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
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf3" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf4" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf5" )]        
        public string UDF5 { get; set; }
        
    }
}