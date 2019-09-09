using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class WctPushMsgQuery : Pager {     

        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name="主键")]
        public string MSG_ID { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [Display(Name="消息类型")]
        public string MSG_TYPE { get; set; }
        /// <summary>
        /// 任务描述
        /// </summary>
        [Display(Name="任务描述")]
        public string MSG_RMK { get; set; }
        /// <summary>
        /// 推送粉丝标签
        /// </summary>
        [Display(Name="推送粉丝标签")]
        public string FANS_TAG { get; set; }
        /// <summary>
        /// 服务号
        /// </summary>
        [Display(Name="服务号")]
        public string WCT_SERVICE_NO { get; set; }
        /// <summary>
        /// 订阅号
        /// </summary>
        [Display(Name="订阅号")]
        public string WCT_SSPT_NO { get; set; }
        /// <summary>
        /// 推送内容
        /// </summary>
        [Display(Name="推送内容")]
        public string MSG_CONTENT { get; set; }
        /// <summary>
        /// 推送状态：待推送，已发布
        /// </summary>
        [Display(Name="推送状态：待推送，已发布")]
        public string MSG_STATUS { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        [Display(Name="推送时间")]
        public DateTime? PUSH_DATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
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
        /// 微信图文素材ID
        /// </summary>
        [Display(Name="微信图文素材ID")]
        public string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}