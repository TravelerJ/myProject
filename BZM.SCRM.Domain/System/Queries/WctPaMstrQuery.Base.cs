using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.System.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class WctPaMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string PA_ID { get; set; }
        /// <summary>
        /// 公众号名称
        /// </summary>
        [Display(Name="公众号名称")]
        public string PA_NAME { get; set; }
        /// <summary>
        /// 公众号原始ID
        /// </summary>
        [Display(Name="公众号原始ID")]
        public string PA_ORIGINAL_ID { get; set; }
        /// <summary>
        /// appid
        /// </summary>
        [Display(Name="appid")]
        public string PA_APPID { get; set; }
        /// <summary>
        /// appsecret
        /// </summary>
        [Display(Name="appsecret")]
        public string PA_APPSECRET { get; set; }
        /// <summary>
        /// 公众号登录用户名
        /// </summary>
        [Display(Name="公众号登录用户名")]
        public string PA_USER { get; set; }
        /// <summary>
        /// 公众号登录密码
        /// </summary>
        [Display(Name="公众号登录密码")]
        public string PA_PASSWORD { get; set; }
        /// <summary>
        /// 组织机构编号
        /// </summary>
        [Display(Name="组织机构编号")]
        public string PA_ID_NO { get; set; }
        /// <summary>
        /// 公众号类型ID（服务号、订阅号、企业号）
        /// </summary>
        [Display(Name="公众号类型ID（服务号、订阅号、企业号）")]
        public decimal? PA_TYPE_ID { get; set; }
        /// <summary>
        /// 公众号AUTH认证地址
        /// </summary>
        [Display(Name="公众号AUTH认证地址")]
        public string PA_AUTH_URL { get; set; }
        /// <summary>
        /// 是否开启多客服
        /// </summary>
        [Display(Name="是否开启多客服")]
        public decimal PA_CUS_SVC_ENABLED { get; set; }
        /// <summary>
        /// 公众号加密密钥
        /// </summary>
        [Display(Name="公众号加密密钥")]
        public string PA_ENCODINGAESKEY { get; set; }
        /// <summary>
        /// 公众号access token
        /// </summary>
        [Display(Name="公众号access token")]
        public string PA_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 公众号access token到期时间
        /// </summary>
        [Display(Name="公众号access token到期时间")]
        public DateTime? PA_ACCESS_TOKEN_EXP_TIME { get; set; }
        /// <summary>
        /// 公众号JS API TICKET
        /// </summary>
        [Display(Name="公众号JS API TICKET")]
        public string PA_JSAPITICKET { get; set; }
        /// <summary>
        /// 公众号JS API TICKET到期时间
        /// </summary>
        [Display(Name="公众号JS API TICKET到期时间")]
        public DateTime? PA_JSAPITICKET_EXP_TIME { get; set; }
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
        /// 预约失败/超时模版
        /// </summary>
        [Display(Name="预约失败/超时模版")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 支付模版
        /// </summary>
        [Display(Name="支付模版")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 满意度调查模版
        /// </summary>
        [Display(Name="满意度调查模版")]
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
        /// 管理者邮件
        /// </summary>
        [Display(Name="管理者邮件")]
        public string PA_MANAGER_EMAIL { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 关联bpm（支付系统）的支付通道的主键
        /// </summary>
        [Display(Name="关联bpm（支付系统）的支付通道的主键")]
        public long? BPMPAYCHANNELID { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Display(Name="商户号")]
        public string MCH_ID { get; set; }
        /// <summary>
        /// 支付安全秘钥
        /// </summary>
        [Display(Name="支付安全秘钥")]
        public string SIGNKEY { get; set; }
        /// <summary>
        /// 公众号令牌
        /// </summary>
        [Display(Name="公众号令牌")]
        public string AUTHORIZER_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 公众号刷新令牌
        /// </summary>
        [Display(Name="公众号刷新令牌")]
        public string AUTHORIZER_REFRESH_TOKEN { get; set; }
        /// <summary>
        /// 公众号令牌获取时间
        /// </summary>
        [Display(Name="公众号令牌获取时间")]
        public DateTime? AUTHORIZER_TOKEN_TIME { get; set; }
        /// <summary>
        /// 开放平台授权状态
        /// </summary>
        [Display(Name="开放平台授权状态")]
        public long? OP_AUTH_STATUS { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// API支付安全证书
        /// </summary>
        [Display(Name="API支付安全证书")]
        public string APICLIENT_CERT { get; set; }
        /// <summary>
        /// 公众号关注url
        /// </summary>
        [Display(Name="公众号关注url")]
        public string PA_FOLLOW_URL { get; set; }
        /// <summary>
        /// 服务完成通知模版
        /// </summary>
        [Display(Name="服务完成通知模版")]
        public string PA_TEMPLATE_SERVICE { get; set; }
        /// <summary>
        /// 卡券核销模版
        /// </summary>
        [Display(Name="卡券核销模版")]
        public string PA_TEMPLATE_TICKET_VERIFICA { get; set; }
        /// <summary>
        /// 卡券发放模版
        /// </summary>
        [Display(Name="卡券发放模版")]
        public string PA_TEMPLATE_TICKET_ISSUE { get; set; }
        /// <summary>
        /// 预约成功模版
        /// </summary>
        [Display(Name="预约成功模版")]
        public string PA_TEMPLATE_APT { get; set; }
    }
}