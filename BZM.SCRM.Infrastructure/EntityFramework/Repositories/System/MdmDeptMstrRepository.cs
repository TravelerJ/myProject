using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using Spring.Datas.Queries;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 部门仓储
    /// </summary>
    public class MdmDeptMstrRepository : SCRMRespositoryBase<MdmDeptMstr,decimal>, IMdmDeptMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public MdmDeptMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetMdmDeptPageList(MdmDeptMstrQuery query)
        {
            return _sqlQuery.Select(@"
                DEPT_ID,
                DEPT_NO,
                DEPT_NAME,
               (
		           CASE DEPT_STATUS
		           WHEN 1 THEN
			           '启用'
		           ELSE
			           '禁用'
		           END
	                    ) AS DEPT_STATUS")
                .Filter("DEPT_NAME", query.DEPT_NAME, Operator.Contains)
                .Filter("DEPT_NO", query.DEPT_NO, Operator.Contains)
                .Filter("BG_NO", AbpSession.BG_NO)
                .Filter("DEL_FLAG", "1")
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>(@"MDM_DEPT_MSTR", Context.Database.GetDbConnection(), query);

        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetMdmDeptList()
        {
            return _sqlQuery.Select(@"
                DEPT_ID,
                DEPT_NAME")
                .Filter("BG_NO", AbpSession.USR_TYPE == "9" ? "" : AbpSession.BG_NO)
                .Filter("DEL_FLAG", "1")
                .OrderBy("DEPT_NO")
                .GetList<dynamic>(@"MDM_DEPT_MSTR", Context.Database.GetDbConnection());

        }


        /// <summary>
        /// 批量删除部门信息
        /// </summary>
        /// <param name="deptIds"></param>
        public void BatchDelMdmDeptInfo(string deptIds)
        {
            var sql = "Update MDM_DEPT_MSTR set DEL_FLAG=0 Where DEPT_ID in (" + deptIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
