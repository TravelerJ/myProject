using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmDutyMstrDto : EntityDto<decimal> {    

        /// <summary>
        /// 职务编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "职务编号输入过长，不能超过50位" )]         
        [Display( Name = "职务编号" )]        
        public string DUTY_NO { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "职务名称输入过长，不能超过100位" )]         
        [Display( Name = "职务名称" )]        
        public string DUTY_NAME { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        [Display( Name = "父节点ID" )]        
        public decimal? DUTY_PARENT_ID { get; set; }
        /// <summary>
        /// 节点层级
        /// </summary>
        [Display( Name = "节点层级" )]        
        public decimal? DUTY_LEVEL { get; set; }
        /// <summary>
        /// 职务状态
        /// </summary>
                 
        [Display( Name = "职务状态" )]        
        public decimal DUTY_STATUS { get; set; }
        /// <summary>
        /// 机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "机构代码输入过长，不能超过50位" )]         
        [Display( Name = "机构代码" )]        
        public string ORG_NO { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编码输入过长，不能超过50位" )]         
        [Display( Name = "集团编码" )]        
        public string BG_NO { get; set; }
        
    }
}