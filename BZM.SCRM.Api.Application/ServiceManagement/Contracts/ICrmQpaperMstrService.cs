using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmQpaperMstrService : IApplicationService {
        /// <summary>
        /// 创建套卷
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        CrmQpaperMstr CreateQpaper(CrmQpaperMstrDto dto);

        /// <summary>
        /// 启用/禁用套卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CrmQpaperMstr EnableQpaper(string id);

        /// <summary>
        /// 删除套卷
        /// </summary>
        /// <param name="ids"></param>
        void DelQpaper(string ids);

        /// <summary>
        /// 获取套卷的题目信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<CrmQpaperQuDto> GetQuList(string ids);
    }
}
