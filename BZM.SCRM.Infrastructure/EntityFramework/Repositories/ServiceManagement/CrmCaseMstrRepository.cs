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
    public class CrmCaseMstrRepository : SCRMRespositoryBase<CrmCaseMstr, string>, ICrmCaseMstrRepository
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
        public CrmCaseMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取客户反馈分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetCrmCasePageList(CrmCaseMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "cm.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);

            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                where += string.IsNullOrEmpty(where) ? "to_char(apt.APT_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'" : "and to_char(apt.APT_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'";
            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += string.IsNullOrEmpty(where) ? "to_char(apt.APT_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'" : "and to_char(apt.APT_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'";
            }

            if (query.CASE_TYPE > 0)
            {
                where += string.IsNullOrEmpty(where) ? "cm.CASE_TYPE='" + query.CASE_TYPE + "'" : " and cm.CASE_TYPE='" + query.CASE_TYPE + "'";
            }
            return _sqlQuery.Select(@"cm.CASE_NO,
                                cm.UDF1,
                                cm.CASE_DATE,
                                cm.CASE_CLASS,
                                cm.CASE_TYPE,
                                CASE
                            WHEN cm.CASE_TYPE = 10 THEN '表扬员工'
                            WHEN cm.CASE_TYPE = 11 THEN '表扬店铺'
                            WHEN cm.CASE_TYPE = 20 THEN '投诉员工'
                            WHEN cm.CASE_TYPE = 21 THEN '投诉店铺'
                            END CASE_TYPE_TEXT,
                             cm.CASE_CONTENT,
                             bu.bu_name,
                             bu.parent_bu_name,
                             (
                                SELECT wct.udf3 FROM sys_usr_wct wct WHERE wct.bu_no = cm.CREATE_ORG_NO AND wct.open_id = cm.REF_CASE_NO AND rownum = 1
                            ) WXName,
                            (SELECT USR_JOB FROM SYS_USR_MSTR WHERE USR_ID=TO_NUMBER(REGEXP_REPLACE(cm.RESPONSIBLE_PSN,'[^0-9]','')))UsrJob")
                            .Filter("cm.DEL_FLAG", 1)
                            .And("cm.CASE_TYPE>0")
                            //.Filter("cm.CASE_TYPE", query.CASE_TYPE)
                            .Contains("cm.UDF1", query.UDF1)
                            .And(where)
                            //.Filter("to_char(cm.CASE_DATE,'yyyy-MM-dd')>=", query.START_DATE)
                            //.Filter("to_char(cm.CASE_DATE,'yyyy-MM-dd')<=", query.END_DATE)
                            .Filter("bu.PARENT_BU_NO", query.AREA_NO)
                               .Filter("bu.BU_NO", query.BU_NO)
                               .OrderBy("cm.CASE_DATE desc")
                              .GetPageList<dynamic>(@"CRM_CASE_MSTR cm
                            LEFT JOIN mdm_bu_mstr bu ON cm.CREATE_ORG_NO = bu.bu_no", Context.Database.GetDbConnection(), query);
        }
    }
}
