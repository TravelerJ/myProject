using Abp.Domain.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using System.Collections.Generic;

namespace SCRM.Domain.WeChatPlatform.Repositories
{
    /// <summary>
    /// 微信菜单仓储
    /// </summary>
    public interface IWctMenuMstrRepository : IRepository<WctMenuMstr,string> {
        /// <summary>
        /// 获取微信菜单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetWxMenuList(WctMenuMstrQuery query);
        /// <summary>
        /// 删除微信菜单
        /// </summary>
        /// <param name="menuId"></param>
        void DelWxMenuInfo(string menuId);
    }
}
