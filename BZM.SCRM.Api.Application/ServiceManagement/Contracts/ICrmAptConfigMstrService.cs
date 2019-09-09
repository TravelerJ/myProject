using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmAptConfigMstrService : IApplicationService
    {
        /// <summary>
        /// 新增/编辑预约配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        CrmAptConfigMstr SaveCrmAptConfig(CrmAptConfigMstrDto dto,out string msg);

        /// <summary>
        /// 删除预约配置
        /// </summary>
        /// <param name="ids"></param>
        void DeleteCrmAptConfig(string ids);

        /// <summary>
        /// 验证时间段是否配置
        /// </summary>
        /// <param name="apt_type"></param>
        /// <returns></returns>
        IList<AptTimeperiodConfig> VerifyPeriodIsConfig(int apt_type);
    }
}
