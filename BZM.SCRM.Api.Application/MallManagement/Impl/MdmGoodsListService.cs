
using AutoMapper.Configuration;
using BT.BPMLIVE.Common.Message;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Util;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using SCRM.Domain.ServiceManagement.Repositories;
using Spring.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmGoodsListService : SCRMAppServiceBase, IMdmGoodsListService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsListRepository _mdmGoodsListRepository;
        private readonly IMdmGoodsMstrRepository _mdmGoodsMstrRepository;
        private readonly IMdmGoodsMstrService _mdmGoodsMstrService;
        private readonly IResFileMstrRepository _resFileMstrRepository;
        private readonly WxHelper _wxHelper;
        private readonly InitHelper _initHelper;



        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmGoodsListService(IMdmGoodsListRepository mdmGoodsListRepository, WxHelper wxHelper, InitHelper initHelper, IResFileMstrRepository resFileMstrRepository, IMdmGoodsMstrRepository mdmGoodsMstrRepository, IMdmGoodsMstrService mdmGoodsMstrService)
        {
            _mdmGoodsListRepository = mdmGoodsListRepository;
            _wxHelper = wxHelper;
            _initHelper = initHelper;
            _resFileMstrRepository = resFileMstrRepository;
            _mdmGoodsMstrRepository = mdmGoodsMstrRepository;
            _mdmGoodsMstrService = mdmGoodsMstrService;
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<GoodsInfoListModel> GetGoodsInfoList(GoodsInfoInputModel model)
        {
            if (!CheckParam(model, out string errMsg))
            {
                throw new Exception(errMsg);
            }

            //上架商品
            if (model.goodStatus == "1")
            {
                List<GoodsInfoListModel> list = new List<GoodsInfoListModel>();

                List<MdmGoodsList> goodsList = _mdmGoodsListRepository.GetPutAwayGoodsList(model).Data;
                foreach (var good in goodsList)
                {
                    list.Add(new GoodsInfoListModel()
                    {
                        GOODS_NO = good.GL_NO.ToString(),
                        GOODS_NAME = good.GL_NAME.ToString(),
                        GOODS_LARGECLASS_CODE = good.UDF3.ToString(),
                        GOODS_LARGECLASS_NAME = good.UDF4.ToString(),
                        GOODS_INCLASS_CODE = good.UDF5.ToString(),
                        GOODS_INCLASS_NAME = good.UDF6.ToString(),
                        GOODS_SMALLCLASS_CODE = good.UDF7.ToString(),
                        GOODS_SMALLCLASS_NAME = good.UDF8.ToString(),
                        UNIT = good.GL_UNIT + "",
                        RETAILPRICE = Convert.ToDecimal(string.IsNullOrEmpty(good.UDF9 + "") ? "0" : good.UDF9.ToString()),
                        MEMBERSHIP_PRICE = Convert.ToDecimal(string.IsNullOrEmpty(good.UDF10 + "") ? "0" : good.UDF10.ToString()),
                        Gl_Material = good.GL_MATERIAL + "",
                        Made_In = good.MADE_IN + "",
                        Gl_Rmk = good.GL_RMK + "",
                        Promotion_Info = good.PROMOTION_INFO + "",
                        Image_Url = string.IsNullOrEmpty(good.UDF2)?"":good.UDF2.ToString(),
                        Gl_Desc = good.GL_DESC,
                        Gl_Warranty_Desc = good.GL_WARRANTY_DESC,
                        Member_Price = Convert.ToDecimal(good.MEMBER_PRICE),
                        Member_Points = Convert.ToDecimal(good.MENBER_POINTS),
                        Enable_MP = Convert.ToDecimal(good.ENABLE_MP),
                        Goods_Sales = string.IsNullOrEmpty(good.GOODS_SALES + "") ? 0 : Convert.ToDecimal(good.GOODS_SALES),
                        GL_STATUS = Convert.ToDecimal(good.GL_STATUS),
                        GL_ID = good.Id.ToString()
                    });
                }

                return list;
            }
            else
            {
                string url = "", msg = "";
                if (!_wxHelper.GetErpApiUrl(AbpSession.BG_NO, ref url, ref msg, "new"))
                {
                    throw new Exception(msg);
                }

                model.storeNo = AbpSession.ORG_NO;
                string returnData = _mdmGoodsListRepository.GetErpGoodsInfo(url, model);
                JObject jobj = (JObject)JsonConvert.DeserializeObject(returnData);
                if (Convert.ToBoolean(jobj["IsSuccess"]))
                {
                    string result = jobj["result"].ToString();
                    return TransferGoodsModel(result);
                }
                else
                {
                    throw new Exception("获取erp商品失败:" + jobj["msg"].ToString());
                }
            }
        }

        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="model"></param>
        public MdmGoodsList SaveErpGoodsInfo(GoodsInfoListModel model)
        {
            var info = _mdmGoodsListRepository.FirstOrDefault(m => m.BU_NO == AbpSession.ORG_NO && m.GL_NO == model.GOODS_NO);
            if (info == null)
            {
                MdmGoodsListDto goods = new MdmGoodsListDto()
                {
                    Id = Guid.NewGuid().ToString(),
                    GL_NO = model.GOODS_NO,
                    GL_NAME = model.GOODS_NAME,
                    //GL_LARGECLASS = Convert.ToDecimal(model.GOODS_LARGECLASS_CODE),
                    GL_UNIT = model.UNIT,
                    GL_MATERIAL = model.Gl_Material,
                    MADE_IN = model.Made_In,
                    GL_RMK = model.Gl_Rmk,
                    UDF2 = model.Image_Url,
                    GL_BRAND = model.GOODS_BRAND,
                    PROMOTION_INFO = model.Promotion_Info,
                    GL_DESC = model.Gl_Desc,
                    GL_WARRANTY_DESC = model.Gl_Warranty_Desc,
                    DEL_FLAG = 1,
                    GL_TYPE = 0,
                    MEMBER_PRICE = (double)model.Member_Price,
                    MENBER_POINTS = (long)model.Member_Points,
                    ENABLE_MP = (byte)model.Enable_MP,
                    GOODS_SALES = model.Goods_Sales,
                    IS_ERPGOODS = 1,
                    UDF3 = model.GOODS_LARGECLASS_CODE,
                    UDF4 = model.GOODS_LARGECLASS_NAME,
                    UDF5 = model.GOODS_INCLASS_CODE,
                    UDF6 = model.GOODS_INCLASS_NAME,
                    UDF7 = model.GOODS_SMALLCLASS_CODE,
                    UDF8 = model.GOODS_SMALLCLASS_NAME,
                    UDF9 = model.RETAILPRICE + "",
                    UDF10 = model.MEMBERSHIP_PRICE + ""
                };
                _initHelper.InitAdd(goods, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                return _mdmGoodsListRepository.Insert(goods.ToEntity());
            }
            else
            {
                info.UDF2 = model.Image_Url;
                info.GL_DESC = model.Gl_Desc;
                info.GL_WARRANTY_DESC = model.Gl_Warranty_Desc;
                info.UPDATE_PSN = AbpSession.USR_ID;
                info.UPDATE_DATE = DateTime.Now;
                info.GL_MATERIAL = model.Gl_Material;
                info.MADE_IN = model.Made_In;
                info.GL_RMK = model.Gl_Rmk;
                info.GL_BRAND = model.GOODS_BRAND;
                info.PROMOTION_INFO = model.Promotion_Info;
                info.BU_NO = AbpSession.ORG_NO;
                info.BG_NO = AbpSession.BG_NO;
                info.MEMBER_PRICE = (double)model.Member_Price;
                info.MENBER_POINTS = (long)model.Member_Points;
                info.ENABLE_MP = (byte)model.Enable_MP;
                info.GOODS_SALES = model.Goods_Sales;
                info.IS_ERPGOODS = 1;
                info.UDF3 = model.GOODS_LARGECLASS_CODE;
                info.UDF4 = model.GOODS_LARGECLASS_NAME;
                info.UDF5 = model.GOODS_INCLASS_CODE;
                info.UDF6 = model.GOODS_INCLASS_NAME;
                info.UDF7 = model.GOODS_SMALLCLASS_CODE;
                info.UDF8 = model.GOODS_SMALLCLASS_NAME;
                info.UDF9 = model.RETAILPRICE + "";

                return _mdmGoodsListRepository.Update(info);
            }
        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="model"></param>
        public void PutAwayGoods(GoodsInfoListModel model)
        {
            if (string.IsNullOrEmpty(model.GOODS_NO))
            {
                var goods = _mdmGoodsListRepository.FirstOrDefault(m => m.IS_ERPGOODS == 1 && m.DEL_FLAG == 1 && m.GL_NO == model.GOODS_NO && m.BU_NO == AbpSession.ORG_NO);
                if (goods == null)
                {
                    MdmGoodsList mdmGoodsList = SaveErpGoodsInfo(model);
                    mdmGoodsList.GL_STATUS = 1;
                    _mdmGoodsListRepository.Update(mdmGoodsList);
                }
            }
            else
            {
                var entity = _mdmGoodsListRepository.Get(model.GL_ID);
                entity.GL_STATUS = 1;
                _mdmGoodsListRepository.Update(entity);
            }
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="goodsId"></param>
        public void OffRackGoods(string goodsId)
        {
            var entity = _mdmGoodsListRepository.Get(goodsId);
            if (entity == null)
            {
                throw new Exception("该商品暂未上架,请选择已上架商品！");
            }
            entity.GL_STATUS = 0;
            _mdmGoodsListRepository.Update(entity);
        }

        /// <summary>
        /// 检查接口入参
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool CheckParam(GoodsInfoInputModel model, out string errMsg)
        {
            bool flag = true;
            errMsg = "";
            int len;
            if (model == null)
            {
                flag = false;
                errMsg = "传入参数为空";
            }

            if (!int.TryParse(model.iDisplayStart + "", out len) || !int.TryParse(model.iDisplayLength + "", out len))
            {
                flag = false;
                errMsg = "开始条数或分页长度类型不正确";
            }
            return flag;
        }

        /// <summary>
        /// 转换数据对象
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public List<GoodsInfoListModel> TransferGoodsModel(string result)
        {
            List<GoodsInfoListModel> list = new List<GoodsInfoListModel>();

            //erp返回的商品信息
            List<GoodsInfoReturnModel> goodsList = JsonConvert.DeserializeObject<List<GoodsInfoReturnModel>>(result);
            if (goodsList.Count == 0)
            {
                return null;
            }

            //当前门店数据库中商品信息
            var infoList = _mdmGoodsListRepository.GetAllList(m => m.DEL_FLAG == 1 && m.IS_ERPGOODS == 1 && m.BU_NO == AbpSession.ORG_NO);
            foreach (GoodsInfoReturnModel item in goodsList)
            {
                var info = infoList.FirstOrDefault(f => f.GL_NO == item.GOODS_NO);

                if (info == null)
                {
                    info = new MdmGoodsList();
                }

                list.Add(new GoodsInfoListModel()
                {
                    GOODS_NO = item.GOODS_NO,
                    GOODS_NAME = item.GOODS_NAME,
                    GOODS_LARGECLASS_CODE = item.GOODS_LARGECLASS_CODE,
                    GOODS_LARGECLASS_NAME = item.GOODS_LARGECLASS_NAME,
                    GOODS_INCLASS_CODE = item.GOODS_INCLASS_CODE,
                    GOODS_INCLASS_NAME = item.GOODS_INCLASS_NAME,
                    GOODS_SMALLCLASS_CODE = item.GOODS_SMALLCLASS_CODE,
                    GOODS_SMALLCLASS_NAME = item.GOODS_SMALLCLASS_NAME,
                    GOODS_SUBCLASS_CODE = item.GOODS_SUBCLASS_CODE,
                    GOODS_SUBCLASS_NAME = item.GOODS_SUBCLASS_NAME,
                    UNIT = item.UNIT,
                    GOODS_BRAND = item.GOODS_BRAND,
                    IS_COMBO = item.IS_COMBO,
                    IA_QTY = item.IA_QTY,
                    RETAILPRICE = item.RETAILPRICE,
                    MEMBERSHIP_PRICE = item.MEMBERSHIP_PRICE,
                    Gl_Material = info.GL_MATERIAL,
                    Made_In = info.MADE_IN,
                    Gl_Rmk = info.GL_RMK,
                    Promotion_Info = info.PROMOTION_INFO,
                    Image_Url = info.UDF2,
                    Gl_Desc = info.GL_DESC,
                    Gl_Warranty_Desc = info.GL_WARRANTY_DESC,
                    Member_Price = string.IsNullOrEmpty(info.Id) ? item.MEMBERSHIP_PRICE : Convert.ToDecimal(info.MEMBER_PRICE),
                    Member_Points = info.MENBER_POINTS,
                    Enable_MP = info.ENABLE_MP,
                    Goods_Sales = info.GOODS_SALES,
                    GL_STATUS = info.GL_STATUS,
                    GL_ID = info.Id
                });
            }

            return list;
        }

        /// <summary>
        /// 根据id获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MdmGoodsListDto GetGoodsInfoById(string id)
        {
            string files = "";
            var dto = _mdmGoodsListRepository.Get(id).ToDto();
            var filesList = _resFileMstrRepository.GetAllList(m => m.BIZ_NO == id);
            foreach (var item in filesList)
            {
                files += (string.IsNullOrEmpty(files) ? "" : "|") + item.FILE_NAME;
            }
            dto.files = files;

            return dto;
        }

        /// <summary>
        /// 商品上架/下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnMsg SetGoodsInfoStatus(string id)
        {
            var rm = new ReturnMsg();
            var goods = _mdmGoodsListRepository.Get(id);
            if (goods == null)
            {
                rm.IsSuccess = false;
                rm.msg = "该商品不存在";
                return rm;
            }
            if (goods.GL_STATUS == 1)
            {
                goods.GL_STATUS = 0;
            }
            else
            {
                goods.GL_STATUS = 1;
            }
            goods.UPDATE_DATE = DateTime.Now;
            goods.UPDATE_PSN = AbpSession.USR_ID;
            _mdmGoodsListRepository.Update(goods);
            rm.IsSuccess = true;
            rm.msg = goods.GL_STATUS == 1 ? "上架成功" : "下架成功";

            return rm;
        }

        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <param name="mdmGoodsListDto"></param>
        public void SaveGoodsInfo(MdmGoodsListDto mdmGoodsListDto, ref string msg)
        {
            if (mdmGoodsListDto == null)
            {
                throw new Exception("请填写商品信息");
            }
            if (mdmGoodsListDto.newPublicInfos.Exists(m => m.GOODS_STATUS == "1"))
            {
                mdmGoodsListDto.GL_STATUS = 1;
            }
            if (_mdmGoodsMstrService.NewAddGoods(mdmGoodsListDto, ref msg))
            {
                if (string.IsNullOrEmpty(mdmGoodsListDto.Id))
                {
                    _initHelper.InitAdd<MdmGoodsListDto>(mdmGoodsListDto, (decimal)AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    _mdmGoodsListRepository.Insert(mdmGoodsListDto.ToEntity());
                }
                else
                {
                    _initHelper.InitUpdate<MdmGoodsListDto>(mdmGoodsListDto, (decimal)AbpSession.USR_ID);
                    _mdmGoodsListRepository.Update(mdmGoodsListDto.ToEntity());
                }
            }
            else
            {
                throw new Exception("保存商品属性失败");
            }
        }
    }
}
