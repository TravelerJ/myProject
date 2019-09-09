using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using System.Threading.Tasks;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface ISysUsrMstrService : IApplicationService {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        /// <param name="bizType"></param>
        /// <returns></returns>
        Task<SysUsrMstrDto> Login(string userName, string password, string orgNo, string bgNo,string bizType);
        /// <summary>
        /// web登录验证
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg Login(SysUsrMstrQuery query);
        /// <summary>
        /// 保存员工信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveSysUsrInfo(SysUsrMstrDto dto);
        /// <summary>
        /// 批量删除员工信息
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        ReturnMsg DelSysUsrInfo(string userIds);
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ReturnMsg ResetPassWord(decimal? userId);
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        ReturnMsg GetSysUsrMstrNavTree();
    }
}
