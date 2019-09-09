using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.WeChatPlatform
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class TagHistRepository : SCRMRespositoryBase<TagHist,string>, ITagHistRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public TagHistRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 删除标签记录信息
        /// </summary>
        /// <param name="wctId"></param>
        /// <param name="fleId"></param>
        public void DelTagHistInfo(string wctId,string fleId)
        {
            var sql = "DELETE FROM TAG_HIST  Where TAG_REF_FIELD_ID='" + fleId+ "' and TAG_REF_ROW_NO='"+wctId+"'";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
