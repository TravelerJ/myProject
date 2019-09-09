using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 系统模块服务
    /// </summary>
    public interface IWctSysmoduleMstrService : IApplicationService {

        /// <summary>
        /// 批量删除系统模块信息
        /// </summary>
        /// <param name="sysMoudleIds"></param>
        /// <returns></returns>
        ReturnMsg DelSysMoudleInfo(string sysMoudleIds);
        /// <summary>
        /// 保存系统模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveSysMoudleInfo(WctSysmoduleMstrDto dto);
    }
}
