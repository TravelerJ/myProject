﻿using System.ComponentModel.DataAnnotations;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CrmAptMstrQuery
    {
        /// <summary>
        /// 区域编码
        /// </summary>
        [Display(Name = "区域编码")]
        public string AREA_NO { get; set; }

        /// <summary>
        /// 门店编码
        /// </summary>
        [Display(Name = "门店编码")]
        public string BU_NO { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public string START_DATE { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public string END_DATE { get; set; }
    }
}