using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmMsgConfig : Entity<string> {       

        /// <summary>
        /// 预约类型(1试驾2售后)
        /// </summary>
        public virtual decimal? APT_TYPE { get; set; }
        /// <summary>
        /// 预约提前提醒小时
        /// </summary>
        public virtual double? APT_REMIND_DATE { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 100, ErrorMessage = "备用字段1输入过长，不能超过100位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [StringLength( 100, ErrorMessage = "备用字段2输入过长，不能超过100位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 100, ErrorMessage = "备用字段3输入过长，不能超过100位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 100, ErrorMessage = "备用字段4输入过长，不能超过100位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 100, ErrorMessage = "备用字段5输入过长，不能超过100位" )]
        public virtual string UDF5 { get; set; }
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
        /// 门店编码
        /// </summary>
        [Required(ErrorMessage = "门店编码不能为空")]
        [StringLength( 50, ErrorMessage = "门店编码输入过长，不能超过50位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Required(ErrorMessage = "集团编码不能为空")]
        [StringLength( 50, ErrorMessage = "集团编码输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        [Required(ErrorMessage = "删除状态不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 消息提醒类型(1预约)
        /// </summary>
        [Required(ErrorMessage = "消息提醒类型(1预约)不能为空")]
        public virtual long MSG_REMIND_TYPE { get; set; }
        /// <summary>
        /// 提醒事件(1预约成功/2预约失败/3取消预约/4提醒进店/5试驾中/施工提醒/6试驾完成/完工提醒/7预约超时)
        /// </summary>
        public virtual decimal? REMIND_EVENT_TYPE { get; set; }
        /// <summary>
        /// 提醒方式(1.即时,2.小时,3.当天)
        /// </summary>
        public virtual decimal? REMIND_MODE { get; set; }
        /// <summary>
        /// 预约提醒时间
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约提醒时间输入过长，不能超过50位" )]
        public virtual string APT_REMIND_TIME { get; set; }
    }
}