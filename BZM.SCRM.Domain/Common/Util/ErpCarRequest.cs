using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// 请求erp车辆数据
    /// </summary>
    public class ErpCarRequest
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public string brandId { get; set; }
        /// <summary>
        /// 品牌编码
        /// </summary>
        public string brandCode { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string brandName { get; set; }
        /// <summary>
        /// 车系id
        /// </summary>
        public string classId { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        public string classCode { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        public string className { get; set; }
        /// <summary>
        /// 车型id
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// 车型编码
        /// </summary>
        public string typeCode { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string typeName { get; set; }
        /// <summary>
        /// 车型细分id
        /// </summary>
        public string subTypeId { get; set; }
        /// <summary>
        /// 车型细分编码
        /// </summary>
        public string subTypeCode { get; set; }
        /// <summary>
        /// 车型细分名称
        /// </summary>
        public string subTypeName { get; set; }
        /// <summary>
        /// 开始页
        /// </summary>
        public int iDisplayStart { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int iDisplayLength { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string orgNo { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        private string url { get; set; }

        /// <summary>
        /// 构造方法传入请求地址
        /// </summary>
        /// <this name="url"></this>
        public ErpCarRequest(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// 请求erp品牌数据
        /// </summary>
        /// <returns></returns>
        public string PostErpBrandInfo()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("brandId", this.brandId);
            dic.Add("brandCode", this.brandCode);
            dic.Add("brandName", this.brandName);
            dic.Add("iDisplayStart", this.iDisplayStart);
            dic.Add("iDisplayLength", this.iDisplayLength);
            var json = JsonConvert.SerializeObject(dic);

            return HttpRequest.ErpRequestApi(json, "MDM/GetCarBrandInfo", this.url, this.orgNo);
        }

        /// <summary>
        /// 车系
        /// </summary>
        /// <returns></returns>
        public string PostErpClassInfo()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("brandId", this.brandId);
            dic.Add("brandCode", this.brandCode);
            dic.Add("brandName", this.brandName);
            dic.Add("iDisplayStart", this.iDisplayStart);
            dic.Add("iDisplayLength", this.iDisplayLength);
            dic.Add("classId", this.classId);
            dic.Add("classCode", this.classCode);
            dic.Add("className", this.className);
            var json = JsonConvert.SerializeObject(dic);

            return HttpRequest.ErpRequestApi(json, "MDM/GetCarClassInfo", this.url, this.orgNo);
        }
        /// <summary>
        /// 车型
        /// </summary>
        /// <returns></returns>
        public string PostErpTypeInfo()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("iDisplayStart", this.iDisplayStart);
            dic.Add("iDisplayLength", this.iDisplayLength);
            dic.Add("brandCode", this.brandCode);
            dic.Add("classCode", this.classCode);
            dic.Add("brandId", this.brandId);
            dic.Add("classId", this.classId);
            dic.Add("typeId", this.typeId);
            var json = JsonConvert.SerializeObject(dic);

            return HttpRequest.ErpRequestApi(json, "MDM/GetCarTypeInfo", this.url, this.orgNo);
        }
        /// <summary>
        /// 车型细分
        /// </summary>
        /// <returns></returns>
        public string PostErpSubTypeInfo()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("brandCode", this.brandCode);
            dic.Add("brandName", this.brandName);
            dic.Add("iDisplayStart", this.iDisplayStart);
            dic.Add("iDisplayLength", this.iDisplayLength);
            dic.Add("classCode", this.classCode);
            dic.Add("className", this.className);
            dic.Add("typeCode", this.typeCode);
            dic.Add("typeName", this.typeName);
            dic.Add("subTypeCode", this.subTypeCode);
            dic.Add("subTypeName", this.subTypeName);
            dic.Add("brandId", this.brandId);
            dic.Add("classId", this.classId);
            dic.Add("typeId", this.typeId);
            dic.Add("subTypeId", this.subTypeId);
            var json = JsonConvert.SerializeObject(dic);

            return HttpRequest.ErpRequestApi(json, "MDM/GetCarSubTypeInfo", this.url, this.orgNo);
        }

        /// <summary>
        /// 获取ERP车辆信息
        /// </summary>
        /// <param name="level"></param>
        /// <param name="msg"></param>
        /// <param name="parentids"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<CarInfoModel> GetERPCarInfo(int level, ref string msg, string parentids = "", string ids = "")
        {
            List<CarInfoModel> list = new List<CarInfoModel>();
            try
            {
                switch (level)
                {
                    case 1://品牌
                        if (!string.IsNullOrEmpty(ids))
                        {
                            this.brandId = ids;
                        }
                        string carbrands = this.PostErpBrandInfo();
                        list = GetCarResult(level, carbrands, ref msg);
                        break;
                    case 2://车系
                        if (!string.IsNullOrEmpty(parentids))
                        {
                            this.brandId = parentids;
                        }
                        if (!string.IsNullOrEmpty(ids))
                        {
                            this.classId = ids;
                        }
                        string carclass = this.PostErpClassInfo();
                        list = GetCarResult(level, carclass, ref msg);
                        break;
                    case 3://车型    
                        if (!string.IsNullOrEmpty(parentids))
                        {
                            this.classId = parentids;
                        }
                        if (!string.IsNullOrEmpty(ids))
                        {
                            this.typeId = ids;
                        }
                        string cartype = this.PostErpTypeInfo();
                        list = GetCarResult(level, cartype, ref msg);
                        break;
                    case 4://车型细分
                        if (!string.IsNullOrEmpty(parentids))
                        {
                            this.typeId = parentids;
                        }
                        if (!string.IsNullOrEmpty(ids))
                        {
                            this.subTypeId = ids;
                        }
                        string carsubtype = this.PostErpSubTypeInfo();
                        list = GetCarResult(level, carsubtype, ref msg);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                list = null;
            }
            return list;
        }

        /// <summary>
        /// 车型数据结果处理
        /// </summary>
        /// <param name="level"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public List<CarInfoModel> GetCarResult(int level, string result, ref string errMsg)
        {
            JObject jObject = (JObject)JsonConvert.DeserializeObject(result);
            if (Convert.ToBoolean(jObject["IsSuccess"]) && jObject["result"].ToString() != "[]")
            {
                string classResult = jObject["result"] + "";
                List<ErpCarReturnModel> erplist = JsonConvert.DeserializeObject<List<ErpCarReturnModel>>(classResult);
                List<CarInfoModel> list = TransferCarModel(erplist, level);

                return list;
            }
            else
            {
                string name = "";
                switch (level)
                {
                    case 1:
                        name = "品牌";
                        break;
                    case 2:
                        name = "车系";
                        break;
                    case 3:
                        name = "车型";
                        break;
                    case 4:
                        name = "车型细分";
                        break;
                    default:
                        break;
                }
                errMsg = "获取" + name + "信息失败";
            }
            return null;
        }

        /// <summary>
        /// 转换model信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public List<CarInfoModel> TransferCarModel(List<ErpCarReturnModel> list, int level)
        {
            if (list.Count == 0)
            {
                return null;
            }
            List<CarInfoModel> carlist = new List<CarInfoModel>();

            foreach (var item in list)
            {
                CarInfoModel model = new CarInfoModel()
                {
                    CLASS_LEVEL = level,
                    CLASS_ATTR = "ZC",
                    CLASS_STATUS = 1,
                    BIZ_TYPE = item.BIZ_TYPE
                };

                switch (level)
                {
                    case 1:
                        model.CLASS_ID = item.BRAND_ID;
                        model.CLASS_NO = item.BRAND_CODE;
                        model.CLASS_NAME = item.BRAND_NAME;
                        model.PARENT_ID = "";
                        break;
                    case 2:
                        model.CLASS_ID = item.CLASS_ID;
                        model.CLASS_NO = item.CLASS_CODE;
                        model.CLASS_NAME = item.CLASS_NAME;
                        model.PARENT_ID = item.BRAND_ID;
                        break;
                    case 3:
                        model.CLASS_ID = item.TYPE_ID;
                        model.CLASS_NO = item.TYPE_CODE;
                        model.CLASS_NAME = item.TYPE_NAME;
                        model.PARENT_ID = item.CLASS_ID;
                        break;
                    case 4:
                        model.CLASS_ID = item.SUBTYPE_ID;
                        model.CLASS_NO = item.SUBTYPE_CODE;
                        model.CLASS_NAME = item.SUBTYPE_NAME;
                        model.PARENT_ID = item.TYPE_ID;
                        break;
                    default:
                        break;
                }

                carlist.Add(model);
            }

            return carlist;
        }
    }
}
