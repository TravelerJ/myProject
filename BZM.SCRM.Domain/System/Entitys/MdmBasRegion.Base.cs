using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 省市地表
    /// </summary>
    public partial class MdmBasRegion : Entity<string> {       

        /// <summary>
        /// 区域编号
        /// </summary>
        [Required(ErrorMessage = "区域编号不能为空")]
        [StringLength( 20, ErrorMessage = "区域编号输入过长，不能超过20位" )]
        public virtual string REGION_NO { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [Required(ErrorMessage = "区域名称不能为空")]
        [StringLength( 100, ErrorMessage = "区域名称输入过长，不能超过100位" )]
        public virtual string REGION_NAME { get; set; }
        /// <summary>
        /// 区域层级(0-省/1-市/2-区)
        /// </summary>
        [Required(ErrorMessage = "区域层级(0-省/1-市/2-区)不能为空")]
        public virtual long REGION_LEVEL { get; set; }
        /// <summary>
        /// 父区域编号(顶级为00)
        /// </summary>
        [Required(ErrorMessage = "父区域编号(顶级为00)不能为空")]
        [StringLength( 20, ErrorMessage = "父区域编号(顶级为00)输入过长，不能超过20位" )]
        public virtual string PARENT_REGION_NO { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        public virtual long? REGION_FLAG1 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        public virtual long? REGION_FLAG2 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        public virtual long? REGION_FLAG3 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        public virtual long? REGION_FLAG4 { get; set; }
        /// <summary>
        /// 区域标示1
        /// </summary>
        public virtual long? REGION_FLAG5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required(ErrorMessage = "创建日期不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Required(ErrorMessage = "更新人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Required(ErrorMessage = "更新日期不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Required(ErrorMessage = "数据删除标志(1-有效/0-已删除)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
    }
}