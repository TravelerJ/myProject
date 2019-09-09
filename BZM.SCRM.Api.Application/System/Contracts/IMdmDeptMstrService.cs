using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Dtos;

namespace SCRM.Application.System.Contracts
{
    /// <summary>
    /// 部门服务
    /// </summary>
    public interface IMdmDeptMstrService : IApplicationService {
        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveMdmDeptInfo(MdmDeptMstrDto dto);
        /// <summary>
        /// 批量删除部门信息
        /// </summary>
        /// <param name="deptIds"></param>
        /// <returns></returns>
        ReturnMsg DelMdmDeptInfo(string deptIds);
    }
}
