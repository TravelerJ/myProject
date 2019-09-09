using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctBasConfigService : IApplicationService {
        /// <summary>
        /// 保存基础配置信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveWctBasConfigInfo(WctBasConfigDto dto);
    }
}
