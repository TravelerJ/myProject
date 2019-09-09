using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmQpaperQuService : IApplicationService {
        /// <summary>
        /// 编辑/新增题目
        /// </summary>
        /// <param name="crmQpaperQuDto"></param>
        /// <returns></returns>
        CrmQpaperQu SaveQpaperQuInfo(CrmQpaperQuDto crmQpaperQuDto,ref string msg);

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="ids"></param>
        void DelQpaperQuInfo(string ids);
    }
}
