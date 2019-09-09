using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ResFileMstrDto : EntityDto<string> {    

        /// <summary>
        /// 文件名
        /// </summary>
        [StringLength( 500, ErrorMessage = "文件名输入过长，不能超过500位" )]         
        [Display( Name = "文件名" )]        
        public string FILE_NAME { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [Display( Name = "文件大小" )]        
        public decimal? FILE_SIZE { get; set; }
        /// <summary>
        /// 文件分类
        /// </summary>
        [StringLength( 20, ErrorMessage = "文件分类输入过长，不能超过20位" )]         
        [Display( Name = "文件分类" )]        
        public string FILE_CLASS { get; set; }
        /// <summary>
        /// 业务单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "业务单号输入过长，不能超过50位" )]         
        [Display( Name = "业务单号" )]        
        public string BIZ_NO { get; set; }
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
        /// 文件物理路径
        /// </summary>
        [StringLength( 2000, ErrorMessage = "文件物理路径输入过长，不能超过2000位" )]         
        [Display( Name = "文件物理路径" )]        
        public string FILE_PATH { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        [Display( Name = "显示顺序" )]        
        public long? FILE_SORT { get; set; }
        /// <summary>
        /// 文件起始日期
        /// </summary>
        [Display( Name = "文件起始日期" )]        
        public DateTime? FILE_SDATE { get; set; }
        /// <summary>
        /// 文件截止日期
        /// </summary>
        [Display( Name = "文件截止日期" )]        
        public DateTime? FILE_EDATE { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]         
        [Display( Name = "文件属性" )]        
        public string FILE_ATTR1 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]         
        [Display( Name = "文件属性" )]        
        public string FILE_ATTR2 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]         
        [Display( Name = "文件属性" )]        
        public string FILE_ATTR3 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]         
        [Display( Name = "文件属性" )]        
        public string FILE_ATTR4 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]         
        [Display( Name = "文件属性" )]        
        public string FILE_ATTR5 { get; set; }
        
    }
}