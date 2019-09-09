using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries {
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class AptDriveConfigQuery : Pager {     

        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name="主键ID")]
        public string DRIVE_ID { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        [Display(Name="品牌ID")]
        public string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Display(Name="品牌名称")]
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系ID
        /// </summary>
        [Display(Name="车系ID")]
        public string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [Display(Name="车系名称")]
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型ID
        /// </summary>
        [Display(Name="车型ID")]
        public string TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [Display(Name="车型名称")]
        public string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分ID
        /// </summary>
        [Display(Name="车型细分ID")]
        public string SUBTYPE_ID { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [Display(Name="车型细分名称")]
        public string SUBTYPE_NAME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name="修改人")]
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name="修改时间")]
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Display(Name="门店编码")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF3 { get; set; }
    }
}