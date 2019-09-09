using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SysUsrAuthDto : EntityDto<string> {    

        /// <summary>
        /// 用户ID
        /// </summary>
                 
        [Display( Name = "用户ID" )]        
        public long USR_ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
                 
        [Display( Name = "角色ID" )]        
        public long ROLE_ID { get; set; }
        /// <summary>
        /// 私有菜单权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有菜单权限输入过长，不能超过2000位" )]         
        [Display( Name = "私有菜单权限" )]        
        public string SP_MENU_RIGHT { get; set; }
        /// <summary>
        /// 私有数据权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有数据权限输入过长，不能超过2000位" )]         
        [Display( Name = "私有数据权限" )]        
        public string SP_DATA_RIGHT { get; set; }
        /// <summary>
        /// 私有系统权限
        /// </summary>
        [StringLength( 2000, ErrorMessage = "私有系统权限输入过长，不能超过2000位" )]         
        [Display( Name = "私有系统权限" )]        
        public string SP_SYS_RIGHT { get; set; }
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
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        
    }
}