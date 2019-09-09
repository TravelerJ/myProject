using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICrmAptConfigMstrRepository : IRepository<CrmAptConfigMstr,string> {
        /// <summary>
        /// 获取预约配置分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetAptConfigPageList(CrmAptConfigMstrQuery query);

        /// <summary>
        /// 根据条件获取预约数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        dynamic GetAptConfigList(string where);
    }
}
