using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 职务服务
    /// </summary>
    public interface IMdmDutyMstrService : IApplicationService {
        /// <summary>
        /// 保存职务信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveMdmDutyInfo(MdmDutyMstrDto dto);
        /// <summary>
        /// 批量删除职务信息
        /// </summary>
        /// <param name="sysMoudleIds"></param>
        /// <returns></returns>
        ReturnMsg DelMdmDutyInfo(string sysMoudleIds);
    }
}
