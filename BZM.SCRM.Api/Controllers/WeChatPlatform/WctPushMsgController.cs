
using BZM.SCRM.Api.Controllers;
using SCRM.Application.WeChatPlatform.Contracts;

namespace SCRM.Controllers.WeChatPlatform
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class WctPushMsgController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IWctPushMsgService _wctPushMsgService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="wctPushMsgService">服务</param>
        /// </summary>
        public WctPushMsgController( IWctPushMsgService wctPushMsgService ) {
            _wctPushMsgService = wctPushMsgService;
        }
    }
}
