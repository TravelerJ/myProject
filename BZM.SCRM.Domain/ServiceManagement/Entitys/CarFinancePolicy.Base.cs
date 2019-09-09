using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    ///  车辆金融标签表
    /// </summary>
    public partial class CarFinancePolicy : Entity<string> {       

        /// <summary>
        /// 品牌代码
        /// </summary>
        [Required(ErrorMessage = "品牌代码不能为空")]
        [StringLength( 50, ErrorMessage = "品牌代码输入过长，不能超过50位" )]
        public virtual string BRAND_CODE { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Required(ErrorMessage = "品牌名称不能为空")]
        [StringLength( 100, ErrorMessage = "品牌名称输入过长，不能超过100位" )]
        public virtual string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系代码
        /// </summary>
        [Required(ErrorMessage = "车系代码不能为空")]
        [StringLength( 50, ErrorMessage = "车系代码输入过长，不能超过50位" )]
        public virtual string CLASS_CODE { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [Required(ErrorMessage = "车系名称不能为空")]
        [StringLength( 100, ErrorMessage = "车系名称输入过长，不能超过100位" )]
        public virtual string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型代码
        /// </summary>
        [Required(ErrorMessage = "车型代码不能为空")]
        [StringLength( 50, ErrorMessage = "车型代码输入过长，不能超过50位" )]
        public virtual string TYPE_CODE { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [Required(ErrorMessage = "车型名称不能为空")]
        [StringLength( 100, ErrorMessage = "车型名称输入过长，不能超过100位" )]
        public virtual string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型细分代码输入过长，不能超过50位" )]
        public virtual string SUBTYPE_CODE { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型细分名称输入过长，不能超过100位" )]
        public virtual string SUBTYPE_NAME { get; set; }
        /// <summary>
        /// 标签级别(1.品牌，2.车系，3.车型，4.车型细分)
        /// </summary>
        [Required(ErrorMessage = "标签级别(1.品牌，2.车系，3.车型，4.车型细分)不能为空")]
        public virtual byte TAG_LEVEL { get; set; }
        /// <summary>
        /// 车辆类型(新车(NC)，二手车(UC)，售后车(AC))
        /// </summary>
        [StringLength( 20, ErrorMessage = "车辆类型(新车(NC)，二手车(UC)，售后车(AC))输入过长，不能超过20位" )]
        public virtual string BIZ_TYPE { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        [Required(ErrorMessage = "标签id不能为空")]
        [StringLength( 500, ErrorMessage = "标签id输入过长，不能超过500位" )]
        public virtual string TAG_IDS { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Required(ErrorMessage = "标签名称不能为空")]
        [StringLength( 4000, ErrorMessage = "标签名称输入过长，不能超过4000位" )]
        public virtual string TAG_JSON { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 门店编码
        /// </summary>
        [Required(ErrorMessage = "门店编码不能为空")]
        [StringLength( 20, ErrorMessage = "门店编码输入过长，不能超过20位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Required(ErrorMessage = "集团编码不能为空")]
        [StringLength( 20, ErrorMessage = "集团编码输入过长，不能超过20位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 二手车车架号
        /// </summary>
        [StringLength( 50, ErrorMessage = "二手车车架号输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
    }
}