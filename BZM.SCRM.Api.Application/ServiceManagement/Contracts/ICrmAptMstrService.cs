using Abp.Application.Services;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmAptMstrService : IApplicationService {
        /// <summary>
        /// 更新预约单状态为已完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CrmAptMstr UpdateStatusToComplete(string id);
    }
}
