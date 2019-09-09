using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ITagMstrService : IApplicationService {
        /// <summary>
        /// 保存标签信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveTagInfo(TagMstrDto dto);
        /// <summary>
        /// 批量删除标签信息
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        ReturnMsg DelTagInfo(string tagId);
    }
}
