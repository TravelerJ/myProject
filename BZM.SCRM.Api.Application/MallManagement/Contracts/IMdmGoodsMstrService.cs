using Abp.Application.Services;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmGoodsMstrService : IApplicationService
    {
        /// <summary>
        /// 保存秒杀商品
        /// </summary>
        /// <param name="mdmGoodsMstrDtos"></param>
        void SaveMsGoodsInfo(List<MdmGoodsMstrDto> mdmGoodsMstrDtos);

        /// <summary>
        /// 保存商品主信息
        /// </summary>
        /// <param name="mdmGoodsListDto"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool NewAddGoods(MdmGoodsListDto mdmGoodsListDto, ref string msg);

        /// <summary>
        /// 创建商品编号
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        string CreateGoodsNo(string goodsNo);
    }
}
