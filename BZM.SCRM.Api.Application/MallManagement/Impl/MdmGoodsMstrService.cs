
using BZM.SCRM.Application;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmGoodsMstrService : SCRMAppServiceBase, IMdmGoodsMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsMstrRepository _mdmGoodsMstrRepository;
        private readonly IMdmGoodsSplService _mdmGoodsSplService;
        private readonly IInvInventoryService _invInventoryService;
        public IConfiguration _configuration { get; }

        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmGoodsMstrService(IMdmGoodsMstrRepository mdmGoodsMstrRepository, IMdmGoodsSplService mdmGoodsSplService, IInvInventoryService invInventoryService, IConfiguration configuration)
        {
            _mdmGoodsMstrRepository = mdmGoodsMstrRepository;
            _mdmGoodsSplService = mdmGoodsSplService;
            _invInventoryService = invInventoryService;
            _configuration = configuration;
        }

        /// <summary>
        /// 保存秒杀商品
        /// </summary>
        /// <param name="mdmGoodsMstrDtos"></param>
        public void SaveMsGoodsInfo(List<MdmGoodsMstrDto> mdmGoodsMstrDtos)
        {
            foreach (var item in mdmGoodsMstrDtos)
            {
                var goods = _mdmGoodsMstrRepository.Get(item.GOODS_ID);
                goods.SP_FLAG = item.SP_FLAG;
                goods.SP_SDATE = item.SP_SDATE;
                goods.SP_EDATE = item.SP_EDATE;
                goods.SP_QTY = item.SP_QTY;
                goods.SP_PRICE = item.SP_PRICE;

                _mdmGoodsMstrRepository.Update(goods);
            }
        }

        /// <summary>
        /// 保存商品主信息
        /// </summary>
        /// <param name="mdmGoodsListDto"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool NewAddGoods(MdmGoodsListDto mdmGoodsListDto, ref string msg)
        {
            bool flag = false;
            if (mdmGoodsListDto.newPublicInfos != null && mdmGoodsListDto.newPublicInfos.Count > 0)
            {
                int maxNum = int.Parse(_configuration["MaxGoodsTjNum"]);
                int num = 0;

                foreach (var item in mdmGoodsListDto.newPublicInfos)
                {
                    if (item.PROMOTION_ATTR == "TJ")
                    {
                        num += 1;
                    }
                }

                var tjList =_mdmGoodsMstrRepository.LongCount(k => k.PROMOTION_ATTR == "TJ" && k.CREATE_ORG_NO == AbpSession.ORG_NO && k.DEL_FLAG == 1);
                if (tjList + num >= maxNum)
                {
                    msg = "特价已达上限，已有7个特价商品已上架";
                }
                else
                {
                    flag = NewDoMdmGoodsMstr(mdmGoodsListDto);
                }
            }
            else
            {
                msg = "未设置属性信息";
            }
            return flag;
        }

        /// <summary>
        /// 保存商品主信息
        /// </summary>
        /// <param name="mdmGoodsListDto"></param>
        /// <returns></returns>
        private bool NewDoMdmGoodsMstr(MdmGoodsListDto mdmGoodsListDto)
        {
            foreach (var item in mdmGoodsListDto.newPublicInfos)
            {
                #region GoodsMstrModel
                var goodMstr = _mdmGoodsMstrRepository.FirstOrDefault(k => k.GOODS_NO == item.GOODS_NO);

                goodMstr.GOODS_LARGECLASS = mdmGoodsListDto.GL_LARGECLASS;
                goodMstr.GOODS_INCLASS = mdmGoodsListDto.GL_INCLASS;
                goodMstr.GOODS_SMALLCLASS = mdmGoodsListDto.GL_SMALLCLASS;
                goodMstr.GOODS_SUBCLASS = mdmGoodsListDto.GL_SUBCLASS;
                goodMstr.GOODS_NAME = mdmGoodsListDto.GL_NAME;
                goodMstr.GOODS_TYPE = mdmGoodsListDto.GL_TYPE;
                goodMstr.UNIT = mdmGoodsListDto.GL_UNIT;
                goodMstr.GOODS_SPEC = mdmGoodsListDto.GL_SPEC;
                goodMstr.GOODS_MODEL = mdmGoodsListDto.GL_MODEL;
                goodMstr.GOODS_MATERIAL = mdmGoodsListDto.GL_MATERIAL;
                goodMstr.GOODS_RMK = item.GOODS_RMK;
                goodMstr.IS_THREE_COMMITMENTS = item.IS_THREE_COMMITMENTS;
                goodMstr.PUR_ATTR = string.IsNullOrEmpty(mdmGoodsListDto.GL_PUR_ATTR) ? 0 : Convert.ToInt32(mdmGoodsListDto.GL_PUR_ATTR);
                goodMstr.GOODS_PUR_ATTR = mdmGoodsListDto.GL_PUR_ATTR;
                goodMstr.GOODS_QA = mdmGoodsListDto.GL_QA;
                goodMstr.GOODS_BRAND = mdmGoodsListDto.GL_BRAND;
                goodMstr.IS_COMBO = mdmGoodsListDto.IS_COMBO;
                goodMstr.PROMOTION_ATTR = item.PROMOTION_ATTR;
                goodMstr.BARCODE = item.BARCODE;
                goodMstr.GOODS_STATUS = Convert.ToInt32(item.GOODS_STATUS);
                goodMstr.UPDATE_DATE = DateTime.Now;
                goodMstr.UPDATE_PSN = (decimal)AbpSession.USR_ID;
                goodMstr.DEL_FLAG = 1;
                goodMstr.GL_ID = mdmGoodsListDto.Id;
                goodMstr.SHOW_IN_LIST = (long)item.SHOW_IN_LIST;
                goodMstr.PROPERTY_IMAGE = item.PROPERTY_IMAGE;

                if (goodMstr.Id == 0)
                {
                    string PK = CreateGoodsNo(goodMstr.GOODS_NO);
                    goodMstr.CREATE_ORG_NO = AbpSession.ORG_NO;
                    goodMstr.BG_NO = AbpSession.BG_NO;
                    goodMstr.CREATE_DATE = DateTime.Now;
                    goodMstr.CREATE_PSN = (decimal)AbpSession.USR_ID;
                    goodMstr.GOODS_NO = string.IsNullOrEmpty(goodMstr.GOODS_NO) ? PK : goodMstr.GOODS_NO;
                    goodMstr.Id = int.Parse(PK);
                }
                #endregion

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["code"] = goodMstr.GOODS_NO;
                dic["name"] = goodMstr.GOODS_NAME;
                dic["price1"] = item.PL_SELL_PRICE;
                dic["price2"] = item.PL_PROMO_PRICE;
                dic["price3"] = 0;

                if (goodMstr.Id == 0 || string.IsNullOrEmpty(goodMstr.Id + ""))
                {
                    _mdmGoodsMstrRepository.Insert(goodMstr);

                    //插入销售价格  MdmGoodsSpl
                    _mdmGoodsSplService.AddSalePrice(dic);

                    //新增库存 InvInventory
                    _invInventoryService.AddInventory(goodMstr.GOODS_NO, item, CreateGoodsNo(""));
                }
                else
                {
                    _mdmGoodsMstrRepository.Update(goodMstr);

                    //修改销售价格
                    _mdmGoodsSplService.UpdateSalePrice(dic, goodMstr.GOODS_NO);

                    //修改库存
                    _invInventoryService.UpdateInventory(goodMstr.GOODS_NO, item, CreateGoodsNo(""));
                }
            }
            return true;
        }

        /// <summary>
        /// 创建商品编号
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        public string CreateGoodsNo(string goodsNo)
        {
            if (string.IsNullOrEmpty(goodsNo))
            {
                Random rd = new Random();
                return DateTime.Now.ToString("yyMMdd") + rd.Next(1000, 9999);
            }
            return goodsNo;
        }
    }
}
