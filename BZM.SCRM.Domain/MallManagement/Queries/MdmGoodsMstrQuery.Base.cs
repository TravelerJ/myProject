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
    public partial class MdmGoodsMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public long GOODS_ID { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Display(Name="商品编号")]
        public string GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name="商品名称")]
        public string GOODS_NAME { get; set; }
        /// <summary>
        /// 商品打印名称
        /// </summary>
        [Display(Name="商品打印名称")]
        public string GOODS_PRINT_NAME { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [Display(Name="商品类型")]
        public long GOODS_TYPE { get; set; }
        /// <summary>
        /// 大类
        /// </summary>
        [Display(Name="大类")]
        public long GOODS_LARGECLASS { get; set; }
        /// <summary>
        /// 中类
        /// </summary>
        [Display(Name="中类")]
        public long GOODS_INCLASS { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        [Display(Name="小类")]
        public long? GOODS_SMALLCLASS { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        [Display(Name="子类")]
        public long? GOODS_SUBCLASS { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        [Display(Name="商品等级")]
        public long? GOODS_LEVEL { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [Display(Name="产品编号")]
        public string PRODUCT_NO { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [Display(Name="产品名称")]
        public string PRODUCT_NAME { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        [Display(Name="条形码")]
        public string BARCODE { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [Display(Name="适用品牌")]
        public string CAR_BRAND_ID { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [Display(Name="适用品牌")]
        public string CAR_BRAND_DESC { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [Display(Name="适用车系")]
        public string CAR_CLASS_ID { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [Display(Name="适用车系")]
        public string CAR_CLASS_DESC { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [Display(Name="适用车型")]
        public string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [Display(Name="适用车型")]
        public string CAR_TYPE_DESC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Display(Name="单位")]
        public string UNIT { get; set; }
        /// <summary>
        /// 子单位值
        /// </summary>
        [Display(Name="子单位值")]
        public long? SUBUNITVALUE { get; set; }
        /// <summary>
        /// 子单位启用
        /// </summary>
        [Display(Name="子单位启用")]
        public long? SUBUNITENABLED { get; set; }
        /// <summary>
        /// 子单位
        /// </summary>
        [Display(Name="子单位")]
        public string SUBUNIT { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [Display(Name="记忆码")]
        public string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name="规格")]
        public string GOODS_SPEC { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Display(Name="型号")]
        public string GOODS_MODEL { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        [Display(Name="材质")]
        public string GOODS_MATERIAL { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [Display(Name="有效期")]
        public long? GOODS_SHELFLIFE { get; set; }
        /// <summary>
        /// 原产地
        /// </summary>
        [Display(Name="原产地")]
        public string MADE_IN { get; set; }
        /// <summary>
        /// 是否临时商品
        /// </summary>
        [Display(Name="是否临时商品")]
        public long? IS_TEMP { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public long GOODS_STATUS { get; set; }
        /// <summary>
        /// 安全库存设置
        /// </summary>
        [Display(Name="安全库存设置")]
        public long? GOODS_SS_NEED { get; set; }
        /// <summary>
        /// 适用机构
        /// </summary>
        [Display(Name="适用机构")]
        public string GOODS_ORG_NO { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        [Display(Name="商品备注")]
        public string GOODS_RMK { get; set; }
        /// <summary>
        /// 是否三包
        /// </summary>
        [Display(Name="是否三包")]
        public long? IS_THREE_COMMITMENTS { get; set; }
        /// <summary>
        /// 商品适用门店ID
        /// </summary>
        [Display(Name="商品适用门店ID")]
        public string LIMITED_STORE_ID { get; set; }
        /// <summary>
        /// 商品适用门店名称
        /// </summary>
        [Display(Name="商品适用门店名称")]
        public string LIMITED_STORE_NAME { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [Display(Name="权限")]
        public string DATARIGHT { get; set; }
        /// <summary>
        /// 标准工时
        /// </summary>
        [Display(Name="标准工时")]
        public double? ST_WORK_TIME { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        [Display(Name="采购属性")]
        public string GOODS_PUR_ATTR { get; set; }
        /// <summary>
        /// 商品品质
        /// </summary>
        [Display(Name="商品品质")]
        public string GOODS_QA { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        [Display(Name="商品品牌")]
        public string GOODS_BRAND { get; set; }
        /// <summary>
        /// 商品性能
        /// </summary>
        [Display(Name="商品性能")]
        public string GOODS_FUNC { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        [Display(Name="是否套餐")]
        public long? IS_COMBO { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        [Display(Name="采购属性")]
        public long? PUR_ATTR { get; set; }
        /// <summary>
        /// 精品属性
        /// </summary>
        [Display(Name="精品属性")]
        public string GOODS_PLM_ATTR1 { get; set; }
        /// <summary>
        /// 商品属性(SP-商品/CZ-储值卡/ZC-整车)
        /// </summary>
        [Display(Name="商品属性(SP-商品/CZ-储值卡/ZC-整车)")]
        public string GOODS_ATTR { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name="创建日期")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name="更新日期")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        [Display(Name="商品简介")]
        public string GOODS_CONTENT { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        [Display(Name="上架时间")]
        public DateTime? GOODS_ONSALE_DATE { get; set; }
        /// <summary>
        /// 下架时间
        /// </summary>
        [Display(Name="下架时间")]
        public DateTime? GOODS_OFFSALE_DATE { get; set; }
        /// <summary>
        /// 是否可积分兑换(1-可/0-否)
        /// </summary>
        [Display(Name="是否可积分兑换(1-可/0-否)")]
        public long? IS_SCORE_GET { get; set; }
        /// <summary>
        /// 商品SKU序号=1的属性ID
        /// </summary>
        [Display(Name="商品SKU序号=1的属性ID")]
        public string SKU_PROPERTY_ID1 { get; set; }
        /// <summary>
        /// 商品SKU序号=1的属性值
        /// </summary>
        [Display(Name="商品SKU序号=1的属性值")]
        public string SKU_PROPERTY_VALUE1 { get; set; }
        /// <summary>
        /// 商品SKU序号=2的属性ID
        /// </summary>
        [Display(Name="商品SKU序号=2的属性ID")]
        public string SKU_PROPERTY_ID2 { get; set; }
        /// <summary>
        /// 商品SKU序号=2的属性值
        /// </summary>
        [Display(Name="商品SKU序号=2的属性值")]
        public string SKU_PROPERTY_VALUE2 { get; set; }
        /// <summary>
        /// 商品SKU序号=3的属性ID
        /// </summary>
        [Display(Name="商品SKU序号=3的属性ID")]
        public string SKU_PROPERTY_ID3 { get; set; }
        /// <summary>
        /// 商品SKU序号=3的属性值
        /// </summary>
        [Display(Name="商品SKU序号=3的属性值")]
        public string SKU_PROPERTY_VALUE3 { get; set; }
        /// <summary>
        /// 商品SKU序号=4的属性ID
        /// </summary>
        [Display(Name="商品SKU序号=4的属性ID")]
        public string SKU_PROPERTY_ID4 { get; set; }
        /// <summary>
        /// 商品SKU序号=4的属性值
        /// </summary>
        [Display(Name="商品SKU序号=4的属性值")]
        public string SKU_PROPERTY_VALUE4 { get; set; }
        /// <summary>
        /// 商品SKU序号=5的属性ID
        /// </summary>
        [Display(Name="商品SKU序号=5的属性ID")]
        public string SKU_PROPERTY_ID5 { get; set; }
        /// <summary>
        /// 商品SKU序号=5的属性值
        /// </summary>
        [Display(Name="商品SKU序号=5的属性值")]
        public string SKU_PROPERTY_VALUE5 { get; set; }
        /// <summary>
        /// 平安保险项目ID
        /// </summary>
        [Display(Name="平安保险项目ID")]
        public string OUT_SYS_ID_PINGAN { get; set; }
        /// <summary>
        /// 太平洋保险项目ID
        /// </summary>
        [Display(Name="太平洋保险项目ID")]
        public string OUT_SYS_ID_CPIC { get; set; }
        /// <summary>
        /// 上汽阿里项目ID
        /// </summary>
        [Display(Name="上汽阿里项目ID")]
        public string OUT_SYS_ID_SHANGQI { get; set; }
        /// <summary>
        /// 总部项目ID
        /// </summary>
        [Display(Name="总部项目ID")]
        public string OUT_SYS_ID_PAZB { get; set; }
        /// <summary>
        /// 商品排序编号
        /// </summary>
        [Display(Name="商品排序编号")]
        public long? GOODS_SORT_NO { get; set; }
        /// <summary>
        /// GL编号
        /// </summary>
        [Display(Name="GL编号")]
        public string GL_ID { get; set; }
        /// <summary>
        /// 是否封面推荐
        /// </summary>
        [Display(Name="是否封面推荐")]
        public long? SHOW_IN_LIST { get; set; }
        /// <summary>
        /// 促销属性(TJ-特价)
        /// </summary>
        [Display(Name="促销属性(TJ-特价)")]
        public string PROMOTION_ATTR { get; set; }
        /// <summary>
        /// 是否秒杀(0否，1是)
        /// </summary>
        [Display(Name="是否秒杀(0否，1是)")]
        public byte? SP_FLAG { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name="开始时间")]
        public DateTime? SP_SDATE { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        [Display(Name="截止时间")]
        public DateTime? SP_EDATE { get; set; }
        /// <summary>
        /// 秒杀数量
        /// </summary>
        [Display(Name="秒杀数量")]
        public double? SP_QTY { get; set; }
        /// <summary>
        /// 秒杀价
        /// </summary>
        [Display(Name="秒杀价")]
        public double? SP_PRICE { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}