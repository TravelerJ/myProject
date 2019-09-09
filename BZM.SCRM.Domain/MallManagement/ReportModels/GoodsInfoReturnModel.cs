using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.MallManagement.ReportModels
{
    public class GoodsInfoReturnModel
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GOODS_NAME { get; set; }
        /// <summary>
        /// 一级类别编码
        /// </summary>
        public string GOODS_LARGECLASS_CODE { get; set; }
        /// <summary>
        /// 一级类别名称
        /// </summary>
        public string GOODS_LARGECLASS_NAME { get; set; }
        /// <summary>
        /// 二级类别编码
        /// </summary>
        public string GOODS_INCLASS_CODE { get; set; }
        /// <summary>
        /// 二级类别名称
        /// </summary>
        public string GOODS_INCLASS_NAME { get; set; }
        /// <summary>
        /// 三级类别编码
        /// </summary>
        public string GOODS_SMALLCLASS_CODE { get; set; }
        /// <summary>
        /// 三级类别名称
        /// </summary>
        public string GOODS_SMALLCLASS_NAME { get; set; }
        /// <summary>
        /// 四级类别编码
        /// </summary>
        public string GOODS_SUBCLASS_CODE { get; set; }
        /// <summary>
        /// 四级类别名称
        /// </summary>
        public string GOODS_SUBCLASS_NAME { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string UNIT { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        public string GOODS_BRAND { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        public int? IS_COMBO { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int? IA_QTY { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        public decimal? RETAILPRICE { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public decimal? MEMBERSHIP_PRICE { get; set; }
    }
}
