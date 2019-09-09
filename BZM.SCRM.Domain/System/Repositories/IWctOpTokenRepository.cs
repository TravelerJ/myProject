using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 开放平台仓储
    /// </summary>
    public interface IWctOpTokenRepository : IRepository<WctOpToken,string> {
    }
}
