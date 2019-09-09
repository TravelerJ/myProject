using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 延长保修/保险续保主表
    /// </summary>
    public partial class StoreAdvertiseMstr : Entity<string> {       

        /// <summary>
        /// 宣传主题
        /// </summary>
        [Required(ErrorMessage = "宣传主题不能为空")]
        [StringLength( 50, ErrorMessage = "宣传主题输入过长，不能超过50位" )]
        public virtual string ADVERTISE_THEME { get; set; }
        /// <summary>
        /// 展示类型(1.图文,2.海报)
        /// </summary>
        [Required(ErrorMessage = "展示类型(1.图文,2.海报)不能为空")]
        public virtual decimal ADVERTISE_TYPE { get; set; }
        /// <summary>
        /// 图文内容
        /// </summary>
        public virtual string ADVERTISE_CONTENT { get; set; }
        /// <summary>
        /// 海报链接
        /// </summary>
        [StringLength( 100, ErrorMessage = "海报链接输入过长，不能超过100位" )]
        public virtual string ADVERTISE_POSTER_URL { get; set; }
        /// <summary>
        /// 门店联系方式
        /// </summary>
        [StringLength( 20, ErrorMessage = "门店联系方式输入过长，不能超过20位" )]
        public virtual string STORE_CONTRACT { get; set; }
        /// <summary>
        /// 启用状态(1.启用,2.禁用)
        /// </summary>
        public virtual decimal? ADVERTISE_STATUS { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength( 20, ErrorMessage = "创建人输入过长，不能超过20位" )]
        public virtual string CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength( 20, ErrorMessage = "修改人输入过长，不能超过20位" )]
        public virtual string UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
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
        /// <summary>
        /// 宣传类别(1.延长保修,2.保险续保)
        /// </summary>
        public virtual byte? ADVERTISE_CATEGORY { get; set; }
    }
}