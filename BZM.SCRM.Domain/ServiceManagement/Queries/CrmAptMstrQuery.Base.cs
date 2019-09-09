using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CrmAptMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string APT_ID { get; set; }
        /// <summary>
        /// 预约单号
        /// </summary>
        [Display(Name="预约单号")]
        public string APT_NO { get; set; }
        /// <summary>
        /// 预约类型(主动/被动)
        /// </summary>
        [Display(Name="预约类型(主动/被动)")]
        public string APT_TYPE { get; set; }
        /// <summary>
        /// 预约类别
        /// </summary>
        [Display(Name="预约类别")]
        public string APT_CLASS { get; set; }
        /// <summary>
        /// 预约方式（qq/电话）
        /// </summary>
        [Display(Name="预约方式（qq/电话）")]
        public string APT_CHANNEL { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name="客户编号")]
        public string CUS_NO { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [Display(Name="客户姓名")]
        public string CUS_NAME { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Display(Name="客户电话")]
        public string CUS_PHONE_NO { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        [Display(Name="会员编号")]
        public string MEMBER_NO { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [Display(Name="车牌号")]
        public string CAR_ID { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        [Display(Name="车架号")]
        public string VIN { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        [Display(Name="预约日期")]
        public DateTime APT_DATE { get; set; }
        /// <summary>
        /// 预约时间段
        /// </summary>
        [Display(Name="预约时间段")]
        public string APT_TIMESPAN { get; set; }
        /// <summary>
        /// 预约服务项目
        /// </summary>
        [Display(Name="预约服务项目")]
        public string APT_SVC_ITEM { get; set; }
        /// <summary>
        /// 预约内容
        /// </summary>
        [Display(Name="预约内容")]
        public string APT_CONTENT { get; set; }
        /// <summary>
        /// 预约机构代码
        /// </summary>
        [Display(Name="预约机构代码")]
        public string APT_BU_NO { get; set; }
        /// <summary>
        /// 预估总金额
        /// </summary>
        [Display(Name="预估总金额")]
        public decimal? EST_TOTAL_AMT { get; set; }
        /// <summary>
        /// 预估总数量
        /// </summary>
        [Display(Name="预估总数量")]
        public long? EST_TOTAL_QTY { get; set; }
        /// <summary>
        /// 预估工时金额
        /// </summary>
        [Display(Name="预估工时金额")]
        public decimal? EST_MH_AMT { get; set; }
        /// <summary>
        /// 预估材料金额
        /// </summary>
        [Display(Name="预估材料金额")]
        public decimal? EST_MATERIAL_AMT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string APT_RMK { get; set; }
        /// <summary>
        /// 送修人(委托人)
        /// </summary>
        [Display(Name="送修人(委托人)")]
        public string CONSIGNER { get; set; }
        /// <summary>
        /// 送修人(委托人)电话
        /// </summary>
        [Display(Name="送修人(委托人)电话")]
        public string CONSIGNER_PHONE { get; set; }
        /// <summary>
        /// 指定服务顾问
        /// </summary>
        [Display(Name="指定服务顾问")]
        public long? IS_SA_APPOINT { get; set; }
        /// <summary>
        /// 接待人员
        /// </summary>
        [Display(Name="接待人员")]
        public string SERVICE_DESK { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public string APT_STATUS { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF10 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 1.预约试驾，2.养修预约
        /// </summary>
        [Display(Name="1.预约试驾，2.养修预约")]
        public byte? BOOKING_TYPE { get; set; }
        /// <summary>
        /// 微信粉丝openid
        /// </summary>
        [Display(Name="微信粉丝openid")]
        public string OPENID { get; set; }
        /// <summary>
        /// 是否已发送进店提醒(0.否/1.是)
        /// </summary>
        [Display(Name="是否已发送进店提醒(0.否/1.是)")]
        public decimal? IS_INSHOP { get; set; }
        /// <summary>
        /// 是否已发送超时提醒(0.否/1.是)
        /// </summary>
        [Display(Name="是否已发送超时提醒(0.否/1.是)")]
        public decimal? IS_TIMEOUT { get; set; }
    }
}