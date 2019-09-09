using Abp.EntityFrameworkCore;
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
    /// 仓储
    /// </summary>
    public class CrmQpaperMstrRepository : SCRMRespositoryBase<CrmQpaperMstr, string>, ICrmQpaperMstrRepository
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
        public CrmQpaperMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetCrmQpaperMstrPageList(CrmQpaperMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);

            return _sqlQuery.Select(@"PAPER_ID, PAPER_NAME, PAPER_TYPE, INCLUDE_QUESTION_IDS, PAPER_SDATE, PAPER_EDATE, PAPER_DESC, PAPER_STATUS")
                .Filter("DEL_FLAG", 1)
                .Contains("PAPER_NAME", query.PAPER_NAME)
                .Filter("PAPER_TYPE", query.PAPER_TYPE)
                .Filter("PAPER_STATUS", query.PAPER_STATUS)
                .And(where)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>(" CRM_QPAPER_MSTR", Context.Database.GetDbConnection(), query);
        }
    }
}
