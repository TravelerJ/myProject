using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Queries {
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class SysUsrWctQuery : Pager {     

        /// <summary>
        /// pk值
        /// </summary>
        [Display(Name="pk值")]
        public string WCT_ID { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Display(Name="商户号")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name="用户ID")]
        public decimal USR_ID { get; set; }
        /// <summary>
        /// 微信openid
        /// </summary>
        [Display(Name="微信openid")]
        public string OPEN_ID { get; set; }
        /// <summary>
        /// 关联员工编号
        /// </summary>
        [Display(Name="关联员工编号")]
        public string CUS_SVC_CODE { get; set; }
        /// <summary>
        /// 关注状态(0-取消关注/1-已关注)
        /// </summary>
        [Display(Name="关注状态(0-取消关注/1-已关注)")]
        public decimal? FOLLOW_STATUS { get; set; }
        /// <summary>
        /// 粉丝来源(1-微信/2-导入/3-手工添加)
        /// </summary>
        [Display(Name="粉丝来源(1-微信/2-导入/3-手工添加)")]
        public decimal? USR_SOURCE { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        [Display(Name="注册日期")]
        public DateTime? REG_DATE { get; set; }
        /// <summary>
        /// 推荐人用户ID
        /// </summary>
        [Display(Name="推荐人用户ID")]
        public decimal? REFEREE_USR_ID { get; set; }
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
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 取消关注时间
        /// </summary>
        [Display(Name="取消关注时间")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name="性别")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name="昵称")]
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 用户微信图像
        /// </summary>
        [Display(Name="用户微信图像")]
        public string WX_AVATAR_URL { get; set; }
        /// <summary>
        /// 微信公众号ID
        /// </summary>
        [Display(Name="微信公众号ID")]
        public string APP_ID { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Display(Name="标签名称")]
        public string TAG_NAME { get; set; }
        /// <summary>
        /// 销售顾问专属Ticket
        /// </summary>
        [Display(Name="销售顾问专属Ticket")]
        public string TICKET { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 售后预约code
        /// </summary>
        [Display(Name="售后预约code")]
        public string AFTER_SALE_CODE { get; set; }
    }
}