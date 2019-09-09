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
    public class CrmQpaperQuRepository : SCRMRespositoryBase<CrmQpaperQu, string>, ICrmQpaperQuRepository
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
        public CrmQpaperQuRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetCrmQpaperQuPageList(CrmQpaperQuQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"QU_ID, QU_SN, QU_TYPE, QU_NAME, QU_ENABLED, QU_ANSWER, PAPER_TYPE")
                .Filter("DEL_FLAG", 1)
                .Filter("QU_SN", query.QU_SN)
                .Contains("QU_NAME", query.QU_NAME)
                .Filter("PAPER_TYPE", query.PAPER_TYPE)
                .Filter("QU_TYPE", query.QU_TYPE)
                .Filter("QU_ENABLED", query.QU_ENABLED)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>(" CRM_QPAPER_QU", Context.Database.GetDbConnection(), query);
        }
    }
}
