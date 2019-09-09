using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICrmAptMstrRepository : IRepository<CrmAptMstr,string> {
        /// <summary>
        /// 获取客户管理分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetCrmAptMstrPageList(CrmAptMstrQuery query);
    }
}
