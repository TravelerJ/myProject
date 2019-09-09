using BZM.SCRM.Domain.MallManagement.ReportModels;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmGoodsListDto
    {
        /// <summary>
        /// 商品关联图片
        /// </summary>
        public string files { get; set; }


        /// <summary>
        /// 属性集合
        /// </summary>
       public List<NewPublicInfo> newPublicInfos { get; set; }
    }
}