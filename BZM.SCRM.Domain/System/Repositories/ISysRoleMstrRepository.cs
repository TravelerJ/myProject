using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface ISysRoleMstrRepository : IRepository<SysRoleMstr,decimal> {
        /// <summary>
        /// 获取用户角色范围
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<string>> GetUserRoleScope(decimal userId);

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        List<dynamic> GetRoleList(string sql);
        /// <summary>
        /// 获取角色权限分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetRolePageList(SysRoleMstrQuery query);
        /// <summary>
        /// 批量删除角色权限信息
        /// </summary>
        /// <param name="roleIds"></param>
        void BatchDelSysRoleInfo(string roleIds);
    }
}
