using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmGoodsListService : IApplicationService {
        /// <summary>
        /// 获取erp商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<GoodsInfoListModel> GetGoodsInfoList(GoodsInfoInputModel model);

        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="model"></param>
        MdmGoodsList SaveErpGoodsInfo(GoodsInfoListModel model);

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="model"></param>
        void PutAwayGoods(GoodsInfoListModel model);

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="goodsId"></param>
        void OffRackGoods(string goodsId);

        /// <summary>
        /// 根据id获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MdmGoodsListDto GetGoodsInfoById(string id);

        /// <summary>
        /// 商品上架/下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnMsg SetGoodsInfoStatus(string id);

        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <param name="mdmGoodsListDto"></param>
        void SaveGoodsInfo(MdmGoodsListDto mdmGoodsListDto, ref string msg);
    }
}
