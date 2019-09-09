using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.WeChatPlatform
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctPushMsgRepository : SCRMRespositoryBase<WctPushMsg,string>, IWctPushMsgRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctPushMsgRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }
    }
}
