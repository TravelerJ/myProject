using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctPushMsgRepository : IRepository<WctPushMsg,string> {
    }
}
