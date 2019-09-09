using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 消息推送记录表
    /// </summary>
    public partial class WctPushMsg : Entity<string> {       

        /// <summary>
        /// 消息类型
        /// </summary>
        [Required(ErrorMessage = "消息类型不能为空")]
        [StringLength( 50, ErrorMessage = "消息类型输入过长，不能超过50位" )]
        public virtual string MSG_TYPE { get; set; }
        /// <summary>
        /// 任务描述
        /// </summary>
        [StringLength( 500, ErrorMessage = "任务描述输入过长，不能超过500位" )]
        public virtual string MSG_RMK { get; set; }
        /// <summary>
        /// 推送粉丝标签
        /// </summary>
        [StringLength( 4000, ErrorMessage = "推送粉丝标签输入过长，不能超过4000位" )]
        public virtual string FANS_TAG { get; set; }
        /// <summary>
        /// 服务号
        /// </summary>
        [StringLength( 4000, ErrorMessage = "服务号输入过长，不能超过4000位" )]
        public virtual string WCT_SERVICE_NO { get; set; }
        /// <summary>
        /// 订阅号
        /// </summary>
        [StringLength( 4000, ErrorMessage = "订阅号输入过长，不能超过4000位" )]
        public virtual string WCT_SSPT_NO { get; set; }
        /// <summary>
        /// 推送内容
        /// </summary>
        [Required(ErrorMessage = "推送内容不能为空")]
        [StringLength( 2000, ErrorMessage = "推送内容输入过长，不能超过2000位" )]
        public virtual string MSG_CONTENT { get; set; }
        /// <summary>
        /// 推送状态：待推送，已发布
        /// </summary>
        [Required(ErrorMessage = "推送状态：待推送，已发布不能为空")]
        [StringLength( 50, ErrorMessage = "推送状态：待推送，已发布输入过长，不能超过50位" )]
        public virtual string MSG_STATUS { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        public virtual DateTime? PUSH_DATE { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
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
        /// 微信图文素材ID
        /// </summary>
        [StringLength( 300, ErrorMessage = "微信图文素材ID输入过长，不能超过300位" )]
        public virtual string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}