using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatApi.Entitys
{
    /// <summary>
    /// 客户行为记录
    /// </summary>
    public partial class CrmBehaviorRecord : Entity<string> {       

        /// <summary>
        /// 行为类型(1.历史搜索,2.资讯收藏,3.资讯点赞,4.资讯分享,5.活动报名,6.询底价,7.评论点赞,8.价格咨询9.收藏车型,10.收藏车系)
        /// </summary>
        public virtual decimal? BEHAVIOR_TYPE { get; set; }
        /// <summary>
        /// 行为内容
        /// </summary>
        [StringLength( 100, ErrorMessage = "行为内容输入过长，不能超过100位" )]
        public virtual string BEHAVIOR_CONTENT { get; set; }
        /// <summary>
        /// 行为次数
        /// </summary>
        public virtual decimal? BEHAVIOR_NUM { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户手机号输入过长，不能超过100位" )]
        public virtual string CUS_MOBILE { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength( 100, ErrorMessage = "用户姓名输入过长，不能超过100位" )]
        public virtual string CUS_NAME { get; set; }
        /// <summary>
        /// 微信用户openId
        /// </summary>
        [Required(ErrorMessage = "微信用户openId不能为空")]
        [StringLength( 100, ErrorMessage = "微信用户openId输入过长，不能超过100位" )]
        public virtual string OPENID { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        [Required(ErrorMessage = "机构编码不能为空")]
        [StringLength( 50, ErrorMessage = "机构编码输入过长，不能超过50位" )]
        public virtual string BU_NO { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Required(ErrorMessage = "集团编码不能为空")]
        [StringLength( 50, ErrorMessage = "集团编码输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 关联资讯编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联资讯编号输入过长，不能超过50位" )]
        public virtual string MATERIAL_ID { get; set; }
        /// <summary>
        /// 是否点赞
        /// </summary>
        public virtual decimal? IS_PRAISE { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        public virtual decimal? IS_COLLECTION { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal? CREATE_PSN { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UPDATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public virtual decimal? UPDATE_PSN { get; set; }
        /// <summary>
        /// Vin
        /// </summary>
        [StringLength( 1000, ErrorMessage = "Vin输入过长，不能超过1000位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        [StringLength( 1000, ErrorMessage = "备用字段2输入过长，不能超过1000位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        [StringLength( 1000, ErrorMessage = "备用字段3输入过长，不能超过1000位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        [StringLength( 1000, ErrorMessage = "备用字段4输入过长，不能超过1000位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        [StringLength( 1000, ErrorMessage = "备用字段5输入过长，不能超过1000位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 是否删除(0是,1否)
        /// </summary>
        [Required(ErrorMessage = "是否删除(0是,1否)不能为空")]
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 消息状态(0.未读,1.已读)
        /// </summary>
        public virtual decimal? IS_READ { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual decimal? USR_ID { get; set; }
        /// <summary>
        /// 关联评论编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联评论编号输入过长，不能超过50位" )]
        public virtual string COMMENT_ID { get; set; }
        /// <summary>
        /// 品牌编码
        /// </summary>
        [StringLength( 100, ErrorMessage = "品牌编码输入过长，不能超过100位" )]
        public virtual string CAR_BRANDCODE { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "品牌名称输入过长，不能超过200位" )]
        public virtual string CAR_BRANDNAME { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        [StringLength( 100, ErrorMessage = "车系编码输入过长，不能超过100位" )]
        public virtual string CAR_CLASSCODE { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "车系名称输入过长，不能超过200位" )]
        public virtual string CAR_CLASSNAME { get; set; }
        /// <summary>
        /// 车型编码
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型编码输入过长，不能超过100位" )]
        public virtual string CAR_TYPECODE { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "车型名称输入过长，不能超过200位" )]
        public virtual string CAR_TYPE_NAME { get; set; }
        /// <summary>
        /// 车型细分编码
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型细分编码输入过长，不能超过100位" )]
        public virtual string CAR_SUBTYPECODE { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "车型细分名称输入过长，不能超过200位" )]
        public virtual string CAR_SUBTYPENAME { get; set; }
        /// <summary>
        /// 是否新车(1新车,2二手车)
        /// </summary>
        public virtual long? IS_NEW_CAR { get; set; }
    }
}