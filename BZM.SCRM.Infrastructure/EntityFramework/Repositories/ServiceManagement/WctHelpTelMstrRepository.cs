using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Infrastructure.EntityFramework.Repositories.ServiceManagement
{

    /// <summary>
    /// 救援仓储
    /// </summary>
    public class WctHelpTelMstrRepository : SCRMRespositoryBase<WctHelpTelMstr, string>, IWctHelpTelMstrRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        public PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctHelpTelMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetHelpInfoPageList(WctHelpTelMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            var list = _sqlQuery.Select(@"TEL_ID, TEL_NAME, TEL_NO,TEL_ID_NO, CREATE_ORG_NO, CREATE_PSN, CREATE_DATE, UPDATE_PSN, UPDATE_DATE, BG_NO,
case TEL_TYPE when 'insurance' then '保险' when 'help' then '救援' else '' end as TEL_TYPE")
                .Filter("DEL_FLAG", 1)
                .Filter("CREATE_ORG_NO", query.CREATE_ORG_NO)
                .Contains("TEL_NO",query.TEL_NO)
                .And(where)
                .OrderBy("CREATE_DATE DESC")
                .GetPageList<dynamic>(" WCT_HELP_TEL_MSTR", Context.Database.GetDbConnection(), query);

            return list;
        }
    }
}
