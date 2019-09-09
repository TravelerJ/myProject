using Abp.Application.Services;
using SCRM.Application.MallManagement.Dtos;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ITxnSoMstrService : IApplicationService
    {
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="soNo"></param>
        /// <param name="expressNo"></param>
        /// <returns></returns>
        TxnSoMstrDto UpdateExpressNo(string soNo, string expressNo = "");

        /// <summary>
        /// 订单收货
        /// </summary>
        /// <param name="soNo"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        TxnSoMstrDto UpdateOrderStatus(string soNo, string orderStatus = "");
    }
}
