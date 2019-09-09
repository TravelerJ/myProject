using System.Collections.Generic;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctAppMstrDto {
        /// <summary>
        /// 子应用集合
        /// </summary>
        public List<WctAppItemDto> appItemList { get; set; }
    }
}