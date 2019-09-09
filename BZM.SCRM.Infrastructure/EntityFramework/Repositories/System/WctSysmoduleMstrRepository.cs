using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.System.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.System
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctSysmoduleMstrRepository : SCRMRespositoryBase<WctSysmoduleMstr,string>, IWctSysmoduleMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctSysmoduleMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }


        /// <summary>
        /// 获取系统模块分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetSysModulePageList(WctSysmoduleMstrQuery query)
        {
            var sql = "";
            if (!string.IsNullOrEmpty(query.SYSM_JSON_VALUE))
            {
                sql = "to_char(SYSM_JSON_VALUE) like '%" + query.SYSM_JSON_VALUE + "%'";
            }
            return _sqlQuery.Select(@"
                SYSM_ID,
                SYSM_KEY,
                SYSM_TITLE,
                to_char(SYSM_JSON_VALUE),
                UPDATE_DATE")
                .Filter("SYSM_KEY", query.SYSM_KEY)
                .Filter("SYSM_TITLE", query.SYSM_TITLE)               
                .Filter("BG_NO", AbpSession.BG_NO)
                .Filter("DEL_FLAG", "1")
                .And("SYSM_CODE is null")
                .And(sql)
                .OrderBy("UPDATE_DATE desc")
                .GetPageList<dynamic>(@"WCT_SYSMODULE_MSTR", Context.Database.GetDbConnection(), query);
                   
        }

        /// <summary>
        /// 获取系统模块列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<dynamic> GetSysModuleList()
        {

            return _sqlQuery.Select(@"
                SYSM_ID,
                SYSM_KEY,
                SYSM_TITLE,
                SYSM_JSON_VALUE,
                UPDATE_DATE")
                .Filter("BG_NO", AbpSession.BG_NO)
                .Filter("DEL_FLAG", "1")
                .And("SYSM_CODE is null")
                .OrderBy("UPDATE_DATE desc")
                .GetList<dynamic>(@"WCT_SYSMODULE_MSTR", Context.Database.GetDbConnection());

        }

        /// <summary>
        /// 获取系统模块列表
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<WctSysmoduleMstrModel> GetSysModuleList(List<string>Ids,string key)
        {

            return _sqlQuery.Select(@"*")
                .Filter("SYSM_CODE",key)
                .Filter("DEL_FLAG", "1")
                .In("SYSM_ID",Ids)
                .OrderBy("UPDATE_DATE desc")
                .GetList<WctSysmoduleMstrModel>(@"WCT_SYSMODULE_MSTR", Context.Database.GetDbConnection());

        }


        /// <summary>
        /// 批量删除系统模块信息
        /// </summary>
        /// <param name="sysMoudleIds"></param>
        public void BatchDelSysMoudleInfo(string sysMoudleIds)
        {
            var sql = "Update WCT_SYSMODULE_MSTR set DEL_FLAG=0 Where SYSM_ID in (" + sysMoudleIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
