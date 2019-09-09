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
    public class StoreAdvertiseMstrRepository : SCRMRespositoryBase<StoreAdvertiseMstr, string>, IStoreAdvertiseMstrRepository
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
        public StoreAdvertiseMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetStoreAdvertisePageList(StoreAdvertiseMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "BU_NO", AbpSession.ORG_NO, AbpSession.BG_NO);

            return _sqlQuery.Select(@"ADVERTISE_ID,
                ADVERTISE_THEME,
                ADVERTISE_TYPE,
                ADVERTISE_CONTENT,
                ADVERTISE_POSTER_URL,
                STORE_CONTRACT,
                ADVERTISE_STATUS,
                ADVERTISE_CATEGORY，
                UPDATE_DATE")
                .Filter("DEL_FLAG", 1)
                .Contains("ADVERTISE_THEME", query.ADVERTISE_THEME)
                .Filter("ADVERTISE_TYPE", query.ADVERTISE_TYPE)
                .Filter("ADVERTISE_STATUS", query.ADVERTISE_STATUS)
                .Filter("ADVERTISE_CATEGORY", query.ADVERTISE_CATEGORY)
                .And(where)
                .And("ADVERTISE_TYPE!='0'")
                .OrderBy("UPDATE_DATE DESC")
                .GetPageList<dynamic>(" store_advertise_mstr", Context.Database.GetDbConnection(), query);
        }
    }
}
