using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using Spring.Datas.Queries;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.WeChatPlatform
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class TagMstrRepository : SCRMRespositoryBase<TagMstr,string>, ITagMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public TagMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取标签分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetTagMstrPageList(TagMstrQuery query)
        {
            return _sqlQuery.Select(@"
                TAG_MSTR_CODE,
                TAG_NAME,
                TAG_MSTR_DESC,
                CREATE_DATE,
                CASE TAG_STATUS
                WHEN 1 THEN
                '是'
                ELSE
                '否'
                END TAG_STATUS")
                .Filter("TAG_NAME", query.TAG_NAME,Operator.Contains)
                .Filter("CREATE_ORG_NO",AbpSession.ORG_NO)
                .Filter("DEL_FLAG", 1)
                .OrderBy("UPDATE_DATE desc")
                .GetPageList<dynamic>(@"TAG_MSTR", Context.Database.GetDbConnection(), query);
        }


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<dynamic> GetTagMstrList(TagMstrQuery query)
        {
            return _sqlQuery.Select(@"
                TAG_MSTR_CODE,
                TAG_NAME")
                .Filter("CREATE_ORG_NO", query.CREATE_ORG_NO)
                .Filter("DEL_FLAG", 1)
                .OrderBy("UPDATE_DATE desc")
                .GetList<dynamic>(@"TAG_MSTR", Context.Database.GetDbConnection());
        }
    }
}
