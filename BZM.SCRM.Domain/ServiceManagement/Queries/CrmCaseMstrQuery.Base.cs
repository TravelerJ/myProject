using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CrmCaseMstrQuery : Pager {     

        /// <summary>
        /// 事件编号
        /// </summary>
        [Display(Name="事件编号")]
        public string CASE_NO { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        [Display(Name="事件类型")]
        public decimal? CASE_TYPE { get; set; }
        /// <summary>
        /// 事件分类
        /// </summary>
        [Display(Name="事件分类")]
        public string CASE_CLASS { get; set; }
        /// <summary>
        /// 关联业务单号
        /// </summary>
        [Display(Name="关联业务单号")]
        public string REF_BIZ_NO { get; set; }
        /// <summary>
        /// 关联业务部门
        /// </summary>
        [Display(Name="关联业务部门")]
        public string REF_BIZ_DEPT { get; set; }
        /// <summary>
        /// 客户机构名称
        /// </summary>
        [Display(Name="客户机构名称")]
        public string CUS_ORG_NAME { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        [Display(Name="客户来源")]
        public string CUS_FROM { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [Display(Name="客户姓名")]
        public string CUS_NAME { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Display(Name="客户电话")]
        public string CUS_MOBILE { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [Display(Name="车牌号")]
        public string CAR_NO { get; set; }
        /// <summary>
        /// 事件来源
        /// </summary>
        [Display(Name="事件来源")]
        public string CASE_FROM { get; set; }
        /// <summary>
        /// 事件优先级
        /// </summary>
        [Display(Name="事件优先级")]
        public decimal? CASE_PRIORITY { get; set; }
        /// <summary>
        /// 事件内容
        /// </summary>
        [Display(Name="事件内容")]
        public string CASE_CONTENT { get; set; }
        /// <summary>
        /// 事件状态
        /// </summary>
        [Display(Name="事件状态")]
        public string CASE_STATUS { get; set; }
        /// <summary>
        /// 事件拥有者
        /// </summary>
        [Display(Name="事件拥有者")]
        public decimal CASE_OWNER { get; set; }
        /// <summary>
        /// 关联事件编号
        /// </summary>
        [Display(Name="关联事件编号")]
        public string REF_CASE_NO { get; set; }
        /// <summary>
        /// 预计完成日期
        /// </summary>
        [Display(Name="预计完成日期")]
        public DateTime? FCST_FINISH_DATE { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Display(Name="联系手机")]
        public string CONTRACT_MOBILE { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        [Display(Name="联系邮箱")]
        public string CONTRACT_EMAIL { get; set; }
        /// <summary>
        /// 满意度调查结果
        /// </summary>
        [Display(Name="满意度调查结果")]
        public string CSI_RESULT { get; set; }
        /// <summary>
        /// 满意度调查结果原因
        /// </summary>
        [Display(Name="满意度调查结果原因")]
        public string CSI_RSN { get; set; }
        /// <summary>
        /// 接单日期
        /// </summary>
        [Display(Name="接单日期")]
        public DateTime CASE_DATE { get; set; }
        /// <summary>
        /// 事件地点
        /// </summary>
        [Display(Name="事件地点")]
        public string CASE_WHERE { get; set; }
        /// <summary>
        /// 事件原因
        /// </summary>
        [Display(Name="事件原因")]
        public string CASE_REASON { get; set; }
        /// <summary>
        /// 调查结果
        /// </summary>
        [Display(Name="调查结果")]
        public string CASE_RESULT { get; set; }
        /// <summary>
        /// 客户处理结果
        /// </summary>
        [Display(Name="客户处理结果")]
        public string CUS_RESULT { get; set; }
        /// <summary>
        /// 事件处理方案
        /// </summary>
        [Display(Name="事件处理方案")]
        public string CASE_SOLUTION { get; set; }
        /// <summary>
        /// 费用账号
        /// </summary>
        [Display(Name="费用账号")]
        public string EXPENSE_ACCT_NO { get; set; }
        /// <summary>
        /// 费用开户行
        /// </summary>
        [Display(Name="费用开户行")]
        public string EXPENSE_BANK { get; set; }
        /// <summary>
        /// 费用户名
        /// </summary>
        [Display(Name="费用户名")]
        public string EXPENSE_ACCT_NAME { get; set; }
        /// <summary>
        /// 费用金额
        /// </summary>
        [Display(Name="费用金额")]
        public decimal? EXPENSE_AMT { get; set; }
        /// <summary>
        /// 充值手机
        /// </summary>
        [Display(Name="充值手机")]
        public string CHARGE_MOBILE { get; set; }
        /// <summary>
        /// 礼品名称
        /// </summary>
        [Display(Name="礼品名称")]
        public string GIFT_NAME { get; set; }
        /// <summary>
        /// 礼品邮寄地址
        /// </summary>
        [Display(Name="礼品邮寄地址")]
        public string GIFT_ADDR { get; set; }
        /// <summary>
        /// 事件责任人
        /// </summary>
        [Display(Name="事件责任人")]
        public string RESPONSIBLE_PSN { get; set; }
        /// <summary>
        /// 事件责任人承担
        /// </summary>
        [Display(Name="事件责任人承担")]
        public decimal? RESPONSIBLE_PSN_PAY { get; set; }
        /// <summary>
        /// 附件1
        /// </summary>
        [Display(Name="附件1")]
        public string ATTACHMENT_PATH1 { get; set; }
        /// <summary>
        /// 附件2
        /// </summary>
        [Display(Name="附件2")]
        public string ATTACHMENT_PATH2 { get; set; }
        /// <summary>
        /// 附件3
        /// </summary>
        [Display(Name="附件3")]
        public string ATTACHMENT_PATH3 { get; set; }
        /// <summary>
        /// 附件4
        /// </summary>
        [Display(Name="附件4")]
        public string ATTACHMENT_PATH4 { get; set; }
        /// <summary>
        /// 附件5
        /// </summary>
        [Display(Name="附件5")]
        public string ATTACHMENT_PATH5 { get; set; }
        /// <summary>
        /// 工作流编号
        /// </summary>
        [Display(Name="工作流编号")]
        public string WORKFLOW_NO { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
    }
}