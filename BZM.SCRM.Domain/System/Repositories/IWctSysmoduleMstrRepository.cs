using Abp.Domain.Repositories;
using BZM.SCRM.Domain.System.ReportModels;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.WeChatPlatform.Entitys;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 系统模块仓储
    /// </summary>
    public interface IWctSysmoduleMstrRepository : IRepository<WctSysmoduleMstr,string> {
        /// <summary>
        /// 获取系统模块分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetSysModulePageList(WctSysmoduleMstrQuery query);
        /// <summary>
        /// 批量删除系统模块信息
        /// </summary>
        /// <param name="sysMoudleIds"></param>
        void BatchDelSysMoudleInfo(string sysMoudleIds);
        /// <summary>
        /// 获取系统模块列表
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetSysModuleList();
        /// <summary>
        /// 获取系统模块列表
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        List<WctSysmoduleMstrModel> GetSysModuleList(List<string> Ids, string key);
    }
}
