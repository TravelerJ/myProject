using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 预约主表
    /// </summary>
    public partial class CrmAptMstr : Entity<string> {       

        /// <summary>
        /// 预约单号
        /// </summary>
        [Required(ErrorMessage = "预约单号不能为空")]
        [StringLength( 50, ErrorMessage = "预约单号输入过长，不能超过50位" )]
        public virtual string APT_NO { get; set; }
        /// <summary>
        /// 预约类型(主动/被动)
        /// </summary>
        [Required(ErrorMessage = "预约类型(主动/被动)不能为空")]
        [StringLength( 20, ErrorMessage = "预约类型(主动/被动)输入过长，不能超过20位" )]
        public virtual string APT_TYPE { get; set; }
        /// <summary>
        /// 预约类别
        /// </summary>
        [Required(ErrorMessage = "预约类别不能为空")]
        [StringLength( 100, ErrorMessage = "预约类别输入过长，不能超过100位" )]
        public virtual string APT_CLASS { get; set; }
        /// <summary>
        /// 预约方式（qq/电话）
        /// </summary>
        [Required(ErrorMessage = "预约方式（qq/电话）不能为空")]
        [StringLength( 20, ErrorMessage = "预约方式（qq/电话）输入过长，不能超过20位" )]
        public virtual string APT_CHANNEL { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "客户编号输入过长，不能超过50位" )]
        public virtual string CUS_NO { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [Required(ErrorMessage = "客户姓名不能为空")]
        [StringLength( 100, ErrorMessage = "客户姓名输入过长，不能超过100位" )]
        public virtual string CUS_NAME { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Required(ErrorMessage = "客户电话不能为空")]
        [StringLength( 20, ErrorMessage = "客户电话输入过长，不能超过20位" )]
        public virtual string CUS_PHONE_NO { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "会员编号输入过长，不能超过50位" )]
        public virtual string MEMBER_NO { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [StringLength( 50, ErrorMessage = "车牌号输入过长，不能超过50位" )]
        public virtual string CAR_ID { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        [StringLength( 50, ErrorMessage = "车架号输入过长，不能超过50位" )]
        public virtual string VIN { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        [Required(ErrorMessage = "预约日期不能为空")]
        public virtual DateTime APT_DATE { get; set; }
        /// <summary>
        /// 预约时间段
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约时间段输入过长，不能超过50位" )]
        public virtual string APT_TIMESPAN { get; set; }
        /// <summary>
        /// 预约服务项目
        /// </summary>
        [StringLength( 500, ErrorMessage = "预约服务项目输入过长，不能超过500位" )]
        public virtual string APT_SVC_ITEM { get; set; }
        /// <summary>
        /// 预约内容
        /// </summary>
        [StringLength( 200, ErrorMessage = "预约内容输入过长，不能超过200位" )]
        public virtual string APT_CONTENT { get; set; }
        /// <summary>
        /// 预约机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约机构代码输入过长，不能超过50位" )]
        public virtual string APT_BU_NO { get; set; }
        /// <summary>
        /// 预估总金额
        /// </summary>
        public virtual decimal? EST_TOTAL_AMT { get; set; }
        /// <summary>
        /// 预估总数量
        /// </summary>
        public virtual long? EST_TOTAL_QTY { get; set; }
        /// <summary>
        /// 预估工时金额
        /// </summary>
        public virtual decimal? EST_MH_AMT { get; set; }
        /// <summary>
        /// 预估材料金额
        /// </summary>
        public virtual decimal? EST_MATERIAL_AMT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "备注输入过长，不能超过100位" )]
        public virtual string APT_RMK { get; set; }
        /// <summary>
        /// 送修人(委托人)
        /// </summary>
        [StringLength( 100, ErrorMessage = "送修人(委托人)输入过长，不能超过100位" )]
        public virtual string CONSIGNER { get; set; }
        /// <summary>
        /// 送修人(委托人)电话
        /// </summary>
        [StringLength( 20, ErrorMessage = "送修人(委托人)电话输入过长，不能超过20位" )]
        public virtual string CONSIGNER_PHONE { get; set; }
        /// <summary>
        /// 指定服务顾问
        /// </summary>
        public virtual long? IS_SA_APPOINT { get; set; }
        /// <summary>
        /// 接待人员
        /// </summary>
        [StringLength( 20, ErrorMessage = "接待人员输入过长，不能超过20位" )]
        public virtual string SERVICE_DESK { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        [StringLength( 50, ErrorMessage = "状态输入过长，不能超过50位" )]
        public virtual string APT_STATUS { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF10 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Required(ErrorMessage = "数据删除标志(1-有效/0-已删除)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 1.预约试驾，2.养修预约
        /// </summary>
        public virtual int? BOOKING_TYPE { get; set; }
        /// <summary>
        /// 微信粉丝openid
        /// </summary>
        [StringLength( 100, ErrorMessage = "微信粉丝openid输入过长，不能超过100位" )]
        public virtual string OPENID { get; set; }
        /// <summary>
        /// 是否已发送进店提醒(0.否/1.是)
        /// </summary>
        public virtual decimal? IS_INSHOP { get; set; }
        /// <summary>
        /// 是否已发送超时提醒(0.否/1.是)
        /// </summary>
        public virtual decimal? IS_TIMEOUT { get; set; }
    }
}