using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.WeChatPlatform.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Sql.Queries;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.WeChatPlatform
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctAppMstrRepository : SCRMRespositoryBase<WctAppMstr,string>, IWctAppMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctAppMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取主应用列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<WctAppInfoModel> GetAppMstrList()
        {
            return _sqlQuery.Select(@"
                APP_ID key,
                APP_SORT sort,
                APP_NAME appName,
                WCT_MODULE_ID moduleId,
                WCT_APP_URL appUrl,
                WCT_MODULE_TYPE moduleType,
                UDF2 moduleKey,
                UDF3 module_icon")
                .Filter("BU_NO", AbpSession.ORG_NO)
                .Filter("DEL_FLAG", 1)
                .OrderBy("APP_SORT")
                .GetList<WctAppInfoModel>(@"WCT_APP_MSTR", Context.Database.GetDbConnection());
        }
    }
}
