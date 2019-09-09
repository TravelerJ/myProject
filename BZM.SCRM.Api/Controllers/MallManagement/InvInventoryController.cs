
using BZM.SCRM.Api.Controllers;
using SCRM.Application.MallManagement.Contracts;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class InvInventoryController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IInvInventoryService _invInventoryService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="invInventoryService">服务</param>
        /// </summary>
        public InvInventoryController( IInvInventoryService invInventoryService ) {
            _invInventoryService = invInventoryService;
        }
    }
}
