using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
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
    public class SysUsrWctRepository : SCRMRespositoryBase<SysUsrWct,string>, ISysUsrWctRepository {
        
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
        public SysUsrWctRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery,
            PermissionHelper permissionHelper) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }


        /// <summary>
        /// 分页获取粉丝信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetWctInfoPageList(SysUsrWctQuery query)
        {
            var perssion = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "wct.bu_no", AbpSession.ORG_NO, AbpSession.BG_NO);
            var joinSql = query.FOLLOW_STATUS == null ? "" : "wct.follow_status=" + query.FOLLOW_STATUS + "";
            return _sqlQuery.Select(@"
                    wct.Wct_Id,
	                wct.bu_no,
	                wct.usr_id,
	                wct.open_id,
	                wct.cus_svc_code,
	                wct.usr_source,
	                wct.reg_date,
	                wct.referee_usr_id,
	                wct.create_date,
	                wct.update_date,
	                usr.usr_name,
	                usr.usr_real_name,
	                usr.usr_mobile,
	                wct.UDF1 unfollow_date,
	                wct.UDF2 sex,
	                wct.UDF3 nickname,
	                    (
		                    CASE wct.follow_status
		                    WHEN 1 THEN
			                    '已关注'
		                    ELSE
			                    '取消关注'
		                    END
	                    ) AS follow_status,
	                    (
		                    CASE wct.UDF4
		                    WHEN '1' THEN
			                    '是'
		                    ELSE
			                    '否'
		                    END
	                    ) AS IsBlack,
	                wct.WX_AVATAR_URL,
	                wct.tag_name,
	                bu.BU_NAME,
	                bu.PARENT_BU_NAME")
                    .Filter("wct.UDF3",query.nickName,Operator.Contains)
                    .Filter("usr.usr_real_name", query.realName, Operator.Contains)
                    .Filter("bu.PARENT_BU_NO", query.parentorgNo)
                    .Filter("bu.BU_NO", query.orgNo)
                    .Filter("wct.TAG_NAME",query.TAG_NAME)
                    .Filter("usr.usr_mobile", query.mobile)
                    .Filter("wct.reg_date", query.BEGIN_REG_DATE, Operator.GreaterEqual)
                    .Filter("wct.reg_date", query.END_REG_DATE, Operator.LessEqual)
                    .Filter("wct.del_flag", "1")
                    .And(perssion)
                    .And(joinSql)
                    .OrderBy("wct.create_date,wct.wct_id desc")
                    .GetPageList<dynamic>(@"sys_usr_wct wct 
                     left join sys_usr_mstr usr on wct.usr_id=usr.usr_id 
                     left join mdm_bu_mstr bu on wct.bu_no=bu.bu_no", Context.Database.GetDbConnection(), query);
        }
    }
}
