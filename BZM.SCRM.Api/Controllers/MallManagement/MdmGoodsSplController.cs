
using BZM.SCRM.Api.Controllers;
using SCRM.Application.MallManagement.Contracts;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class MdmGoodsSplController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsSplService _mdmGoodsSplService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="mdmGoodsSplService">服务</param>
        /// </summary>
        public MdmGoodsSplController( IMdmGoodsSplService mdmGoodsSplService ) {
            _mdmGoodsSplService = mdmGoodsSplService;
        }
    }
}
