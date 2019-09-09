using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BZM.SCRM.Domain.System.ReportModels
{
    /// <summary>
    /// 系统模块model
    /// </summary>
    public class WctSysmoduleMstrModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Required(ErrorMessage = "模块Key不能为空")]
        [StringLength(50, ErrorMessage = "模块Key输入过长，不能超过50位")]
        public virtual string SYSM_ID { get; set; }
        /// <summary>
        /// 模块Key
        /// </summary>
        [Required(ErrorMessage = "模块Key不能为空")]
        [StringLength(50, ErrorMessage = "模块Key输入过长，不能超过50位")]
        public virtual string SYSM_KEY { get; set; }
        /// <summary>
        /// 模块标题
        /// </summary>
        [Required(ErrorMessage = "模块标题不能为空")]
        [StringLength(50, ErrorMessage = "模块标题输入过长，不能超过50位")]
        public virtual string SYSM_TITLE { get; set; }
        /// <summary>
        /// 模版页面地址
        /// </summary>
        [StringLength(500, ErrorMessage = "模版页面地址输入过长，不能超过500位")]
        public virtual string SYSM_URL_TEMPLATE { get; set; }
        /// <summary>
        /// 模版配置内容
        /// </summary>
        [Required(ErrorMessage = "模版配置内容不能为空")]
        public virtual string SYSM_JSON_VALUE { get; set; }
        /// <summary>
        /// 模块code
        /// </summary>
        [StringLength(50, ErrorMessage = "模块code输入过长，不能超过50位")]
        public virtual string SYSM_CODE { get; set; }
        /// <summary>
        /// 是否需要auth认证
        /// </summary>
        public virtual long? SYSM_IS_AUTH { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength(50, ErrorMessage = "创建机构代码输入过长，不能超过50位")]
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
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength(50, ErrorMessage = "集团编号输入过长，不能超过50位")]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 模块类型(1.功能模块,2.普通模块)
        /// </summary>
        public virtual long? SYSM_MODULE_TYPE { get; set; }
        /// <summary>
        /// 模块图标
        /// </summary>
        [StringLength(100, ErrorMessage = "模块图标输入过长，不能超过100位")]
        public virtual string SYSM_MODULE_LOGO { get; set; }
    }
}
