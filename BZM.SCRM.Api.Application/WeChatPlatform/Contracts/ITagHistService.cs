using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ITagHistService : IApplicationService {
        /// <summary>
        /// 更新用户标签记录
        /// </summary>
        /// <param name="wct"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        ReturnMsg UpdateTagHistInfo(SysUsrWctDto wct, ReturnMsg rm);
    }
}
