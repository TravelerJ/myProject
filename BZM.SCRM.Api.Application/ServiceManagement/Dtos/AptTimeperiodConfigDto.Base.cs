using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AptTimeperiodConfigDto : EntityDto<string> {    

        /// <summary>
        /// 预约类型(1.预约试驾,2.预约维保)
        /// </summary>
        [Display( Name = "预约类型(1.预约试驾,2.预约维保)" )]        
        public decimal? APT_TYPE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Display( Name = "序号" )]        
        public decimal? SORT_NO { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [StringLength( 20, ErrorMessage = "开始时间输入过长，不能超过20位" )]         
        [Display( Name = "开始时间" )]        
        public string PERIOD_STIME { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [StringLength( 20, ErrorMessage = "结束时间输入过长，不能超过20位" )]         
        [Display( Name = "结束时间" )]        
        public string PERIOD_ETIME { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display( Name = "是否已删除" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "机构编码输入过长，不能超过20位" )]         
        [Display( Name = "机构编码" )]        
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