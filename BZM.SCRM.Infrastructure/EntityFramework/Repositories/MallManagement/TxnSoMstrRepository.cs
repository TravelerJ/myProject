using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class TxnSoMstrRepository : SCRMRespositoryBase<TxnSoMstr, string>, ITxnSoMstrRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        private readonly PermissionHelper _permissionHelper;
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public TxnSoMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取订单分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetOrderPageList(TxnSoMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "so.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                where += string.IsNullOrEmpty(where) ? " and TO_char(so.CREATE_DATE,'yyyy-mm-dd') >= '" + query.START_DATE + "'" : "TO_char(so.CREATE_DATE, 'yyyy-mm-dd') >= '" + query.START_DATE + "'";
            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += string.IsNullOrEmpty(where) ? " and TO_char(so.CREATE_DATE,'yyyy-mm-dd') <= '" + query.END_DATE + "'" : "TO_char(so.CREATE_DATE,'yyyy-mm-dd') <= '" + query.END_DATE + "'";
            }
            return _sqlQuery.Select(@"so.*,cus.ERP_MEMBER_NO,bu.bu_name,mbm.bu_name  as BG_NAME")
                .Filter("so.DEL_FLAG", 1)
                .Filter("so.STATUS", query.STATUS)
                .Filter("so.SO_NO", query.SO_NO)
                .Filter("cus.ERP_MEMBER_NO", query.ERP_MEMBER_NO)
                .Filter("so.QUEUE_NO", query.QUEUE_NO)
                .Filter("so.CUS_NAME", query.CUS_NAME)
                .Filter("so.EXPRESS_NO", query.EXPRESS_NO)
                .In("so.biz_type", new string[] { "DS", "MS" })
                .And(where)
                .OrderBy("so.CREATE_DATE desc")
                .GetPageList<dynamic>(@"TXN_SO_MSTR so left join sys_usr_mstr cus on so.CREATE_PSN = cus.usr_id left join MDM_BU_MSTR bu on bu.bu_no = so.ORG_NO left join MDM_BU_MSTR mbm on mbm.bu_no = bu.parent_bu_no", Context.Database.GetDbConnection(), query);

        }
    }
}
