using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.MallManagement.Dtos {
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmGoodsClassDto : EntityDto<long> {    

        /// <summary>
        /// 分类代码
        /// </summary>
        [StringLength( 40, ErrorMessage = "分类代码输入过长，不能超过40位" )]         
        [Display( Name = "分类代码" )]        
        public string CLASS_NO { get; set; }
        /// <summary>
        /// 分类层级
        /// </summary>
                 
        [Display( Name = "分类层级" )]        
        public long CLASS_LEVEL { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "分类名称输入过长，不能超过100位" )]         
        [Display( Name = "分类名称" )]        
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 上级分类ID
        /// </summary>
        [Display( Name = "上级分类ID" )]        
        public long? PARENT_ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
                 
        [Display( Name = "状态" )]        
        public long CLASS_STATUS { get; set; }
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
        /// 分类属性
        /// </summary>
        [StringLength( 10, ErrorMessage = "分类属性输入过长，不能超过10位" )]         
        [Display( Name = "分类属性" )]        
        public string CLASS_ATTR { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        
    }
}