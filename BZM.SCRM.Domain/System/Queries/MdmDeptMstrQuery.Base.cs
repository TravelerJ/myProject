using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.System.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class MdmDeptMstrQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public decimal DEPT_ID { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Display(Name="部门编号")]
        public string DEPT_NO { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Display(Name="部门名称")]
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 上级部门ID
        /// </summary>
        [Display(Name="上级部门ID")]
        public decimal? DEPT_PARENT_ID { get; set; }
        /// <summary>
        /// 业务单元编号
        /// </summary>
        [Display(Name="业务单元编号")]
        public string ORG_NO { get; set; }
        /// <summary>
        /// 部门状态
        /// </summary>
        [Display(Name="部门状态")]
        public decimal DEPT_STATUS { get; set; }
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
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        [Display(Name="集团编码")]
        public string BG_NO { get; set; }
    }
}