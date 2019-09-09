using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ITagMstrRepository : IRepository<TagMstr,string> {

        /// <summary>
        /// 获取标签分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetTagMstrPageList(TagMstrQuery query);
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<dynamic> GetTagMstrList(TagMstrQuery query);
    }
}
