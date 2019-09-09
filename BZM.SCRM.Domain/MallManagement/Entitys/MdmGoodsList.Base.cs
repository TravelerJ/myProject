using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    ///  商品信息主表
    /// </summary>
    public partial class MdmGoodsList : Entity<string> {       

        /// <summary>
        /// 主商品编号
        /// </summary>
        [Required(ErrorMessage = "主商品编号不能为空")]
        [StringLength( 50, ErrorMessage = "主商品编号输入过长，不能超过50位" )]
        public virtual string GL_NO { get; set; }
        /// <summary>
        /// 主商品名称
        /// </summary>
        [Required(ErrorMessage = "主商品名称不能为空")]
        [StringLength( 200, ErrorMessage = "主商品名称输入过长，不能超过200位" )]
        public virtual string GL_NAME { get; set; }
        /// <summary>
        /// 主商品打印名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "主商品打印名称输入过长，不能超过100位" )]
        public virtual string GL_PRINT_NAME { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [Required(ErrorMessage = "商品类型不能为空")]
        public virtual long GL_TYPE { get; set; }
        /// <summary>
        /// 大类
        /// </summary>
        [Required(ErrorMessage = "大类不能为空")]
        public virtual long GL_LARGECLASS { get; set; }
        /// <summary>
        /// 中类
        /// </summary>
        [Required(ErrorMessage = "中类不能为空")]
        public virtual long GL_INCLASS { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        public virtual long? GL_SMALLCLASS { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        public virtual long? GL_SUBCLASS { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        public virtual long? GL_LEVEL { get; set; }
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
        public virtual string GL_UNIT { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [StringLength( 50, ErrorMessage = "记忆码输入过长，不能超过50位" )]
        public virtual string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [StringLength( 40, ErrorMessage = "规格输入过长，不能超过40位" )]
        public virtual string GL_SPEC { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [StringLength( 40, ErrorMessage = "型号输入过长，不能超过40位" )]
        public virtual string GL_MODEL { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        [StringLength( 40, ErrorMessage = "材质输入过长，不能超过40位" )]
        public virtual string GL_MATERIAL { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public virtual long? GL_SHELFLIFE { get; set; }
        /// <summary>
        /// 原产地
        /// </summary>
        [StringLength( 40, ErrorMessage = "原产地输入过长，不能超过40位" )]
        public virtual string MADE_IN { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public virtual long GL_STATUS { get; set; }
        /// <summary>
        /// 适用机构
        /// </summary>
        [StringLength( 50, ErrorMessage = "适用机构输入过长，不能超过50位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品备注输入过长，不能超过100位" )]
        public virtual string GL_RMK { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        [StringLength( 500, ErrorMessage = "属性输入过长，不能超过500位" )]
        public virtual string GL_PROPERTY { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public virtual long? COMMENT_NUM { get; set; }
        /// <summary>
        /// 热度
        /// </summary>
        public virtual long? HIT_NUM { get; set; }
        /// <summary>
        /// 促销信息
        /// </summary>
        [StringLength( 1000, ErrorMessage = "促销信息输入过长，不能超过1000位" )]
        public virtual string PROMOTION_INFO { get; set; }
        /// <summary>
        /// 主商品描述
        /// </summary>
        [NotMapped]
        public virtual object GL_DESC { get; set; }
        /// <summary>
        /// 主商品规格描述
        /// </summary>
        [NotMapped]
        public virtual object GL_SPEC_DESC { get; set; }
        /// <summary>
        /// 主商品包装描述
        /// </summary>
        [NotMapped]
        public virtual object GL_PACKAGE_DESC { get; set; }
        /// <summary>
        /// 主商品描述(手机版)
        /// </summary>
        [NotMapped]
        public virtual object GL_DESC_M { get; set; }
        /// <summary>
        /// 主商品规格描述(手机版)
        /// </summary>
        [NotMapped]
        public virtual object GL_SPEC_DESC_M { get; set; }
        /// <summary>
        /// 主商品包装描述(手机版)
        /// </summary>
        [NotMapped]
        public virtual object GL_PACKAGE_DESC_M { get; set; }
        /// <summary>
        /// 主商品售后说明
        /// </summary>
        [NotMapped]
        public virtual object GL_WARRANTY_DESC { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "采购属性输入过长，不能超过50位" )]
        public virtual string GL_PUR_ATTR { get; set; }
        /// <summary>
        /// 商品品质
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品品质输入过长，不能超过50位" )]
        public virtual string GL_QA { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品品牌输入过长，不能超过100位" )]
        public virtual string GL_BRAND { get; set; }
        /// <summary>
        /// 商品性能
        /// </summary>
        [StringLength( 200, ErrorMessage = "商品性能输入过长，不能超过200位" )]
        public virtual string GL_FUNC { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        public virtual long? IS_COMBO { get; set; }
        /// <summary>
        /// 商品属性(SP-商品/CZ-储值卡/ZC-整车)
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品属性(SP-商品/CZ-储值卡/ZC-整车)输入过长，不能超过100位" )]
        public virtual string GOODS_ATTR { get; set; }
        /// <summary>
        /// 物流提供方
        /// </summary>
        [StringLength( 100, ErrorMessage = "物流提供方输入过长，不能超过100位" )]
        public virtual string LGS_SP { get; set; }
        /// <summary>
        /// 物流提供方编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "物流提供方编号输入过长，不能超过50位" )]
        public virtual string LGS_SP_NO { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        [Required(ErrorMessage = "起始日期不能为空")]
        public virtual DateTime GL_SDATE { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        [Required(ErrorMessage = "截止日期不能为空")]
        public virtual DateTime GL_EDATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 2000, ErrorMessage = "未定义字段输入过长，不能超过2000位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 一级类别编码(erp)
        /// </summary>
        [StringLength( 50, ErrorMessage = "一级类别编码(erp)输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 一级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "一级类别名称输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 二级类别编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "二级类别编码输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 二级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "二级类别名称输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 三级类别编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "三级类别编码输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 三级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "三级类别名称输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [StringLength( 50, ErrorMessage = "零售价输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF10 { get; set; }
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
        /// 促销属性(TJ-特价)
        /// </summary>
        [StringLength( 10, ErrorMessage = "促销属性(TJ-特价)输入过长，不能超过10位" )]
        public virtual string PROMOTION_ATTR { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public virtual double? MEMBER_PRICE { get; set; }
        /// <summary>
        /// 会员积分
        /// </summary>
        public virtual long? MENBER_POINTS { get; set; }
        /// <summary>
        /// 是否启用(1,启用,0.禁用)
        /// </summary>
        public virtual byte? ENABLE_MP { get; set; }
        /// <summary>
        /// 商品销量
        /// </summary>
        public virtual decimal? GOODS_SALES { get; set; }
        /// <summary>
        /// 是否erp商品(1:是,0:否)
        /// </summary>
        public virtual byte? IS_ERPGOODS { get; set; }
    }
}