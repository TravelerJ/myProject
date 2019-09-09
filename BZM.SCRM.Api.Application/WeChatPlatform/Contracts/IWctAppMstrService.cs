using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctAppMstrService : IApplicationService {
        /// <summary>
        /// 获取功能模块子菜单
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        ReturnMsg GetAppItemInfo(string appId);
        /// <summary>
        /// 删除app菜单
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        ReturnMsg DelAppInfo(string appId);
        /// <summary>
        /// 保存app菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveAppInfo(WctAppMstrDto dto);
    }
}
