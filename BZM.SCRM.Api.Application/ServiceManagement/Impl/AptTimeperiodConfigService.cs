
using BZM.SCRM.Application;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Repositories;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class AptTimeperiodConfigService : SCRMAppServiceBase, IAptTimeperiodConfigService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IAptTimeperiodConfigRepository _aptTimeperiodConfigRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public AptTimeperiodConfigService( IAptTimeperiodConfigRepository aptTimeperiodConfigRepository ) {
            _aptTimeperiodConfigRepository = aptTimeperiodConfigRepository;
        }
    }
}
