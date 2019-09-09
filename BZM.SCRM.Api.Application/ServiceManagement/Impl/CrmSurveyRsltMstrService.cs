
using BZM.SCRM.Application;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Repositories;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmSurveyRsltMstrService : SCRMAppServiceBase, ICrmSurveyRsltMstrService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmSurveyRsltMstrRepository _crmSurveyRsltMstrRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmSurveyRsltMstrService( ICrmSurveyRsltMstrRepository crmSurveyRsltMstrRepository ) {
            _crmSurveyRsltMstrRepository = crmSurveyRsltMstrRepository;
        }
    }
}
