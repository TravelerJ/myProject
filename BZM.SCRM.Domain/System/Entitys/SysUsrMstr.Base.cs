using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys {
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class SysUsrMstr : Entity<decimal> {       

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength( 50, ErrorMessage = "用户名输入过长，不能超过50位" )]
        public virtual string USR_NAME { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "用户密码不能为空")]
        [StringLength( 50, ErrorMessage = "用户密码输入过长，不能超过50位" )]
        public virtual string USR_PWD { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [Required(ErrorMessage = "用户状态不能为空")]
        public virtual decimal USR_STATUS { get; set; }
        /// <summary>
        ///  是否有头像1=已上传 0=未上传 
        /// </summary>
        public virtual decimal? USR_AVATAR_STATUS { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        [Required(ErrorMessage = "注册日期不能为空")]
        public virtual DateTime USR_REG_DATE { get; set; }
        /// <summary>
        /// 所属机构代码
        /// </summary>
        [Required(ErrorMessage = "所属机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "所属机构代码输入过长，不能超过50位" )]
        public virtual string ORG_NO { get; set; }
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
        /// 真实姓名
        /// </summary>
        [StringLength( 100, ErrorMessage = "真实姓名输入过长，不能超过100位" )]
        public virtual string USR_REAL_NAME { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        [StringLength( 20, ErrorMessage = "用户手机输入过长，不能超过20位" )]
        public virtual string USR_MOBILE { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户邮箱输入过长，不能超过50位" )]
        public virtual string USR_EMAIL { get; set; }
        /// <summary>
        /// 手机认证(0-未认证/1-已认证)
        /// </summary>
        public virtual long? USR_MOBILE_PASS { get; set; }
        /// <summary>
        /// 图像路径
        /// </summary>
        [StringLength( 100, ErrorMessage = "图像路径输入过长，不能超过100位" )]
        public virtual string USR_AVATAR_PATH { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        [StringLength( 50, ErrorMessage = "支付宝账号输入过长，不能超过50位" )]
        public virtual string USR_ALIPAY { get; set; }
        /// <summary>
        /// 邀请码
        /// </summary>
        [StringLength( 20, ErrorMessage = "邀请码输入过长，不能超过20位" )]
        public virtual string INVITATION_CODE { get; set; }
        /// <summary>
        /// 来源渠道
        /// </summary>
        [StringLength( 50, ErrorMessage = "来源渠道输入过长，不能超过50位" )]
        public virtual string FROM_CHANNEL { get; set; }
        /// <summary>
        /// 邀请码
        /// </summary>
        [StringLength( 20, ErrorMessage = "邀请码输入过长，不能超过20位" )]
        public virtual string FROM_INVITATION_CODE { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户描述输入过长，不能超过50位" )]
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
        /// 用户昵称
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户昵称输入过长，不能超过100位" )]
        public virtual string USR_NICKNAME { get; set; }
        /// <summary>
        /// 用户地域
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户地域输入过长，不能超过100位" )]
        public virtual string USR_REGION { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// ERP机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP机构代码输入过长，不能超过50位" )]
        public virtual string ERP_ORG_NO { get; set; }
        /// <summary>
        /// ERP员工代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP员工代码输入过长，不能超过50位" )]
        public virtual string ERP_EMP_ID { get; set; }
        /// <summary>
        /// 用户设备ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户设备ID输入过长，不能超过50位" )]
        public virtual string USR_DEVICE_ID { get; set; }
        /// <summary>
        /// 用户工号
        /// </summary>
        [StringLength( 50, ErrorMessage = "用户工号输入过长，不能超过50位" )]
        public virtual string USR_EMP_NO { get; set; }
        /// <summary>
        /// 账号类型(0-NA普通账号/1-EA企业管理员/2-GA普通管理员/9-SA超级管理员)
        /// </summary>
        [StringLength( 20, ErrorMessage = "账号类型(0-NA普通账号/1-EA企业管理员/2-GA普通管理员/9-SA超级管理员)输入过长，不能超过20位" )]
        public virtual string USR_TYPE { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual long? DEPT_ID { get; set; }
        /// <summary>
        /// 业务来源
        /// </summary>
        [StringLength( 1000, ErrorMessage = "业务来源输入过长，不能超过1000位" )]
        public virtual string USR_BIZ_FROM { get; set; }
        /// <summary>
        /// 休眠间隔
        /// </summary>
        public virtual long? USR_ASSIGN_SPAN { get; set; }
        /// <summary>
        /// 是否自动分配
        /// </summary>
        public virtual long? USR_ASSIGN_AUTO { get; set; }
        /// <summary>
        /// 当前状态(0-离线/1-在线/2-离开/3-繁忙)
        /// </summary>
        public virtual long? USR_CURRENT_STATUS { get; set; }
        /// <summary>
        /// 心跳日期
        /// </summary>
        public virtual DateTime? BEAT_DATE { get; set; }
        /// <summary>
        /// 登录日期
        /// </summary>
        public virtual DateTime? LOGIN_DATE { get; set; }
        /// <summary>
        /// 退出日期
        /// </summary>
        public virtual DateTime? LOGOUT_DATE { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "供应商编码输入过长，不能超过50位" )]
        public virtual string SUP_NO { get; set; }
        /// <summary>
        /// 用户评级
        /// </summary>
        public virtual long? USR_GRADE { get; set; }
        /// <summary>
        /// 用户角色名(冗余)
        /// </summary>
        [StringLength( 2000, ErrorMessage = "用户角色名(冗余)输入过长，不能超过2000位" )]
        public virtual string USR_ROLE_NAMES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 500, ErrorMessage = "输入过长，不能超过500位" )]
        public virtual string USR_DESC { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        [StringLength( 100, ErrorMessage = "职业输入过长，不能超过100位" )]
        public virtual string USR_JOB { get; set; }
        /// <summary>
        /// 所属行业
        /// </summary>
        [StringLength( 100, ErrorMessage = "所属行业输入过长，不能超过100位" )]
        public virtual string USR_FIELD { get; set; }
        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [StringLength( 200, ErrorMessage = "兴趣爱好输入过长，不能超过200位" )]
        public virtual string USR_HOBBY { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        [StringLength( 200, ErrorMessage = "所在地输入过长，不能超过200位" )]
        public virtual string USR_LOCATION { get; set; }
        /// <summary>
        /// 二维码路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "二维码路径输入过长，不能超过200位" )]
        public virtual string USR_QRCODE_PATH { get; set; }
        /// <summary>
        /// 最后接单日期
        /// </summary>
        public virtual DateTime? LAST_REC_ORDER_DATE { get; set; }
        /// <summary>
        /// ERP客户编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP客户编号输入过长，不能超过50位" )]
        public virtual string ERP_CUS_NO { get; set; }
        /// <summary>
        /// ERP会员编号
        /// </summary>
        [StringLength( 500, ErrorMessage = "ERP会员编号输入过长，不能超过500位" )]
        public virtual string ERP_MEMBER_NO { get; set; }
        /// <summary>
        /// 用户名拼音
        /// </summary>
        [StringLength( 75, ErrorMessage = "用户名拼音输入过长，不能超过75位" )]
        public virtual string USR_SPELL { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 微信用户openId
        /// </summary>
        [StringLength( 200, ErrorMessage = "微信用户openId输入过长，不能超过200位" )]
        public virtual string OPEN_ID { get; set; }
        /// <summary>
        /// 销售顾问负责的品牌
        /// </summary>
        [StringLength( 1000, ErrorMessage = "销售顾问负责的品牌输入过长，不能超过1000位" )]
        public virtual string SALE_BRANDS { get; set; }
        /// <summary>
        /// 职务编码
        /// </summary>
        public virtual long? DUTY_ID { get; set; }
    }
}