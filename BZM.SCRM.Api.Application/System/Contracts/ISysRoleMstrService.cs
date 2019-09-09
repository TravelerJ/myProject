using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface ISysRoleMstrService : IApplicationService {
        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ReturnMsg GetRoleList(decimal? userId);
        /// <summary>
        /// 获取角色权限分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetRolePageList(SysRoleMstrQuery query);
        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveSysRoleInfo(SysRoleMstrDto dto);
        /// <summary>
        /// 批量删除角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        ReturnMsg DelSysRoleInfo(string roleIds);
    }
}
