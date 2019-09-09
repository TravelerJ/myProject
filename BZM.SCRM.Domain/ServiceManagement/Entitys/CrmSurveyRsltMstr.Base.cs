using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.ServiceManagement.Entitys
{
    /// <summary>
    /// 问卷答案表
    /// </summary>
    public partial class CrmSurveyRsltMstr : Entity<string> {       

        /// <summary>
        /// 问卷ID
        /// </summary>
        [Required(ErrorMessage = "问卷ID不能为空")]
        [StringLength( 50, ErrorMessage = "问卷ID输入过长，不能超过50位" )]
        public virtual string SURVEY_ID { get; set; }
        /// <summary>
        /// 问卷标题
        /// </summary>
        [Required(ErrorMessage = "问卷标题不能为空")]
        [StringLength( 200, ErrorMessage = "问卷标题输入过长，不能超过200位" )]
        public virtual string SURVEY_TITLE { get; set; }
        /// <summary>
        /// 答案描述
        /// </summary>
        [Required(ErrorMessage = "答案描述不能为空")]
        [StringLength( 4000, ErrorMessage = "答案描述输入过长，不能超过4000位" )]
        public virtual string ANSWER_JSON { get; set; }
        /// <summary>
        /// 答案分值
        /// </summary>
        public virtual double? ANSWER_SCORE { get; set; }
        /// <summary>
        /// 答题者ID
        /// </summary>
        [Required(ErrorMessage = "答题者ID不能为空")]
        public virtual decimal REPORT_PSN { get; set; }
        /// <summary>
        /// 答题者名称
        /// </summary>
        [Required(ErrorMessage = "答题者名称不能为空")]
        [StringLength( 50, ErrorMessage = "答题者名称输入过长，不能超过50位" )]
        public virtual string REPORT_NAME { get; set; }
        /// <summary>
        /// 答题者的微信OpenID
        /// </summary>
        [StringLength( 50, ErrorMessage = "答题者的微信OpenID输入过长，不能超过50位" )]
        public virtual string REPORT_OPENID { get; set; }
        /// <summary>
        /// 答题时间
        /// </summary>
        [Required(ErrorMessage = "答题时间不能为空")]
        public virtual DateTime REPORT_DATE { get; set; }
        /// <summary>
        /// 答题者IP
        /// </summary>
        [StringLength( 50, ErrorMessage = "答题者IP输入过长，不能超过50位" )]
        public virtual string REPORT_IP { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义字段输入过长，不能超过50位" )]
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
    }
}