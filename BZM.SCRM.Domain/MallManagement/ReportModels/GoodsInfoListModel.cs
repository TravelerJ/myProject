using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.MallManagement.ReportModels
{
    public class GoodsInfoListModel
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        public string GL_ID { get; set; }

        /// <summary>
        /// 商品状态(1.已上架,0.已下架)
        /// </summary>
        public decimal GL_STATUS { get; set; }

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

        /// <summary>
        /// 材质
        /// </summary>
        public string Gl_Material { get; set; }

        /// <summary>
        /// 原产地
        /// </summary>
        public string Made_In { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        public string Gl_Rmk { get; set; }
        /// <summary>
        /// 促销信息
        /// </summary>
        public string Promotion_Info { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image_Url { get; set; }
        /// <summary>
        /// 图文介绍
        /// </summary>
        public object Gl_Desc { get; set; }
        /// <summary>
        /// 售后说明
        /// </summary>
        public object Gl_Warranty_Desc { get; set; }

        /// <summary>
        /// 会员价
        /// </summary>
        public decimal? Member_Price { get; set; }

        /// <summary>
        /// 会员积分
        /// </summary>
        public decimal? Member_Points { get; set; }

        /// <summary>
        /// 是否启用会员价和积分的组合支付方式
        /// </summary>
        public decimal? Enable_MP { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public decimal? Goods_Sales { get; set; }
    }
}
