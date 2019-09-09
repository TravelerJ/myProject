using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 金融政策标签表
    /// </summary>
    public partial class FinanceTagConfig : Entity<string> {       

        /// <summary>
        /// 标签名称
        /// </summary>
        [Required(ErrorMessage = "标签名称不能为空")]
        [StringLength( 20, ErrorMessage = "标签名称输入过长，不能超过20位" )]
        public virtual string TAG_NAME { get; set; }
        /// <summary>
        /// 标签详情
        /// </summary>
        [Required(ErrorMessage = "标签详情不能为空")]
        [StringLength( 500, ErrorMessage = "标签详情输入过长，不能超过500位" )]
        public virtual string TAG_DESCRIBE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Required(ErrorMessage = "序号不能为空")]
        public virtual long SORT_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public virtual decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Required(ErrorMessage = "门店编码不能为空")]
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Required(ErrorMessage = "集团编码不能为空")]
        [StringLength( 20, ErrorMessage = "集团编码输入过长，不能超过20位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 20, ErrorMessage = "输入过长，不能超过20位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 20, ErrorMessage = "输入过长，不能超过20位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
    }
}