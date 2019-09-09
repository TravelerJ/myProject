
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common.Util;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Repositories;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using BT.BPMLIVE.Common;
using System.Data;
using BZM.SCRM.Domain.Common;
using SCRM.Application.ServiceManagement.Dtos;
using System.Linq;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class ResFileMstrService : SCRMAppServiceBase, IResFileMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IResFileMstrRepository _resFileMstrRepository;

        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;

        private readonly WxHelper _wxHelper;

        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public ResFileMstrService(IResFileMstrRepository resFileMstrRepository, WxHelper wxHelper, IMdmBuMstrRepository mdmBuMstrRepository, InitHelper initHelper)
        {
            _resFileMstrRepository = resFileMstrRepository;
            _wxHelper = wxHelper;
            _mdmBuMstrRepository = mdmBuMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 获取erp车型数据
        /// </summary>
        /// <returns></returns>
        public List<CarInfo> GetErpCarList()
        {
            List<CarInfo> list = new List<CarInfo>();
            var newList = new List<CarInfo>();
            string url = "";
            string msg = "";

            //var buInfo = _mdmBuMstrRepository.Get(AbpSession.ORG_NO);
            //if (buInfo == null)
            //{
            //    throw new Exception("暂未查到该门店");
            //}
            //var arr = buInfo.CARBRAND_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var getUrl = _wxHelper.GetErpApiUrl(AbpSession.BG_NO, ref url, ref msg, "new");
            if (!getUrl)
            {
                throw new Exception(msg);
            }

            #region 请求erp接口
            ErpCarRequest request = new ErpCarRequest(url);
            request.iDisplayStart = 0;
            request.iDisplayLength = 100000;
            request.orgNo = AbpSession.ORG_NO;

            string brands = request.PostErpBrandInfo();
            JObject jo = (JObject)JsonConvert.DeserializeObject(brands);
            if (!Convert.ToBoolean(jo["IsSuccess"]))
            {
                throw new Exception("获取品牌信息失败！");
            }

            DataTable carbrandDt = _Convert.JsonToDataTable(jo["result"].ToString());
            BindCarImg(list, carbrandDt, 1);

            string carClass = request.PostErpClassInfo();
            JObject jo1 = (JObject)JsonConvert.DeserializeObject(carClass);
            if (!Convert.ToBoolean(jo1["IsSuccess"]))
            {
                throw new Exception("获取车系信息失败！");
            }
            DataTable carClassDt = _Convert.JsonToDataTable(jo1["result"].ToString());
            BindCarImg(list, carClassDt, 2);

            string carTypes = request.PostErpTypeInfo();
            JObject jo2 = (JObject)JsonConvert.DeserializeObject(carTypes);
            if (!Convert.ToBoolean(jo2["IsSuccess"]))
            {
                throw new Exception("获取车型信息失败！");
            }
            DataTable carTypeDt = _Convert.JsonToDataTable(jo2["result"].ToString());
            BindCarImg(list, carTypeDt, 3);

            string carSubTypes = request.PostErpSubTypeInfo();
            JObject jo3 = (JObject)JsonConvert.DeserializeObject(carSubTypes);
            if (!Convert.ToBoolean(jo3["IsSuccess"]))
            {
                throw new Exception("获取车型细分信息失败！");
            }
            DataTable carSubtypeDt = _Convert.JsonToDataTable(jo3["result"].ToString());
            BindCarImg(list, carSubtypeDt, 4);
            #endregion

            var brandList = list.Where(c => c.PARENT_ID == "0").ToList();
            foreach (var item in brandList)
            {
                var result = GetCarInfos(item, list);
                newList.Add(result);

            }
            return newList;
        }

        /// <summary>
        /// 获取车辆数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public CarInfo GetCarInfos(CarInfo item, List<CarInfo> list)
        {
            var childList = list.Where(c => c.PARENT_ID == item.CLASS_ID).ToList();
            item.ChildInfo = childList;
            foreach (var child in childList)
            {
                GetCarInfos(child, list);
            }
            return item;
        }
        /// <summary>
        /// 绑定车型图片
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dt"></param>
        /// <param name="type">1.品牌，2.车系，3.车型，4.车型细分</param>
        private void BindCarImg(List<CarInfo> list, DataTable dt, int type)
        {
            var imgList = _resFileMstrRepository.GetAllList(m => m.CREATE_ORG_NO == AbpSession.ORG_NO);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CarInfo model = new CarInfo();
                model.CLASS_LEVEL = type;
                switch (type)
                {
                    case 1:
                        model.ChildInfo = new List<CarInfo>();
                        model.CLASS_ID = dt.Rows[i]["BRAND_ID"].ToString();
                        model.CLASS_NO = dt.Rows[i]["BRAND_CODE"].ToString();
                        model.CLASS_NAME = dt.Rows[i]["BRAND_NAME"].ToString();
                        model.PARENT_ID = "0";
                        break;
                    case 2:
                        model.CLASS_ID = dt.Rows[i]["CLASS_ID"].ToString();
                        model.CLASS_NO = dt.Rows[i]["CLASS_CODE"].ToString();
                        model.CLASS_NAME = dt.Rows[i]["CLASS_NAME"].ToString();
                        model.PARENT_ID = dt.Rows[i]["BRAND_ID"].ToString();
                        break;
                    case 3:
                        model.CLASS_ID = dt.Rows[i]["TYPE_ID"].ToString();
                        model.CLASS_NO = dt.Rows[i]["TYPE_CODE"].ToString();
                        model.CLASS_NAME = dt.Rows[i]["TYPE_NAME"].ToString();
                        model.PARENT_ID = dt.Rows[i]["CLASS_ID"].ToString();
                        break;
                    case 4:
                        model.CLASS_ID = dt.Rows[i]["SUBTYPE_ID"].ToString();
                        model.CLASS_NO = dt.Rows[i]["SUBTYPE_CODE"].ToString();
                        model.CLASS_NAME = dt.Rows[i]["SUBTYPE_NAME"].ToString();
                        model.PARENT_ID = dt.Rows[i]["TYPE_ID"].ToString();
                        break;
                    default:
                        break;
                }

                var img = imgList.FindAll(f => f.BIZ_NO == model.CLASS_ID);
                model.FILE_ID = img != null && img.Count > 0 ? img[0].Id : "";
                model.imgName = img != null && img.Count > 0 ? img[0].FILE_NAME : "";

                list.Add(model);
            }
        }

        /// <summary>
        /// 保存车型关联图
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <param name="bizNo">车型id</param>
        /// <param name="fileName">图片名</param>
        public void SaveCarResFile(string fileId, string bizNo, string fileName)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                //删除已保存的文件
                var list = _resFileMstrRepository.GetAllList(m => m.BIZ_NO == bizNo);
                foreach (var item in list)
                {
                    var entity = _resFileMstrRepository.Get(item.Id);
                    _resFileMstrRepository.Delete(entity);
                }

                ResFileMstrDto dto = new ResFileMstrDto();
                _initHelper.InitAdd(dto, Convert.ToDecimal(AbpSession.USR_ID), AbpSession.ORG_NO, AbpSession.BG_NO);
                dto.Id = Guid.NewGuid().ToString("N");
                dto.BIZ_NO = bizNo;
                dto.FILE_NAME = fileName;

                _resFileMstrRepository.Insert(dto.ToEntity());
            }
            else
            {
                var list = _resFileMstrRepository.GetAllList(m => m.BIZ_NO == bizNo && m.Id != fileId);
                foreach (var item in list)
                {
                    var e = _resFileMstrRepository.Get(item.Id);
                    _resFileMstrRepository.Delete(e);
                }

                var entity = _resFileMstrRepository.Get(fileId);
                var dto = entity.ToDto();
                _initHelper.InitUpdate(dto, Convert.ToDecimal(AbpSession.USR_ID));
                dto.FILE_NAME = fileName;
                dto.BIZ_NO = bizNo;

                _resFileMstrRepository.Update(dto.ToEntity());
            }
        }
    }
}
