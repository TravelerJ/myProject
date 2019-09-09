using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 用户角色关系仓储
    /// </summary>
    public interface ISysUsrAuthRepository : IRepository<SysUsrAuth,string> {
        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="userId"></param>
        void DelSysUsrAuthInfo(string userId);
    }
}
