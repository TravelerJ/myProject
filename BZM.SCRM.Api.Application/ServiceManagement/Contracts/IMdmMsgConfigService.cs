using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmMsgConfigService : IApplicationService {
        /// <summary>
        /// 获取已选消息配置
        /// </summary>
        /// <returns></returns>
        Dictionary<string, IEnumerable<MdmMsgConfig>> GetSectedMsgConfig();

        /// <summary>
        /// 保存消息配置
        /// </summary>
        /// <param name="msgList"></param>
        bool SaveMsgConfig(List<MdmMsgConfigDto> msgList);
    }
}
