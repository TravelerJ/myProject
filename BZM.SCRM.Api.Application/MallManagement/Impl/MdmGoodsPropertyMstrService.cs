
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using Newtonsoft.Json;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmGoodsPropertyMstrService : SCRMAppServiceBase, IMdmGoodsPropertyMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsPropertyMstrRepository _mdmGoodsPropertyMstrRepository;
        private readonly IMdmGoodsMstrRepository _mdmGoodsMstrRepository;

        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmGoodsPropertyMstrService(IMdmGoodsPropertyMstrRepository mdmGoodsPropertyMstrRepository, IMdmGoodsMstrRepository mdmGoodsMstrRepository, InitHelper initHelper)
        {
            _mdmGoodsPropertyMstrRepository = mdmGoodsPropertyMstrRepository;
            _mdmGoodsMstrRepository = mdmGoodsMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 获取商品分类属性
        /// </summary>
        /// <param name="goodsClassId"></param>
        /// <returns></returns>
        public string GetPropertyList(string goodsClassId)
        {
            var properlist = _mdmGoodsPropertyMstrRepository.GetAllList(m => m.PROPERTY_EN_NAME == goodsClassId && m.PROPERTY_TYPE == 2 && m.CREATE_ORG_NO == AbpSession.ORG_NO);

            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (var item in properlist)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("PROPERTY_ID", item.Id);
                dic.Add("PROPERTY_NAME", item.PROPERTY_NAME);

                var itemList = _mdmGoodsPropertyMstrRepository.GetAllList(m => m.PROPERTY_PARENTID == item.Id);
                Dictionary<string, string> itemDic = new Dictionary<string, string>();
                foreach (var value in itemList)
                {
                    itemDic.Add("id", value.Id);
                    itemDic.Add("value", value.PROPERTY_NAME);
                }
                dic.Add("itemList", itemDic);

                list.Add(dic);
            }

            var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(list, jsonSetting);
        }

        /// <summary>
        /// 保存商品分类属性
        /// </summary>
        /// <param name="dto"></param>
        public void SaveGoodsProperty(MdmGoodsPropertyMstrDto dto)
        {
            string propertyId = dto.Id;
            //保存主属性
            MdmGoodsPropertyMstrDto mstrProperty = new MdmGoodsPropertyMstrDto()
            {
                PROPERTY_NAME = dto.PROPERTY_NAME,
                PROPERTY_TYPE = 2,
                PROPERTY_PARENTID = dto.PROPERTY_EN_NAME,
                PROPERTY_LEVEL = 0,
                PROPERTY_EN_NAME = dto.PROPERTY_EN_NAME,
                Id = propertyId
            };

            if (!SaveProperty(mstrProperty, ref propertyId))
            {
                throw new Exception("绑定分类失败");
            }

            //保存属性明细
            string propertyItemId = "";
            string where = "";
            string _values = "|" + dto.PROPERTY_DEFAULT_VALUE + "|";

            string[] arr = dto.PROPERTY_DEFAULT_VALUE.Split('|');
            foreach (var item in arr)
            {
                MdmGoodsPropertyMstrDto itemProperty = new MdmGoodsPropertyMstrDto()
                {
                    PROPERTY_NAME = dto.PROPERTY_NAME,
                    PROPERTY_TYPE = 3,
                    PROPERTY_PARENTID = propertyId,
                    PROPERTY_LEVEL = 0,
                    PROPERTY_EN_NAME = dto.PROPERTY_EN_NAME,
                    PROPERTY_DEFAULT_VALUE = item
                };

                if (!_mdmGoodsPropertyMstrRepository.ValidateProperty(propertyId, item) && !string.IsNullOrEmpty(item))
                {
                    if (!SaveProperty(itemProperty, ref propertyItemId))
                    {
                        throw new Exception("绑定属性明细失败");
                    }
                }

                //修改sku时，删除项验证
                if (!string.IsNullOrEmpty(propertyId))
                {
                    var list = _mdmGoodsPropertyMstrRepository.GetAllList(m => m.PROPERTY_PARENTID == propertyId);
                    //遍历数据库所有已存sku值
                    foreach (MdmGoodsPropertyMstr model in list)
                    {
                        //若该值已被删除（不包含在新数据内）
                        if (!_values.Contains("|" + model.PROPERTY_DEFAULT_VALUE + "|"))
                        {
                            //验证该值是否被商品使用
                            var mstrList = _mdmGoodsMstrRepository.GetAllList(m => m.SKU_PROPERTY_ID1 == model.Id || m.SKU_PROPERTY_ID2 == model.Id || m.SKU_PROPERTY_ID3 == model.Id || m.SKU_PROPERTY_ID4 == model.Id || m.SKU_PROPERTY_ID5 == model.Id);
                            if (mstrList != null && mstrList.Count > 0)
                            {
                                throw new Exception("sku已被使用：" + model.PROPERTY_DEFAULT_VALUE);
                            }
                        }
                    }
                }
                where += " and PROPERTY_DEFAULT_VALUE!='" + item + "'";
            }

            _mdmGoodsPropertyMstrRepository.DelProValue(propertyId, where);
        }

        /// <summary>
        /// 保存属性
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool SaveProperty(MdmGoodsPropertyMstrDto dto, ref string id)
        {
            _initHelper.InitAdd<MdmGoodsPropertyMstrDto>(dto, Convert.ToDecimal(AbpSession.USR_ID), AbpSession.ORG_NO, AbpSession.BG_NO);
            dto.PROPERTY_STATUS = 1;
            dto.PROPERTY_DOMAIN = 1;

            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                id = dto.Id;

                return _mdmGoodsPropertyMstrRepository.Insert(dto.ToEntity()) != null ? true : false;
            }
            else
            {
                dto.DEL_FLAG = 1;
                dto.UPDATE_DATE = DateTime.Now;
                dto.UPDATE_PSN = Convert.ToDecimal(AbpSession.USR_ID);

                return _mdmGoodsPropertyMstrRepository.Insert(dto.ToEntity()) != null ? true : false;
            }
        }


        /// <summary>
        /// 删除商品分类属性
        /// </summary>
        /// <param name="id"></param>
        public void DelGoodsProperty(string id)
        {
            var entity = _mdmGoodsPropertyMstrRepository.Get(id);
            if (entity != null)
            {
                var list = _mdmGoodsPropertyMstrRepository.GetAllList(m => m.PROPERTY_PARENTID == entity.Id);

                foreach (var item in list)
                {
                    _mdmGoodsPropertyMstrRepository.Delete(item);
                }
                _mdmGoodsPropertyMstrRepository.Delete(entity);
            }
            else
            {
                throw new Exception("id参数有误！");
            }
        }
    }
}
