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
    public partial class CarFinancePolicyQuery : Pager {     

        /// <summary>
        /// 金融ID
        /// </summary>
        [Display(Name="金融ID")]
        public string FINANCE_ID { get; set; }
        /// <summary>
        /// 品牌代码
        /// </summary>
        [Display(Name="品牌代码")]
        public string BRAND_CODE { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Display(Name="品牌名称")]
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系代码
        /// </summary>
        [Display(Name="车系代码")]
        public string CLASS_CODE { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [Display(Name="车系名称")]
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型代码
        /// </summary>
        [Display(Name="车型代码")]
        public string TYPE_CODE { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [Display(Name="车型名称")]
        public string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分代码
        /// </summary>
        [Display(Name="车型细分代码")]
        public string SUBTYPE_CODE { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [Display(Name="车型细分名称")]
        public string SUBTYPE_NAME { get; set; }
        /// <summary>
        /// 标签级别(1.品牌，2.车系，3.车型，4.车型细分)
        /// </summary>
        [Display(Name="标签级别(1.品牌，2.车系，3.车型，4.车型细分)")]
        public byte TAG_LEVEL { get; set; }
        /// <summary>
        /// 车辆类型(新车(NC)，二手车(UC)，售后车(AC))
        /// </summary>
        [Display(Name="车辆类型(新车(NC)，二手车(UC)，售后车(AC))")]
        public string BIZ_TYPE { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        [Display(Name="标签id")]
        public string TAG_IDS { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Display(Name="标签名称")]
        public string TAG_JSON { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public long? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name="修改人")]
        public long? UPDATE_PSN { get; set; }
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
        /// 删除标识
        /// </summary>
        [Display(Name="删除标识")]
        public byte? DEL_FLAG { get; set; }
        /// <summary>
        /// 二手车车架号
        /// </summary>
        [Display(Name="二手车车架号")]
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
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public string UDF5 { get; set; }
    }
}