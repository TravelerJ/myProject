using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys {
    /// <summary>
    /// 商品分类表
    /// </summary>
    public partial class MdmGoodsClass : Entity<long> {       

        /// <summary>
        /// 分类代码
        /// </summary>
        [Required(ErrorMessage = "分类代码不能为空")]
        [StringLength( 40, ErrorMessage = "分类代码输入过长，不能超过40位" )]
        public virtual string CLASS_NO { get; set; }
        /// <summary>
        /// 分类层级
        /// </summary>
        [Required(ErrorMessage = "分类层级不能为空")]
        public virtual long CLASS_LEVEL { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [Required(ErrorMessage = "分类名称不能为空")]
        [StringLength( 100, ErrorMessage = "分类名称输入过长，不能超过100位" )]
        public virtual string CLASS_NAME { get; set; }
        /// <summary>
        /// 上级分类ID
        /// </summary>
        public virtual long? PARENT_ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public virtual long CLASS_STATUS { get; set; }
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
        /// 分类属性
        /// </summary>
        [StringLength( 10, ErrorMessage = "分类属性输入过长，不能超过10位" )]
        public virtual string CLASS_ATTR { get; set; }
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