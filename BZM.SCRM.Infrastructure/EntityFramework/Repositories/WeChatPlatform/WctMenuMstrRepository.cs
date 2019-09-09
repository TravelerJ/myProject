using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Sql.Queries;
using System.Collections.Generic;

namespace SCRM.Infrastructure.Datas.MySql.EntityFramework.Repositories {    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctMenuMstrRepository : SCRMRespositoryBase<WctMenuMstr,string>, IWctMenuMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctMenuMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取微信菜单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetWxMenuList(WctMenuMstrQuery query)
        {
            return _sqlQuery.Select(@"*")
                .Filter("MENU_ID_NO", AbpSession.ORG_NO)
                .Filter("MENU_LEVEL",query.MENU_LEVEL)
                .Filter("MENU_PARENTID",query.MENU_PARENTID)
                .Filter("DEL_FLAG", 1)
                .Filter("MENU_STATUS",1)
                .OrderBy("MENU_DISPLAYINDEX")
                .GetList<dynamic>(@"WCT_MENU_MSTR", Context.Database.GetDbConnection());
        }
        /// <summary>
        /// 删除微信菜单
        /// </summary>
        /// <param name="menuId"></param>
        public void DelWxMenuInfo(string menuId)
        {
            var sql = "DELETE FROM WCT_MENU_MSTR  Where MENU_ID='" + menuId + "'";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
