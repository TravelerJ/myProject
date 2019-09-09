using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ISysUsrWctService : IApplicationService {
        /// <summary>
        /// 粉丝打标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg WctMakeTag(SysUsrWctDto dto);
        /// <summary>
        /// 更改粉丝黑名单状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg UpdateFansBlackStatus(SysUsrWctQuery query);
    }
}
