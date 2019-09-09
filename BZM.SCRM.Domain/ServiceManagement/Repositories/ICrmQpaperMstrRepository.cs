using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICrmQpaperMstrRepository : IRepository<CrmQpaperMstr,string> {
        PagerList<dynamic> GetCrmQpaperMstrPageList(CrmQpaperMstrQuery query);
    }
}
