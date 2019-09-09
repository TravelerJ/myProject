using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CrmEvaMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string EVA_ID { get; set; }
        /// <summary>
        /// 评价类型
        /// </summary>
        [Display(Name="评价类型")]
        public string EVA_TYPE { get; set; }
        /// <summary>
        /// 服务评价值
        /// </summary>
        [Display(Name="服务评价值")]
        public long? EVA_SERVICE_VALUE { get; set; }
        /// <summary>
        /// 态度评价值
        /// </summary>
        [Display(Name="态度评价值")]
        public long? EVA_ATTITUDE_VALUE { get; set; }
        /// <summary>
        /// 环境评价值
        /// </summary>
        [Display(Name="环境评价值")]
        public long? EVA_ENV_VALUE { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE1 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE2 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE3 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE4 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE5 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE6 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE7 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE8 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE9 { get; set; }
        /// <summary>
        /// 其他评价值
        /// </summary>
        [Display(Name="其他评价值")]
        public long? EVA_OTR_VALUE10 { get; set; }
        /// <summary>
        /// 总评价值
        /// </summary>
        [Display(Name="总评价值")]
        public long? EVA_TOTAL_VALUE { get; set; }
        /// <summary>
        /// 评价对象类型(人/机构)
        /// </summary>
        [Display(Name="评价对象类型(人/机构)")]
        public string EVA_OBJ_TYPE { get; set; }
        /// <summary>
        /// 评价对象编码
        /// </summary>
        [Display(Name="评价对象编码")]
        public string EVA_OBJ_NO { get; set; }
        /// <summary>
        /// 评价对象名称
        /// </summary>
        [Display(Name="评价对象名称")]
        public string EVA_OBJ_NAME { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        [Display(Name="评价时间")]
        public DateTime EVA_DATE { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        [Display(Name="评价内容")]
        public string EVA_CONTENT { get; set; }
        /// <summary>
        /// 评价备注
        /// </summary>
        [Display(Name="评价备注")]
        public string EVA_RMK { get; set; }
        /// <summary>
        /// 关联单号
        /// </summary>
        [Display(Name="关联单号")]
        public string EVA_REF_NO { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [Display(Name="关联单号1")]
        public string EVA_REF_NO1 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [Display(Name="关联单号1")]
        public string EVA_REF_NO2 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [Display(Name="关联单号1")]
        public string EVA_REF_NO3 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [Display(Name="关联单号1")]
        public string EVA_REF_NO4 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        [Display(Name="关联单号1")]
        public string EVA_REF_NO5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        [Display(Name="未定义字段")]
        public string UDF10 { get; set; }
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
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        [Display(Name="品牌id")]
        public string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Display(Name="品牌名称")]
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系id
        /// </summary>
        [Display(Name="车系id")]
        public string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [Display(Name="车系名称")]
        public string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型id
        /// </summary>
        [Display(Name="车型id")]
        public string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        [Display(Name="车型名称")]
        public string CAR_TYPE_NAME { get; set; }
    }
}