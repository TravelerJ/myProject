using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    ///  预约时段系统表
    /// </summary>
    public partial class AptTimeperiodConfig : Entity<string> {       

        /// <summary>
        /// 预约类型(1.预约试驾,2.预约维保)
        /// </summary>
        public virtual decimal? APT_TYPE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public virtual decimal? SORT_NO { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required(ErrorMessage = "开始时间不能为空")]
        [StringLength( 20, ErrorMessage = "开始时间输入过长，不能超过20位" )]
        public virtual string PERIOD_STIME { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Required(ErrorMessage = "结束时间不能为空")]
        [StringLength( 20, ErrorMessage = "结束时间输入过长，不能超过20位" )]
        public virtual string PERIOD_ETIME { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        [Required(ErrorMessage = "机构编码不能为空")]
        [StringLength( 20, ErrorMessage = "机构编码输入过长，不能超过20位" )]
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
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
    }
}