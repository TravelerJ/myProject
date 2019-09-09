using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 微信公众号表
    /// </summary>
    public partial class WctPaMstr : Entity<string> {       

        /// <summary>
        /// 公众号名称
        /// </summary>
        [Required(ErrorMessage = "公众号名称不能为空")]
        [StringLength( 50, ErrorMessage = "公众号名称输入过长，不能超过50位" )]
        public virtual string PA_NAME { get; set; }
        /// <summary>
        /// 公众号原始ID
        /// </summary>
        [Required(ErrorMessage = "公众号原始ID不能为空")]
        [StringLength( 50, ErrorMessage = "公众号原始ID输入过长，不能超过50位" )]
        public virtual string PA_ORIGINAL_ID { get; set; }
        /// <summary>
        /// appid
        /// </summary>
        [Required(ErrorMessage = "appid不能为空")]
        [StringLength( 50, ErrorMessage = "appid输入过长，不能超过50位" )]
        public virtual string PA_APPID { get; set; }
        /// <summary>
        /// appsecret
        /// </summary>
        [Required(ErrorMessage = "appsecret不能为空")]
        [StringLength( 100, ErrorMessage = "appsecret输入过长，不能超过100位" )]
        public virtual string PA_APPSECRET { get; set; }
        /// <summary>
        /// 公众号登录用户名
        /// </summary>
        [StringLength( 100, ErrorMessage = "公众号登录用户名输入过长，不能超过100位" )]
        public virtual string PA_USER { get; set; }
        /// <summary>
        /// 公众号登录密码
        /// </summary>
        [StringLength( 50, ErrorMessage = "公众号登录密码输入过长，不能超过50位" )]
        public virtual string PA_PASSWORD { get; set; }
        /// <summary>
        /// 组织机构编号
        /// </summary>
        [Required(ErrorMessage = "组织机构编号不能为空")]
        [StringLength( 50, ErrorMessage = "组织机构编号输入过长，不能超过50位" )]
        public virtual string PA_ID_NO { get; set; }
        /// <summary>
        /// 公众号类型ID（服务号、订阅号、企业号）
        /// </summary>
        [Required(ErrorMessage = "公众号类型ID（服务号、订阅号、企业号）不能为空")]
        public virtual decimal PA_TYPE_ID { get; set; }
        /// <summary>
        /// 公众号AUTH认证地址
        /// </summary>
        [StringLength( 1000, ErrorMessage = "公众号AUTH认证地址输入过长，不能超过1000位" )]
        public virtual string PA_AUTH_URL { get; set; }
        /// <summary>
        /// 是否开启多客服
        /// </summary>
        [Required(ErrorMessage = "是否开启多客服不能为空")]
        public virtual decimal PA_CUS_SVC_ENABLED { get; set; }
        /// <summary>
        /// 公众号加密密钥
        /// </summary>
        [StringLength( 100, ErrorMessage = "公众号加密密钥输入过长，不能超过100位" )]
        public virtual string PA_ENCODINGAESKEY { get; set; }
        /// <summary>
        /// 公众号access token
        /// </summary>
        [StringLength( 600, ErrorMessage = "公众号access token输入过长，不能超过600位" )]
        public virtual string PA_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 公众号access token到期时间
        /// </summary>
        public virtual DateTime? PA_ACCESS_TOKEN_EXP_TIME { get; set; }
        /// <summary>
        /// 公众号JS API TICKET
        /// </summary>
        [StringLength( 600, ErrorMessage = "公众号JS API TICKET输入过长，不能超过600位" )]
        public virtual string PA_JSAPITICKET { get; set; }
        /// <summary>
        /// 公众号JS API TICKET到期时间
        /// </summary>
        public virtual DateTime? PA_JSAPITICKET_EXP_TIME { get; set; }
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
        /// 预约失败/超时模版
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约失败/超时模版输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 支付模版
        /// </summary>
        [StringLength( 50, ErrorMessage = "支付模版输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 满意度调查模版
        /// </summary>
        [StringLength( 50, ErrorMessage = "满意度调查模版输入过长，不能超过50位" )]
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
        /// 管理者邮件
        /// </summary>
        [StringLength( 200, ErrorMessage = "管理者邮件输入过长，不能超过200位" )]
        public virtual string PA_MANAGER_EMAIL { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 关联bpm（支付系统）的支付通道的主键
        /// </summary>
        public virtual long? BPMPAYCHANNELID { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [StringLength( 50, ErrorMessage = "商户号输入过长，不能超过50位" )]
        public virtual string MCH_ID { get; set; }
        /// <summary>
        /// 支付安全秘钥
        /// </summary>
        [StringLength( 50, ErrorMessage = "支付安全秘钥输入过长，不能超过50位" )]
        public virtual string SIGNKEY { get; set; }
        /// <summary>
        /// 公众号令牌
        /// </summary>
        [StringLength( 500, ErrorMessage = "公众号令牌输入过长，不能超过500位" )]
        public virtual string AUTHORIZER_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 公众号刷新令牌
        /// </summary>
        [StringLength( 500, ErrorMessage = "公众号刷新令牌输入过长，不能超过500位" )]
        public virtual string AUTHORIZER_REFRESH_TOKEN { get; set; }
        /// <summary>
        /// 公众号令牌获取时间
        /// </summary>
        public virtual DateTime? AUTHORIZER_TOKEN_TIME { get; set; }
        /// <summary>
        /// 开放平台授权状态
        /// </summary>
        public virtual long? OP_AUTH_STATUS { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// API支付安全证书
        /// </summary>
        [StringLength( 1000, ErrorMessage = "API支付安全证书输入过长，不能超过1000位" )]
        public virtual string APICLIENT_CERT { get; set; }
        /// <summary>
        /// 公众号关注url
        /// </summary>
        [StringLength( 200, ErrorMessage = "公众号关注url输入过长，不能超过200位" )]
        public virtual string PA_FOLLOW_URL { get; set; }
        /// <summary>
        /// 服务完成通知模版
        /// </summary>
        [StringLength( 200, ErrorMessage = "服务完成通知模版输入过长，不能超过200位" )]
        public virtual string PA_TEMPLATE_SERVICE { get; set; }
        /// <summary>
        /// 卡券核销模版
        /// </summary>
        [StringLength( 200, ErrorMessage = "卡券核销模版输入过长，不能超过200位" )]
        public virtual string PA_TEMPLATE_TICKET_VERIFICA { get; set; }
        /// <summary>
        /// 卡券发放模版
        /// </summary>
        [StringLength( 200, ErrorMessage = "卡券发放模版输入过长，不能超过200位" )]
        public virtual string PA_TEMPLATE_TICKET_ISSUE { get; set; }
        /// <summary>
        /// 预约成功模版
        /// </summary>
        [StringLength( 200, ErrorMessage = "预约成功模版输入过长，不能超过200位" )]
        public virtual string PA_TEMPLATE_APT { get; set; }
    }
}