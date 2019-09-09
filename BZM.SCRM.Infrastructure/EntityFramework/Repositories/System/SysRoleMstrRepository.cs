using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using Spring.Datas.Queries;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class SysRoleMstrRepository : SCRMRespositoryBase<SysRoleMstr,decimal>, ISysRoleMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
        /// <summary>
        /// 权限helper
        /// </summary>
        protected readonly PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public SysRoleMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取用户角色范围
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>>GetUserRoleScope(decimal userId)
        {
            return _sqlQuery.Select(@"
              wm_concat (DISTINCT nvl (ROLE_SCOPE, 'MD')) ROLE_SCOPE")
              .And("role_id in(select role_id from sys_usr_auth auth where usr_id=" + userId + ")")
              .Filter("del_flag",1)
              .GetList<string>(@"sys_role_mstr", Context.Database.GetDbConnection());
        }


        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<dynamic> GetRoleList(string sql)
        {
            var rolePerssion = _permissionHelper.GetRoleSql(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, AbpSession.ORG_NO, AbpSession.BG_NO);
            rolePerssion = rolePerssion + sql;
            return _sqlQuery.Select(@"
                ROLE_ID,
                ROLE_NAME")
                .And(rolePerssion)
                .OrderBy("CREATE_DATE desc")
                .GetList<dynamic>("SYS_ROLE_MSTR", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 获取角色权限分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetRolePageList(SysRoleMstrQuery query)
        {
            var rolePerssion = _permissionHelper.GetRoleSql(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, AbpSession.ORG_NO, AbpSession.BG_NO,"role.");
            rolePerssion = rolePerssion + query.sql;
            return _sqlQuery.Select(@"
                role.ROLE_ID,
                role.ROLE_NAME,
                role.ROLE_SCOPE,
               (
		           CASE role.ROLE_STATUS
		           WHEN 1 THEN
			           '启用'
		           ELSE
			           '禁用'
		           END
	                    ) AS ROLE_STATUS,
                role.ROLE_DESC,
                bu.BU_NAME")
                .Filter("role.ROLE_NAME", query.ROLE_NAME,Operator.Contains)
                .Filter("role.ROLE_DESC", query.ROLE_DESC, Operator.Contains)
                .Filter("role.DEL_FLAG","1")
                .And(rolePerssion)
                .OrderBy("role.CREATE_DATE desc")
                .GetPageList<dynamic>(@"SYS_ROLE_MSTR role 
                LEFT JOIN MDM_BU_MSTR bu on role.CREATE_ORG_NO=bu.BU_NO", Context.Database.GetDbConnection(),query);
        }

        /// <summary>
        /// 批量删除角色权限信息
        /// </summary>
        /// <param name="roleIds"></param>
        public void BatchDelSysRoleInfo(string roleIds)
        {
            var sql = "Update SYS_ROLE_MSTR set DEL_FLAG=0 Where ROLE_ID in (" + roleIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
