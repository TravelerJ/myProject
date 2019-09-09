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
    /// 机构仓储
    /// </summary>
    public class MdmBuMstrRepository : SCRMRespositoryBase<MdmBuMstr,string>, IMdmBuMstrRepository {
        
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
        public MdmBuMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }


        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic>GetMdmBuMstrList(MdmBuMstrQuery query)
        {
            var perssion = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "BU_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            perssion = query.BU_TYPE != 0 ? string.IsNullOrEmpty(perssion) ? "BU_TYPE=" + query.BU_TYPE + "" : perssion + " and BU_TYPE=" + query.BU_TYPE + "" : perssion;
            return _sqlQuery.Select(@"BU_NO,BU_NAME")
                .Filter("PARENT_BU_NO",query.PARENT_BU_NO)
                .Filter("BU_STATUS", "1")
                .Filter("DEL_FLAG", "1")
                .And(perssion)
                .OrderBy("BU_TYPE")
                .GetList<dynamic>("MDM_BU_MSTR", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 获取机构分页列表
        /// </summary>
        /// <returns></returns>
        public PagerList<dynamic> GetMdmBuMstrPageList(MdmBuMstrQuery query)
        {
            var perssion = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "BU_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            perssion = query.BU_TYPE != 0 ? perssion + " and BU_TYPE=" + query.BU_TYPE + "" : perssion;
            return _sqlQuery.Select(@"*")
                .Filter("BU_NO", query.BU_NO)
                .Filter("BU_NAME", query.BU_NAME,Operator.Contains)
                .Filter("DEL_FLAG", "1")
                .And(perssion)
                .OrderBy("BU_TYPE")
                .GetPageList<dynamic>("MDM_BU_MSTR", Context.Database.GetDbConnection(),query);
        }

        /// <summary>
        /// 批量删除机构信息
        /// </summary>
        /// <param name="buNos"></param>
        public void BatchDelBuInfo(string buNos)
        {
            var sql = "Update MDM_BU_MSTR set DEL_FLAG=0 Where BU_NO in (" + buNos + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
