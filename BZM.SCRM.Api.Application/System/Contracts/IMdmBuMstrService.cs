using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 门店服务
    /// </summary>
    public interface IMdmBuMstrService : IApplicationService {
        /// <summary>
        /// 保存机构信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveMdmBuInfo(MdmBuMstrDto dto);
        /// <summary>
        /// 批量删除机构信息
        /// </summary>
        /// <param name="buNos"></param>
        /// <returns></returns>
        ReturnMsg DelBuInfo(string buNos);
    }
}
