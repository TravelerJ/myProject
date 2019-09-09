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
    public partial class MdmGoodsPropertyMstrQuery : Pager {     

        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name="主键")]
        public string PROPERTY_ID { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        [Display(Name="属性名称")]
        public string PROPERTY_NAME { get; set; }
        /// <summary>
        /// 属性英文名称
        /// </summary>
        [Display(Name="属性英文名称")]
        public string PROPERTY_EN_NAME { get; set; }
        /// <summary>
        /// 属性类型 1属性组2属性3属性明细
        /// </summary>
        [Display(Name="属性类型 1属性组2属性3属性明细")]
        public decimal PROPERTY_TYPE { get; set; }
        /// <summary>
        /// 父级属性ID
        /// </summary>
        [Display(Name="父级属性ID")]
        public string PROPERTY_PARENTID { get; set; }
        /// <summary>
        /// 属性节点层级 0父节点
        /// </summary>
        [Display(Name="属性节点层级 0父节点")]
        public decimal PROPERTY_LEVEL { get; set; }
        /// <summary>
        /// 属性作用域 (商品 1/SKU 2)
        /// </summary>
        [Display(Name="属性作用域 (商品 1/SKU 2)")]
        public decimal PROPERTY_DOMAIN { get; set; }
        /// <summary>
        /// 属性输入值类型（int, text, richtext, select.....）
        /// </summary>
        [Display(Name="属性输入值类型（int, text, richtext, select.....）")]
        public string PROPERTY_INPUT_FLAG { get; set; }
        /// <summary>
        /// 属性值最大长度
        /// </summary>
        [Display(Name="属性值最大长度")]
        public decimal? PROPERTY_MAX_LENGTH { get; set; }
        /// <summary>
        /// 属性值默认值
        /// </summary>
        [Display(Name="属性值默认值")]
        public string PROPERTY_DEFAULT_VALUE { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        [Display(Name="删除标识")]
        public decimal PROPERTY_STATUS { get; set; }
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
        public decimal DEL_FLAG { get; set; }
    }
}