using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatApi.Queries {
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CrmBehaviorRecordQuery : Pager {     

        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name="主键")]
        public string BEHAVIOR_ID { get; set; }
        /// <summary>
        /// 行为类型(1.历史搜索,2.资讯收藏,3.资讯点赞,4.资讯分享,5.活动报名,6.询底价,7.评论点赞,8.价格咨询9.收藏车型,10.收藏车系)
        /// </summary>
        [Display(Name="行为类型(1.历史搜索,2.资讯收藏,3.资讯点赞,4.资讯分享,5.活动报名,6.询底价,7.评论点赞,8.价格咨询9.收藏车型,10.收藏车系)")]
        public decimal? BEHAVIOR_TYPE { get; set; }
        /// <summary>
        /// 行为内容
        /// </summary>
        [Display(Name="行为内容")]
        public string BEHAVIOR_CONTENT { get; set; }
        /// <summary>
        /// 行为次数
        /// </summary>
        [Display(Name="行为次数")]
        public decimal? BEHAVIOR_NUM { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        [Display(Name="用户手机号")]
        public string CUS_MOBILE { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Display(Name="用户姓名")]
        public string CUS_NAME { get; set; }
        /// <summary>
        /// 微信用户openId
        /// </summary>
        [Display(Name="微信用户openId")]
        public string OPENID { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        [Display(Name="机构编码")]
        public string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 关联资讯编号
        /// </summary>
        [Display(Name="关联资讯编号")]
        public string MATERIAL_ID { get; set; }
        /// <summary>
        /// 是否点赞
        /// </summary>
        [Display(Name="是否点赞")]
        public decimal? IS_PRAISE { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        [Display(Name="是否收藏")]
        public decimal? IS_COLLECTION { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name="创建时间")]
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name="更新时间")]
        public DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// Vin
        /// </summary>
        [Display(Name="Vin")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [Display(Name="备用字段2")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [Display(Name="备用字段3")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [Display(Name="备用字段4")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [Display(Name="备用字段5")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 是否删除(0是,1否)
        /// </summary>
        [Display(Name="是否删除(0是,1否)")]
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 消息状态(0.未读,1.已读)
        /// </summary>
        [Display(Name="消息状态(0.未读,1.已读)")]
        public decimal? IS_READ { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Display(Name="用户id")]
        public decimal? USR_ID { get; set; }
        /// <summary>
        /// 关联评论编号
        /// </summary>
        [Display(Name="关联评论编号")]
        public string COMMENT_ID { get; set; }
        /// <summary>
        /// 品牌编码
        /// </summary>
        [Display(Name="品牌编码")]
        public string CAR_BRANDCODE { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Display(Name="品牌名称")]
        public string CAR_BRANDNAME { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        [Display(Name="车系编码")]
        public string CAR_CLASSCODE { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [Display(Name="车系名称")]
        public string CAR_CLASSNAME { get; set; }
        /// <summary>
        /// 车型编码
        /// </summary>
        [Display(Name="车型编码")]
        public string CAR_TYPECODE { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [Display(Name="车型名称")]
        public string CAR_TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分编码
        /// </summary>
        [Display(Name="车型细分编码")]
        public string CAR_SUBTYPECODE { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [Display(Name="车型细分名称")]
        public string CAR_SUBTYPENAME { get; set; }
        /// <summary>
        /// 是否新车(1新车,2二手车)
        /// </summary>
        [Display(Name="是否新车(1新车,2二手车)")]
        public long? IS_NEW_CAR { get; set; }
    }
}