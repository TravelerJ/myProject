using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.ServiceManagement.ReportModels
{
    /// <summary>
    /// 二手车model
    /// </summary>
    public class UseCarStockModel
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public string GOODS_CLASS1_NO { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string GOODS_CLASS1_NAME { get; set; }

        /// <summary>
        /// 车系id
        /// </summary>
        public string GOODS_CLASS2_NO { get; set; }

        /// <summary>
        /// 车系名称
        /// </summary>
        public string GOODS_CLASS2_NAME { get; set; }

        /// <summary>
        /// 车型id
        /// </summary>
        public string GOODS_CLASS3_NO { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string GOODS_CLASS3_NAME { get; set; }

        /// <summary>
        /// 车型细分id
        /// </summary>
        public string GOODS_NO { get; set; }

        /// <summary>
        /// 车型细分名称
        /// </summary>
        public string GOODS_NAME { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// 二手车列表显示名称
        /// </summary>
        public string CarDisplay { get; set; }
    }
}
