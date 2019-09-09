
using BZM.SCRM.Application;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Domain.WeChatPlatform.Repositories;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class WctAppItemService : SCRMAppServiceBase, IWctAppItemService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IWctAppItemRepository _wctAppItemRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctAppItemService( IWctAppItemRepository wctAppItemRepository ) {
            _wctAppItemRepository = wctAppItemRepository;
        }
    }
}
