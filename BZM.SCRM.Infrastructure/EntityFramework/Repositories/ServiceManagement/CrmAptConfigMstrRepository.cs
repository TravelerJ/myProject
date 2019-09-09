using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.ServiceManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class CrmAptConfigMstrRepository : SCRMRespositoryBase<CrmAptConfigMstr, string>, ICrmAptConfigMstrRepository
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
        public CrmAptConfigMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取预约配置分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetAptConfigPageList(CrmAptConfigMstrQuery query)
        {
            //string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "BU_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"APT_CONFIG_ID, APT_CONFIG_SDATE, APT_CONFIG_EDATE,APT_TYPE,case APT_TYPE when 1 then '预约试驾' when 2 then '养修预约' else '' end as APT_TYPENAME, APT_CONFIG_JSON, APT_MIN_DISCOUNT, UPDATE_DATE, DIS_TYPE,case DIS_TYPE when 1 then '折扣' when 2 then '金额' else '' end as DIS_TYPENAME, APT_LIMIT, IS_DEFAULT")
                .Filter("DEL_FLAG", 1)
                .Filter("DIS_TYPE", query.DIS_TYPE)
                .Filter("APT_TYPE", query.APT_TYPE)
                .Filter("BU_NO",AbpSession.ORG_NO)
                //.And(where)
                .And("APT_TYPE!='0'")
                .OrderBy("UPDATE_DATE DESC")
                .GetPageList<dynamic>(" CRM_APT_CONFIG_MSTR", Context.Database.GetDbConnection(), query);
        }

        public dynamic GetAptConfigList(string where)
        {
            return _sqlQuery.Select("*")
                .And(where)
                .OrderBy("UPDATE_DATE DESC")
                .GetPageList<dynamic>(" CRM_APT_CONFIG_MSTR", Context.Database.GetDbConnection(), 1);
        }
    }
}
