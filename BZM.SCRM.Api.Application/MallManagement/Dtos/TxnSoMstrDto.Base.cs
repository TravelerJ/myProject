using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TxnSoMstrDto : EntityDto<string> {    

        /// <summary>
        /// 工单类型（估价单、工单）
        /// </summary>
        [StringLength( 20, ErrorMessage = "工单类型（估价单、工单）输入过长，不能超过20位" )]         
        [Display( Name = "工单类型（估价单、工单）" )]        
        public string SO_TYPE { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        [StringLength( 2, ErrorMessage = "业务类型输入过长，不能超过2位" )]         
        [Display( Name = "业务类型" )]        
        public string BIZ_TYPE { get; set; }
        /// <summary>
        /// 销售类型
        /// </summary>
                 
        [Display( Name = "销售类型" )]        
        public long SALE_TYPE { get; set; }
        /// <summary>
        /// 机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "机构代码输入过长，不能超过50位" )]         
        [Display( Name = "机构代码" )]        
        public string ORG_NO { get; set; }
        /// <summary>
        /// 预约单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "预约单号输入过长，不能超过50位" )]         
        [Display( Name = "预约单号" )]        
        public string BOOK_NO { get; set; }
        /// <summary>
        /// 参考单号
        /// </summary>
        [StringLength( 20, ErrorMessage = "参考单号输入过长，不能超过20位" )]         
        [Display( Name = "参考单号" )]        
        public string REF_NO { get; set; }
        /// <summary>
        /// 排队号
        /// </summary>
        [StringLength( 20, ErrorMessage = "排队号输入过长，不能超过20位" )]         
        [Display( Name = "排队号" )]        
        public string QUEUE_NO { get; set; }
        /// <summary>
        /// 服务顾问
        /// </summary>
        [StringLength( 100, ErrorMessage = "服务顾问输入过长，不能超过100位" )]         
        [Display( Name = "服务顾问" )]        
        public string SA { get; set; }
        /// <summary>
        /// 服务顾问名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "服务顾问名称输入过长，不能超过200位" )]         
        [Display( Name = "服务顾问名称" )]        
        public string SA_NAME { get; set; }
        /// <summary>
        /// 销售组
        /// </summary>
        [StringLength( 20, ErrorMessage = "销售组输入过长，不能超过20位" )]         
        [Display( Name = "销售组" )]        
        public string SALE_TEAM { get; set; }
        /// <summary>
        /// 销售员
        /// </summary>
        [Display( Name = "销售员" )]        
        public double? SALE_PSN { get; set; }
        /// <summary>
        /// 历史单号
        /// </summary>
        [StringLength( 20, ErrorMessage = "历史单号输入过长，不能超过20位" )]         
        [Display( Name = "历史单号" )]        
        public string OLD_SO_NO { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "客户编号输入过长，不能超过50位" )]         
        [Display( Name = "客户编号" )]        
        public string CUS_NO { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "客户名称输入过长，不能超过100位" )]         
        [Display( Name = "客户名称" )]        
        public string CUS_NAME { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        [StringLength( 20, ErrorMessage = "会员编号输入过长，不能超过20位" )]         
        [Display( Name = "会员编号" )]        
        public string MEMBER_NO { get; set; }
        /// <summary>
        /// 车票号
        /// </summary>
        [StringLength( 20, ErrorMessage = "车票号输入过长，不能超过20位" )]         
        [Display( Name = "车票号" )]        
        public string CARID { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        [StringLength( 50, ErrorMessage = "车架号输入过长，不能超过50位" )]         
        [Display( Name = "车架号" )]        
        public string VIN { get; set; }
        /// <summary>
        /// 进厂里程
        /// </summary>
        [Display( Name = "进厂里程" )]        
        public decimal? IN_MILEAGE { get; set; }
        /// <summary>
        /// 下次保养里程
        /// </summary>
        [Display( Name = "下次保养里程" )]        
        public decimal? NEXT_MMILEAGE { get; set; }
        /// <summary>
        /// 下次保养日期
        /// </summary>
        [Display( Name = "下次保养日期" )]        
        public DateTime? NEXT_MDATE { get; set; }
        /// <summary>
        /// 本次油表
        /// </summary>
        [StringLength( 10, ErrorMessage = "本次油表输入过长，不能超过10位" )]         
        [Display( Name = "本次油表" )]        
        public string IN_OIL { get; set; }
        /// <summary>
        /// 预计交车日期
        /// </summary>
        [Display( Name = "预计交车日期" )]        
        public DateTime? FCST_DELIVERY_DATE { get; set; }
        /// <summary>
        /// 是否旧料退回
        /// </summary>
        [Display( Name = "是否旧料退回" )]        
        public double? IS_RTN_OLD_MATERIAL { get; set; }
        /// <summary>
        /// 客户描述
        /// </summary>
        [StringLength( 200, ErrorMessage = "客户描述输入过长，不能超过200位" )]         
        [Display( Name = "客户描述" )]        
        public string CUSTOMER_DESC { get; set; }
        /// <summary>
        /// 维修建议
        /// </summary>
        [StringLength( 500, ErrorMessage = "维修建议输入过长，不能超过500位" )]         
        [Display( Name = "维修建议" )]        
        public string MADVICE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]         
        [Display( Name = "备注" )]        
        public string REMARK { get; set; }
        /// <summary>
        /// 原价金额
        /// </summary>
                 
        [Display( Name = "原价金额" )]        
        public decimal SO_AMT { get; set; }
        /// <summary>
        /// 材料金额
        /// </summary>
                 
        [Display( Name = "材料金额" )]        
        public decimal MATERIAL_AMT { get; set; }
        /// <summary>
        /// 工时金额
        /// </summary>
                 
        [Display( Name = "工时金额" )]        
        public decimal MH_AMT { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
                 
        [Display( Name = "折扣率" )]        
        public decimal DISCOUNT_RATE { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
                 
        [Display( Name = "折扣金额" )]        
        public decimal DISCOUNT_AMT { get; set; }
        /// <summary>
        /// 减免金额
        /// </summary>
                 
        [Display( Name = "减免金额" )]        
        public decimal EXEMPT_AMT { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
                 
        [Display( Name = "应收金额" )]        
        public decimal YS_AMT { get; set; }
        /// <summary>
        /// 实收会员储值
        /// </summary>
        [Display( Name = "实收会员储值" )]        
        public decimal? SS_MCARD { get; set; }
        /// <summary>
        /// 实收代金券
        /// </summary>
        [Display( Name = "实收代金券" )]        
        public decimal? SS_COUPON { get; set; }
        /// <summary>
        /// 实收次卡
        /// </summary>
        [Display( Name = "实收次卡" )]        
        public decimal? SS_SERVICE_CARD { get; set; }
        /// <summary>
        /// 实收积分
        /// </summary>
        [Display( Name = "实收积分" )]        
        public decimal? SS_SCORE { get; set; }
        /// <summary>
        /// 抹零金额
        /// </summary>
        [Display( Name = "抹零金额" )]        
        public decimal? WIPE_ZERO_AMT { get; set; }
        /// <summary>
        /// 是否挂账
        /// </summary>
        [Display( Name = "是否挂账" )]        
        public long? IS_CREDIT { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        [Display( Name = "是否打印" )]        
        public long? IS_PRINT { get; set; }
        /// <summary>
        /// 打印日期
        /// </summary>
        [Display( Name = "打印日期" )]        
        public DateTime? PRINT_DATE { get; set; }
        /// <summary>
        /// 工作流单号
        /// </summary>
        [StringLength( 20, ErrorMessage = "工作流单号输入过长，不能超过20位" )]         
        [Display( Name = "工作流单号" )]        
        public string WORKFLOW_NO { get; set; }
        /// <summary>
        /// 保险公司
        /// </summary>
        [StringLength( 50, ErrorMessage = "保险公司输入过长，不能超过50位" )]         
        [Display( Name = "保险公司" )]        
        public string INS_COMPANY { get; set; }
        /// <summary>
        /// 送修人
        /// </summary>
        [StringLength( 200, ErrorMessage = "送修人输入过长，不能超过200位" )]         
        [Display( Name = "送修人" )]        
        public string CONSIGNER { get; set; }
        /// <summary>
        /// 送修人电话
        /// </summary>
        [StringLength( 50, ErrorMessage = "送修人电话输入过长，不能超过50位" )]         
        [Display( Name = "送修人电话" )]        
        public string CONSIGNER_PHONE { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        [Display( Name = "是否开票" )]        
        public long? IS_INVOICE { get; set; }
        /// <summary>
        /// 完工时间
        /// </summary>
        [Display( Name = "完工时间" )]        
        public DateTime? PROCS_FINISH_TIME { get; set; }
        /// <summary>
        /// 完工人
        /// </summary>
        [Display( Name = "完工人" )]        
        public long? PROCS_FINISH_PSN { get; set; }
        /// <summary>
        /// 委外加工方
        /// </summary>
        [StringLength( 20, ErrorMessage = "委外加工方输入过长，不能超过20位" )]         
        [Display( Name = "委外加工方" )]        
        public string PROCS_ORG_NO { get; set; }
        /// <summary>
        /// 是否红单
        /// </summary>
        [Display( Name = "是否红单" )]        
        public long? IS_RED { get; set; }
        /// <summary>
        /// 是否回访
        /// </summary>
        [Display( Name = "是否回访" )]        
        public long? IS_RVISIT { get; set; }
        /// <summary>
        /// 内返日期
        /// </summary>
        [Display( Name = "内返日期" )]        
        public DateTime? REWORK_DATE { get; set; }
        /// <summary>
        /// 内返操作人
        /// </summary>
        [Display( Name = "内返操作人" )]        
        public long? REWORK_PSN { get; set; }
        /// <summary>
        /// 工单明细版本号
        /// </summary>
        [StringLength( 36, ErrorMessage = "工单明细版本号输入过长，不能超过36位" )]         
        [Display( Name = "工单明细版本号" )]        
        public string ITEM_SYNC_VERSION { get; set; }
        /// <summary>
        /// 是否结果填报
        /// </summary>
        [Display( Name = "是否结果填报" )]        
        public decimal? IS_RESULT_REPORT { get; set; }
        /// <summary>
        /// 是否在店等候
        /// </summary>
        [StringLength( 20, ErrorMessage = "是否在店等候输入过长，不能超过20位" )]         
        [Display( Name = "是否在店等候" )]        
        public string IS_WAIT { get; set; }
        /// <summary>
        /// 预诊断结果
        /// </summary>
        [StringLength( 100, ErrorMessage = "预诊断结果输入过长，不能超过100位" )]         
        [Display( Name = "预诊断结果" )]        
        public string PRE_DIAGNOSIS_RESULT { get; set; }
        /// <summary>
        /// 辅助字段1
        /// </summary>
        [StringLength( 100, ErrorMessage = "辅助字段1输入过长，不能超过100位" )]         
        [Display( Name = "辅助字段1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 辅助字段2
        /// </summary>
        [StringLength( 100, ErrorMessage = "辅助字段2输入过长，不能超过100位" )]         
        [Display( Name = "辅助字段2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 辅助字段3
        /// </summary>
        [StringLength( 100, ErrorMessage = "辅助字段3输入过长，不能超过100位" )]         
        [Display( Name = "辅助字段3" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 辅助字段4
        /// </summary>
        [StringLength( 100, ErrorMessage = "辅助字段4输入过长，不能超过100位" )]         
        [Display( Name = "辅助字段4" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 辅助字段5
        /// </summary>
        [StringLength( 100, ErrorMessage = "辅助字段5输入过长，不能超过100位" )]         
        [Display( Name = "辅助字段5" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 是否对账
        /// </summary>
        [Display( Name = "是否对账" )]        
        public long? IS_AS { get; set; }
        /// <summary>
        /// 结算人
        /// </summary>
        [Display( Name = "结算人" )]        
        public long? SETTLE_PSN { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        [Display( Name = "结算日期" )]        
        public DateTime? SETTLE_DATE { get; set; }
        /// <summary>
        /// 结算金额(客户付费)
        /// </summary>
        [Display( Name = "结算金额(客户付费)" )]        
        public decimal? SETTLE_CUS_AMT { get; set; }
        /// <summary>
        /// 结算金额(厂家付费)
        /// </summary>
        [Display( Name = "结算金额(厂家付费)" )]        
        public decimal? SETTLE_MFG_AMT { get; set; }
        /// <summary>
        /// 结算金额(第三方付费)
        /// </summary>
        [Display( Name = "结算金额(第三方付费)" )]        
        public decimal? SETTLE_3RD_AMT { get; set; }
        /// <summary>
        /// 结算金额(内部付费)
        /// </summary>
        [Display( Name = "结算金额(内部付费)" )]        
        public decimal? SETTLE_INNER_AMT { get; set; }
        /// <summary>
        /// 获取积分
        /// </summary>
        [Display( Name = "获取积分" )]        
        public long? GET_SCORE { get; set; }
        /// <summary>
        /// 厂家编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "厂家编码输入过长，不能超过50位" )]         
        [Display( Name = "厂家编码" )]        
        public string MFG_NO { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "厂家名称输入过长，不能超过100位" )]         
        [Display( Name = "厂家名称" )]        
        public string MFG_NAME { get; set; }
        /// <summary>
        /// 委外机构编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "委外机构编码输入过长，不能超过50位" )]         
        [Display( Name = "委外机构编码" )]        
        public string CONSIGN_ORG_NO { get; set; }
        /// <summary>
        /// 委外机构名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "委外机构名称输入过长，不能超过200位" )]         
        [Display( Name = "委外机构名称" )]        
        public string CONSIGN_ORG_NAME { get; set; }
        /// <summary>
        /// 结算确认
        /// </summary>
        [Display( Name = "结算确认" )]        
        public long? AR_CONFIRM { get; set; }
        /// <summary>
        /// 结算确认日期
        /// </summary>
        [Display( Name = "结算确认日期" )]        
        public DateTime? AR_CONFIRM_DATE { get; set; }
        /// <summary>
        /// 结算确认人
        /// </summary>
        [Display( Name = "结算确认人" )]        
        public long? AR_CONFIRM_PSN { get; set; }
        /// <summary>
        /// 同步标志位
        /// </summary>
        [StringLength( 30, ErrorMessage = "同步标志位输入过长，不能超过30位" )]         
        [Display( Name = "同步标志位" )]        
        public string SYNC_FLAG { get; set; }
        /// <summary>
        /// 销售订单状态
        /// </summary>
        [StringLength( 50, ErrorMessage = "销售订单状态输入过长，不能超过50位" )]         
        [Display( Name = "销售订单状态" )]        
        public string STATUS { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 索赔单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "索赔单号输入过长，不能超过50位" )]         
        [Display( Name = "索赔单号" )]        
        public string CLAIM_NO { get; set; }
        /// <summary>
        /// 索赔厂商编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "索赔厂商编码输入过长，不能超过50位" )]         
        [Display( Name = "索赔厂商编码" )]        
        public string CLAIM_SP_NO { get; set; }
        /// <summary>
        /// 索赔厂商名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "索赔厂商名称输入过长，不能超过100位" )]         
        [Display( Name = "索赔厂商名称" )]        
        public string CLAIM_SP_NAME { get; set; }
        /// <summary>
        /// 原厂单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "原厂单号输入过长，不能超过50位" )]         
        [Display( Name = "原厂单号" )]        
        public string SP_CLAIM_NO { get; set; }
        /// <summary>
        /// 申报时间
        /// </summary>
        [Display( Name = "申报时间" )]        
        public DateTime? CLAIM_DECLARE_TIME { get; set; }
        /// <summary>
        /// 申报人ID
        /// </summary>
        [Display( Name = "申报人ID" )]        
        public decimal? CLAIM_DECLARE_PSN_ID { get; set; }
        /// <summary>
        /// 申报人名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "申报人名称输入过长，不能超过50位" )]         
        [Display( Name = "申报人名称" )]        
        public string CLAIM_DECLARE_PSN_NAME { get; set; }
        /// <summary>
        /// 确认时间
        /// </summary>
        [StringLength( 50, ErrorMessage = "确认时间输入过长，不能超过50位" )]         
        [Display( Name = "确认时间" )]        
        public string CLAIM_CONFIRM_DATE { get; set; }
        /// <summary>
        /// 确认人
        /// </summary>
        [StringLength( 50, ErrorMessage = "确认人输入过长，不能超过50位" )]         
        [Display( Name = "确认人" )]        
        public string CLAIM_CONFIRM_PSN { get; set; }
        /// <summary>
        /// 索赔金额
        /// </summary>
        [Display( Name = "索赔金额" )]        
        public decimal? CLAIM_AMT { get; set; }
        /// <summary>
        /// 索赔状态
        /// </summary>
        [StringLength( 50, ErrorMessage = "索赔状态输入过长，不能超过50位" )]         
        [Display( Name = "索赔状态" )]        
        public string CLAIM_STATUS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "备注输入过长，不能超过100位" )]         
        [Display( Name = "备注" )]        
        public string CLAIM_RMK { get; set; }
        /// <summary>
        /// 货运单号
        /// </summary>
        [StringLength( 100, ErrorMessage = "货运单号输入过长，不能超过100位" )]         
        [Display( Name = "货运单号" )]        
        public string EXPRESS_NO { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        [StringLength( 50, ErrorMessage = "配送方式输入过长，不能超过50位" )]         
        [Display( Name = "配送方式" )]        
        public string DELIVERY_TYPE { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [StringLength( 50, ErrorMessage = "支付方式输入过长，不能超过50位" )]         
        [Display( Name = "支付方式" )]        
        public string PAY_TYPE { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        [StringLength( 50, ErrorMessage = "发票类型输入过长，不能超过50位" )]         
        [Display( Name = "发票类型" )]        
        public string INVOICE_TYPE { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        [StringLength( 50, ErrorMessage = "发票抬头输入过长，不能超过50位" )]         
        [Display( Name = "发票抬头" )]        
        public string INVOICE_TITLE { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [StringLength( 75, ErrorMessage = "商户订单号输入过长，不能超过75位" )]         
        [Display( Name = "商户订单号" )]        
        public string SO_ORDERNO { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 是否推送成功
        /// </summary>
        [Display( Name = "是否推送成功" )]        
        public long? IS_PUSH { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [StringLength( 200, ErrorMessage = "微信订单号输入过长，不能超过200位" )]         
        [Display( Name = "微信订单号" )]        
        public string WX_SO_ORDERNO { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        [StringLength( 30, ErrorMessage = "结算方式输入过长，不能超过30位" )]         
        [Display( Name = "结算方式" )]        
        public string SETTLE_WAY { get; set; }
        
    }
}