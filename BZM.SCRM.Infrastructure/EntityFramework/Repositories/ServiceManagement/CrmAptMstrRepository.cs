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
    /// 预约管理仓储
    /// </summary>
    public class CrmAptMstrRepository : SCRMRespositoryBase<CrmAptMstr, string>, ICrmAptMstrRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        private PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public CrmAptMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取预约管理分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetCrmAptMstrPageList(CrmAptMstrQuery query)
        {
            //string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            string where = "";
            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                where += "to_char(apt.APT_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'";
            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += string.IsNullOrEmpty(where) ? " to_char(apt.APT_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'" : " and to_char(apt.APT_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'";
            }

            return _sqlQuery.Select(@"apt.APT_NO,apt.APT_CLASS,apt.SERVICE_DESK,apt.APT_CHANNEL,apt.CUS_NO,apt.UDF3,apt.UDF4,apt.UDF5,apt.UDF6,apt.CUS_NAME,apt.CUS_PHONE_NO,apt.CAR_ID,apt.VIN,apt.APT_DATE,apt.APT_TIMESPAN, apt.APT_STATUS, bu.BU_NAME, BU.PARENT_BU_NAME, wct.UDF3 NICK_NAME")
                .Filter("apt.del_flag", 1)
                .Contains("apt.APT_NO", query.APT_NO)
                .Contains("apt.CUS_NAME", query.CUS_NAME)
                .Contains("apt.CUS_PHONE_NO", query.CUS_PHONE_NO)
                .Filter("apt.APT_CLASS", query.APT_CLASS)
                .Filter("apt.APT_STATUS", query.APT_STATUS)
                //.Filter("to_char(apt.APT_DATE,'yyyy-MM-dd')>=", query.START_DATE)
                //.Filter("to_char(apt.APT_DATE,'yyyy-MM-dd')<=", query.END_DATE)
                .Filter("bu.PARENT_BU_NO", query.AREA_NO)
                .Filter("bu.BU_NO", query.BU_NO)
                .And(where)
                .OrderBy("apt.CREATE_DATE DESC")
                .GetPageList<dynamic>("CRM_APT_MSTR apt left join mdm_bu_mstr bu on apt.APT_BU_NO = bu.bu_no left join sys_usr_wct wct on apt.OPENID = wct.OPEN_ID", Context.Database.GetDbConnection(), query);
        }
    }
}
