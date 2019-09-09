using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    /// 订单详情表
    /// </summary>
    public partial class TxnSoDet : Entity<string> {       

        /// <summary>
        /// 销售订单号
        /// </summary>
        [Required(ErrorMessage = "销售订单号不能为空")]
        [StringLength( 50, ErrorMessage = "销售订单号输入过长，不能超过50位" )]
        public virtual string SO_NO { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        [StringLength( 20, ErrorMessage = "活动编号输入过长，不能超过20位" )]
        public virtual string ACTIVITY_NO { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [Required(ErrorMessage = "商品编码不能为空")]
        [StringLength( 50, ErrorMessage = "商品编码输入过长，不能超过50位" )]
        public virtual string GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        [StringLength( 100, ErrorMessage = "商品名称输入过长，不能超过100位" )]
        public virtual string GOODS_NAME { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [StringLength( 20, ErrorMessage = "商品描述输入过长，不能超过20位" )]
        public virtual string GOODS_DESC { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        [StringLength( 1000, ErrorMessage = "问题描述输入过长，不能超过1000位" )]
        public virtual string PROBLEM_DESC { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [Required(ErrorMessage = "商品类型不能为空")]
        [StringLength( 20, ErrorMessage = "商品类型输入过长，不能超过20位" )]
        public virtual string GOODS_TYPE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public virtual decimal QTY { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Required(ErrorMessage = "单价不能为空")]
        public virtual decimal PRICE { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Required(ErrorMessage = "金额不能为空")]
        public virtual decimal AMOUNT { get; set; }
        /// <summary>
        /// 减免金额
        /// </summary>
        [Required(ErrorMessage = "减免金额不能为空")]
        public virtual decimal EXEMPT_AMT { get; set; }
        /// <summary>
        /// 折扣类型
        /// </summary>
        [Required(ErrorMessage = "折扣类型不能为空")]
        public virtual long DISCOUNT_TYPE { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        [Required(ErrorMessage = "折扣率不能为空")]
        public virtual decimal DISCOUNT_RATE { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
        [Required(ErrorMessage = "折扣金额不能为空")]
        public virtual decimal DISCOUNT_AMT { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        [Required(ErrorMessage = "应收金额不能为空")]
        public virtual decimal YS_AMT { get; set; }
        /// <summary>
        /// 付费类型
        /// </summary>
        [Required(ErrorMessage = "付费类型不能为空")]
        [StringLength( 20, ErrorMessage = "付费类型输入过长，不能超过20位" )]
        public virtual string PAY_MODE { get; set; }
        /// <summary>
        /// 销售方式
        /// </summary>
        [Required(ErrorMessage = "销售方式不能为空")]
        [StringLength( 20, ErrorMessage = "销售方式输入过长，不能超过20位" )]
        public virtual string SELL_TYPE { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public virtual long? PAY_TYPE { get; set; }
        /// <summary>
        /// 销售人员
        /// </summary>
        [Required(ErrorMessage = "销售人员不能为空")]
        public virtual long SALE_PSN { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public virtual long? WH_ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "仓库名称输入过长，不能超过200位" )]
        public virtual string WH_NAME { get; set; }
        /// <summary>
        /// 库位ID
        /// </summary>
        public virtual long? LC_ID { get; set; }
        /// <summary>
        /// 库位名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "库位名称输入过长，不能超过50位" )]
        public virtual string LC_NAME { get; set; }
        /// <summary>
        /// 是否施工
        /// </summary>
        public virtual long? IS_WORKING { get; set; }
        /// <summary>
        /// 是否发料
        /// </summary>
        public virtual long? IS_MATERIAL_GI { get; set; }
        /// <summary>
        /// 是否商品套餐
        /// </summary>
        public virtual long? IS_GOODS_COMBO { get; set; }
        /// <summary>
        /// 是否临时采购
        /// </summary>
        public virtual long? IS_TEMP_BUY { get; set; }
        /// <summary>
        /// 受损程度系数
        /// </summary>
        public virtual decimal? DAMAGE_GRADE_RATE { get; set; }
        /// <summary>
        /// 钣喷面积系数
        /// </summary>
        public virtual decimal? PAINT_AREA_RATE { get; set; }
        /// <summary>
        /// 钣喷材料系数
        /// </summary>
        public virtual decimal? PAINT_PART_RATE { get; set; }
        /// <summary>
        /// 单项获取积分
        /// </summary>
        public virtual decimal? GET_SCORE { get; set; }
        /// <summary>
        /// 单项抵扣积分
        /// </summary>
        public virtual decimal? NEED_SCORE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 1000, ErrorMessage = "备注输入过长，不能超过1000位" )]
        public virtual string REMARK { get; set; }
        /// <summary>
        /// 次卡卡号
        /// </summary>
        [StringLength( 6, ErrorMessage = "次卡卡号输入过长，不能超过6位" )]
        public virtual string SERVICE_NO { get; set; }
        /// <summary>
        /// 维修类型
        /// </summary>
        [Required(ErrorMessage = "维修类型不能为空")]
        public virtual long MAINTAIN_CLASS { get; set; }
        /// <summary>
        /// 维修子类型
        /// </summary>
        public virtual long? MAINTAIN_SUBCLASS { get; set; }
        /// <summary>
        /// 价格系数
        /// </summary>
        public virtual decimal? PRICE_PARA { get; set; }
        /// <summary>
        /// 商品一级类别
        /// </summary>
        public virtual long? GOODS_LARGECLASS { get; set; }
        /// <summary>
        /// 商品二级类别
        /// </summary>
        public virtual long? GOODS_INCLASS { get; set; }
        /// <summary>
        /// 商品三级类别
        /// </summary>
        public virtual long? GOODS_SMALLCLASS { get; set; }
        /// <summary>
        /// 来源机构代码
        /// </summary>
        [StringLength( 20, ErrorMessage = "来源机构代码输入过长，不能超过20位" )]
        public virtual string FROM_ORG_NO { get; set; }
        /// <summary>
        /// 技师编码
        /// </summary>
        [StringLength( 100, ErrorMessage = "技师编码输入过长，不能超过100位" )]
        public virtual string ENGINEER_ID { get; set; }
        /// <summary>
        /// 技师名称
        /// </summary>
        [StringLength( 30, ErrorMessage = "技师名称输入过长，不能超过30位" )]
        public virtual string ENGINEER_NAME { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public virtual decimal? REL_QTY { get; set; }
        /// <summary>
        /// 是否商品升级
        /// </summary>
        public virtual long? IS_SP_UPGRADE { get; set; }
        /// <summary>
        /// 施工工时
        /// </summary>
        [StringLength( 40, ErrorMessage = "施工工时输入过长，不能超过40位" )]
        public virtual string WORK_MH { get; set; }
        /// <summary>
        /// 派工组
        /// </summary>
        [StringLength( 40, ErrorMessage = "派工组输入过长，不能超过40位" )]
        public virtual string ASSGIN_TEAM { get; set; }
        /// <summary>
        /// 派工工位
        /// </summary>
        [StringLength( 40, ErrorMessage = "派工工位输入过长，不能超过40位" )]
        public virtual string WORK_STATION { get; set; }
        /// <summary>
        /// 标准工时
        /// </summary>
        public virtual double? STD_WORK_TIME { get; set; }
        /// <summary>
        /// 次卡支付数量
        /// </summary>
        public virtual long? S_PAY_QTY { get; set; }
        /// <summary>
        /// 套餐次卡
        /// </summary>
        public virtual long? IS_COMBO_SERVICE { get; set; }
        /// <summary>
        /// 抵扣券号
        /// </summary>
        [StringLength( 50, ErrorMessage = "抵扣券号输入过长，不能超过50位" )]
        public virtual string DC_COUPON { get; set; }
        /// <summary>
        /// 是否增项
        /// </summary>
        [Required(ErrorMessage = "是否增项不能为空")]
        public virtual long IS_ADD { get; set; }
        /// <summary>
        /// 工单明细顺序号
        /// </summary>
        [Required(ErrorMessage = "工单明细顺序号不能为空")]
        public virtual long ROW_SN { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        public virtual long? DATA_FLAG { get; set; }
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