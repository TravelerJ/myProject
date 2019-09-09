using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctBasConfigDto : EntityDto<string> {    

        /// <summary>
        /// 验证码APPKEY
        /// </summary>
        [StringLength( 50, ErrorMessage = "验证码APPKEY输入过长，不能超过50位" )]         
        [Display( Name = "验证码APPKEY" )]        
        public string SMS_APP_KEY { get; set; }
        /// <summary>
        /// 验证码秘钥
        /// </summary>
        [StringLength( 50, ErrorMessage = "验证码秘钥输入过长，不能超过50位" )]         
        [Display( Name = "验证码秘钥" )]        
        public string SMS_MASTER_SECRET { get; set; }
        /// <summary>
        /// 验证码code
        /// </summary>
        [StringLength( 20, ErrorMessage = "验证码code输入过长，不能超过20位" )]         
        [Display( Name = "验证码code" )]        
        public string SMS_CODE_ID { get; set; }
        /// <summary>
        /// 是否对接ERP
        /// </summary>
                 
        [Display( Name = "是否对接ERP" )]        
        public long IS_TOERP { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength( 20, ErrorMessage = "创建人输入过长，不能超过20位" )]         
        [Display( Name = "创建人" )]        
        public string CREATOR { get; set; }
        /// <summary>
        /// 操作人编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "操作人编码输入过长，不能超过20位" )]         
        [Display( Name = "操作人编码" )]        
        public string OPRATOR_NO { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        [StringLength( 20, ErrorMessage = "会员等级输入过长，不能超过20位" )]         
        [Display( Name = "会员等级" )]        
        public string MEMBER_LEVEL { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]        
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display( Name = "更新人" )]        
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display( Name = "更新时间" )]        
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否启用第三方
        /// </summary>
                 
        [Display( Name = "是否启用第三方" )]        
        public long OPEN_IS_ENABLED { get; set; }
        /// <summary>
        /// 第三方appid
        /// </summary>
        [StringLength( 50, ErrorMessage = "第三方appid输入过长，不能超过50位" )]         
        [Display( Name = "第三方appid" )]        
        public string OPEN_APP_ID { get; set; }
        /// <summary>
        /// 第三方秘钥
        /// </summary>
        [StringLength( 50, ErrorMessage = "第三方秘钥输入过长，不能超过50位" )]         
        [Display( Name = "第三方秘钥" )]        
        public string OPEN_APP_SECRET { get; set; }
        /// <summary>
        /// 第三方token
        /// </summary>
        [StringLength( 50, ErrorMessage = "第三方token输入过长，不能超过50位" )]         
        [Display( Name = "第三方token" )]        
        public string OPEN_APP_TOKEN { get; set; }
        /// <summary>
        /// 第三方加密key
        /// </summary>
        [StringLength( 50, ErrorMessage = "第三方加密key输入过长，不能超过50位" )]         
        [Display( Name = "第三方加密key" )]        
        public string OPEN_SECRET_KEY { get; set; }
        /// <summary>
        /// 终端ip
        /// </summary>
        [StringLength( 20, ErrorMessage = "终端ip输入过长，不能超过20位" )]         
        [Display( Name = "终端ip" )]        
        public string CLIENT_IP { get; set; }
        /// <summary>
        /// 旧接口地址
        /// </summary>
        [StringLength( 30, ErrorMessage = "旧接口地址输入过长，不能超过30位" )]         
        [Display( Name = "旧接口地址" )]        
        public string ERP_API_OURL { get; set; }
        /// <summary>
        /// 新接口地址
        /// </summary>
        [StringLength( 30, ErrorMessage = "新接口地址输入过长，不能超过30位" )]         
        [Display( Name = "新接口地址" )]        
        public string ERP_API_NURL { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [Display( Name = "是否有效" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [StringLength( 20, ErrorMessage = "集团编码输入过长，不能超过20位" )]         
        [Display( Name = "集团编码" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 是否按集团分配应用
        /// </summary>
        [Display( Name = "是否按集团分配应用" )]        
        public long? IS_GROUP { get; set; }
        /// <summary>
        /// 功能应用配置
        /// </summary>
        [Display( Name = "功能应用配置" )]        
        public long? IS_APPCONFIG { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段1输入过长，不能超过50位" )]         
        [Display( Name = "备用字段1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段2输入过长，不能超过50位" )]         
        [Display( Name = "备用字段2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段3输入过长，不能超过50位" )]         
        [Display( Name = "备用字段3" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段4输入过长，不能超过50位" )]         
        [Display( Name = "备用字段4" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段5输入过长，不能超过50位" )]         
        [Display( Name = "备用字段5" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 是否单店模式
        /// </summary>
        [Display( Name = "是否单店模式" )]        
        public decimal? IS_ONLYSTORE { get; set; }
        /// <summary>
        /// 是否推送iris
        /// </summary>
        [Display( Name = "是否推送iris" )]        
        public decimal? IS_IRIS { get; set; }
        /// <summary>
        /// erp接口头验证appId
        /// </summary>
        [StringLength( 500, ErrorMessage = "erp接口头验证appId输入过长，不能超过500位" )]         
        [Display( Name = "erp接口头验证appId" )]        
        public string ERP_APP_ID { get; set; }
        /// <summary>
        /// erp接口头验证appKey
        /// </summary>
        [StringLength( 500, ErrorMessage = "erp接口头验证appKey输入过长，不能超过500位" )]         
        [Display( Name = "erp接口头验证appKey" )]        
        public string ERP_APP_KEY { get; set; }
        /// <summary>
        /// erp接口头验证appsecret
        /// </summary>
        [StringLength( 500, ErrorMessage = "erp接口头验证appsecret输入过长，不能超过500位" )]         
        [Display( Name = "erp接口头验证appsecret" )]        
        public string ERP_APP_SECRET { get; set; }
        /// <summary>
        /// 微信支付回调地址
        /// </summary>
        [StringLength( 100, ErrorMessage = "微信支付回调地址输入过长，不能超过100位" )]         
        [Display( Name = "微信支付回调地址" )]        
        public string WXPAY_RETURNURL { get; set; }
        /// <summary>
        /// IRIS预约接口
        /// </summary>
        [StringLength( 100, ErrorMessage = "IRIS预约接口输入过长，不能超过100位" )]         
        [Display( Name = "IRIS预约接口" )]        
        public string IRIS_APT_URL { get; set; }
        /// <summary>
        /// IRIS聊天接口
        /// </summary>
        [StringLength( 100, ErrorMessage = "IRIS聊天接口输入过长，不能超过100位" )]         
        [Display( Name = "IRIS聊天接口" )]        
        public string IRIS_CHAT_URL { get; set; }
        /// <summary>
        /// 模版预约url
        /// </summary>
        [StringLength( 100, ErrorMessage = "模版预约url输入过长，不能超过100位" )]         
        [Display( Name = "模版预约url" )]        
        public string APT_URL { get; set; }
        /// <summary>
        /// 是否允许转赠代金券
        /// </summary>
        [Display( Name = "是否允许转赠代金券" )]        
        public decimal? IS_TRANSFER { get; set; }
        /// <summary>
        /// 是否发送短信通知
        /// </summary>
        [Display( Name = "是否发送短信通知" )]        
        public decimal? IS_SEND_MSG { get; set; }
        /// <summary>
        /// 短消息code
        /// </summary>
        [StringLength( 20, ErrorMessage = "短消息code输入过长，不能超过20位" )]         
        [Display( Name = "短消息code" )]        
        public string SMS_MSG_CODE { get; set; }
        /// <summary>
        /// 是否允许兑换券
        /// </summary>
        [Display( Name = "是否允许兑换券" )]        
        public decimal? IS_EXCHANGE_TICKET { get; set; }
        /// <summary>
        /// redis存储地址
        /// </summary>
        [Display( Name = "redis存储地址" )]        
        public long? REDIS_NUM { get; set; }
        /// <summary>
        /// 销售预约人员
        /// </summary>
        [StringLength( 50, ErrorMessage = "销售预约人员输入过长，不能超过50位" )]         
        [Display( Name = "销售预约人员" )]        
        public string SALE_APT { get; set; }
        /// <summary>
        /// 售后预约人员
        /// </summary>
        [StringLength( 50, ErrorMessage = "售后预约人员输入过长，不能超过50位" )]         
        [Display( Name = "售后预约人员" )]        
        public string AFTER_SALE_APT { get; set; }
        /// <summary>
        /// 是否对接比滋特
        /// </summary>
        [Display( Name = "是否对接比滋特" )]        
        public decimal? IS_BZT { get; set; }
        /// <summary>
        /// 比滋特用户名
        /// </summary>
        [StringLength( 100, ErrorMessage = "比滋特用户名输入过长，不能超过100位" )]         
        [Display( Name = "比滋特用户名" )]        
        public string TOKEN_USR_NAME { get; set; }
        /// <summary>
        /// 比滋特密码
        /// </summary>
        [StringLength( 100, ErrorMessage = "比滋特密码输入过长，不能超过100位" )]         
        [Display( Name = "比滋特密码" )]        
        public string TOKEN_USR_PWD { get; set; }
        /// <summary>
        /// token类型
        /// </summary>
        [StringLength( 100, ErrorMessage = "token类型输入过长，不能超过100位" )]         
        [Display( Name = "token类型" )]        
        public string GRANT_TYPE { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        [StringLength( 100, ErrorMessage = "客户端id输入过长，不能超过100位" )]         
        [Display( Name = "客户端id" )]        
        public string CLIENT_ID { get; set; }
        /// <summary>
        /// 客户端secret
        /// </summary>
        [StringLength( 100, ErrorMessage = "客户端secret输入过长，不能超过100位" )]         
        [Display( Name = "客户端secret" )]        
        public string CLIENT_SECRET { get; set; }
        /// <summary>
        /// 比滋特接口路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "比滋特接口路径输入过长，不能超过200位" )]         
        [Display( Name = "比滋特接口路径" )]        
        public string IBZT_URL { get; set; }
        /// <summary>
        /// 商品来源(1.比滋特,2.ERP)
        /// </summary>
        [Display( Name = "商品来源(1.比滋特,2.ERP)" )]        
        public decimal? GOODS_FROM { get; set; }
        /// <summary>
        /// 车型来源(1.比滋特,2.ERP)
        /// </summary>
        [Display( Name = "车型来源(1.比滋特,2.ERP)" )]        
        public decimal? CAR_FROM { get; set; }
        /// <summary>
        /// 比滋特token
        /// </summary>
        [StringLength( 4000, ErrorMessage = "比滋特token输入过长，不能超过4000位" )]         
        [Display( Name = "比滋特token" )]        
        public string BZT_TOKEN { get; set; }
        /// <summary>
        /// token获取时间
        /// </summary>
        [Display( Name = "token获取时间" )]        
        public DateTime? BZT_TOKEN_TIME { get; set; }
        /// <summary>
        /// 是否随机分配销售顾问(1.随机,0.不随机)
        /// </summary>
        [Display( Name = "是否随机分配销售顾问(1.随机,0.不随机)" )]        
        public decimal? IS_RANDOMSALE { get; set; }
        /// <summary>
        /// 是否车辆绑定会员
        /// </summary>
        [Display( Name = "是否车辆绑定会员" )]        
        public decimal? IS_CAR_BIND { get; set; }
        /// <summary>
        /// 是否预约提醒(0不提醒1提醒)
        /// </summary>
        [Display( Name = "是否预约提醒(0不提醒1提醒)" )]        
        public decimal? IS_APT_REMIND { get; set; }
        /// <summary>
        /// 是否按集团预约配置
        /// </summary>
        [Display( Name = "是否按集团预约配置" )]        
        public decimal? IS_APT_GROUP { get; set; }
        
    }
}