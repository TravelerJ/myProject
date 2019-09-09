
using BZM.SCRM.Application;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Domain.WeChatPlatform.Repositories;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class WctPushMsgService : SCRMAppServiceBase, IWctPushMsgService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IWctPushMsgRepository _wctPushMsgRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctPushMsgService( IWctPushMsgRepository wctPushMsgRepository ) {
            _wctPushMsgRepository = wctPushMsgRepository;
        }
    }
}
