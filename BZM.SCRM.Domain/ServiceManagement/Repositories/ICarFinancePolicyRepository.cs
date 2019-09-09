using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICarFinancePolicyRepository : IRepository<CarFinancePolicy,string> {
        /// <summary>
        /// 获取金融政策分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetFinancePolicyList(CarFinancePolicyQuery query);
    }
}
