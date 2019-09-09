using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctReplyMstrService : IApplicationService {
        /// <summary>
        /// 保存回复信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveReplyInfo(WctReplyMstrDto dto);
        /// <summary>
        /// 批量删除回复信息
        /// </summary>
        /// <param name="replyIds"></param>
        /// <returns></returns>
        ReturnMsg DelReplyInfo(string replyIds);
        /// <summary>
        /// 更改回复信息状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg UpdateReplyStatus(WctReplyMstrQuery query);
    }
}
