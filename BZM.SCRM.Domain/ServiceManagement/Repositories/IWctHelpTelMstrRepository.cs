using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctHelpTelMstrRepository : IRepository<WctHelpTelMstr,string> {
        /// <summary>
        /// 分页获取救援信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetHelpInfoPageList(WctHelpTelMstrQuery query);
    }
}
