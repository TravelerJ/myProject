using Abp.Domain.Repositories;
using BZM.SCRM.Domain.System.ReportModels;
using SCRM.Domain.System.Entitys;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ISysNavTreeRepository : IRepository<SysNavTree,string> {

        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SysUsrMstrNavTreeModel> GetSysUsrMstrNavTree(decimal userId);
        /// <summary>
        /// 管理员菜单列表
        /// </summary>
        /// <returns></returns>
        List<SysUsrMstrNavTreeModel> GetSysUsrMstrNavTreeList();
    }
}
