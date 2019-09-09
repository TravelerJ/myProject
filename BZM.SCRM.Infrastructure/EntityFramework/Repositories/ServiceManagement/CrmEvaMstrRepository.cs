using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Chat;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.ServiceManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class CrmEvaMstrRepository : SCRMRespositoryBase<CrmEvaMstr, string>, ICrmEvaMstrRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        public PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public CrmEvaMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public PagerList<dynamic> GetCrmEvaPageList(CrmEvaMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "mstr.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);

            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " and to_char(mstr.EVA_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'";
                }
                else
                {
                    where += " to_char(mstr.EVA_DATE,'yyyy-MM-dd')>='" + query.START_DATE + "'";
                }

            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += " and to_char(mstr.EVA_DATE,'yyyy-MM-dd')<='" + query.END_DATE + "'";
            }
            return _sqlQuery.Select(@"mstr.EVA_ID,
                                mstr.EVA_TYPE,
                                mstr.EVA_DATE,
                                mstr.EVA_OBJ_TYPE,
                                mstr.EVA_CONTENT,
                                mstr.EVA_OBJ_NAME,
                                mstr.EVA_TOTAL_VALUE,
                                mstr.CREATE_ORG_NO,
                                mstr.EVA_REF_NO1,
                                mstr.EVA_REF_NO,
                                mstr.UDF4,
                                bu.bu_name,
                                bu.parent_bu_name,
                               (SELECT USR_JOB FROM SYS_USR_MSTR WHERE USR_ID = TO_NUMBER(REGEXP_REPLACE(mstr.EVA_OBJ_NO, '[^0-9]', '')))UsrJob")
                               .Filter("mstr.DEL_FLAG", 1)
                               .NotEqual("mstr.EVA_TYPE", "聊天信息")
                               .And(where)
                               .Contains("mstr.EVA_OBJ_TYPE", query.EVA_OBJ_TYPE)
                               .Contains("mstr.EVA_OBJ_NAME", query.EVA_OBJ_NAME)
                               .Filter("bu.PARENT_BU_NO", query.AREA_NO)
                               .Filter("bu.BU_NO", query.BU_NO)
                               .In("EVA_TYPE", query.EVA_TYPES)
                               .OrderBy("mstr.EVA_DATE desc")
                               .GetPageList<dynamic>(@" CRM_EVA_MSTR mstr
                               LEFT JOIN mdm_bu_mstr bu ON mstr.CREATE_ORG_NO = bu.bu_no", Context.Database.GetDbConnection(), query);
        }

        public PagerList<dynamic> GetMessageCenterPageList(CrmEvaMstrQuery query)
        {
            string where = "";
            if (!string.IsNullOrEmpty(query.START_DATE))
            {
                where += "to_char(a.create_date,'yyyy-MM-dd')>=" + query.START_DATE;
            }
            if (!string.IsNullOrEmpty(query.END_DATE))
            {
                where += string.IsNullOrEmpty(where) ? "to_char(a.create_date,'yyyy-MM-dd')<=" + query.END_DATE + "" : " and to_char(a.create_date,'yyyy-MM-dd')<=" + query.END_DATE + "";
            }

            return _sqlQuery.Select(@"SELECT a.EVA_ID,a.EVA_CONTENT,a.eva_ref_no2 as OpenId,a.CREATE_DATE,(CASE WHEN a.EVA_REF_NO3 = '1' THEN '是' ELSE '否' end) as MessageStatus,(SELECT b.UDF3 FROM sys_usr_wct b where b.open_id=a.eva_ref_no2 and b.bu_no='" + AbpSession.ORG_NO + @"' and b.del_flag!=0 and rownum=1)NICKNAME")
                .Filter("DEL_FLAG", 1)
                .Filter("a.EVA_TYPE", "聊天信息")
                .Filter("a.create_org_no", AbpSession.ORG_NO)
                //.And("to_char(a.create_date,'yyyy-MM-dd')>=" + query.START_DATE)
                //.And("to_char(a.create_date,'yyyy-MM-dd')<=" + query.END_DATE)
                .And(where)
                .Filter("a.EVA_REF_NO3", query.REPLY_STATUS)
                .Contains("a.UDF3", query.UDF3)
                .GetPageList<dynamic>("CRM_EVA_MSTR a", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="eva_obj_no"></param>
        /// <returns></returns>
        public List<UserOnlineModel> GetUserOnlineList(string eva_obj_no)
        {
            return _sqlQuery.Select(@"
                eva.eva_ref_no OPEN_ID,
	            eva.bg_no,
	            wct.WX_AVATAR_URL,
	            wct.udf3 nickName,
	            (
		            SELECT
			            EVA_CONTENT
		            FROM
			            (
				            SELECT
					            EVA_CONTENT,
					            eva_ref_no,
					            EVA_OBJ_NO,
					            EVA_TYPE
				            FROM
					            crm_eva_mstr
				            ORDER BY
					            EVA_DATE DESC
			            ) b
		            WHERE
			            (
				            (
					            b.eva_ref_no = wct.OPEN_ID
					            AND b.EVA_OBJ_NO = '" + eva_obj_no + @"'
                            )

                            OR(
                                b.eva_ref_no = '" + eva_obj_no + @"'

                                AND b.EVA_OBJ_NO = wct.OPEN_ID
                            )
			            )
		            AND b.EVA_TYPE = '服务咨询'

                    AND ROWNUM = 1
	            ) LastMessage,
	            (
                    SELECT

                        EVA_DATE

                    FROM
                        (
                            SELECT

                                EVA_DATE,
                                eva_ref_no,
                                EVA_OBJ_NO,
                                EVA_TYPE

                            FROM

                                crm_eva_mstr

                            ORDER BY

                                EVA_DATE DESC
                        ) c

                    WHERE
                        (
                            (
                                c.eva_ref_no = wct.OPEN_ID

                                AND c.EVA_OBJ_NO = '" + eva_obj_no + @"'
                            )

                            OR(
                                c.eva_ref_no = '" + eva_obj_no + @"'

                                AND c.EVA_OBJ_NO = wct.OPEN_ID
                            )
			            )
		            AND c.EVA_TYPE = '服务咨询'

                    AND ROWNUM = 1
	            ) LastMessageDate,
	            (
                    SELECT

                        count(*)

                    FROM
                        crm_eva_mstr

                    WHERE
                        eva_ref_no = eva.eva_ref_no

                    AND EVA_OBJ_NO = '" + eva_obj_no + @"'

                    AND UDF1 = '未读'
	            ) UnreadCount")

                .GetList<UserOnlineModel>(@"
                (
		            SELECT
			            eva_ref_no,
			            bg_no
		            FROM
			            crm_eva_mstr
		            WHERE
			            EVA_OBJ_NO = '" + eva_obj_no + @"'

                    AND EVA_TYPE = '服务咨询'

                    AND eva_ref_no LIKE 'o%'

                    GROUP BY

                        eva_ref_no,
                        bg_no
                    ) eva
                LEFT JOIN sys_usr_wct wct ON eva.eva_ref_no = wct.open_id", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 获取用户消息分页
        /// </summary>
        /// <param name="type"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagerList<UserOnlineModel> GetUserOnlineListByPage(string type, string orgNo, string bgNo, int pageIndex, int pageSize)
        {
            var addSql = "";
            if (type == "2")
            {
                addSql = "CREATE_ORG_NO='" + orgNo + "'";
            }
            if (type == "1" || type == "9")
            {
                addSql = "BG_NO='" + bgNo + "'";
            }
            return _sqlQuery.Select(@"
                        eva.eva_obj_no USER_ID,
                        eva.eva_obj_name,
	                    eva.eva_ref_no OPEN_ID,
	                    eva.bg_no,
                        eva.create_org_no BU_NO,
	                    wct.WX_AVATAR_URL,
	                    wct.udf3 nickName,
	                    (
		                    SELECT

                                EVA_CONTENT

                            FROM
                                (
                                    SELECT

                                        EVA_CONTENT,
                                        eva_ref_no,
                                        EVA_OBJ_NO,
                                        EVA_TYPE,
                                        BG_NO,
                                        CREATE_ORG_NO
                                    FROM

                                        crm_eva_mstr

                                    ORDER BY

                                        EVA_DATE DESC
                                ) b

                            WHERE
                                (
                                    (
                                        b.eva_ref_no = wct.OPEN_ID
                                    )

                                    OR(
                                b.EVA_OBJ_NO = wct.OPEN_ID
                                    )
			                    )

                            AND b.EVA_TYPE = '服务咨询'
                            AND b." + addSql + @"
                            AND ROWNUM = 1
	                    ) LastMessage,
	                    (
                            SELECT

                                EVA_DATE

                            FROM
                                (
                                    SELECT

                                        EVA_DATE,
                                        eva_ref_no,
                                        EVA_OBJ_NO,
                                        EVA_TYPE,
                                        BG_NO,
                                        CREATE_ORG_NO

                                    FROM

                                        crm_eva_mstr

                                    ORDER BY

                                        EVA_DATE DESC
                                ) c

                            WHERE
                                (
                                    (
                                        c.eva_ref_no = wct.OPEN_ID
                                    )

                                    OR(
                                c.EVA_OBJ_NO = wct.OPEN_ID
                                    )
			                    )
		                    AND c.EVA_TYPE = '服务咨询'
                            AND c." + addSql + @"
                            AND ROWNUM = 1
	                    ) LastMessageDate,
                        (
		                        SELECT
			                        count(*)
		                        FROM
			                        crm_eva_mstr
		                        WHERE
			                        eva_ref_no = eva.eva_ref_no
		                        AND UDF1 = '未读' AND "+addSql+@"
	                        ) UnreadCount")
                .OrderBy("LastMessageDate desc")
                .GetPageList<UserOnlineModel>(@"
                         (
                            SELECT
                                eva_obj_no,
                                eva_obj_name,
                                eva_ref_no,
                                bg_no,
                                create_org_no
                            FROM

                                crm_eva_mstr

                            WHERE
                        EVA_TYPE = '服务咨询' 
                         AND " + addSql + @"
                            AND eva_ref_no LIKE 'o%'
                            GROUP BY
                            eva_obj_name,
                            eva_obj_no,
                            eva_ref_no, 
                            create_org_no,
                            bg_no
                        ) eva
                    LEFT JOIN sys_usr_wct wct ON eva.eva_ref_no = wct.open_id", Context.Database.GetDbConnection(), pageIndex, pageSize);
        }

        /// <summary>
        /// 获取分页消息列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        /// <param name="iDisplayStart"></param>
        /// <param name="iDisplayLength"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public PagerList<CrmEvaMstrModel> GetMeaasegePagList(string userId, string toUserId, int iDisplayStart, int iDisplayLength, DateTime? time)
        {
            var sql = "(EVA_REF_NO ='" + userId + "' and EVA_OBJ_NO='" + toUserId + "')  or (EVA_OBJ_NO='" + userId + "' and EVA_REF_NO='" + toUserId + "') and EVA_TYPE ='服务咨询'";
            if (time.HasValue)
            {
                sql += " and EVA_DATE<=to_date('" + time + "','yyyy-MM-dd hh24:mi:ss')";
            }
            return _sqlQuery.Select(@"*")
                .Filter("DEL_FLAG", 1)
                .And(sql)
                .OrderBy("EVA_DATE desc")
                .GetPageList<CrmEvaMstrModel>(@"CRM_EVA_MSTR", Context.Database.GetDbConnection(), iDisplayStart, iDisplayLength);
        }

        /// <summary>
        /// 获取消息集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<CrmEvaMstrModel> GetChatMeaasgeList(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return _sqlQuery.Select(@"*")
                .Filter("EVA_TYPE", "服务咨询")
                .And("to_char(EVA_DATE,'iw')=to_char(sysdate,'iw')")
                .GetList<CrmEvaMstrModel>(@"CRM_EVA_MSTR", Context.Database.GetDbConnection());
            }
            return _sqlQuery.Select(@"*")
                .Filter("EVA_TYPE", "服务咨询")
                .And("(EVA_REF_NO in (" + ids + ") or EVA_OBJ_NO in (" + ids + "))")
                .And("to_char(EVA_DATE,'iw')=to_char(sysdate,'iw')")
                .GetList<CrmEvaMstrModel>(@"CRM_EVA_MSTR", Context.Database.GetDbConnection());

        }

        /// <summary>
        /// 顾问更新消息状态
        /// </summary>
        /// <param name="toUserId"></param>
        /// <param name="userId"></param>
        public void UpdateMessageStatus(string toUserId, string userId)
        {
            var sql = "Update CRM_EVA_MSTR set UDF1='已读' where EVA_REF_NO='" + userId + "' and EVA_OBJ_NO='" + toUserId + "'";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection());
        }
    }
}
