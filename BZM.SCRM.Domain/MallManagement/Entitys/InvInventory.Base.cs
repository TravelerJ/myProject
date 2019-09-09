using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.MallManagement.Entitys
{
    /// <summary>
    /// 商品库存表
    /// </summary>
    public partial class InvInventory : Entity<long> {       

        /// <summary>
        /// 所属机构
        /// </summary>
        [Required(ErrorMessage = "所属机构不能为空")]
        [StringLength( 50, ErrorMessage = "所属机构输入过长，不能超过50位" )]
        public virtual string ORG_NO { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public virtual long? WH_ID { get; set; }
        /// <summary>
        /// 库位编号
        /// </summary>
        public virtual long? LC_ID { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required(ErrorMessage = "商品编号不能为空")]
        [StringLength( 50, ErrorMessage = "商品编号输入过长，不能超过50位" )]
        public virtual string GOODS_NO { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        [StringLength( 50, ErrorMessage = "批次号输入过长，不能超过50位" )]
        public virtual string BATCH_NO { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public virtual decimal QTY { get; set; }
        /// <summary>
        /// 数据标志
        /// </summary>
        public virtual long? DATA_FLAG { get; set; }
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
    }
}