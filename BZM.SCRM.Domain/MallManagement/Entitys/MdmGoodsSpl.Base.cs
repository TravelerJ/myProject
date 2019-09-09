using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    /// 商品价格表
    /// </summary>
    public partial class MdmGoodsSpl : Entity<string> {       

        /// <summary>
        /// 买方代码
        /// </summary>
        [StringLength( 2000, ErrorMessage = "买方代码输入过长，不能超过2000位" )]
        public virtual string PL_BUYER_NO { get; set; }
        /// <summary>
        /// 买方名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "买方名称输入过长，不能超过4000位" )]
        public virtual string PL_BUYER_NAME { get; set; }
        /// <summary>
        /// 买方类型
        /// </summary>
        [StringLength( 20, ErrorMessage = "买方类型输入过长，不能超过20位" )]
        public virtual string PL_BUYER_TYPE { get; set; }
        /// <summary>
        /// 卖方代码
        /// </summary>
        [Required(ErrorMessage = "卖方代码不能为空")]
        [StringLength( 4000, ErrorMessage = "卖方代码输入过长，不能超过4000位" )]
        public virtual string PL_SELLER_NO { get; set; }
        /// <summary>
        /// 卖方名称
        /// </summary>
        [Required(ErrorMessage = "卖方名称不能为空")]
        [StringLength( 4000, ErrorMessage = "卖方名称输入过长，不能超过4000位" )]
        public virtual string PL_SELLER_NAME { get; set; }
        /// <summary>
        /// 卖方类型
        /// </summary>
        [Required(ErrorMessage = "卖方类型不能为空")]
        [StringLength( 20, ErrorMessage = "卖方类型输入过长，不能超过20位" )]
        public virtual string PL_SELLER_TYPE { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [Required(ErrorMessage = "商品编码不能为空")]
        [StringLength( 50, ErrorMessage = "商品编码输入过长，不能超过50位" )]
        public virtual string PL_GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        [StringLength( 4000, ErrorMessage = "商品名称输入过长，不能超过4000位" )]
        public virtual string PL_GOODS_NAME { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [Required(ErrorMessage = "零售价不能为空")]
        public virtual decimal PL_SELL_PRICE { get; set; }
        /// <summary>
        /// 促销价
        /// </summary>
        public virtual decimal? PL_PROMO_PRICE { get; set; }
        /// <summary>
        /// 内部价
        /// </summary>
        public virtual decimal? PL_INNER_PRICE { get; set; }
        /// <summary>
        /// 索赔价
        /// </summary>
        public virtual decimal? PL_CLAIM_PRICE { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public virtual DateTime? PL_SDATE { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public virtual DateTime? PL_EDATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string PL_UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string PL_UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string PL_UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string PL_UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string PL_UDF5 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}