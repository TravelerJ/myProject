using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICarFinancePolicyService : IApplicationService {
        /// <summary>
        /// 获取可选和已选标签
        /// </summary>
        /// <param name="code">车型编码</param>
        /// <param name="level">车型级别</param>
        /// <param name="subCode">车型细分编码</param>
        /// <param name="vin">车架号</param>
        /// <returns></returns>
        Dictionary<string, IList<FinanceTagConfig>> GetOptionalTagList(string code, int level, string subCode, string vin = "");

        /// <summary>
        /// 保存金融政策
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool SavePolicyInfo(CarFinancePolicyDto dto,ref string msg);

        /// <summary>
        /// 删除金融政策
        /// </summary>
        /// <param name="ids"></param>
        void DeletePolicy(string ids);
    }
}
