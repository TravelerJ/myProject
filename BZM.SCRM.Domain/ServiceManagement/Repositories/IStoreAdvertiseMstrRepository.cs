using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IStoreAdvertiseMstrRepository : IRepository<StoreAdvertiseMstr,string> {
        PagerList<dynamic> GetStoreAdvertisePageList(StoreAdvertiseMstrQuery query);
    }
}
