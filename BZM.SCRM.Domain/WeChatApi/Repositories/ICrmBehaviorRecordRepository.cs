using Abp.Domain.Repositories;
using SCRM.Domain.WeChatApi.Entitys;

namespace SCRM.Domain.WeChatApi.Repositories {
    /// <summary>
    /// 客户行为记录仓储
    /// </summary>
    public interface ICrmBehaviorRecordRepository : IRepository<CrmBehaviorRecord,string> {
    }
}
