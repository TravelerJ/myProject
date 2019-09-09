using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 评论/聊天主表
    /// </summary>
    public partial class CrmEvaMstr : Entity<string> {       

        /// <summary>
        /// 评价类型
        /// </summary>
        [Required(ErrorMessage = "评价类型不能为空")]
        [StringLength( 50, ErrorMessage = "评价类型输入过长，不能超过50位" )]
        public virtual string EVA_TYPE { get; set; }
        /// <summary>
        /// 服务评价值
        /// </summary>
        public virtual long? EVA_SERVICE_VALUE { get; set; }
        /// <summary>
        /// 态度评价值
        /// </summary>
        public virtual long? EVA_ATTITUDE_VALUE { get; set; }
        /// <summary>
        /// 环境评价值
        /// </summary>
        public virtual long? EVA_ENV_VALUE { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE1 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE2 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE3 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE4 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE5 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE6 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE7 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE8 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE9 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        public virtual long? EVA_OTR_VALUE10 { get; set; }
        /// <summary>
        /// 总评价值
        /// </summary>
        public virtual long? EVA_TOTAL_VALUE { get; set; }
        /// <summary>
        /// 评价对象类型(人/机构)
        /// </summary>
        [Required(ErrorMessage = "评价对象类型(人/机构)不能为空")]
        [StringLength( 10, ErrorMessage = "评价对象类型(人/机构)输入过长，不能超过10位" )]
        public virtual string EVA_OBJ_TYPE { get; set; }
        /// <summary>
        /// 评价对象编码
        /// </summary>
        [StringLength( 50, ErrorMessage = "评价对象编码输入过长，不能超过50位" )]
        public virtual string EVA_OBJ_NO { get; set; }
        /// <summary>
        /// 评价对象名称
        /// </summary>
        [Required(ErrorMessage = "评价对象名称不能为空")]
        [StringLength( 100, ErrorMessage = "评价对象名称输入过长，不能超过100位" )]
        public virtual string EVA_OBJ_NAME { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        [Required(ErrorMessage = "评价时间不能为空")]
        public virtual DateTime EVA_DATE { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        [StringLength( 550, ErrorMessage = "评价内容输入过长，不能超过550位" )]
        public virtual string EVA_CONTENT { get; set; }
        /// <summary>
        /// 评价备注
        /// </summary>
        [StringLength( 200, ErrorMessage = "评价备注输入过长，不能超过200位" )]
        public virtual string EVA_RMK { get; set; }
        /// <summary>
        /// 关联单号
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号1输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO1 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号1输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO2 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号1输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO3 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号1输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO4 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联单号1输入过长，不能超过50位" )]
        public virtual string EVA_REF_NO5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 750, ErrorMessage = "未定义字段输入过长，不能超过750位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 750, ErrorMessage = "未定义字段输入过长，不能超过750位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF10 { get; set; }
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
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        [StringLength( 100, ErrorMessage = "品牌id输入过长，不能超过100位" )]
        public virtual string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "品牌名称输入过长，不能超过200位" )]
        public virtual string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系id
        /// </summary>
        [StringLength( 100, ErrorMessage = "车系id输入过长，不能超过100位" )]
        public virtual string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "车系名称输入过长，不能超过200位" )]
        public virtual string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型id
        /// </summary>
        [StringLength( 100, ErrorMessage = "车型id输入过长，不能超过100位" )]
        public virtual string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "车型名称输入过长，不能超过200位" )]
        public virtual string CAR_TYPE_NAME { get; set; }
    }
}