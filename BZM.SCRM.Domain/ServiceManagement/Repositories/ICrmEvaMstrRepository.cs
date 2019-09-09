using Abp.Domain.Repositories;
using BZM.SCRM.Domain.Common.Chat;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using Spring.Domains.Repositories;
using System;
using System.Collections.Generic;

namespace SCRM.Domain.ServiceManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICrmEvaMstrRepository : IRepository<CrmEvaMstr,string> {
        /// <summary>
        /// 获取客户评价分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetCrmEvaPageList(CrmEvaMstrQuery query);

        /// <summary>
        /// 获取信息中心分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMessageCenterPageList(CrmEvaMstrQuery query);
        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="toUserId"></param>
        /// <param name="userId"></param>
        void UpdateMessageStatus(string toUserId, string userId);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="eva_obj_no"></param>
        /// <returns></returns>
        List<UserOnlineModel> GetUserOnlineList(string eva_obj_no);
        /// <summary>
        /// 获取用户消息分页
        /// </summary>
        /// <param name="type"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagerList<UserOnlineModel> GetUserOnlineListByPage(string type, string orgNo, string bgNo, int pageIndex, int pageSize);
        /// <summary>
        /// 获取分页消息列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toUserId"></param>
        /// <param name="iDisplayStart"></param>
        /// <param name="iDisplayLength"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        PagerList<CrmEvaMstrModel> GetMeaasegePagList(string userId, string toUserId, int iDisplayStart, int iDisplayLength, DateTime? time);
        /// <summary>
        /// 获取消息集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<CrmEvaMstrModel> GetChatMeaasgeList(string ids);
    }
}
