
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using Newtonsoft.Json;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class MdmGoodsClassService : SCRMAppServiceBase, IMdmGoodsClassService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsClassRepository _mdmGoodsClassRepository;

        private readonly IMdmGoodsMstrRepository _mdmGoodsMstrRepository;

        private readonly InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmGoodsClassService(IMdmGoodsClassRepository mdmGoodsClassRepository, IMdmGoodsMstrRepository mdmGoodsMstrRepository, InitHelper initHelper)
        {
            _mdmGoodsClassRepository = mdmGoodsClassRepository;
            _mdmGoodsMstrRepository = mdmGoodsMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MdmGoodsClassDto SaveGoodsClass(MdmGoodsClassDto dto)
        {
            if (dto.Id == 0 || string.IsNullOrEmpty(dto.Id + ""))
            {
                var classList = _mdmGoodsClassRepository.GetAllList(m => m.CLASS_NO == dto.CLASS_NO || m.CLASS_NAME == dto.CLASS_NAME && m.BG_NO == AbpSession.BG_NO);
                if (classList == null || classList.Count == 0)
                {
                    _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    return _mdmGoodsClassRepository.Insert(dto.ToEntity()).ToDto();
                }
                else
                {
                    throw new Exception("分类编码或名称已存在");
                }
            }
            else
            {
                var classInfo = _mdmGoodsClassRepository.Get(dto.Id);
                classInfo.CLASS_STATUS = dto.CLASS_STATUS;

                IList<string> goodsClassIdList = new List<string>();
                if (dto.CLASS_STATUS == 0)
                {
                    goodsClassIdList.Add(dto.Id + "");
                    if (!CheckBind(ref goodsClassIdList))
                    {
                        throw new Exception("无法删除已绑定商品的商品分类");
                    }
                }
                dto.UPDATE_PSN = Convert.ToDecimal(AbpSession.USR_ID);
                dto.UPDATE_DATE = DateTime.Now;

                var classDto = _mdmGoodsClassRepository.Update(dto.ToEntity()).ToDto();

                if (classDto.CLASS_STATUS == 0 && classDto != null)
                {
                    //删除所有子类
                    string sqlStr = "";
                    foreach (string classIds in goodsClassIdList)
                    {
                        sqlStr = string.IsNullOrEmpty(sqlStr) ? classIds : sqlStr + "," + classIds;
                    }
                    sqlStr = " CLASS_ID in (" + sqlStr + ")";
                    bool flag = _mdmGoodsClassRepository.DelGoodsClass(sqlStr);
                    if (!flag)
                    {
                        throw new Exception("保存失败");
                    }
                }
            }
            return dto;
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGoodsClass(long id)
        {
            var classList = _mdmGoodsClassRepository.GetAllList(m => m.PARENT_ID == id);
            var mstrList = _mdmGoodsMstrRepository.GetAllList(m => m.GOODS_LARGECLASS == id || m.GOODS_INCLASS == id || m.GOODS_SMALLCLASS == id);
            if (classList?.Count > 0 || mstrList?.Count > 0)
            {
                throw new Exception("该分类下存在正常的子级分类或商品！请先删除子类或商品");
            }
            var entity = _mdmGoodsClassRepository.Get(id);
            _mdmGoodsClassRepository.Delete(entity);
        }

        private bool CheckBind(ref IList<string> goodsClassIdList)
        {
            BindChildClassIds(ref goodsClassIdList);
            //验证四级分类是否绑定
            for (int i = 0; i < goodsClassIdList.Count; i++)
            {
                string sql = "";
                if (i == 0)
                    sql = "GOODS_LARGECLASS in (" + goodsClassIdList[i] + ")";
                if (i == 1)
                    sql = "GOODS_INCLASS in (" + goodsClassIdList[i] + ")";
                if (i == 2)
                    sql = "GOODS_SMALLCLASS in (" + goodsClassIdList[i] + ")";
                if (i == 3)
                    sql = "GOODS_SUBCLASS in (" + goodsClassIdList[i] + ")";
                if (_mdmGoodsClassRepository.GetBindGoodsNum(sql) && i <= 3)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 绑定分类主键list的子类
        /// </summary>
        /// <param name="goodsIdList"></param>
        private void BindChildClassIds(ref IList<string> goodsIdList)
        {
            string childClassIds = "";
            int lvl = goodsIdList.Count;

            string sqlClassIds = "PARENT_ID in (" + goodsIdList[lvl - 1] + ") and bg_no='" + AbpSession.BG_NO + "'";

            string json = ""; //client.GetMDM_GOODS_CLASSJson(sqlClassIds);
            List<Dictionary<string, object>> list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            foreach (Dictionary<string, object> info in list)
            {
                object value;
                string strClassId = info.TryGetValue("CLASS_ID", out value) ? value.ToString() : "";

                if (!string.IsNullOrEmpty(strClassId))
                {
                    childClassIds = childClassIds == "" ? strClassId : childClassIds + "," + strClassId;
                }
            }
            if (!string.IsNullOrEmpty(childClassIds))
            {
                goodsIdList.Add(childClassIds);
                BindChildClassIds(ref goodsIdList);
            }
        }
    }
}
