using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 公众号服务
    /// </summary>
    public interface IWctPaMstrService : IApplicationService {

        /// <summary>
        /// 批量删除公众号信息
        /// </summary>
        /// <param name="paIds"></param>
        /// <returns></returns>
        ReturnMsg DelPaInfo(string paIds);
        /// <summary>
        /// 保存公众号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SavePaInfo(WctPaMstrDto dto);
    }
}
