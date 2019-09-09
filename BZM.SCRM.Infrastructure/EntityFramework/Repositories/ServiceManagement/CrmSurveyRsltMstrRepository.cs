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
    public class CrmSurveyRsltMstrRepository : SCRMRespositoryBase<CrmSurveyRsltMstr, string>, ICrmSurveyRsltMstrRepository
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
        public CrmSurveyRsltMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetSurveyRsltPageList(CrmSurveyRsltMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "sur.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);

            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                where += string.IsNullOrEmpty(where) ? "to_char(sur.CREATE_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'" : "and to_char(sur.CREATE_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'";
            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += string.IsNullOrEmpty(where) ? "to_char(sur.CREATE_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'" : "and to_char(sur.CREATE_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'";
            }

            return _sqlQuery.Select(@" sur.RSLT_ID,sur.SURVEY_TITLE,sur.ANSWER_SCORE,sur.REPORT_NAME,sur.REPORT_DATE,sur.CREATE_DATE,sur.ANSWER_JSON,bu.BU_NAME,BU.PARENT_BU_NAME")
                .Filter("sur.DEL_FLAG", 1)
                .Filter("bu.PARENT_BU_NO", query.AREA_NO)
                .Filter("bu.BU_NO", query.BU_NO)
                //.Filter("to_char(sur.CREATE_DATE,'yyyy-MM-dd')>=", query.START_DATE)
                //.Filter("to_char(sur.CREATE_DATE,'yyyy-MM-dd')<=", query.END_DATE)
                .And(where)
                .Contains("sur.REPORT_NAME", query.REPORT_NAME)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>(@"CRM_SURVEY_RSLT_MSTR sur left join mdm_bu_mstr bu on sur.CREATE_ORG_NO=bu.bu_no", Context.Database.GetDbConnection(), query);
        }
    }
}
