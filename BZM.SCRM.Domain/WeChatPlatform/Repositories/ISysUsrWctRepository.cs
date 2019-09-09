using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ISysUsrWctRepository : IRepository<SysUsrWct,string> {
        /// <summary>
        /// 分页获取粉丝信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetWctInfoPageList(SysUsrWctQuery query);
    }
}
