using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.ServiceManagement
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class AptDriveConfigRepository : SCRMRespositoryBase<AptDriveConfig,string>, IAptDriveConfigRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public AptDriveConfigRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }
    }
}
