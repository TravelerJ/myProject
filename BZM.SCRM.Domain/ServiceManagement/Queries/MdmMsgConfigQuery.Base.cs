﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "消息提醒设置" )]
    public partial class MdmMsgConfigQuery : Pager {     

        /// <summary>
        /// 门店配置id
        /// </summary>
        [Display(Name="门店配置id")]
        public string BU_CONFIG_ID { get; set; }
        /// <summary>
        /// 预约类型(1试驾2售后)
        /// </summary>
        [Display(Name="预约类型(1试驾2售后)")]
        public decimal? APT_TYPE { get; set; }
        /// <summary>
        /// 预约提前提醒小时
        /// </summary>
        [Display(Name="预约提前提醒小时")]
        public double? APT_REMIND_DATE { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [Display(Name="备用字段1")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [Display(Name="备用字段2")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [Display(Name="备用字段3")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [Display(Name="备用字段4")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [Display(Name="备用字段5")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name="更新时间")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Display(Name="门店编码")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        [Display(Name="删除状态")]
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 消息提醒类型(1预约)
        /// </summary>
        [Display(Name="消息提醒类型(1预约)")]
        public long MSG_REMIND_TYPE { get; set; }
        /// <summary>
        /// 提醒事件(1预约成功/2预约失败/3取消预约/4提醒进店/5试驾中/施工提醒/6试驾完成/完工提醒/7预约超时)
        /// </summary>
        [Display(Name="提醒事件(1预约成功/2预约失败/3取消预约/4提醒进店/5试驾中/施工提醒/6试驾完成/完工提醒/7预约超时)")]
        public decimal? REMIND_EVENT_TYPE { get; set; }
        /// <summary>
        /// 提醒方式(1.即时,2.小时,3.当天)
        /// </summary>
        [Display(Name="提醒方式(1.即时,2.小时,3.当天)")]
        public decimal? REMIND_MODE { get; set; }
        /// <summary>
        /// 预约提醒时间
        /// </summary>
        [Display(Name="预约提醒时间")]
        public string APT_REMIND_TIME { get; set; }
    }
}