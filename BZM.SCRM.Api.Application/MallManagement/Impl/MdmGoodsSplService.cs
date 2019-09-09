
using BZM.SCRM.Application;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmGoodsSplService : SCRMAppServiceBase, IMdmGoodsSplService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsSplRepository _mdmGoodsSplRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmGoodsSplService(IMdmGoodsSplRepository mdmGoodsSplRepository)
        {
            _mdmGoodsSplRepository = mdmGoodsSplRepository;
        }

        /// <summary>
        /// 插入销售价格方案
        /// </summary>
        /// <param name="dic"></param>
        public void AddSalePrice(Dictionary<string, object> dic)
        {
            MdmGoodsSplDto mdmGoodsSplDto = new MdmGoodsSplDto();

            mdmGoodsSplDto.Id = Guid.NewGuid().ToString("N");
            mdmGoodsSplDto.PL_SELLER_NO = AbpSession.ORG_NO;
            mdmGoodsSplDto.PL_SELLER_NAME = "tt";
            mdmGoodsSplDto.PL_SELLER_TYPE = "ORG";//??
            mdmGoodsSplDto.PL_GOODS_NO = dic["code"].ToString();
            mdmGoodsSplDto.PL_GOODS_NAME = dic["name"].ToString();
            mdmGoodsSplDto.PL_SELL_PRICE = Convert.ToDecimal(dic["price1"]);
            mdmGoodsSplDto.PL_PROMO_PRICE = Convert.ToDecimal(dic["price2"]);
            mdmGoodsSplDto.PL_INNER_PRICE = Convert.ToDecimal(dic["price3"]);
            mdmGoodsSplDto.PL_SDATE = DateTime.Now;
            mdmGoodsSplDto.BG_NO = AbpSession.BG_NO;
            mdmGoodsSplDto.DEL_FLAG = 1;

            _mdmGoodsSplRepository.Insert(mdmGoodsSplDto.ToEntity());
        }

        /// <summary>
        /// 修改价格销售方案
        /// </summary>
        public void UpdateSalePrice(Dictionary<string, object> dic, string goodsNo)
        {
            var entity = _mdmGoodsSplRepository.FirstOrDefault(k => k.PL_GOODS_NO == goodsNo);
            if (entity != null)
            {
                entity.PL_SELL_PRICE= Convert.ToDecimal(dic["price1"]);
                entity.PL_PROMO_PRICE= Convert.ToDecimal(dic["price2"]);
                entity.PL_INNER_PRICE= Convert.ToDecimal(dic["price3"]);
                entity.PL_GOODS_NO= goodsNo;

                _mdmGoodsSplRepository.Update(entity);
            }
        }
    }
}
