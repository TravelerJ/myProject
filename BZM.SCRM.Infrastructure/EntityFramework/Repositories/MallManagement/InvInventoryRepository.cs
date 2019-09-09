using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class InvInventoryRepository : SCRMRespositoryBase<InvInventory,long>, IInvInventoryRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public InvInventoryRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }
    }
}
