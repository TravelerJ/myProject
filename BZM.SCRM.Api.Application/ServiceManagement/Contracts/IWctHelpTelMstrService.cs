using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctHelpTelMstrService : IApplicationService {
        /// <summary>
        /// 编辑/保存救援信息
        /// </summary>
        /// <param name="helpDto"></param>
        /// <returns></returns>
        WctHelpTelMstr SaveHelpTelInfo(WctHelpTelMstrDto helpDto);

        /// <summary>
        /// 删除救援信息
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        bool DelHelpTelInfo(string ids);
    }
}
