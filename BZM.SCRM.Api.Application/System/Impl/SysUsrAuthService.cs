
using BZM.SCRM.Application;
using SCRM.Application.System.Contracts;
using SCRM.Domain.System.Repositories;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class SysUsrAuthService : SCRMAppServiceBase, ISysUsrAuthService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ISysUsrAuthRepository _sysUsrAuthRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public SysUsrAuthService( ISysUsrAuthRepository sysUsrAuthRepository ) {
            _sysUsrAuthRepository = sysUsrAuthRepository;
        }
    }
}
