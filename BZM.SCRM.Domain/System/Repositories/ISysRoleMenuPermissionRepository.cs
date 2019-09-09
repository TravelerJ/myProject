using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ISysRoleMenuPermissionRepository : IRepository<SysRoleMenuPermission,string> {
        /// <summary>
        /// 批量删除角色菜单信息
        /// </summary>
        /// <param name="roleId"></param>
        void DelSysRoleMenuInfo(string roleId);
    }
}
