using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.System.Dtos {
    /// <summary>
    /// 
    /// </summary>
    public partial class SysUsrMstrDto : EntityDto<decimal> {    

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户名输入过长，不能超过50位" )]         
        [Display( Name = "用户名" )]        
        public string USR_NAME { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户密码输入过长，不能超过50位" )]         
        [Display( Name = "用户密码" )]        
        public string USR_PWD { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
                 
        [Display( Name = "用户状态" )]        
        public decimal USR_STATUS { get; set; }
        /// <summary>
        ///  是否有头像1=已上传 0=未上传 
        /// </summary>
        [Display( Name = " 是否有头像1=已上传 0=未上传 " )]        
        public decimal? USR_AVATAR_STATUS { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
                 
        [Display( Name = "注册日期" )]        
        public DateTime USR_REG_DATE { get; set; }
        /// <summary>
        /// 所属机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "所属机构代码输入过长，不能超过50位" )]         
        [Display( Name = "所属机构代码" )]        
        public string ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
                 
        [Display( Name = "创建人" )]        
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
                 
        [Display( Name = "创建日期" )]        
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
                 
        [Display( Name = "更新人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
                 
        [Display( Name = "更新日期" )]        
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构代码" )]        
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength( 100, ErrorMessage = "真实姓名输入过长，不能超过100位" )]         
        [Display( Name = "真实姓名" )]        
        public string USR_REAL_NAME { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        [StringLength( 20, ErrorMessage = "用户手机输入过长，不能超过20位" )]         
        [Display( Name = "用户手机" )]        
        public string USR_MOBILE { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户邮箱输入过长，不能超过50位" )]         
        [Display( Name = "用户邮箱" )]        
        public string USR_EMAIL { get; set; }
        /// <summary>
        /// 手机认证(0-未认证/1-已认证)
        /// </summary>
        [Display( Name = "手机认证(0-未认证/1-已认证)" )]        
        public long? USR_MOBILE_PASS { get; set; }
        /// <summary>
        /// 图像路径
        /// </summary>
        [StringLength( 100, ErrorMessage = "图像路径输入过长，不能超过100位" )]         
        [Display( Name = "图像路径" )]        
        public string USR_AVATAR_PATH { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        [StringLength( 50, ErrorMessage = "支付宝账号输入过长，不能超过50位" )]         
        [Display( Name = "支付宝账号" )]        
        public string USR_ALIPAY { get; set; }
        /// <summary>
        /// 邀请码
        /// </summary>
        [StringLength( 20, ErrorMessage = "邀请码输入过长，不能超过20位" )]         
        [Display( Name = "邀请码" )]        
        public string INVITATION_CODE { get; set; }
        /// <summary>
        /// 来源渠道
        /// </summary>
        [StringLength( 50, ErrorMessage = "来源渠道输入过长，不能超过50位" )]         
        [Display( Name = "来源渠道" )]        
        public string FROM_CHANNEL { get; set; }
        /// <summary>
        /// 邀请码
        /// </summary>
        [StringLength( 20, ErrorMessage = "邀请码输入过长，不能超过20位" )]         
        [Display( Name = "邀请码" )]        
        public string FROM_INVITATION_CODE { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户描述输入过长，不能超过50位" )]         
        [Display( Name = "用户描述" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]         
        [Display( Name = "未定义" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户昵称输入过长，不能超过100位" )]         
        [Display( Name = "用户昵称" )]        
        public string USR_NICKNAME { get; set; }
        /// <summary>
        /// 用户地域
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户地域输入过长，不能超过100位" )]         
        [Display( Name = "用户地域" )]        
        public string USR_REGION { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// ERP机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP机构代码输入过长，不能超过50位" )]         
        [Display( Name = "ERP机构代码" )]        
        public string ERP_ORG_NO { get; set; }
        /// <summary>
        /// ERP员工代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP员工代码输入过长，不能超过50位" )]         
        [Display( Name = "ERP员工代码" )]        
        public string ERP_EMP_ID { get; set; }
        /// <summary>
        /// 用户设备ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户设备ID输入过长，不能超过50位" )]         
        [Display( Name = "用户设备ID" )]        
        public string USR_DEVICE_ID { get; set; }
        /// <summary>
        /// 用户工号
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户工号输入过长，不能超过50位" )]         
        [Display( Name = "用户工号" )]        
        public string USR_EMP_NO { get; set; }
        /// <summary>
        /// 账号类型(0-NA普通账号/1-EA企业管理员/2-GA普通管理员/9-SA超级管理员)
        /// </summary>
        [StringLength( 20, ErrorMessage = "账号类型(0-NA普通账号/1-EA企业管理员/2-GA普通管理员/9-SA超级管理员)输入过长，不能超过20位" )]         
        [Display( Name = "账号类型(0-NA普通账号/1-EA企业管理员/2-GA普通管理员/9-SA超级管理员)" )]        
        public string USR_TYPE { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [Display( Name = "所属部门" )]        
        public long? DEPT_ID { get; set; }
        /// <summary>
        /// 业务来源
        /// </summary>
        [StringLength( 1000, ErrorMessage = "业务来源输入过长，不能超过1000位" )]         
        [Display( Name = "业务来源" )]        
        public string USR_BIZ_FROM { get; set; }
        /// <summary>
        /// 休眠间隔
        /// </summary>
        [Display( Name = "休眠间隔" )]        
        public long? USR_ASSIGN_SPAN { get; set; }
        /// <summary>
        /// 是否自动分配
        /// </summary>
        [Display( Name = "是否自动分配" )]        
        public long? USR_ASSIGN_AUTO { get; set; }
        /// <summary>
        /// 当前状态(0-离线/1-在线/2-离开/3-繁忙)
        /// </summary>
        [Display( Name = "当前状态(0-离线/1-在线/2-离开/3-繁忙)" )]        
        public long? USR_CURRENT_STATUS { get; set; }
        /// <summary>
        /// 心跳日期
        /// </summary>
        [Display( Name = "心跳日期" )]        
        public DateTime? BEAT_DATE { get; set; }
        /// <summary>
        /// 登录日期
        /// </summary>
        [Display( Name = "登录日期" )]        
        public DateTime? LOGIN_DATE { get; set; }
        /// <summary>
        /// 退出日期
        /// </summary>
        [Display( Name = "退出日期" )]        
        public DateTime? LOGOUT_DATE { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "供应商编码输入过长，不能超过50位" )]         
        [Display( Name = "供应商编码" )]        
        public string SUP_NO { get; set; }
        /// <summary>
        /// 用户评级
        /// </summary>
        [Display( Name = "用户评级" )]        
        public long? USR_GRADE { get; set; }
        /// <summary>
        /// 用户角色名(冗余)
        /// </summary>
        [StringLength( 2000, ErrorMessage = "用户角色名(冗余)输入过长，不能超过2000位" )]         
        [Display( Name = "用户角色名(冗余)" )]        
        public string USR_ROLE_NAMES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 500, ErrorMessage = "输入过长，不能超过500位" )]         
        [Display( Name = "UsrDesc" )]        
        public string USR_DESC { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        [StringLength( 100, ErrorMessage = "职业输入过长，不能超过100位" )]         
        [Display( Name = "职业" )]        
        public string USR_JOB { get; set; }
        /// <summary>
        /// 所属行业
        /// </summary>
        [StringLength( 100, ErrorMessage = "所属行业输入过长，不能超过100位" )]         
        [Display( Name = "所属行业" )]        
        public string USR_FIELD { get; set; }
        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [StringLength( 200, ErrorMessage = "兴趣爱好输入过长，不能超过200位" )]         
        [Display( Name = "兴趣爱好" )]        
        public string USR_HOBBY { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        [StringLength( 200, ErrorMessage = "所在地输入过长，不能超过200位" )]         
        [Display( Name = "所在地" )]        
        public string USR_LOCATION { get; set; }
        /// <summary>
        /// 二维码路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "二维码路径输入过长，不能超过200位" )]         
        [Display( Name = "二维码路径" )]        
        public string USR_QRCODE_PATH { get; set; }
        /// <summary>
        /// 最后接单日期
        /// </summary>
        [Display( Name = "最后接单日期" )]        
        public DateTime? LAST_REC_ORDER_DATE { get; set; }
        /// <summary>
        /// ERP客户编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP客户编号输入过长，不能超过50位" )]         
        [Display( Name = "ERP客户编号" )]        
        public string ERP_CUS_NO { get; set; }
        /// <summary>
        /// ERP会员编号
        /// </summary>
        [StringLength( 500, ErrorMessage = "ERP会员编号输入过长，不能超过500位" )]         
        [Display( Name = "ERP会员编号" )]        
        public string ERP_MEMBER_NO { get; set; }
        /// <summary>
        /// 用户名拼音
        /// </summary>
        [StringLength( 75, ErrorMessage = "用户名拼音输入过长，不能超过75位" )]         
        [Display( Name = "用户名拼音" )]        
        public string USR_SPELL { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 微信用户openId
        /// </summary>
        [StringLength( 200, ErrorMessage = "微信用户openId输入过长，不能超过200位" )]         
        [Display( Name = "微信用户openId" )]        
        public string OPEN_ID { get; set; }
        /// <summary>
        /// 销售顾问负责的品牌
        /// </summary>
        [StringLength( 1000, ErrorMessage = "销售顾问负责的品牌输入过长，不能超过1000位" )]         
        [Display( Name = "销售顾问负责的品牌" )]        
        public string SALE_BRANDS { get; set; }
        /// <summary>
        /// 职务编码
        /// </summary>
        [Display(Name = "职务编码")]
        public  long? DUTY_ID { get; set; }

    }
}