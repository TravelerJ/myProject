using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StoreAdvertiseMstrDto : EntityDto<string> {    

        /// <summary>
        /// 宣传主题
        /// </summary>
        [StringLength( 50, ErrorMessage = "宣传主题输入过长，不能超过50位" )]         
        [Display( Name = "宣传主题" )]        
        public string ADVERTISE_THEME { get; set; }
        /// <summary>
        /// 展示类型(1.图文,2.海报)
        /// </summary>
                 
        [Display( Name = "展示类型(1.图文,2.海报)" )]        
        public decimal ADVERTISE_TYPE { get; set; }
        /// <summary>
        /// 图文内容
        /// </summary>
        [Display( Name = "图文内容" )]        
        public string ADVERTISE_CONTENT { get; set; }
        /// <summary>
        /// 海报链接
        /// </summary>
        [StringLength( 100, ErrorMessage = "海报链接输入过长，不能超过100位" )]         
        [Display( Name = "海报链接" )]        
        public string ADVERTISE_POSTER_URL { get; set; }
        /// <summary>
        /// 门店联系方式
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店联系方式输入过长，不能超过20位" )]         
        [Display( Name = "门店联系方式" )]        
        public string STORE_CONTRACT { get; set; }
        /// <summary>
        /// 启用状态(1.启用,2.禁用)
        /// </summary>
        [Display( Name = "启用状态(1.启用,2.禁用)" )]        
        public decimal? ADVERTISE_STATUS { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength( 20, ErrorMessage = "创建人输入过长，不能超过20位" )]         
        [Display( Name = "创建人" )]        
        public string CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]        
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength( 20, ErrorMessage = "修改人输入过长，不能超过20位" )]         
        [Display( Name = "修改人" )]        
        public string UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display( Name = "修改时间" )]        
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display( Name = "是否删除" )]        
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
        /// <summary>
        /// 宣传类别(1.延长保修,2.保险续保)
        /// </summary>
        [Display( Name = "宣传类别(1.延长保修,2.保险续保)" )]        
        public byte? ADVERTISE_CATEGORY { get; set; }
        
    }
}