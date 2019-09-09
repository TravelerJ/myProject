using Abp.Domain.Repositories;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.MallManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IMdmGoodsListRepository : IRepository<MdmGoodsList, string>
    {
        /// <summary>
        /// 获取上架商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PagerList<MdmGoodsList> GetPutAwayGoodsList(GoodsInfoInputModel model);
                
        /// <summary>
        /// 获取erp商品信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        string GetErpGoodsInfo(string url, GoodsInfoInputModel model);

        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        dynamic GetGoodsInfoPageList(MdmGoodsListQuery query);
    }
}
