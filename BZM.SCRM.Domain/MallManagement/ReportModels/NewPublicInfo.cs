using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.MallManagement.ReportModels
{
    /// <summary>
    /// 商品属性
    /// </summary>
    public class NewPublicInfo
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GOODS_NO { get; set; }
        /// <summary>
        /// 小商品属性
        /// </summary>
        public string GOODS_RMK { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal PL_SELL_PRICE { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public decimal PL_PROMO_PRICE { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int QTY { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string BARCODE { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string PROPERTY_IMAGE { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string GOODS_STATUS { get; set; }
        /// <summary>
        /// 是否为特价推荐
        /// </summary>
        public string PROMOTION_ATTR { get; set; }
        /// <summary>
        /// 是否主商品封面推荐
        /// </summary>
        public decimal SHOW_IN_LIST { get; set; }
        /// <summary>
        /// 是否三包
        /// </summary>
        public int IS_THREE_COMMITMENTS { get; set; }
    }
}
