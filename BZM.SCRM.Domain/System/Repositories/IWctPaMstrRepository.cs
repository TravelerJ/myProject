using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 公众号仓储
    /// </summary>
    public interface IWctPaMstrRepository : IRepository<WctPaMstr,string> {

        /// <summary>
        /// 获取公众号分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
         PagerList<dynamic> GetWctPaMstrPageList(WctPaMstrQuery query);

        /// <summary>
        /// 批量删除公众信息
        /// </summary>
        /// <param name="paIds"></param>
        void BatchDelPaInfo(string paIds);
    }
}
