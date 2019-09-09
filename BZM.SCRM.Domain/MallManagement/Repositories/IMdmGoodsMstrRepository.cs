using Abp.Domain.Repositories;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;

namespace SCRM.Domain.MallManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IMdmGoodsMstrRepository : IRepository<MdmGoodsMstr, long>
    {
        /// <summary>
        /// 获取秒杀商品分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetMsGoodsPageList(MdmGoodsMstrQuery query);

        /// <summary>
        /// 获取商品规格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        dynamic GetGoodsSpecById(string id);
    }
}
