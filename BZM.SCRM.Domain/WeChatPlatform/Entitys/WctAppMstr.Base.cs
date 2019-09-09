using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 微信app菜单配置主表
    /// </summary>
    public partial class WctAppMstr : Entity<string> {       

        /// <summary>
        /// 主应用key
        /// </summary>
        [StringLength( 30, ErrorMessage = "主应用key输入过长，不能超过30位" )]
        public virtual string APP_KEY { get; set; }
        /// <summary>
        /// 主应用名称
        /// </summary>
        [Required(ErrorMessage = "主应用名称不能为空")]
        [StringLength( 20, ErrorMessage = "主应用名称输入过长，不能超过20位" )]
        public virtual string APP_NAME { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [Required(ErrorMessage = "模块ID不能为空")]
        [StringLength( 50, ErrorMessage = "模块ID输入过长，不能超过50位" )]
        public virtual string WCT_MODULE_ID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Required(ErrorMessage = "修改人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "修改时间不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Required(ErrorMessage = "是否已删除不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
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
        /// 跳转链接
        /// </summary>
        [StringLength( 100, ErrorMessage = "跳转链接输入过长，不能超过100位" )]
        public virtual string WCT_APP_URL { get; set; }
        /// <summary>
        /// 模块功能类型(1.功能模块,2.普通模块)
        /// </summary>
        [Required(ErrorMessage = "模块功能类型(1.功能模块,2.普通模块)不能为空")]
        [StringLength( 20, ErrorMessage = "模块功能类型(1.功能模块,2.普通模块)输入过长，不能超过20位" )]
        public virtual string WCT_MODULE_TYPE { get; set; }
        /// <summary>
        /// 子模块组
        /// </summary>
        [StringLength( 500, ErrorMessage = "子模块组输入过长，不能超过500位" )]
        public virtual string SYS_MODULE_IDS { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段1输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 模块KEY
        /// </summary>
        [StringLength( 50, ErrorMessage = "模块KEY输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段3输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段4输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 50, ErrorMessage = "备用字段5输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 排序应用
        /// </summary>
        public virtual long? APP_SORT { get; set; }
    }
}