using Abp.Application.Services;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IStoreAdvertiseMstrService : IApplicationService {
        /// <summary>
        /// 新增保险续保/门店宣传
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        StoreAdvertiseMstr InsertAdvertise(StoreAdvertiseMstrDto dto);

        /// <summary>
        /// 启用/禁用宣传
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StoreAdvertiseMstr EnableAdvertise(string id);

        /// <summary>
        /// 删除宣传
        /// </summary>
        /// <param name="ids"></param>
        void DeleteAdvertise(string ids);
    }
}
