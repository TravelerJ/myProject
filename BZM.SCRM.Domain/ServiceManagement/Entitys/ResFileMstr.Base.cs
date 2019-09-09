using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 资源表
    /// </summary>
    public partial class ResFileMstr : Entity<string> {       

        /// <summary>
        /// 文件名
        /// </summary>
        [StringLength( 500, ErrorMessage = "文件名输入过长，不能超过500位" )]
        public virtual string FILE_NAME { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual decimal? FILE_SIZE { get; set; }
        /// <summary>
        /// 文件分类
        /// </summary>
        [StringLength( 20, ErrorMessage = "文件分类输入过长，不能超过20位" )]
        public virtual string FILE_CLASS { get; set; }
        /// <summary>
        /// 业务单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "业务单号输入过长，不能超过50位" )]
        public virtual string BIZ_NO { get; set; }
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
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 文件物理路径
        /// </summary>
        [StringLength( 2000, ErrorMessage = "文件物理路径输入过长，不能超过2000位" )]
        public virtual string FILE_PATH { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public virtual long? FILE_SORT { get; set; }
        /// <summary>
        /// 文件起始日期
        /// </summary>
        public virtual DateTime? FILE_SDATE { get; set; }
        /// <summary>
        /// 文件截止日期
        /// </summary>
        public virtual DateTime? FILE_EDATE { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]
        public virtual string FILE_ATTR1 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]
        public virtual string FILE_ATTR2 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]
        public virtual string FILE_ATTR3 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]
        public virtual string FILE_ATTR4 { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [StringLength( 50, ErrorMessage = "文件属性输入过长，不能超过50位" )]
        public virtual string FILE_ATTR5 { get; set; }
    }
}