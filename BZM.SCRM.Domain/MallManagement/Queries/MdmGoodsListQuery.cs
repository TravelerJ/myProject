using System.ComponentModel.DataAnnotations;

namespace SCRM.Domain.MallManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmGoodsListQuery {
        /// <summary>
        /// 区域编码
        /// </summary>
        [Display(Name = "区域编码")]
        public string AREA_NO { get; set; }
    }
}