using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctReplyMstrRepository : IRepository<WctReplyMstr,string> {
        /// <summary>
        /// 获取回复信息分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetReplyPageList(WctReplyMstrQuery query);
        /// <summary>
        /// 批量删除回复信息
        /// </summary>
        /// <param name="replyIds"></param>
        void BatchDelReplyInfo(string replyIds);
        /// <summary>
        /// 批量更新回复信息状态
        /// </summary>
        /// <param name="replyIds"></param>
        /// <param name="status"></param>
        void BatchUpdateReplyStatus(string replyIds, string status);
    }
}
