using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using Spring.Datas.Queries;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Infrastructure.EntityFramework.Repositories.InformationActivitie
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class CmsMaterialMstrRepository : SCRMRespositoryBase<CmsMaterialMstr,string>, ICmsMaterialMstrRepository {
        
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
        public CmsMaterialMstrRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取素材分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetMaterialMstrPageList(CmsMaterialMstrQuery query)
        {
            var perssion= _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "a.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"
                a.MATERIAL_ID,
                a.MATERIAL_COVER_URL,
                a.MATERIAL_TITLE,
                a.CREATE_DATE,
                a.UPDATE_DATE,
                a.MATERIAL_STATUS,
                a.MATERIAL_AUTHOR,
                b.MATERIAL_TYPE_NAME,
                c.BU_NAME")
                .Filter("b.MATERIAL_ATTR", query.MATERIAL_ATTR)
                .Filter("a.MATERIAL_TYPE_ID", query.MATERIAL_TYPE_ID)
                .Filter("a.MATERIAL_TITLE",query.MATERIAL_TITLE,Operator.Contains)
                .Filter("a.UDF2",query.UDF2)
                .Filter("a.DEL_FLAG", 1)
                .In("a.MATERIAL_ID",query.MATERIAL_IDS)
                //.Filter("b.DEL_FLAG", 1)
                .Filter("c.DEL_FLAG", 1)
                .And(perssion)
                .OrderBy("a.UPDATE_DATE desc")
                .GetPageList<dynamic>(@"CMS_MATERIAL_MSTR a
                LEFT JOIN CMS_MATERIAL_TYPE b ON a.MATERIAL_TYPE_ID = b.MATERIAL_TYPE_ID
                LEFT JOIN MDM_BU_MSTR c ON a.CREATE_ORG_NO=c.BU_NO", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 批量删除素材信息
        /// </summary>
        /// <param name="materialIds"></param>
        public void BatchDelMaterialInfo(string materialIds)
        {
            var sql = "Update CMS_MATERIAL_MSTR set DEL_FLAG=0 Where MATERIAL_ID in (" + materialIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }


        /// <summary>
        /// 获取资讯的评论未读信息数列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetMaterialCommentPageList(CmsMaterialMstrQuery query)
        {
            return _sqlQuery.Select(@"
                mstr.MATERIAL_ID,
	            mstr.MATERIAL_TITLE,
	            mstr.MATERIAL_AUTHOR,
	            mstr.COMMENT_RULE,
	            mstr.CREATE_DATE,
	            mstr.CREATE_ORG_NO,
	                CASE
                WHEN com1.SUMCOUNT IS NULL THEN
	                0
                ELSE
	                com1.SUMCOUNT
                END AS SUMCOUNT,
                 CASE
                WHEN com2.READCOUNT IS NULL THEN
	                0
                ELSE
	                com2.READCOUNT
                END AS READCOUNT,
                com.COMMENT_DATE")
                .Filter("mstr.DEL_FLAG",1)
                .Filter("mstr.CREATE_ORG_NO", AbpSession.ORG_NO)
                .Filter("ctype.MATERIAL_ATTR", query.MATERIAL_ATTR)
                .Filter("mstr.MATERIAL_TITLE",query.MATERIAL_TITLE,Operator.Contains)
                .Filter("mstr.MATERIAL_TYPE_ID", query.MATERIAL_TYPE_ID)
                .OrderBy("com.COMMENT_DATE desc nulls last")
                .GetPageList<dynamic>(@"CMS_MATERIAL_MSTR mstr  
                left join CMS_MATERIAL_TYPE ctype on ctype.MATERIAL_TYPE_ID=mstr.MATERIAL_TYPE_ID
                left join (select MATERIAL_ID,max(COMMENT_DATE) COMMENT_DATE from wct_comment_mstr group by MATERIAL_ID) com on mstr.MATERIAL_ID=com.MATERIAL_ID
                left join (select MATERIAL_ID,count(MATERIAL_ID) as SUMCOUNT from wct_comment_mstr where del_flag=1 group by MATERIAL_ID)com1 on com1.MATERIAL_ID=mstr.MATERIAL_ID
                left join (select MATERIAL_ID,count(MATERIAL_ID) as READCOUNT from wct_comment_mstr where del_flag=1 and IS_READ=1 group by MATERIAL_ID)com2 
                on com2.MATERIAL_ID=mstr.MATERIAL_ID", Context.Database.GetDbConnection(), query);
        }
    }
}
