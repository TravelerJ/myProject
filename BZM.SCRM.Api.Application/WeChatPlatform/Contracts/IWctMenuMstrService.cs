using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctMenuMstrService : IApplicationService {
        /// <summary>
        /// 保存微信菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveWxMenuInfo(WctMenuMstrDto dto);
        /// <summary>
        /// 微信菜单发布
        /// </summary>
        /// <returns></returns>
        ReturnMsg PublishWxMenu();
    }
}
