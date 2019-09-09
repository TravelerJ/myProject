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
    public class WctAppItemRepository : SCRMRespositoryBase<WctAppItem,string>, IWctAppItemRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctAppItemRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 删除子应用菜单
        /// </summary>
        /// <param name="appId"></param>
        public void DelAppItemInfo(string appId)
        {
            var sql = "DELETE FROM WCT_APP_ITEM  Where MSTR_ID='"+appId+"'";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }

        /// <summary>
        /// 获取主应用列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<WctAppItemModel> GetAppItemList()
        {
            return _sqlQuery.Select(@"
                MSTR_ID appId,
                ITEM_NAME itemName,
                WCT_APP_URL itemUrl,
                UDF1 moduleId,
                UDF2 module_icon")
                .Filter("BU_NO", AbpSession.ORG_NO)
                .Filter("DEL_FLAG", 1)
                .OrderBy("ITEM_SORT")
                .GetList<WctAppItemModel>(@"WCT_APP_ITEM", Context.Database.GetDbConnection());
        }
    }
}
