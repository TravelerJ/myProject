using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CrmAptConfigMstrDto : EntityDto<string> {    

        /// <summary>
        /// 预约设置开始时间
        /// </summary>
        [Display( Name = "预约设置开始时间" )]        
        public DateTime? APT_CONFIG_SDATE { get; set; }
        /// <summary>
        /// 预约设置结束时间
        /// </summary>
        [Display( Name = "预约设置结束时间" )]        
        public DateTime? APT_CONFIG_EDATE { get; set; }
        /// <summary>
        /// 预约类型（1.预约试驾，2预约维保）
        /// </summary>
                 
        [Display( Name = "预约类型（1.预约试驾，2预约维保）" )]        
        public decimal APT_TYPE { get; set; }
        /// <summary>
        /// 预约设置Json
        /// </summary>
        [StringLength( 4000, ErrorMessage = "预约设置Json输入过长，不能超过4000位" )]         
        [Display( Name = "预约设置Json" )]        
        public string APT_CONFIG_JSON { get; set; }
        /// <summary>
        /// 预约最低折扣
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约最低折扣输入过长，不能超过50位" )]         
        [Display( Name = "预约最低折扣" )]        
        public string APT_MIN_DISCOUNT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 150, ErrorMessage = "备注输入过长，不能超过150位" )]         
        [Display( Name = "备注" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]         
        [Display( Name = "未定义" )]        
        public string UDF9 { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]         
        [Display( Name = "门店编码" )]        
        public string BU_NO { get; set; }
        /// <summary>
        /// 创建机构编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构编码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构编码" )]        
        public string CREATE_ORG_NO { get; set; }
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
        /// 更新人
        /// </summary>
                 
        [Display( Name = "更新人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
                 
        [Display( Name = "更新时间" )]        
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
        /// <summary>
        /// 优惠方式(1.折扣,2.金额)
        /// </summary>
        [Display( Name = "优惠方式(1.折扣,2.金额)" )]        
        public long? DIS_TYPE { get; set; }
        /// <summary>
        /// 预约提前时间
        /// </summary>
        [Display( Name = "预约提前时间" )]        
        public double? APT_LIMIT { get; set; }
        /// <summary>
        /// 是否启用默认配置(1.系统默认,2.自定义配置)
        /// </summary>
        [Display( Name = "是否启用默认配置(1.系统默认,2.自定义配置)" )]        
        public long? IS_DEFAULT { get; set; }
        
    }
}