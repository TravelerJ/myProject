using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using SCRM.Domain.WeChatApi.Entitys;
using SCRM.Domain.WeChatApi.Repositories;
using Spring.Datas.Sql.Queries;

namespace BZM.SCRM.Infrastructure.WeChatApi.Repositories {    
        
    /// <summary>
    /// 客户行为记录仓储
    /// </summary>
    public class CrmBehaviorRecordRepository : SCRMRespositoryBase<CrmBehaviorRecord,string>, ICrmBehaviorRecordRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public CrmBehaviorRecordRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }
    }
}
