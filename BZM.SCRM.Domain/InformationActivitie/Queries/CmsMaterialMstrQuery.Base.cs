using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.InformationActivitie.Queries {
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CmsMaterialMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string MATERIAL_ID { get; set; }
        /// <summary>
        /// 图文素材类型
        /// </summary>
        [Display(Name="图文素材类型")]
        public string MATERIAL_TYPE_ID { get; set; }
        /// <summary>
        /// 图文素材标题
        /// </summary>
        [Display(Name="图文素材标题")]
        public string MATERIAL_TITLE { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Display(Name="作者")]
        public string MATERIAL_AUTHOR { get; set; }
        /// <summary>
        /// 封面图片地址
        /// </summary>
        [Display(Name="封面图片地址")]
        public string MATERIAL_COVER_URL { get; set; }
        /// <summary>
        /// 图文素材内容
        /// </summary>
        [Display(Name="图文素材内容")]
        public object MATERIAL_CONTENT { get; set; }
        /// <summary>
        /// 阅读原文链接
        /// </summary>
        [Display(Name="阅读原文链接")]
        public string MATERIAL_CONTENT_ORI_URL { get; set; }
        /// <summary>
        /// 是否需要显示封面
        /// </summary>
        [Display(Name="是否需要显示封面")]
        public long? MATERIAL_SHOW_COVER { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [Display(Name="微信图文素材ID")]
        public string MATERIAL_MEDIA_ID { get; set; }
        /// <summary>
        /// 微信图文素材摘要
        /// </summary>
        [Display(Name="微信图文素材摘要")]
        public string MATERIAL_DIGEST { get; set; }
        /// <summary>
        /// 外链URL、跳转模块链接
        /// </summary>
        [Display(Name="外链URL、跳转模块链接")]
        public string MATERIAL_URL { get; set; }
        /// <summary>
        /// 关联系统模块ID
        /// </summary>
        [Display(Name="关联系统模块ID")]
        public string MATERIAL_MODULE_ID { get; set; }
        /// <summary>
        /// 关联系统模块中配置参数
        /// </summary>
        [Display(Name="关联系统模块中配置参数")]
        public object MATERIAL_MODULE_PARAM_JSON { get; set; }
        /// <summary>
        /// 是否需要微信认证
        /// </summary>
        [Display(Name="是否需要微信认证")]
        public long? MATERIAL_IS_AUTH { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name="发布时间")]
        public DateTime? RELEASE_DATE { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Display(Name="是否置顶")]
        public long? MATERIAL_IS_TOP { get; set; }
        /// <summary>
        /// 微信图文素材内容
        /// </summary>
        [Display(Name="微信图文素材内容")]
        public object MATERIAL_WCT_CONTENT { get; set; }
        /// <summary>
        /// 微信封面图片地址
        /// </summary>
        [Display(Name="微信封面图片地址")]
        public string MATERIAL_WCT_COVER_URL { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name="创建日期")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name="更新日期")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 关联方式(1链接2详情页面3系统模块)
        /// </summary>
        [Display(Name= "关联方式(1链接2详情页面3系统模块)")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF10 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        [Display(Name="对齐方式")]
        public string MATERIAL_ALIGN_TYPE { get; set; }
        /// <summary>
        /// 标题英文
        /// </summary>
        [Display(Name="标题英文")]
        public string MATERIAL_TITLE_EN { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name="排序号")]
        public string MATERIAL_SORT_NO { get; set; }
        /// <summary>
        /// 封面图片素材mediaID
        /// </summary>
        [Display(Name="封面图片素材mediaID")]
        public string MATERIAL_THUMB_MEDIA_ID { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        [Display(Name="阅读次数")]
        public long? READ_COUNT { get; set; }
        /// <summary>
        /// 分享次数
        /// </summary>
        [Display(Name="分享次数")]
        public long? SHARE_COUNT { get; set; }
        /// <summary>
        /// 收藏次数
        /// </summary>
        [Display(Name="收藏次数")]
        public long? FAV_COUNT { get; set; }
        /// <summary>
        /// 资讯状态
        /// </summary>
        [Display(Name="资讯状态")]
        public string MATERIAL_STATUS { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 评论规则(0.不可评论，1.单向规则，2.双向规则，3.多向规则)
        /// </summary>
        [Display(Name="评论规则(0.不可评论，1.单向规则，2.双向规则，3.多向规则)")]
        public decimal? COMMENT_RULE { get; set; }
        /// <summary>
        /// 是否设为轮播(1.是,0.否)
        /// </summary>
        [Display(Name="是否设为轮播(1.是,0.否)")]
        public decimal? IS_ROUND { get; set; }
        /// <summary>
        /// 缩略图模板类型(1.模板1,2.模板2)
        /// </summary>
        [Display(Name="缩略图模板类型(1.模板1,2.模板2)")]
        public decimal? SLT_MODULE_TYPE { get; set; }
        /// <summary>
        /// 活动类型(1.普通活动,2.抽奖活动)
        /// </summary>
        [Display(Name="活动类型(1.普通活动,2.抽奖活动)")]
        public decimal? MATERIAL_ACT_TYPE { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Display(Name="活动开始时间")]
        public DateTime? ACT_STARTDATE { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Display(Name="活动结束时间")]
        public DateTime? ACT_ENDDATE { get; set; }
        /// <summary>
        /// 可否报名
        /// </summary>
        [Display(Name="可否报名")]
        public decimal? IS_APPLY { get; set; }
        /// <summary>
        /// 人数限制
        /// </summary>
        [Display(Name="人数限制")]
        public long? APPLY_LIMIT { get; set; }
        /// <summary>
        /// 参与人群
        /// </summary>
        [Display(Name="参与人群")]
        public long? ACT_PARTICIPATOR { get; set; }
        /// <summary>
        /// 点赞人数
        /// </summary>
        [Display(Name="点赞人数")]
        public long? SUPPORT_COUNT { get; set; }
    }
}