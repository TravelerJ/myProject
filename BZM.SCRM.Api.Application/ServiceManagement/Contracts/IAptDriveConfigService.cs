using Abp.Application.Services;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using SCRM.Application.ServiceManagement.Dtos;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IAptDriveConfigService : IApplicationService {
        /// <summary>
        /// 预约试驾车型数据
        /// </summary>
        /// <returns></returns>
        List<CarInfoModel> GetAptDriveCarList();

        /// <summary>
        /// 保存预约试驾车型数据
        /// </summary>
        /// <param name="dto"></param>
        void SaveDriveInfo(List<AptDriveConfigDto> dto);
    }
}
