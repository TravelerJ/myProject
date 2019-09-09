using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    /// 商品属性表
    /// </summary>
    public partial class MdmGoodsPropertyMstr : Entity<string> {       

        /// <summary>
        /// 属性名称
        /// </summary>
        [Required(ErrorMessage = "属性名称不能为空")]
        [StringLength( 250, ErrorMessage = "属性名称输入过长，不能超过250位" )]
        public virtual string PROPERTY_NAME { get; set; }
        /// <summary>
        /// 属性英文名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "属性英文名称输入过长，不能超过200位" )]
        public virtual string PROPERTY_EN_NAME { get; set; }
        /// <summary>
        /// 属性类型 1属性组2属性3属性明细
        /// </summary>
        [Required(ErrorMessage = "属性类型 1属性组2属性3属性明细不能为空")]
        public virtual decimal PROPERTY_TYPE { get; set; }
        /// <summary>
        /// 父级属性ID
        /// </summary>
        [Required(ErrorMessage = "父级属性ID不能为空")]
        [StringLength( 50, ErrorMessage = "父级属性ID输入过长，不能超过50位" )]
        public virtual string PROPERTY_PARENTID { get; set; }
        /// <summary>
        /// 属性节点层级 0父节点
        /// </summary>
        [Required(ErrorMessage = "属性节点层级 0父节点不能为空")]
        public virtual decimal PROPERTY_LEVEL { get; set; }
        /// <summary>
        /// 属性作用域 (商品 1/SKU 2)
        /// </summary>
        [Required(ErrorMessage = "属性作用域 (商品 1/SKU 2)不能为空")]
        public virtual decimal PROPERTY_DOMAIN { get; set; }
        /// <summary>
        /// 属性输入值类型（int, text, richtext, select.....）
        /// </summary>
        [StringLength( 50, ErrorMessage = "属性输入值类型（int, text, richtext, select.....）输入过长，不能超过50位" )]
        public virtual string PROPERTY_INPUT_FLAG { get; set; }
        /// <summary>
        /// 属性值最大长度
        /// </summary>
        public virtual decimal? PROPERTY_MAX_LENGTH { get; set; }
        /// <summary>
        /// 属性值默认值
        /// </summary>
        [StringLength( 50, ErrorMessage = "属性值默认值输入过长，不能超过50位" )]
        public virtual string PROPERTY_DEFAULT_VALUE { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        [Required(ErrorMessage = "删除标识不能为空")]
        public virtual decimal PROPERTY_STATUS { get; set; }
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
        [Required(ErrorMessage = "数据删除标志(1-有效/0-已删除)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
    }
}