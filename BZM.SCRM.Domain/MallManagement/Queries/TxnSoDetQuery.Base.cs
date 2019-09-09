using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.MallManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class TxnSoDetQuery : Pager {     

        /// <summary>
        /// 明细ID
        /// </summary>
        [Display(Name="明细ID")]
        public string SOD_ID { get; set; }
        /// <summary>
        /// 销售订单号
        /// </summary>
        [Display(Name="销售订单号")]
        public string SO_NO { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        [Display(Name="活动编号")]
        public string ACTIVITY_NO { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [Display(Name="商品编码")]
        public string GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name="商品名称")]
        public string GOODS_NAME { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [Display(Name="商品描述")]
        public string GOODS_DESC { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        [Display(Name="问题描述")]
        public string PROBLEM_DESC { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [Display(Name="商品类型")]
        public string GOODS_TYPE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Display(Name="数量")]
        public decimal QTY { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Display(Name="单价")]
        public decimal PRICE { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Display(Name="金额")]
        public decimal AMOUNT { get; set; }
        /// <summary>
        /// 减免金额
        /// </summary>
        [Display(Name="减免金额")]
        public decimal EXEMPT_AMT { get; set; }
        /// <summary>
        /// 折扣类型
        /// </summary>
        [Display(Name="折扣类型")]
        public long DISCOUNT_TYPE { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        [Display(Name="折扣率")]
        public decimal DISCOUNT_RATE { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
        [Display(Name="折扣金额")]
        public decimal DISCOUNT_AMT { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        [Display(Name="应收金额")]
        public decimal YS_AMT { get; set; }
        /// <summary>
        /// 付费类型
        /// </summary>
        [Display(Name="付费类型")]
        public string PAY_MODE { get; set; }
        /// <summary>
        /// 销售方式
        /// </summary>
        [Display(Name="销售方式")]
        public string SELL_TYPE { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [Display(Name="支付方式")]
        public long? PAY_TYPE { get; set; }
        /// <summary>
        /// 销售人员
        /// </summary>
        [Display(Name="销售人员")]
        public long SALE_PSN { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name="仓库ID")]
        public long? WH_ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [Display(Name="仓库名称")]
        public string WH_NAME { get; set; }
        /// <summary>
        /// 库位ID
        /// </summary>
        [Display(Name="库位ID")]
        public long? LC_ID { get; set; }
        /// <summary>
        /// 库位名称
        /// </summary>
        [Display(Name="库位名称")]
        public string LC_NAME { get; set; }
        /// <summary>
        /// 是否施工
        /// </summary>
        [Display(Name="是否施工")]
        public long? IS_WORKING { get; set; }
        /// <summary>
        /// 是否发料
        /// </summary>
        [Display(Name="是否发料")]
        public long? IS_MATERIAL_GI { get; set; }
        /// <summary>
        /// 是否商品套餐
        /// </summary>
        [Display(Name="是否商品套餐")]
        public long? IS_GOODS_COMBO { get; set; }
        /// <summary>
        /// 是否临时采购
        /// </summary>
        [Display(Name="是否临时采购")]
        public long? IS_TEMP_BUY { get; set; }
        /// <summary>
        /// 受损程度系数
        /// </summary>
        [Display(Name="受损程度系数")]
        public decimal? DAMAGE_GRADE_RATE { get; set; }
        /// <summary>
        /// 钣喷面积系数
        /// </summary>
        [Display(Name="钣喷面积系数")]
        public decimal? PAINT_AREA_RATE { get; set; }
        /// <summary>
        /// 钣喷材料系数
        /// </summary>
        [Display(Name="钣喷材料系数")]
        public decimal? PAINT_PART_RATE { get; set; }
        /// <summary>
        /// 单项获取积分
        /// </summary>
        [Display(Name="单项获取积分")]
        public decimal? GET_SCORE { get; set; }
        /// <summary>
        /// 单项抵扣积分
        /// </summary>
        [Display(Name="单项抵扣积分")]
        public decimal? NEED_SCORE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string REMARK { get; set; }
        /// <summary>
        /// 次卡卡号
        /// </summary>
        [Display(Name="次卡卡号")]
        public string SERVICE_NO { get; set; }
        /// <summary>
        /// 维修类型
        /// </summary>
        [Display(Name="维修类型")]
        public long MAINTAIN_CLASS { get; set; }
        /// <summary>
        /// 维修子类型
        /// </summary>
        [Display(Name="维修子类型")]
        public long? MAINTAIN_SUBCLASS { get; set; }
        /// <summary>
        /// 价格系数
        /// </summary>
        [Display(Name="价格系数")]
        public decimal? PRICE_PARA { get; set; }
        /// <summary>
        /// 商品一级类别
        /// </summary>
        [Display(Name="商品一级类别")]
        public long? GOODS_LARGECLASS { get; set; }
        /// <summary>
        /// 商品二级类别
        /// </summary>
        [Display(Name="商品二级类别")]
        public long? GOODS_INCLASS { get; set; }
        /// <summary>
        /// 商品三级类别
        /// </summary>
        [Display(Name="商品三级类别")]
        public long? GOODS_SMALLCLASS { get; set; }
        /// <summary>
        /// 来源机构代码
        /// </summary>
        [Display(Name="来源机构代码")]
        public string FROM_ORG_NO { get; set; }
        /// <summary>
        /// 技师编码
        /// </summary>
        [Display(Name="技师编码")]
        public string ENGINEER_ID { get; set; }
        /// <summary>
        /// 技师名称
        /// </summary>
        [Display(Name="技师名称")]
        public string ENGINEER_NAME { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        [Display(Name="出库数量")]
        public decimal? REL_QTY { get; set; }
        /// <summary>
        /// 是否商品升级
        /// </summary>
        [Display(Name="是否商品升级")]
        public long? IS_SP_UPGRADE { get; set; }
        /// <summary>
        /// 施工工时
        /// </summary>
        [Display(Name="施工工时")]
        public string WORK_MH { get; set; }
        /// <summary>
        /// 派工组
        /// </summary>
        [Display(Name="派工组")]
        public string ASSGIN_TEAM { get; set; }
        /// <summary>
        /// 派工工位
        /// </summary>
        [Display(Name="派工工位")]
        public string WORK_STATION { get; set; }
        /// <summary>
        /// 标准工时
        /// </summary>
        [Display(Name="标准工时")]
        public double? STD_WORK_TIME { get; set; }
        /// <summary>
        /// 次卡支付数量
        /// </summary>
        [Display(Name="次卡支付数量")]
        public long? S_PAY_QTY { get; set; }
        /// <summary>
        /// 套餐次卡
        /// </summary>
        [Display(Name="套餐次卡")]
        public long? IS_COMBO_SERVICE { get; set; }
        /// <summary>
        /// 抵扣券号
        /// </summary>
        [Display(Name="抵扣券号")]
        public string DC_COUPON { get; set; }
        /// <summary>
        /// 是否增项
        /// </summary>
        [Display(Name="是否增项")]
        public long IS_ADD { get; set; }
        /// <summary>
        /// 工单明细顺序号
        /// </summary>
        [Display(Name="工单明细顺序号")]
        public long ROW_SN { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        [Display(Name="数据标识")]
        public long? DATA_FLAG { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}