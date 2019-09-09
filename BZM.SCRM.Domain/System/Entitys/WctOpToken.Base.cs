using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctOpToken : Entity<string> {       

        /// <summary>
        /// 第三方Ticket
        /// </summary>
        [StringLength( 500, ErrorMessage = "第三方Ticket输入过长，不能超过500位" )]
        public virtual string COMPONENT_TICKET { get; set; }
        /// <summary>
        /// 第三方令牌
        /// </summary>
        [StringLength( 500, ErrorMessage = "第三方令牌输入过长，不能超过500位" )]
        public virtual string COMPONENT_ACCESS_TOKEN { get; set; }
        /// <summary>
        /// 第三方令牌获取时间
        /// </summary>
        public virtual DateTime? COMPONENT_TOKEN_TIME { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 20, ErrorMessage = "未定义输入过长，不能超过20位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 20, ErrorMessage = "未定义输入过长，不能超过20位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 20, ErrorMessage = "未定义输入过长，不能超过20位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 20, ErrorMessage = "未定义输入过长，不能超过20位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 20, ErrorMessage = "未定义输入过长，不能超过20位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 开放平台AppId
        /// </summary>
        [StringLength(200, ErrorMessage = "开放平台AppId输入过长，不能超过200位")]
        public virtual string COMPONENT_APPID { get; set; }
        /// <summary>
        /// 开放平台AppSecret
        /// </summary>
        [StringLength(200, ErrorMessage = "开放平台AppSecret输入过长，不能超过200位")]
        public virtual string COMPONENT_APPSECRET { get; set; }
        /// <summary>
        /// 开放平台校验token
        /// </summary>
        [StringLength(200, ErrorMessage = "开放平台校验token输入过长，不能超过200位")]
        public virtual string COMPONENT_TOKEN { get; set; }
        /// <summary>
        /// 开放平台加密Key
        /// </summary>
        [StringLength(300, ErrorMessage = "开放平台加密Key输入过长，不能超过300位")]
        public virtual string COMPONENT_ENCODING_AESKEY { get; set; }
    }
}