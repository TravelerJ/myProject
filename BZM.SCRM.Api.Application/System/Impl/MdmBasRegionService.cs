
using BZM.SCRM.Application;
using SCRM.Application.System.Contracts;
using SCRM.Domain.System.Repositories;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmBasRegionService : SCRMAppServiceBase, IMdmBasRegionService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmBasRegionRepository _mdmBasRegionRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmBasRegionService( IMdmBasRegionRepository mdmBasRegionRepository ) {
            _mdmBasRegionRepository = mdmBasRegionRepository;
        }
    }
}
