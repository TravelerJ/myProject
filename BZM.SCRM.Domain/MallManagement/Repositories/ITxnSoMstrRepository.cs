using Abp.Domain.Repositories;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;

namespace SCRM.Domain.MallManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ITxnSoMstrRepository : IRepository<TxnSoMstr,string> {
        /// <summary>
        /// 获取订单分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetOrderPageList(TxnSoMstrQuery query);
    }
}
