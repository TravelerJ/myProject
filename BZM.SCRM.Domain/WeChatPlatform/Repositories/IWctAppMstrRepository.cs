using Abp.Domain.Repositories;
using BZM.SCRM.Domain.WeChatPlatform.ReportModels;
using SCRM.Domain.WeChatPlatform.Entitys;
using System.Collections.Generic;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctAppMstrRepository : IRepository<WctAppMstr,string> {
        /// <summary>
        /// 获取主应用列表
        /// </summary>
        /// <returns></returns>
        List<WctAppInfoModel> GetAppMstrList();
    }
}
