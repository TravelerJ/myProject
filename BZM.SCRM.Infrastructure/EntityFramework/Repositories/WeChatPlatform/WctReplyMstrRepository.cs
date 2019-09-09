using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Queries;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Infrastructure.EntityFramework.Repositories.WeChatPlatform
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctReplyMstrRepository : SCRMRespositoryBase<WctReplyMstr,string>, IWctReplyMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctReplyMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取回复信息分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetReplyPageList(WctReplyMstrQuery query)
        {
            return _sqlQuery.Select(@"
                    REPLY_ID,
	                REPLY_KEYWORD,
	                REPLY_TEXT,
	                REPLY_STATUS,
	                CASE REPLY_TYPE
                WHEN 1 THEN
	                '关注'
                WHEN 2 THEN
	                '默认'
                WHEN 3 THEN
	                '关键词'
                WHEN 4 THEN
	                '新用户关注'
                END REPLY_TYPE,
                    CASE REPLY_CONTENT_TYPE
                WHEN 0 THEN
	                '文本'
                WHEN 1 THEN
	                '图文(链接)'
                WHEN 2 THEN
	                '图文(详情)'
                WHEN 3 THEN
	                '图文(模块)'
                END REPLY_CONTENT_TYPE")
                .Filter("REPLY_KEYWORD", query.REPLY_KEYWORD, Operator.Contains)               
                .Filter("CREATE_ORG_NO",AbpSession.ORG_NO)
                .Filter("DEL_FLAG", "1")
                .And(query.REPLY_TYPE == null ? "" : "REPLY_TYPE=" + query.REPLY_TYPE + "")
                .OrderBy("UPDATE_DATE desc")
                .GetPageList<dynamic>(@"WCT_REPLY_MSTR", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 批量删除回复信息
        /// </summary>
        /// <param name="replyIds"></param>
        public void BatchDelReplyInfo(string replyIds)
        {
            var sql = "Update WCT_REPLY_MSTR set DEL_FLAG=0 Where REPLY_ID in (" + replyIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
        /// <summary>
        /// 批量更新回复信息状态
        /// </summary>
        /// <param name="replyIds"></param>
        public void BatchUpdateReplyStatus(string replyIds,string status)
        {
            var sql = "Update WCT_REPLY_MSTR set REPLY_STATUS='" + status + "' Where REPLY_ID in (" + replyIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
