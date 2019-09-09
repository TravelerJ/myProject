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
    /// 职务仓储
    /// </summary>
    public class MdmDutyMstrRepository : SCRMRespositoryBase<MdmDutyMstr,decimal>, IMdmDutyMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public MdmDutyMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取职务分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetMdmDutyPageList(MdmDutyMstrQuery query)
        {
            return _sqlQuery.Select(@"
                DUTY_ID,
                DUTY_NO,
                DUTY_NAME,
               (
		           CASE DUTY_STATUS
		           WHEN 1 THEN
			           '启用'
		           ELSE
			           '禁用'
		           END
	                    ) AS DUTY_STATUS")
                .Filter("DUTY_NAME", query.DUTY_NAME,Operator.Contains)
                .Filter("DUTY_NO", query.DUTY_NO,Operator.Contains)
                .Filter("BG_NO", AbpSession.BG_NO)
                .Filter("DEL_FLAG", "1")
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>(@"MDM_DUTY_MSTR", Context.Database.GetDbConnection(), query);

        }

        /// <summary>
        /// 获取职务列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetMdmDutyList()
        {
            return _sqlQuery.Select(@"
                DUTY_ID,
                DUTY_NAME")
                .Filter("BG_NO", AbpSession.USR_TYPE=="9"?"":AbpSession.BG_NO)
                .Filter("DEL_FLAG","1")
                .OrderBy("DUTY_NO")
                .GetList<dynamic>(@"MDM_DUTY_MSTR", Context.Database.GetDbConnection());

        }


        /// <summary>
        /// 批量删除职务信息
        /// </summary>
        /// <param name="dutyIds"></param>
        public void BatchDelMdmDutyInfo(string dutyIds)
        {
            var sql = "Update MDM_DUTY_MSTR set DEL_FLAG=0 Where DUTY_ID in (" + dutyIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
