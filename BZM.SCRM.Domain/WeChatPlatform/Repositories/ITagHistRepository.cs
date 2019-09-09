using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ITagHistRepository : IRepository<TagHist,string> {
        /// <summary>
        /// 删除标签记录信息
        /// </summary>
        /// <param name="wctId"></param>
        /// <param name="fleId"></param>
        void DelTagHistInfo(string wctId, string fleId);
    }
}
