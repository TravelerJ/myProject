using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    /// (旧)商品主表
    /// </summary>
    public partial class MdmGoodsMstr : Entity<long> {       

        /// <summary>
        /// 商品编号
        /// </summary>
        [Required(ErrorMessage = "商品编号不能为空")]
        [StringLength( 50, ErrorMessage = "商品编号输入过长，不能超过50位" )]
        public virtual string GOODS_NO { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        [StringLength( 200, ErrorMessage = "商品名称输入过长，不能超过200位" )]
        public virtual string GOODS_NAME { get; set; }
        /// <summary>
        /// 商品打印名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品打印名称输入过长，不能超过100位" )]
        public virtual string GOODS_PRINT_NAME { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [Required(ErrorMessage = "商品类型不能为空")]
        public virtual long GOODS_TYPE { get; set; }
        /// <summary>
        /// 大类
        /// </summary>
        [Required(ErrorMessage = "大类不能为空")]
        public virtual long GOODS_LARGECLASS { get; set; }
        /// <summary>
        /// 中类
        /// </summary>
        [Required(ErrorMessage = "中类不能为空")]
        public virtual long GOODS_INCLASS { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        public virtual long? GOODS_SMALLCLASS { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        public virtual long? GOODS_SUBCLASS { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        public virtual long? GOODS_LEVEL { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "产品编号输入过长，不能超过50位" )]
        public virtual string PRODUCT_NO { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "产品名称输入过长，不能超过100位" )]
        public virtual string PRODUCT_NAME { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        [StringLength( 255, ErrorMessage = "条形码输入过长，不能超过255位" )]
        public virtual string BARCODE { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "适用品牌输入过长，不能超过100位" )]
        public virtual string CAR_BRAND_ID { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [StringLength( 500, ErrorMessage = "适用品牌输入过长，不能超过500位" )]
        public virtual string CAR_BRAND_DESC { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [StringLength( 100, ErrorMessage = "适用车系输入过长，不能超过100位" )]
        public virtual string CAR_CLASS_ID { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [StringLength( 500, ErrorMessage = "适用车系输入过长，不能超过500位" )]
        public virtual string CAR_CLASS_DESC { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [StringLength( 4000, ErrorMessage = "适用车型输入过长，不能超过4000位" )]
        public virtual string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [StringLength( 4000, ErrorMessage = "适用车型输入过长，不能超过4000位" )]
        public virtual string CAR_TYPE_DESC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [StringLength( 10, ErrorMessage = "单位输入过长，不能超过10位" )]
        public virtual string UNIT { get; set; }
        /// <summary>
        /// 子单位值
        /// </summary>
        public virtual long? SUBUNITVALUE { get; set; }
        /// <summary>
        /// 子单位启用
        /// </summary>
        public virtual long? SUBUNITENABLED { get; set; }
        /// <summary>
        /// 子单位
        /// </summary>
        [StringLength( 50, ErrorMessage = "子单位输入过长，不能超过50位" )]
        public virtual string SUBUNIT { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [StringLength( 50, ErrorMessage = "记忆码输入过长，不能超过50位" )]
        public virtual string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [StringLength( 40, ErrorMessage = "规格输入过长，不能超过40位" )]
        public virtual string GOODS_SPEC { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [StringLength( 40, ErrorMessage = "型号输入过长，不能超过40位" )]
        public virtual string GOODS_MODEL { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        [StringLength( 40, ErrorMessage = "材质输入过长，不能超过40位" )]
        public virtual string GOODS_MATERIAL { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public virtual long? GOODS_SHELFLIFE { get; set; }
        /// <summary>
        /// 原产地
        /// </summary>
        [StringLength( 40, ErrorMessage = "原产地输入过长，不能超过40位" )]
        public virtual string MADE_IN { get; set; }
        /// <summary>
        /// 是否临时商品
        /// </summary>
        public virtual long? IS_TEMP { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public virtual long GOODS_STATUS { get; set; }
        /// <summary>
        /// 安全库存设置
        /// </summary>
        public virtual long? GOODS_SS_NEED { get; set; }
        /// <summary>
        /// 适用机构
        /// </summary>
        [StringLength( 20, ErrorMessage = "适用机构输入过长，不能超过20位" )]
        public virtual string GOODS_ORG_NO { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品备注输入过长，不能超过100位" )]
        public virtual string GOODS_RMK { get; set; }
        /// <summary>
        /// 是否三包
        /// </summary>
        public virtual long? IS_THREE_COMMITMENTS { get; set; }
        /// <summary>
        /// 商品适用门店ID
        /// </summary>
        [StringLength( 4000, ErrorMessage = "商品适用门店ID输入过长，不能超过4000位" )]
        public virtual string LIMITED_STORE_ID { get; set; }
        /// <summary>
        /// 商品适用门店名称
        /// </summary>
        [StringLength( 4000, ErrorMessage = "商品适用门店名称输入过长，不能超过4000位" )]
        public virtual string LIMITED_STORE_NAME { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [StringLength( 200, ErrorMessage = "权限输入过长，不能超过200位" )]
        public virtual string DATARIGHT { get; set; }
        /// <summary>
        /// 标准工时
        /// </summary>
        public virtual double? ST_WORK_TIME { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "采购属性输入过长，不能超过50位" )]
        public virtual string GOODS_PUR_ATTR { get; set; }
        /// <summary>
        /// 商品品质
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品品质输入过长，不能超过50位" )]
        public virtual string GOODS_QA { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品品牌输入过长，不能超过100位" )]
        public virtual string GOODS_BRAND { get; set; }
        /// <summary>
        /// 商品性能
        /// </summary>
        [StringLength( 200, ErrorMessage = "商品性能输入过长，不能超过200位" )]
        public virtual string GOODS_FUNC { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        public virtual long? IS_COMBO { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        public virtual long? PUR_ATTR { get; set; }
        /// <summary>
        /// 精品属性
        /// </summary>
        [StringLength( 20, ErrorMessage = "精品属性输入过长，不能超过20位" )]
        public virtual string GOODS_PLM_ATTR1 { get; set; }
        /// <summary>
        /// 商品属性(SP-商品/CZ-储值卡/ZC-整车)
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品属性(SP-商品/CZ-储值卡/ZC-整车)输入过长，不能超过100位" )]
        public virtual string GOODS_ATTR { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required(ErrorMessage = "创建日期不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Required(ErrorMessage = "更新人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Required(ErrorMessage = "更新日期不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        [StringLength( 4000, ErrorMessage = "商品简介输入过长，不能超过4000位" )]
        public virtual string GOODS_CONTENT { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public virtual DateTime? GOODS_ONSALE_DATE { get; set; }
        /// <summary>
        /// 下架时间
        /// </summary>
        public virtual DateTime? GOODS_OFFSALE_DATE { get; set; }
        /// <summary>
        /// 是否可积分兑换(1-可/0-否)
        /// </summary>
        public virtual long? IS_SCORE_GET { get; set; }
        /// <summary>
        /// 商品SKU序号=1的属性ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品SKU序号=1的属性ID输入过长，不能超过50位" )]
        public virtual string SKU_PROPERTY_ID1 { get; set; }
        /// <summary>
        /// 商品SKU序号=1的属性值
        /// </summary>
        [StringLength( 500, ErrorMessage = "商品SKU序号=1的属性值输入过长，不能超过500位" )]
        public virtual string SKU_PROPERTY_VALUE1 { get; set; }
        /// <summary>
        /// 商品SKU序号=2的属性ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品SKU序号=2的属性ID输入过长，不能超过50位" )]
        public virtual string SKU_PROPERTY_ID2 { get; set; }
        /// <summary>
        /// 商品SKU序号=2的属性值
        /// </summary>
        [StringLength( 500, ErrorMessage = "商品SKU序号=2的属性值输入过长，不能超过500位" )]
        public virtual string SKU_PROPERTY_VALUE2 { get; set; }
        /// <summary>
        /// 商品SKU序号=3的属性ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品SKU序号=3的属性ID输入过长，不能超过50位" )]
        public virtual string SKU_PROPERTY_ID3 { get; set; }
        /// <summary>
        /// 商品SKU序号=3的属性值
        /// </summary>
        [StringLength( 500, ErrorMessage = "商品SKU序号=3的属性值输入过长，不能超过500位" )]
        public virtual string SKU_PROPERTY_VALUE3 { get; set; }
        /// <summary>
        /// 商品SKU序号=4的属性ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品SKU序号=4的属性ID输入过长，不能超过50位" )]
        public virtual string SKU_PROPERTY_ID4 { get; set; }
        /// <summary>
        /// 商品SKU序号=4的属性值
        /// </summary>
        [StringLength( 500, ErrorMessage = "商品SKU序号=4的属性值输入过长，不能超过500位" )]
        public virtual string SKU_PROPERTY_VALUE4 { get; set; }
        /// <summary>
        /// 商品SKU序号=5的属性ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品SKU序号=5的属性ID输入过长，不能超过50位" )]
        public virtual string SKU_PROPERTY_ID5 { get; set; }
        /// <summary>
        /// 商品SKU序号=5的属性值
        /// </summary>
        [StringLength( 500, ErrorMessage = "商品SKU序号=5的属性值输入过长，不能超过500位" )]
        public virtual string SKU_PROPERTY_VALUE5 { get; set; }
        /// <summary>
        /// 平安保险项目ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "平安保险项目ID输入过长，不能超过50位" )]
        public virtual string OUT_SYS_ID_PINGAN { get; set; }
        /// <summary>
        /// 太平洋保险项目ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "太平洋保险项目ID输入过长，不能超过50位" )]
        public virtual string OUT_SYS_ID_CPIC { get; set; }
        /// <summary>
        /// 上汽阿里项目ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "上汽阿里项目ID输入过长，不能超过50位" )]
        public virtual string OUT_SYS_ID_SHANGQI { get; set; }
        /// <summary>
        /// 总部项目ID
        /// </summary>
        [StringLength( 100, ErrorMessage = "总部项目ID输入过长，不能超过100位" )]
        public virtual string OUT_SYS_ID_PAZB { get; set; }
        /// <summary>
        /// 商品排序编号
        /// </summary>
        public virtual long? GOODS_SORT_NO { get; set; }
        /// <summary>
        /// GL编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "GL编号输入过长，不能超过50位" )]
        public virtual string GL_ID { get; set; }
        /// <summary>
        /// 是否封面推荐
        /// </summary>
        public virtual long? SHOW_IN_LIST { get; set; }
        /// <summary>
        /// 促销属性(TJ-特价)
        /// </summary>
        [StringLength( 10, ErrorMessage = "促销属性(TJ-特价)输入过长，不能超过10位" )]
        public virtual string PROMOTION_ATTR { get; set; }
        /// <summary>
        /// 是否秒杀(0否，1是)
        /// </summary>
        public virtual byte? SP_FLAG { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? SP_SDATE { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public virtual DateTime? SP_EDATE { get; set; }
        /// <summary>
        /// 秒杀数量
        /// </summary>
        public virtual double? SP_QTY { get; set; }
        /// <summary>
        /// 秒杀价
        /// </summary>
        public virtual double? SP_PRICE { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }

        /// <summary>
        /// 属性图片
        /// </summary>
        [StringLength(50, ErrorMessage = "属性图片输入过长，不能超过200位")]
        public virtual string PROPERTY_IMAGE { get; set; }
    }
}