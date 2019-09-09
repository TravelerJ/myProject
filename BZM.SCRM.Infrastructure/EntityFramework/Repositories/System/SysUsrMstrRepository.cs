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
using System;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class SysUsrMstrRepository : SCRMRespositoryBase<SysUsrMstr,decimal>, ISysUsrMstrRepository {
        
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
        public SysUsrMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetSysUsrPageList(SysUsrMstrQuery query)
        {
            var perssion = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "usr.ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"
                    usr.USR_ID,
                    usr.USR_AVATAR_PATH,
                    usr.USR_NAME,
                    usr.USR_REAL_NAME,
                    usr.USR_EMAIL,
                    usr.UDF1 WeiXin,
                  (
		           CASE usr.USR_STATUS
		           WHEN 1 THEN
			           '启用'
		           ELSE
			           '禁用'
		           END
	                    ) AS USR_STATUS,
                    usr.USR_DESC,
                    dept.DEPT_NAME,
                    duty.DUTY_NAME,
                    bu.BU_SHORT_NAME,
                    usr.CREATE_DATE")
                .Filter("usr.USR_NAME", query.USR_NAME, Operator.Contains)
                .Filter("usr.USR_REAL_NAME", query.USR_REAL_NAME, Operator.Contains)
                .Filter("usr.USR_TYPE", query.USR_TYPE)
                .Filter("duty.DUTY_NAME", query.DUTY_NAME, Operator.Contains)
                .Filter("usr.DEL_FLAG", "1")
                .And("USR_TYPE!='0'")
                .And(perssion)
                .OrderBy("usr.CREATE_DATE desc")
                .GetPageList<dynamic>(@"SYS_USR_MSTR usr
                LEFT JOIN MDM_BU_MSTR bu ON usr.ORG_NO=bu.BU_NO
                LEFT JOIN MDM_DEPT_MSTR dept ON usr.DEPT_ID=dept.DEPT_ID
                LEFT JOIN MDM_DUTY_MSTR duty ON usr.DUTY_ID=duty.DUTY_ID", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 批量删除员工信息
        /// </summary>
        /// <param name="userIds"></param>
        public void BatchDelSysUsrInfo(string userIds)
        {
            var sql = "Update SYS_USR_MSTR set DEL_FLAG=0 Where USR_ID in (" + userIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
