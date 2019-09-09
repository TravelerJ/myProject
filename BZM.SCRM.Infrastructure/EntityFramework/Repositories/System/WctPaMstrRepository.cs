using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
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
    /// 仓储
    /// </summary>
    public class WctPaMstrRepository : SCRMRespositoryBase<WctPaMstr,string>, IWctPaMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
        /// <summary>
        /// 权限helper
        /// </summary>
        protected readonly PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctPaMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }


        /// <summary>
        /// 获取公众号分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetWctPaMstrPageList(WctPaMstrQuery query)
        {
            var perssion = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "WCT_PA_MSTR.PA_ID_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"
                    WCT_PA_MSTR.PA_ID,
	                WCT_PA_MSTR.PA_NAME,
	                WCT_PA_MSTR.PA_ORIGINAL_ID,
	                WCT_PA_MSTR.CREATE_DATE,
	                SYS_USR_MSTR.USR_NAME,
	                BU.BU_NAME,
	                PABU.BU_NAME BG_NAME,
	                PA_APPID,
	                CASE PA_TYPE_ID
                WHEN 1 THEN
	                '服务号'
                WHEN 2 THEN
	                '订阅号'
                WHEN 3 THEN
	                '企业号'
                WHEN 4 THEN
	                '小程序'
                END PA_TYPE_ID")
                .Filter("WCT_PA_MSTR.PA_TYPE_ID",query.PA_TYPE_ID)
                .Filter("WCT_PA_MSTR.PA_NAME",query.PA_NAME, Operator.Contains)
                .Filter("WCT_PA_MSTR.PA_ORIGINAL_ID",query.PA_ORIGINAL_ID)
                .Filter("WCT_PA_MSTR.DEL_FLAG","1")
                .And(perssion)
                .OrderBy("WCT_PA_MSTR.UPDATE_DATE desc")
                .GetPageList<dynamic>(@"WCT_PA_MSTR 
                LEFT JOIN SYS_USR_MSTR ON WCT_PA_MSTR.CREATE_PSN = SYS_USR_MSTR.USR_ID 
                LEFT JOIN MDM_BU_MSTR BU ON WCT_PA_MSTR.PA_ID_NO=BU.BU_NO 
                LEFT JOIN MDM_BU_MSTR PABU ON PABU.BU_NO=BU.PARENT_BU_NO", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 批量删除公众信息
        /// </summary>
        /// <param name="paIds"></param>
        public void BatchDelPaInfo(string paIds)
        {
            var sql = "Update WCT_PA_MSTR set DEL_FLAG=0 Where PA_ID in (" + paIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
