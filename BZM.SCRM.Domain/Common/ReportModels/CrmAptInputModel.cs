using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 推送odm预约入参
    /// </summary>
    public class CrmAptInputModel
    {
        /// <summary>
        /// 门店编码
        /// </summary>
        public string BuNo { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CusNo { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CusName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CusMobile { get; set; }

        /// <summary>
        /// 客户性别
        /// </summary>
        public string CusSex { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 预约类别
        /// </summary>
        public string ScrmAptNo { get; set; }

        /// <summary>
        /// 预约类别
        /// </summary>
        public string AptClass { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime AptDate { get; set; }

        /// <summary>
        /// 预约时间段
        /// </summary>
        public string AptTimeSpan { get; set; }

        /// <summary>
        /// 预约项目
        /// </summary>
        public string AptItem { get; set; }

        /// <summary>
        /// 预约备注
        /// </summary>
        public string AptContent { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarId { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string Vin { get; set; }

    }
}
