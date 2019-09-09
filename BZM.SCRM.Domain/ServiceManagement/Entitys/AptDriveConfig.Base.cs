using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys {
    /// <summary>
    ///  预约试驾配置表
    /// </summary>
    public partial class AptDriveConfig : Entity<string> {       

        /// <summary>
        /// 品牌ID
        /// </summary>
        [Required(ErrorMessage = "品牌ID不能为空")]
        [StringLength( 50, ErrorMessage = "品牌ID输入过长，不能超过50位" )]
        public virtual string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [StringLength( 20, ErrorMessage = "品牌名称输入过长，不能超过20位" )]
        public virtual string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系ID
        /// </summary>
        [Required(ErrorMessage = "车系ID不能为空")]
        [StringLength( 50, ErrorMessage = "车系ID输入过长，不能超过50位" )]
        public virtual string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "车系名称输入过长，不能超过50位" )]
        public virtual string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型ID
        /// </summary>
        [Required(ErrorMessage = "车型ID不能为空")]
        [StringLength( 50, ErrorMessage = "车型ID输入过长，不能超过50位" )]
        public virtual string TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "车型名称输入过长，不能超过50位" )]
        public virtual string TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分ID
        /// </summary>
        [Required(ErrorMessage = "车型细分ID不能为空")]
        [StringLength( 50, ErrorMessage = "车型细分ID输入过长，不能超过50位" )]
        public virtual string SUBTYPE_ID { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型细分名称输入过长，不能超过100位" )]
        public virtual string SUBTYPE_NAME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public virtual decimal? UPDATE_PSN { get; set; }
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
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 50, ErrorMessage = "输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength( 100, ErrorMessage = "输入过长，不能超过100位" )]
        public virtual string UDF3 { get; set; }
    }
}