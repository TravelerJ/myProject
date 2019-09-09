using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 表扬/投诉表
    /// </summary>
    public partial class CrmCaseMstr : Entity<string> {       

        /// <summary>
        /// 事件类型
        /// </summary>
        [Required(ErrorMessage = "事件类型不能为空")]
        public virtual decimal CASE_TYPE { get; set; }
        /// <summary>
        /// 事件分类
        /// </summary>
        [StringLength( 500, ErrorMessage = "事件分类输入过长，不能超过500位" )]
        public virtual string CASE_CLASS { get; set; }
        /// <summary>
        /// 关联业务单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联业务单号输入过长，不能超过50位" )]
        public virtual string REF_BIZ_NO { get; set; }
        /// <summary>
        /// 关联业务部门
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联业务部门输入过长，不能超过50位" )]
        public virtual string REF_BIZ_DEPT { get; set; }
        /// <summary>
        /// 客户机构名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "客户机构名称输入过长，不能超过50位" )]
        public virtual string CUS_ORG_NAME { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        [StringLength( 50, ErrorMessage = "客户来源输入过长，不能超过50位" )]
        public virtual string CUS_FROM { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [StringLength( 50, ErrorMessage = "客户姓名输入过长，不能超过50位" )]
        public virtual string CUS_NAME { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [StringLength( 20, ErrorMessage = "客户电话输入过长，不能超过20位" )]
        public virtual string CUS_MOBILE { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [StringLength( 20, ErrorMessage = "车牌号输入过长，不能超过20位" )]
        public virtual string CAR_NO { get; set; }
        /// <summary>
        /// 事件来源
        /// </summary>
        [StringLength( 50, ErrorMessage = "事件来源输入过长，不能超过50位" )]
        public virtual string CASE_FROM { get; set; }
        /// <summary>
        /// 事件优先级
        /// </summary>
        public virtual decimal? CASE_PRIORITY { get; set; }
        /// <summary>
        /// 事件内容
        /// </summary>
        [StringLength( 4000, ErrorMessage = "事件内容输入过长，不能超过4000位" )]
        public virtual string CASE_CONTENT { get; set; }
        /// <summary>
        /// 事件状态
        /// </summary>
        [Required(ErrorMessage = "事件状态不能为空")]
        [StringLength( 10, ErrorMessage = "事件状态输入过长，不能超过10位" )]
        public virtual string CASE_STATUS { get; set; }
        /// <summary>
        /// 事件拥有者
        /// </summary>
        [Required(ErrorMessage = "事件拥有者不能为空")]
        public virtual decimal CASE_OWNER { get; set; }
        /// <summary>
        /// 关联事件编号
        /// </summary>
        [StringLength( 200, ErrorMessage = "关联事件编号输入过长，不能超过200位" )]
        public virtual string REF_CASE_NO { get; set; }
        /// <summary>
        /// 预计完成日期
        /// </summary>
        public virtual DateTime? FCST_FINISH_DATE { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        [StringLength( 20, ErrorMessage = "联系手机输入过长，不能超过20位" )]
        public virtual string CONTRACT_MOBILE { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        [StringLength( 100, ErrorMessage = "联系邮箱输入过长，不能超过100位" )]
        public virtual string CONTRACT_EMAIL { get; set; }
        /// <summary>
        /// 满意度调查结果
        /// </summary>
        [StringLength( 50, ErrorMessage = "满意度调查结果输入过长，不能超过50位" )]
        public virtual string CSI_RESULT { get; set; }
        /// <summary>
        /// 满意度调查结果原因
        /// </summary>
        [StringLength( 200, ErrorMessage = "满意度调查结果原因输入过长，不能超过200位" )]
        public virtual string CSI_RSN { get; set; }
        /// <summary>
        /// 接单日期
        /// </summary>
        [Required(ErrorMessage = "接单日期不能为空")]
        public virtual DateTime CASE_DATE { get; set; }
        /// <summary>
        /// 事件地点
        /// </summary>
        [StringLength( 200, ErrorMessage = "事件地点输入过长，不能超过200位" )]
        public virtual string CASE_WHERE { get; set; }
        /// <summary>
        /// 事件原因
        /// </summary>
        [StringLength( 200, ErrorMessage = "事件原因输入过长，不能超过200位" )]
        public virtual string CASE_REASON { get; set; }
        /// <summary>
        /// 调查结果
        /// </summary>
        [StringLength( 4000, ErrorMessage = "调查结果输入过长，不能超过4000位" )]
        public virtual string CASE_RESULT { get; set; }
        /// <summary>
        /// 客户处理结果
        /// </summary>
        [StringLength( 4000, ErrorMessage = "客户处理结果输入过长，不能超过4000位" )]
        public virtual string CUS_RESULT { get; set; }
        /// <summary>
        /// 事件处理方案
        /// </summary>
        [StringLength( 100, ErrorMessage = "事件处理方案输入过长，不能超过100位" )]
        public virtual string CASE_SOLUTION { get; set; }
        /// <summary>
        /// 费用账号
        /// </summary>
        [StringLength( 50, ErrorMessage = "费用账号输入过长，不能超过50位" )]
        public virtual string EXPENSE_ACCT_NO { get; set; }
        /// <summary>
        /// 费用开户行
        /// </summary>
        [StringLength( 50, ErrorMessage = "费用开户行输入过长，不能超过50位" )]
        public virtual string EXPENSE_BANK { get; set; }
        /// <summary>
        /// 费用户名
        /// </summary>
        [StringLength( 50, ErrorMessage = "费用户名输入过长，不能超过50位" )]
        public virtual string EXPENSE_ACCT_NAME { get; set; }
        /// <summary>
        /// 费用金额
        /// </summary>
        public virtual decimal? EXPENSE_AMT { get; set; }
        /// <summary>
        /// 充值手机
        /// </summary>
        [StringLength( 20, ErrorMessage = "充值手机输入过长，不能超过20位" )]
        public virtual string CHARGE_MOBILE { get; set; }
        /// <summary>
        /// 礼品名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "礼品名称输入过长，不能超过100位" )]
        public virtual string GIFT_NAME { get; set; }
        /// <summary>
        /// 礼品邮寄地址
        /// </summary>
        [StringLength( 200, ErrorMessage = "礼品邮寄地址输入过长，不能超过200位" )]
        public virtual string GIFT_ADDR { get; set; }
        /// <summary>
        /// 事件责任人
        /// </summary>
        [StringLength( 50, ErrorMessage = "事件责任人输入过长，不能超过50位" )]
        public virtual string RESPONSIBLE_PSN { get; set; }
        /// <summary>
        /// 事件责任人承担
        /// </summary>
        public virtual decimal? RESPONSIBLE_PSN_PAY { get; set; }
        /// <summary>
        /// 附件1
        /// </summary>
        [StringLength( 100, ErrorMessage = "附件1输入过长，不能超过100位" )]
        public virtual string ATTACHMENT_PATH1 { get; set; }
        /// <summary>
        /// 附件2
        /// </summary>
        [StringLength( 100, ErrorMessage = "附件2输入过长，不能超过100位" )]
        public virtual string ATTACHMENT_PATH2 { get; set; }
        /// <summary>
        /// 附件3
        /// </summary>
        [StringLength( 100, ErrorMessage = "附件3输入过长，不能超过100位" )]
        public virtual string ATTACHMENT_PATH3 { get; set; }
        /// <summary>
        /// 附件4
        /// </summary>
        [StringLength( 100, ErrorMessage = "附件4输入过长，不能超过100位" )]
        public virtual string ATTACHMENT_PATH4 { get; set; }
        /// <summary>
        /// 附件5
        /// </summary>
        [StringLength( 100, ErrorMessage = "附件5输入过长，不能超过100位" )]
        public virtual string ATTACHMENT_PATH5 { get; set; }
        /// <summary>
        /// 工作流编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "工作流编号输入过长，不能超过50位" )]
        public virtual string WORKFLOW_NO { get; set; }
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
        [StringLength( 100, ErrorMessage = "未定义字段输入过长，不能超过100位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义字段输入过长，不能超过100位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义字段输入过长，不能超过100位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义字段输入过长，不能超过100位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义字段输入过长，不能超过100位" )]
        public virtual string UDF10 { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Required(ErrorMessage = "数据删除标志(1-有效/0-已删除)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}