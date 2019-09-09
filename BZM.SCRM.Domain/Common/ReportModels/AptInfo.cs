using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 预约model
    /// </summary>
    public class AptInfo
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string smsCode { get; set; }
        /// <summary>
        /// 验证码编号
        /// </summary>
        public string msgId { get; set; }
        /// <summary>
        /// 预约配置人数
        /// </summary>
        public int aptConfigNum { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string orgNo { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public decimal USR_ID { get; set; }
        /// <summary>
        /// 微信openId
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 预约类别(1.售前，2.售后)
        /// </summary>
        public int APT_TYPE { get; set; }
        /// <summary>
        /// 预约类别
        /// </summary>
        public string APT_CLASS { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 客户手机
        /// </summary>
        public string CUS_PHONE_NO { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime APT_DATE { get; set; }
        /// <summary>
        /// 预约时段
        /// </summary>
        public string APT_TIMESPAN { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string MILEAGE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string APT_RMK { get; set; }
        /// <summary>
        /// 接待人员
        /// </summary>
        public string CONSULTANT_NAME { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public decimal BPM_USRID { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string CUS_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        public string BG_NO { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BRAND_CODE { get; set; }
        /// <summary>
        /// 车系
        /// </summary>
        public string CARCLASS_NAME { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        public string CARCLASS_CODE { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string CARTYPE_NAME { get; set; }

        /// <summary>
        /// 车型编码
        /// </summary>
        public string CARTYPE_CODE { get; set; }

        /// <summary>
        /// 车型细分
        /// </summary>
        public string CARTYPEDET_NAME { get; set; }

        /// <summary>
        /// 车型细分编码
        /// </summary>
        public string CARTYPEDET_CODE { get; set; }

        /// <summary>
        /// vin码
        /// </summary>
        public string VIN { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CAR_ID { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public string DISCOUNT { get; set; }
        /// <summary>
        /// 预约项目
        /// </summary>
        public string APT_PROJECT { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string BU_NAME { get; set; }

    }
}
