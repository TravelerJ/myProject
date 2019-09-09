using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IFinanceTagConfigService : IApplicationService {
        /// <summary>
        /// 获取门店配置标签
        /// </summary>
        /// <returns></returns>
        List<FinanceTagConfig> GetFinTagList();

        /// <summary>
        /// 保存金融标签
        /// </summary>
        /// <param name="dto"></param>
        void SaveTag(FinanceTagConfigDto dto);

        /// <summary>
        /// 删除金融标签
        /// </summary>
        /// <param name="id"></param>
        void DeleteTag(string id);
    }
}
