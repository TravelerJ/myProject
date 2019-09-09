using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.InformationActivitie.Entitys
{
    /// <summary>
    ///  资讯类型表
    /// </summary>
    public partial class CmsMaterialType : Entity<string> {       

        /// <summary>
        /// 图文素材类型名
        /// </summary>
        [Required(ErrorMessage = "图文素材类型名不能为空")]
        [StringLength( 200, ErrorMessage = "图文素材类型名输入过长，不能超过200位" )]
        public virtual string MATERIAL_TYPE_NAME { get; set; }
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
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 属性(1.图文，2资讯，3.商城,4.热词)
        /// </summary>
        [StringLength( 50, ErrorMessage = "属性(1.图文，2资讯，3.商城,4.热词)输入过长，不能超过50位" )]
        public virtual string MATERIAL_ATTR { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 资讯类型(1.普通资讯，2.活动资讯，3.询价资讯)
        /// </summary>
        public virtual long? MATERIAL_INFO_TYPE { get; set; }
        /// <summary>
        /// 热词用途(1.首页，2.资讯，3.商城)
        /// </summary>
        public virtual long? HOT_PURPOSE { get; set; }
        /// <summary>
        /// 热词内容
        /// </summary>
        [StringLength( 500, ErrorMessage = "热词内容输入过长，不能超过500位" )]
        public virtual string HOT_CONTENT { get; set; }
    }
}