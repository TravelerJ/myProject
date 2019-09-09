using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.InformationActivitie.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class CmsMaterialTypeQuery : Pager {     

        /// <summary>
        /// PK值
        /// </summary>
        [Display(Name="PK值")]
        public string MATERIAL_TYPE_ID { get; set; }
        /// <summary>
        /// 图文素材类型名
        /// </summary>
        [Display(Name="图文素材类型名")]
        public string MATERIAL_TYPE_NAME { get; set; }
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
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 属性(1.图文，2资讯，3.商城,4.热词)
        /// </summary>
        [Display(Name="属性(1.图文，2资讯，3.商城,4.热词)")]
        public string MATERIAL_ATTR { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 资讯类型(1.普通资讯，2.活动资讯，3.询价资讯)
        /// </summary>
        [Display(Name="资讯类型(1.普通资讯，2.活动资讯，3.询价资讯)")]
        public long? MATERIAL_INFO_TYPE { get; set; }
        /// <summary>
        /// 热词用途(1.首页，2.资讯，3.商城)
        /// </summary>
        [Display(Name="热词用途(1.首页，2.资讯，3.商城)")]
        public long? HOT_PURPOSE { get; set; }
        /// <summary>
        /// 热词内容
        /// </summary>
        [Display(Name="热词内容")]
        public string HOT_CONTENT { get; set; }
    }
}