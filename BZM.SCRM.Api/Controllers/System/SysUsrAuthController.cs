
using BZM.SCRM.Api.Controllers;
using SCRM.Application.System.Contracts;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class SysUsrAuthController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ISysUsrAuthService _sysUsrAuthService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="sysUsrAuthService">服务</param>
        /// </summary>
        public SysUsrAuthController( ISysUsrAuthService sysUsrAuthService ) {
            _sysUsrAuthService = sysUsrAuthService;
        }
    }
}
