using Abp.Application.Services;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using SCRM.Application.MallManagement.Dtos;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IInvInventoryService : IApplicationService {
        /// <summary>
        /// 新增库存
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="newPublicInfo"></param>
        /// <param name="pk"></param>
        void AddInventory(string goodsNo, NewPublicInfo newPublicInfo,string pk);

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="newPublicInfo"></param>
        /// <param name="pk"></param>
        void UpdateInventory(string goodsNo, NewPublicInfo newPublicInfo,string pk);
    }
}
