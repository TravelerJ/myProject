using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmGoodsListDto : EntityDto<string> {    

        /// <summary>
        /// 主商品编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "主商品编号输入过长，不能超过50位" )]         
        [Display( Name = "主商品编号" )]        
        public string GL_NO { get; set; }
        /// <summary>
        /// 主商品名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "主商品名称输入过长，不能超过200位" )]         
        [Display( Name = "主商品名称" )]        
        public string GL_NAME { get; set; }
        /// <summary>
        /// 主商品打印名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "主商品打印名称输入过长，不能超过100位" )]         
        [Display( Name = "主商品打印名称" )]        
        public string GL_PRINT_NAME { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
                 
        [Display( Name = "商品类型" )]        
        public long GL_TYPE { get; set; }
        /// <summary>
        /// 大类
        /// </summary>
                 
        [Display( Name = "大类" )]        
        public long GL_LARGECLASS { get; set; }
        /// <summary>
        /// 中类
        /// </summary>
                 
        [Display( Name = "中类" )]        
        public long GL_INCLASS { get; set; }
        /// <summary>
        /// 小类
        /// </summary>
        [Display( Name = "小类" )]        
        public long? GL_SMALLCLASS { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        [Display( Name = "子类" )]        
        public long? GL_SUBCLASS { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        [Display( Name = "商品等级" )]        
        public long? GL_LEVEL { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "适用品牌输入过长，不能超过100位" )]         
        [Display( Name = "适用品牌" )]        
        public string CAR_BRAND_ID { get; set; }
        /// <summary>
        /// 适用品牌
        /// </summary>
        [StringLength( 500, ErrorMessage = "适用品牌输入过长，不能超过500位" )]         
        [Display( Name = "适用品牌" )]        
        public string CAR_BRAND_DESC { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [StringLength( 100, ErrorMessage = "适用车系输入过长，不能超过100位" )]         
        [Display( Name = "适用车系" )]        
        public string CAR_CLASS_ID { get; set; }
        /// <summary>
        /// 适用车系
        /// </summary>
        [StringLength( 500, ErrorMessage = "适用车系输入过长，不能超过500位" )]         
        [Display( Name = "适用车系" )]        
        public string CAR_CLASS_DESC { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [StringLength( 4000, ErrorMessage = "适用车型输入过长，不能超过4000位" )]         
        [Display( Name = "适用车型" )]        
        public string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        [StringLength( 4000, ErrorMessage = "适用车型输入过长，不能超过4000位" )]         
        [Display( Name = "适用车型" )]        
        public string CAR_TYPE_DESC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [StringLength( 10, ErrorMessage = "单位输入过长，不能超过10位" )]         
        [Display( Name = "单位" )]        
        public string GL_UNIT { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [StringLength( 50, ErrorMessage = "记忆码输入过长，不能超过50位" )]         
        [Display( Name = "记忆码" )]        
        public string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [StringLength( 40, ErrorMessage = "规格输入过长，不能超过40位" )]         
        [Display( Name = "规格" )]        
        public string GL_SPEC { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [StringLength( 40, ErrorMessage = "型号输入过长，不能超过40位" )]         
        [Display( Name = "型号" )]        
        public string GL_MODEL { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        [StringLength( 40, ErrorMessage = "材质输入过长，不能超过40位" )]         
        [Display( Name = "材质" )]        
        public string GL_MATERIAL { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [Display( Name = "有效期" )]        
        public long? GL_SHELFLIFE { get; set; }
        /// <summary>
        /// 原产地
        /// </summary>
        [StringLength( 40, ErrorMessage = "原产地输入过长，不能超过40位" )]         
        [Display( Name = "原产地" )]        
        public string MADE_IN { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
                 
        [Display( Name = "状态" )]        
        public long GL_STATUS { get; set; }
        /// <summary>
        /// 适用机构
        /// </summary>
        [StringLength( 50, ErrorMessage = "适用机构输入过长，不能超过50位" )]         
        [Display( Name = "适用机构" )]        
        public string BU_NO { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品备注输入过长，不能超过100位" )]         
        [Display( Name = "商品备注" )]        
        public string GL_RMK { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        [StringLength( 500, ErrorMessage = "属性输入过长，不能超过500位" )]         
        [Display( Name = "属性" )]        
        public string GL_PROPERTY { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        [Display( Name = "评论数" )]        
        public long? COMMENT_NUM { get; set; }
        /// <summary>
        /// 热度
        /// </summary>
        [Display( Name = "热度" )]        
        public long? HIT_NUM { get; set; }
        /// <summary>
        /// 促销信息
        /// </summary>
        [StringLength( 1000, ErrorMessage = "促销信息输入过长，不能超过1000位" )]         
        [Display( Name = "促销信息" )]        
        public string PROMOTION_INFO { get; set; }
        /// <summary>
        /// 主商品描述
        /// </summary>
        [Display( Name = "主商品描述" )]        
        public object GL_DESC { get; set; }
        /// <summary>
        /// 主商品规格描述
        /// </summary>
        [Display( Name = "主商品规格描述" )]        
        public object GL_SPEC_DESC { get; set; }
        /// <summary>
        /// 主商品包装描述
        /// </summary>
        [Display( Name = "主商品包装描述" )]        
        public object GL_PACKAGE_DESC { get; set; }
        /// <summary>
        /// 主商品描述(手机版)
        /// </summary>
        [Display( Name = "主商品描述(手机版)" )]        
        public object GL_DESC_M { get; set; }
        /// <summary>
        /// 主商品规格描述(手机版)
        /// </summary>
        [Display( Name = "主商品规格描述(手机版)" )]        
        public object GL_SPEC_DESC_M { get; set; }
        /// <summary>
        /// 主商品包装描述(手机版)
        /// </summary>
        [Display( Name = "主商品包装描述(手机版)" )]        
        public object GL_PACKAGE_DESC_M { get; set; }
        /// <summary>
        /// 主商品售后说明
        /// </summary>
        [Display( Name = "主商品售后说明" )]        
        public object GL_WARRANTY_DESC { get; set; }
        /// <summary>
        /// 采购属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "采购属性输入过长，不能超过50位" )]         
        [Display( Name = "采购属性" )]        
        public string GL_PUR_ATTR { get; set; }
        /// <summary>
        /// 商品品质
        /// </summary>
        [StringLength( 50, ErrorMessage = "商品品质输入过长，不能超过50位" )]         
        [Display( Name = "商品品质" )]        
        public string GL_QA { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品品牌输入过长，不能超过100位" )]         
        [Display( Name = "商品品牌" )]        
        public string GL_BRAND { get; set; }
        /// <summary>
        /// 商品性能
        /// </summary>
        [StringLength( 200, ErrorMessage = "商品性能输入过长，不能超过200位" )]         
        [Display( Name = "商品性能" )]        
        public string GL_FUNC { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        [Display( Name = "是否套餐" )]        
        public long? IS_COMBO { get; set; }
        /// <summary>
        /// 商品属性(SP-商品/CZ-储值卡/ZC-整车)
        /// </summary>
        [StringLength( 100, ErrorMessage = "商品属性(SP-商品/CZ-储值卡/ZC-整车)输入过长，不能超过100位" )]         
        [Display( Name = "商品属性(SP-商品/CZ-储值卡/ZC-整车)" )]        
        public string GOODS_ATTR { get; set; }
        /// <summary>
        /// 物流提供方
        /// </summary>
        [StringLength( 100, ErrorMessage = "物流提供方输入过长，不能超过100位" )]         
        [Display( Name = "物流提供方" )]        
        public string LGS_SP { get; set; }
        /// <summary>
        /// 物流提供方编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "物流提供方编号输入过长，不能超过50位" )]         
        [Display( Name = "物流提供方编号" )]        
        public string LGS_SP_NO { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
                 
        [Display( Name = "起始日期" )]        
        public DateTime GL_SDATE { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
                 
        [Display( Name = "截止日期" )]        
        public DateTime GL_EDATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 2000, ErrorMessage = "未定义字段输入过长，不能超过2000位" )]         
        [Display( Name = "未定义字段" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 一级类别编码(erp)
        /// </summary>
        [StringLength( 50, ErrorMessage = "一级类别编码(erp)输入过长，不能超过50位" )]         
        [Display( Name = "一级类别编码(erp)" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 一级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "一级类别名称输入过长，不能超过50位" )]         
        [Display( Name = "一级类别名称" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 二级类别编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "二级类别编码输入过长，不能超过50位" )]         
        [Display( Name = "二级类别编码" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 二级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "二级类别名称输入过长，不能超过50位" )]         
        [Display( Name = "二级类别名称" )]        
        public string UDF6 { get; set; }
        /// <summary>
        /// 三级类别编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "三级类别编码输入过长，不能超过50位" )]         
        [Display( Name = "三级类别编码" )]        
        public string UDF7 { get; set; }
        /// <summary>
        /// 三级类别名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "三级类别名称输入过长，不能超过50位" )]         
        [Display( Name = "三级类别名称" )]        
        public string UDF8 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [StringLength( 50, ErrorMessage = "零售价输入过长，不能超过50位" )]         
        [Display( Name = "零售价" )]        
        public string UDF9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]         
        [Display( Name = "Udf10" )]        
        public string UDF10 { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
                 
        [Display( Name = "创建人" )]        
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
                 
        [Display( Name = "创建日期" )]        
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
                 
        [Display( Name = "更新人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
                 
        [Display( Name = "更新日期" )]        
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构代码" )]        
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 促销属性(TJ-特价)
        /// </summary>
        [StringLength( 10, ErrorMessage = "促销属性(TJ-特价)输入过长，不能超过10位" )]         
        [Display( Name = "促销属性(TJ-特价)" )]        
        public string PROMOTION_ATTR { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        [Display( Name = "会员价" )]        
        public double? MEMBER_PRICE { get; set; }
        /// <summary>
        /// 会员积分
        /// </summary>
        [Display( Name = "会员积分" )]        
        public long? MENBER_POINTS { get; set; }
        /// <summary>
        /// 是否启用(1,启用,0.禁用)
        /// </summary>
        [Display( Name = "是否启用(1,启用,0.禁用)" )]        
        public byte? ENABLE_MP { get; set; }
        /// <summary>
        /// 商品销量
        /// </summary>
        [Display( Name = "商品销量" )]        
        public decimal? GOODS_SALES { get; set; }
        /// <summary>
        /// 是否erp商品(1:是,0:否)
        /// </summary>
        [Display( Name = "是否erp商品(1:是,0:否)" )]        
        public byte? IS_ERPGOODS { get; set; }               
    }
}