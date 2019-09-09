using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmGoodsSplDto : EntityDto<string> {    

        /// <summary>
        /// 买方代码
        /// </summary>
        [StringLength( 2000, ErrorMessage = "买方代码输入过长，不能超过2000位" )]         
        [Display( Name = "买方代码" )]        
        public string PL_BUYER_NO { get; set; }
        /// <summary>
        /// 买方名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "买方名称输入过长，不能超过4000位" )]         
        [Display( Name = "买方名称" )]        
        public string PL_BUYER_NAME { get; set; }
        /// <summary>
        /// 买方类型
        /// </summary>
        [StringLength( 20, ErrorMessage = "买方类型输入过长，不能超过20位" )]         
        [Display( Name = "买方类型" )]        
        public string PL_BUYER_TYPE { get; set; }
        /// <summary>
        /// 卖方代码
        /// </summary>
        [StringLength( 4000, ErrorMessage = "卖方代码输入过长，不能超过4000位" )]         
        [Display( Name = "卖方代码" )]        
        public string PL_SELLER_NO { get; set; }
        /// <summary>
        /// 卖方名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "卖方名称输入过长，不能超过4000位" )]         
        [Display( Name = "卖方名称" )]        
        public string PL_SELLER_NAME { get; set; }
        /// <summary>
        /// 卖方类型
        /// </summary>
        [StringLength( 20, ErrorMessage = "卖方类型输入过长，不能超过20位" )]         
        [Display( Name = "卖方类型" )]        
        public string PL_SELLER_TYPE { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品编码输入过长，不能超过50位" )]         
        [Display( Name = "商品编码" )]        
        public string PL_GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "商品名称输入过长，不能超过4000位" )]         
        [Display( Name = "商品名称" )]        
        public string PL_GOODS_NAME { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
                 
        [Display( Name = "零售价" )]        
        public decimal PL_SELL_PRICE { get; set; }
        /// <summary>
        /// 促销价
        /// </summary>
        [Display( Name = "促销价" )]        
        public decimal? PL_PROMO_PRICE { get; set; }
        /// <summary>
        /// 内部价
        /// </summary>
        [Display( Name = "内部价" )]        
        public decimal? PL_INNER_PRICE { get; set; }
        /// <summary>
        /// 索赔价
        /// </summary>
        [Display( Name = "索赔价" )]        
        public decimal? PL_CLAIM_PRICE { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        [Display( Name = "起始日期" )]        
        public DateTime? PL_SDATE { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        [Display( Name = "截止日期" )]        
        public DateTime? PL_EDATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string PL_UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string PL_UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string PL_UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string PL_UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string PL_UDF5 { get; set; }
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