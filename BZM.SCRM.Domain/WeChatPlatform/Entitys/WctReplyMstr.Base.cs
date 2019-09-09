using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 回复信息主表
    /// </summary>
    public partial class WctReplyMstr : Entity<string> {       

        /// <summary>
        /// 关键字
        /// </summary>
        [StringLength( 50, ErrorMessage = "关键字输入过长，不能超过50位" )]
        public virtual string REPLY_KEYWORD { get; set; }
        /// <summary>
        /// 回复内容类型：0：文本,1：图文(链接),2：图文(详情)3：图文(模块)
        /// </summary>
        [Required(ErrorMessage = "回复内容类型：0：文本,1：图文(链接),2：图文(详情)3：图文(模块)不能为空")]
        public virtual long REPLY_CONTENT_TYPE { get; set; }
        /// <summary>
        /// 文本回复
        /// </summary>
        [StringLength( 1000, ErrorMessage = "文本回复输入过长，不能超过1000位" )]
        public virtual string REPLY_TEXT { get; set; }
        /// <summary>
        /// 组织机构编号
        /// </summary>
        [Required(ErrorMessage = "组织机构编号不能为空")]
        [StringLength( 50, ErrorMessage = "组织机构编号输入过长，不能超过50位" )]
        public virtual string REPLY_ID_NO { get; set; }
        /// <summary>
        /// 回复类型：1.关注，2.默认，3关键词
        /// </summary>
        [Required(ErrorMessage = "回复类型：1.关注，2.默认，3关键词不能为空")]
        public virtual long REPLY_TYPE { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public virtual long? REPLY_DISPLAY_INDEX { get; set; }
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
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF10 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 图文素材主键集
        /// </summary>
        [StringLength( 400, ErrorMessage = "图文素材主键集输入过长，不能超过400位" )]
        public virtual string MATERIAL_IDS { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [StringLength( 30, ErrorMessage = "状态输入过长，不能超过30位" )]
        public virtual string REPLY_STATUS { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [StringLength( 300, ErrorMessage = "微信图文素材ID输入过长，不能超过300位" )]
        public virtual string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
    }
}