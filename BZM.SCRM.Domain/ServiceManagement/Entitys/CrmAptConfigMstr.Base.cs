using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 预约配置表
    /// </summary>
    public partial class CrmAptConfigMstr : Entity<string> {       

        /// <summary>
        /// 预约设置开始时间
        /// </summary>
        public virtual DateTime? APT_CONFIG_SDATE { get; set; }
        /// <summary>
        /// 预约设置结束时间
        /// </summary>
        public virtual DateTime? APT_CONFIG_EDATE { get; set; }
        /// <summary>
        /// 预约类型（1.预约试驾，2预约维保）
        /// </summary>
        [Required(ErrorMessage = "预约类型（1.预约试驾，2预约维保）不能为空")]
        public virtual decimal APT_TYPE { get; set; }
        /// <summary>
        /// 预约设置Json
        /// </summary>
        [StringLength( 4000, ErrorMessage = "预约设置Json输入过长，不能超过4000位" )]
        public virtual string APT_CONFIG_JSON { get; set; }
        /// <summary>
        /// 预约最低折扣
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约最低折扣输入过长，不能超过50位" )]
        public virtual string APT_MIN_DISCOUNT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 150, ErrorMessage = "备注输入过长，不能超过150位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 150, ErrorMessage = "未定义输入过长，不能超过150位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 创建机构编码
        /// </summary>
        [Required(ErrorMessage = "创建机构编码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构编码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Required(ErrorMessage = "更新人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required(ErrorMessage = "更新时间不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Required(ErrorMessage = "数据删除标志(1-有效/0-已删除)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Required(ErrorMessage = "集团编号不能为空")]
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 优惠方式(1.折扣,2.金额)
        /// </summary>
        public virtual long? DIS_TYPE { get; set; }
        /// <summary>
        /// 预约提前时间
        /// </summary>
        public virtual double? APT_LIMIT { get; set; }
        /// <summary>
        /// 是否启用默认配置(1.系统默认,2.自定义配置)
        /// </summary>
        public virtual long? IS_DEFAULT { get; set; }
    }
}