using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.InformationActivitie.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.InformationActivitie
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class WctCommentMstrRepository : SCRMRespositoryBase<WctCommentMstr,string>, IWctCommentMstrRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public WctCommentMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取评论集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<GetCommentModel> GetCommentList(WctCommentMstrQuery query)
        {
            return _sqlQuery.Select(@"
	            a.COMMENT_ID,
	            a.MATERIAL_ID,
	            a.COMMENT_OPENID,
	            a.MAIN_COMMENT_ID,
	            a.USER_ID,
	            a.COMMENT_CONTENT,
	            a.COMMENT_DATE,
	            a.COMMENT_PARENTID,
	            a.SUPPORT_COUNT,
                b.UDF3 NICK_NAME,
                b.WX_AVATAR_URL,
                c.COMMENT_RULE")
                .Filter("a.BU_NO",query.BU_NO)
                .Filter("a.MATERIAL_ID",query.MATERIAL_ID)
                .Filter("c.CREATE_PSN", query.CREATE_PSN)
                .Filter("a.DEL_FLAG",1)
                .Filter("c.DEL_FLAG", 1)
                .OrderBy("a.COMMENT_DATE desc")
                .GetList<GetCommentModel>(@"WCT_COMMENT_MSTR a 
                left join SYS_USR_WCT b on a.COMMENT_OPENID=b.OPEN_ID
                left join CMS_MATERIAL_MSTR c on a.MATERIAL_ID=c.MATERIAL_ID", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int DelCommentInfo(WctCommentMstrQuery query)
        {
            var count = 0;
            var sql = "Delete from WCT_COMMENT_MSTR where COMMENT_ID='" + query.COMMENT_ID + "'";
            if (query.IsMainComment)
                sql += " or MAIN_COMMENT_ID='" + query.COMMENT_ID + "' ";
            count = _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);

            return count;
        }

        /// <summary>
        /// 更新评论状态
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public void UpdateCommentStatus(string materialId)
        {
            var sql = "Update  WCT_COMMENT_MSTR set IS_READ=1 where MATERIAL_ID='"+materialId+"'";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }

    }
}
