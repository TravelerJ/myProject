using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.ServiceManagement.ReportModels
{
    /// <summary>
    /// erp车型数据model
    /// </summary>
    public class ErpCarReturnModel
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BRAND_ID { get; set; }

        /// <summary>
        /// 品牌code
        /// </summary>
        public string BRAND_CODE { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BRAND_NAME { get; set; }

        /// <summary>
        /// 车系id
        /// </summary>
        public string CLASS_ID { get; set; }

        /// <summary>
        /// 车系名称
        /// </summary>
        public string CLASS_CODE { get; set; }

        /// <summary>
        /// 车系名称
        /// </summary>
        public string CLASS_NAME { get; set; }

        /// <summary>
        /// 车型id
        /// </summary>
        public string TYPE_ID { get; set; }

        /// <summary>
        /// 车型code
        /// </summary>
        public string TYPE_CODE { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string TYPE_NAME { get; set; }

        /// <summary>
        /// 车型细分id
        /// </summary>
        public string SUBTYPE_ID { get; set; }

        /// <summary>
        /// 车型细分code
        /// </summary>
        public string SUBTYPE_CODE { get; set; }

        /// <summary>
        /// 车型细分名称
        /// </summary>
        public string SUBTYPE_NAME { get; set; }

        /// <summary>
        /// 业务类型(NC:新车，AC:售后车，UC:二手车)
        /// </summary>
        public string BIZ_TYPE { get; set; }
    }
}
