using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InvInventoryDto : EntityDto<long> {    

        /// <summary>
        /// 所属机构
        /// </summary>
        [StringLength( 50, ErrorMessage = "所属机构输入过长，不能超过50位" )]         
        [Display( Name = "所属机构" )]        
        public string ORG_NO { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        [Display( Name = "仓库编号" )]        
        public long? WH_ID { get; set; }
        /// <summary>
        /// 库位编号
        /// </summary>
        [Display( Name = "库位编号" )]        
        public long? LC_ID { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品编号输入过长，不能超过50位" )]         
        [Display( Name = "商品编号" )]        
        public string GOODS_NO { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        [StringLength( 50, ErrorMessage = "批次号输入过长，不能超过50位" )]         
        [Display( Name = "批次号" )]        
        public string BATCH_NO { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
                 
        [Display( Name = "数量" )]        
        public decimal QTY { get; set; }
        /// <summary>
        /// 数据标志
        /// </summary>
        [Display( Name = "数据标志" )]        
        public long? DATA_FLAG { get; set; }
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
        
    }
}