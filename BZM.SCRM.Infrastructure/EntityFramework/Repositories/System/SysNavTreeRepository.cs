using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.System.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using Spring.Datas.Sql.Queries;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class SysNavTreeRepository : SCRMRespositoryBase<SysNavTree,string>, ISysNavTreeRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public SysNavTreeRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }


        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SysUsrMstrNavTreeModel> GetSysUsrMstrNavTree(decimal userId)
        {
            return _sqlQuery.Select(@"                nav.NAV_NO,	            nav.NAV_NAME,	            nav.NAV_URL,	            nav.NAV_IMG_URL,	            nav.NAV_PARENT_NO,
                nav.NAV_SORT_NO,
                nav.NAV_EXPAND")
                .Filter("auth.USR_ID", userId)
                .Filter("role.DEL_FLAG", "1")
                .Filter("role.ROLE_STATUS", "1")
                .Filter("nav.NAV_STATUS", "1")
                .Filter("nav.DEL_FLAG", "1")
                .OrderBy("nav.NAV_NO,nav.NAV_SORT_NO")
                .GetList<SysUsrMstrNavTreeModel>(@"sys_usr_auth auth                 INNER JOIN SYS_ROLE_MSTR role on auth.ROLE_ID = role.ROLE_ID                INNER JOIN SYS_ROLE_MENU_PERMISSION per on auth.ROLE_ID = per.ROLE_ID                INNER JOIN SYS_NAV_TREE nav on per.PERMISSION = nav.NAV_NO", Context.Database.GetDbConnection());


        }

        /// <summary>
        /// 管理员菜单列表
        /// </summary>
        /// <returns></returns>
        public List<SysUsrMstrNavTreeModel> GetSysUsrMstrNavTreeList()
        {
            return _sqlQuery.Select(@"                nav.NAV_NO,	            nav.NAV_NAME,	            nav.NAV_URL,	            nav.NAV_IMG_URL,	            nav.NAV_PARENT_NO")
                .Filter("nav.NAV_STATUS", "1")
                .Filter("nav.DEL_FLAG", "1")
                .OrderBy("nav.NAV_NO,nav.NAV_SORT_NO")
                .GetList<SysUsrMstrNavTreeModel>(@"SYS_NAV_TREE nav", Context.Database.GetDbConnection());


        }
    }
}
