using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using Spring.Datas.Sql.Queries;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 省市地仓储
    /// </summary>
    public class MdmBasRegionRepository : SCRMRespositoryBase<MdmBasRegion,string>, IMdmBasRegionRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public MdmBasRegionRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取省市地列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetMdmBasRegionList(MdmBasRegionQuery query)
        {
            return _sqlQuery.Select(@"REGION_NO,REGION_NAME")
                .Filter("PARENT_REGION_NO", query.PARENT_REGION_NO)
                .Filter("REGION_LEVEL",query.REGION_LEVEL)
                .Filter("DEL_FLAG", "1")
                .OrderBy("REGION_NO")
                .GetList<dynamic>("MDM_BAS_REGION", Context.Database.GetDbConnection());
        }
    }
}
