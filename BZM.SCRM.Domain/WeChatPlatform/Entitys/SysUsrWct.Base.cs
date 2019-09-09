using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 微信粉丝表
    /// </summary>
    public partial class SysUsrWct : Entity<string> {       

        /// <summary>
        /// 商户号
        /// </summary>
        [Required(ErrorMessage = "商户号不能为空")]
        [StringLength( 50, ErrorMessage = "商户号输入过长，不能超过50位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required(ErrorMessage = "用户ID不能为空")]
        public virtual decimal USR_ID { get; set; }
        /// <summary>
        /// 微信openid
        /// </summary>
        [StringLength( 50, ErrorMessage = "微信openid输入过长，不能超过50位" )]
        public virtual string OPEN_ID { get; set; }
        /// <summary>
        /// 关联员工编号
        /// </summary>
        [StringLength( 1000, ErrorMessage = "关联员工编号输入过长，不能超过1000位" )]
        public virtual string CUS_SVC_CODE { get; set; }
        /// <summary>
        /// 关注状态(0-取消关注/1-已关注)
        /// </summary>
        public virtual decimal? FOLLOW_STATUS { get; set; }
        /// <summary>
        /// 粉丝来源(1-微信/2-导入/3-手工添加)
        /// </summary>
        public virtual decimal? USR_SOURCE { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public virtual DateTime? REG_DATE { get; set; }
        /// <summary>
        /// 推荐人用户ID
        /// </summary>
        public virtual decimal? REFEREE_USR_ID { get; set; }
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
        /// 取消关注时间
        /// </summary>
        [StringLength( 50, ErrorMessage = "取消关注时间输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [StringLength( 50, ErrorMessage = "性别输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength( 50, ErrorMessage = "昵称输入过长，不能超过50位" )]
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 用户微信图像
        /// </summary>
        [StringLength( 500, ErrorMessage = "用户微信图像输入过长，不能超过500位" )]
        public virtual string WX_AVATAR_URL { get; set; }
        /// <summary>
        /// 微信公众号ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "微信公众号ID输入过长，不能超过50位" )]
        public virtual string APP_ID { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "标签名称输入过长，不能超过500位" )]
        public virtual string TAG_NAME { get; set; }
        /// <summary>
        /// 销售顾问专属Ticket
        /// </summary>
        [StringLength( 200, ErrorMessage = "销售顾问专属Ticket输入过长，不能超过200位" )]
        public virtual string TICKET { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 售后预约code
        /// </summary>
        [StringLength( 50, ErrorMessage = "售后预约code输入过长，不能超过50位" )]
        public virtual string AFTER_SALE_CODE { get; set; }
    }
}