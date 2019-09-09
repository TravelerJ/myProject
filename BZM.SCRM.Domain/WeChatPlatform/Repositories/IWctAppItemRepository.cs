using Abp.Domain.Repositories;
using BZM.SCRM.Domain.WeChatPlatform.ReportModels;
using SCRM.Domain.WeChatPlatform.Entitys;
using System.Collections.Generic;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctAppItemRepository : IRepository<WctAppItem,string> {
        /// <summary>
        /// 删除子应用菜单
        /// </summary>
        /// <param name="appId"></param>
         void DelAppItemInfo(string appId);
        /// <summary>
        /// 获取主应用列表
        /// </summary>
        /// <returns></returns>
        List<WctAppItemModel> GetAppItemList();
    }
}
