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
    public class CarFinancePolicyRepository : SCRMRespositoryBase<CarFinancePolicy, string>, ICarFinancePolicyRepository
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
        public CarFinancePolicyRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取金融政策分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetFinancePolicyList(CarFinancePolicyQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select("*")
                .Filter("DEL_FLAG", 1)
                .Filter("BIZ_TYPE", query.BIZ_TYPE)
                .Filter("BRAND_CODE", query.BRAND_CODE)
                .Filter("CLASS_CODE", query.CLASS_CODE)
                .Filter("TYPE_CODE", query.TYPE_CODE)
                .Filter("SUBTYPE_CODE", query.SUBTYPE_CODE)
                .Contains("TAG_IDS", query.TAG_IDS)
                .And(where)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>("CAR_FINANCE_POLICY", Context.Database.GetDbConnection(), query);
        }
    }
}
