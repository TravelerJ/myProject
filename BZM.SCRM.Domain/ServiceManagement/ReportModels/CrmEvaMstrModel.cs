using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.ServiceManagement.ReportModels
{
    /// <summary>
    /// 消息model
    /// </summary>
    public class CrmEvaMstrModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string EVA_ID { get; set; }
        /// <summary>
        /// 评价类型
        /// </summary>
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
        public virtual string EVA_OBJ_TYPE { get; set; }
        /// <summary>
        /// 评价对象编码
        /// </summary>
        public virtual string EVA_OBJ_NO { get; set; }
        /// <summary>
        /// 评价对象名称
        /// </summary>
        public virtual string EVA_OBJ_NAME { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        public virtual DateTime EVA_DATE { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        public virtual string EVA_CONTENT { get; set; }
        /// <summary>
        /// 评价备注
        /// </summary>
        public virtual string EVA_RMK { get; set; }
        /// <summary>
        /// 关联单号
        /// </summary>
        public virtual string EVA_REF_NO { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        public virtual string EVA_REF_NO1 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        public virtual string EVA_REF_NO2 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        public virtual string EVA_REF_NO3 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        public virtual string EVA_REF_NO4 { get; set; }
        /// <summary>
        /// 关联单号1
        /// </summary>
        public virtual string EVA_REF_NO5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义字段
        /// </summary>
        public virtual string UDF10 { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public virtual string BRAND_ID { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public virtual string BRAND_NAME { get; set; }
        /// <summary>
        /// 车系id
        /// </summary>
        public virtual string CLASS_ID { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        public virtual string CLASS_NAME { get; set; }
        /// <summary>
        /// 车型id
        /// </summary>
        public virtual string CAR_TYPE_ID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public virtual string CAR_TYPE_NAME { get; set; }
    }
}
