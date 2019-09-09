using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.InformationActivitie.Entitys {
    /// <summary>
    /// 资讯/图文/商城信息表
    /// </summary>
    public partial class CmsMaterialMstr : Entity<string> {       

        /// <summary>
        /// 图文素材类型
        /// </summary>
        [Required(ErrorMessage = "图文素材类型不能为空")]
        [StringLength( 50, ErrorMessage = "图文素材类型输入过长，不能超过50位" )]
        public virtual string MATERIAL_TYPE_ID { get; set; }
        /// <summary>
        /// 图文素材标题
        /// </summary>
        [Required(ErrorMessage = "图文素材标题不能为空")]
        [StringLength( 500, ErrorMessage = "图文素材标题输入过长，不能超过500位" )]
        public virtual string MATERIAL_TITLE { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [StringLength( 500, ErrorMessage = "作者输入过长，不能超过500位" )]
        public virtual string MATERIAL_AUTHOR { get; set; }
        /// <summary>
        /// 封面图片地址
        /// </summary>
        [StringLength( 500, ErrorMessage = "封面图片地址输入过长，不能超过500位" )]
        public virtual string MATERIAL_COVER_URL { get; set; }
        /// <summary>
        /// 图文素材内容
        /// </summary>
        public virtual string MATERIAL_CONTENT { get; set; }
        /// <summary>
        /// 阅读原文链接
        /// </summary>
        [StringLength( 500, ErrorMessage = "阅读原文链接输入过长，不能超过500位" )]
        public virtual string MATERIAL_CONTENT_ORI_URL { get; set; }
        /// <summary>
        /// 是否需要显示封面
        /// </summary>
        public virtual long? MATERIAL_SHOW_COVER { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [StringLength( 200, ErrorMessage = "微信图文素材ID输入过长，不能超过200位" )]
        public virtual string MATERIAL_MEDIA_ID { get; set; }
        /// <summary>
        /// 微信图文素材摘要
        /// </summary>
        [StringLength( 500, ErrorMessage = "微信图文素材摘要输入过长，不能超过500位" )]
        public virtual string MATERIAL_DIGEST { get; set; }
        /// <summary>
        /// 外链URL、跳转模块链接
        /// </summary>
        [StringLength( 500, ErrorMessage = "外链URL、跳转模块链接输入过长，不能超过500位" )]
        public virtual string MATERIAL_URL { get; set; }
        /// <summary>
        /// 关联系统模块ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联系统模块ID输入过长，不能超过50位" )]
        public virtual string MATERIAL_MODULE_ID { get; set; }
        /// <summary>
        /// 关联系统模块中配置参数
        /// </summary>
        public virtual string MATERIAL_MODULE_PARAM_JSON { get; set; }
        /// <summary>
        /// 是否需要微信认证
        /// </summary>
        public virtual long? MATERIAL_IS_AUTH { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public virtual DateTime? RELEASE_DATE { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public virtual long? MATERIAL_IS_TOP { get; set; }
        /// <summary>
        /// 微信图文素材内容
        /// </summary>
        public virtual string MATERIAL_WCT_CONTENT { get; set; }
        /// <summary>
        /// 微信封面图片地址
        /// </summary>
        [StringLength( 200, ErrorMessage = "微信封面图片地址输入过长，不能超过200位" )]
        public virtual string MATERIAL_WCT_COVER_URL { get; set; }
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
        /// 对齐方式
        /// </summary>
        [StringLength( 20, ErrorMessage = "对齐方式输入过长，不能超过20位" )]
        public virtual string MATERIAL_ALIGN_TYPE { get; set; }
        /// <summary>
        /// 标题英文
        /// </summary>
        [StringLength( 100, ErrorMessage = "标题英文输入过长，不能超过100位" )]
        public virtual string MATERIAL_TITLE_EN { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [StringLength( 10, ErrorMessage = "排序号输入过长，不能超过10位" )]
        public virtual string MATERIAL_SORT_NO { get; set; }
        /// <summary>
        /// 封面图片素材mediaID
        /// </summary>
        [StringLength( 300, ErrorMessage = "封面图片素材mediaID输入过长，不能超过300位" )]
        public virtual string MATERIAL_THUMB_MEDIA_ID { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        public virtual long? READ_COUNT { get; set; }
        /// <summary>
        /// 分享次数
        /// </summary>
        public virtual long? SHARE_COUNT { get; set; }
        /// <summary>
        /// 收藏次数
        /// </summary>
        public virtual long? FAV_COUNT { get; set; }
        /// <summary>
        /// 资讯状态
        /// </summary>
        [StringLength( 50, ErrorMessage = "资讯状态输入过长，不能超过50位" )]
        public virtual string MATERIAL_STATUS { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 评论规则(0.不可评论，1.单向规则，2.双向规则，3.多向规则)
        /// </summary>
        public virtual decimal? COMMENT_RULE { get; set; }
        /// <summary>
        /// 是否设为轮播(1.是,0.否)
        /// </summary>
        public virtual decimal? IS_ROUND { get; set; }
        /// <summary>
        /// 缩略图模板类型(1.模板1,2.模板2)
        /// </summary>
        public virtual decimal? SLT_MODULE_TYPE { get; set; }
        /// <summary>
        /// 活动类型(1.普通活动,2.抽奖活动)
        /// </summary>
        public virtual decimal? MATERIAL_ACT_TYPE { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public virtual DateTime? ACT_STARTDATE { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public virtual DateTime? ACT_ENDDATE { get; set; }
        /// <summary>
        /// 可否报名
        /// </summary>
        public virtual decimal? IS_APPLY { get; set; }
        /// <summary>
        /// 人数限制
        /// </summary>
        public virtual long? APPLY_LIMIT { get; set; }
        /// <summary>
        /// 参与人群
        /// </summary>
        public virtual long? ACT_PARTICIPATOR { get; set; }
        /// <summary>
        /// 点赞人数
        /// </summary>
        public virtual long? SUPPORT_COUNT { get; set; }
    }
}