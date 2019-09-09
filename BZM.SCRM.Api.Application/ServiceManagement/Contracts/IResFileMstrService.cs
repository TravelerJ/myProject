using Abp.Application.Services;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IResFileMstrService : IApplicationService {
        /// <summary>
        /// 获取erp车型数据
        /// </summary>
        /// <returns></returns>
        List<CarInfo> GetErpCarList();

        /// <summary>
        /// 保存车型图
        /// </summary>
        void SaveCarResFile(string fileId,string bizNo,string fileName);
    }
}
