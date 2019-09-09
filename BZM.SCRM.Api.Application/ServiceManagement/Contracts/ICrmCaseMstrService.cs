using Abp.Application.Services;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmCaseMstrService : IApplicationService {
        /// <summary>
        /// 删除客户反馈信息
        /// </summary>
        /// <param name="ids"></param>
        void DeleteCrmCaseInfo(string ids);
    }
}
