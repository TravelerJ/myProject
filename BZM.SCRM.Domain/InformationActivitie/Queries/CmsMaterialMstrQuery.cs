using System.Collections.Generic;

namespace SCRM.Domain.InformationActivitie.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CmsMaterialMstrQuery {
        /// <summary>
        /// 素材用途(1图文,2资讯)
        /// </summary>
        public string MATERIAL_ATTR { get; set; }
        /// <summary>
        /// 执行类型1轮播2上线
        /// </summary>
        public int ExcuteType { get; set; }

        /// <summary>
        /// 素材id集合
        /// </summary>
        public List<string> MATERIAL_IDS { get; set; }
    }
}