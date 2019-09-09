
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using Newtonsoft.Json;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CarFinancePolicyService : SCRMAppServiceBase, ICarFinancePolicyService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICarFinancePolicyRepository _carFinancePolicyRepository;

        private readonly IFinanceTagConfigRepository _financeTagConfigRepository;

        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CarFinancePolicyService(ICarFinancePolicyRepository carFinancePolicyRepository, IFinanceTagConfigRepository financeTagConfigRepository, InitHelper initHelper)
        {
            _carFinancePolicyRepository = carFinancePolicyRepository;
            _financeTagConfigRepository = financeTagConfigRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 获取可选和已选标签
        /// </summary>
        /// <param name="code">车型编码</param>
        /// <param name="level">车型级别</param>
        /// <param name="subCode">车型细分编码</param>
        /// <param name="vin">车架号</param>
        /// <returns></returns>
        public Dictionary<string, IList<FinanceTagConfig>> GetOptionalTagList(string code, int level, string subCode, string vin = "")
        {
            #region 参数验证
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(level + ""))
            {
                throw new Exception("code和level参数不允许为空");
            }

            int result;
            if (int.TryParse(level + "", out result))
            {
                if (level < 3 || level > 4)
                {
                    throw new Exception("level参数有误");
                }
            }
            else
            {
                throw new Exception("level应为数字类型");
            }
            #endregion

            Dictionary<string, IList<FinanceTagConfig>> dic = new Dictionary<string, IList<FinanceTagConfig>>();
            try
            {
                var financeTagConfigs = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO && m.DEL_FLAG == 1);
                //string[] arr = (from tag in financeTagConfigs select tag.Id).ToArray();

                string where = string.Empty;
                //存车型数据
                IList<CarFinancePolicy> cartypelist = null;
                IList<FinanceTagConfig> optionalTagList = null;//可选标签
                IList<FinanceTagConfig> usedTagList = null;//已使用标签

                switch (level)
                {
                    case 3:
                        cartypelist = _carFinancePolicyRepository.GetAllList(m => m.TYPE_CODE == code && m.TAG_LEVEL == 3);

                        if (cartypelist == null || cartypelist.Count == 0)
                        {
                            optionalTagList = financeTagConfigs;
                        }
                        else
                        {
                            CarFinancePolicy info = cartypelist.FirstOrDefault();
                            var tagids = info.TAG_IDS.Replace("'", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);                            
                            optionalTagList = (from tag in financeTagConfigs where !tagids.Contains(tag.Id) select tag).ToList();
                            usedTagList = (from tag in financeTagConfigs where tagids.Contains(tag.Id) select tag).ToList();
                        }
                        break;
                    case 4:
                        if (string.IsNullOrEmpty(vin))//新车
                        {
                            where = string.Format("SUBTYPE_CODE='{0}'", subCode);
                            //车型细分信息
                            var subtypeInfos = _carFinancePolicyRepository.FirstOrDefault(m => m.SUBTYPE_CODE == subCode);

                            if (subtypeInfos != null)
                            {
                                var tagids = subtypeInfos.TAG_IDS.Replace("'", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                optionalTagList = (from tag in financeTagConfigs where !tagids.Contains(tag.Id) select tag).ToList();
                                usedTagList = (from tag in financeTagConfigs where tagids.Contains(tag.Id) select tag).ToList();
                            }
                            else
                            {
                                cartypelist = _carFinancePolicyRepository.GetAllList(m => m.TYPE_CODE == code && m.TAG_LEVEL == 3);
                                if (cartypelist == null || cartypelist.Count == 0)
                                {
                                    optionalTagList = financeTagConfigs;
                                    break;
                                }
                                CarFinancePolicy cinfo = cartypelist[0];

                                var tagids = cinfo.TAG_IDS.Replace("'", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                optionalTagList = (from tag in financeTagConfigs where !tagids.Contains(tag.Id) select tag).ToList();
                                usedTagList = (from tag in financeTagConfigs where tagids.Contains(tag.Id) select tag).ToList();
                            }
                        }
                        else//二手车
                        {
                            //车型细分信息
                            var subtypeInfos = _carFinancePolicyRepository.FirstOrDefault(m => m.SUBTYPE_CODE == subCode && m.UDF1 == vin);

                            if (subtypeInfos != null)
                            {
                                var tagids = subtypeInfos.TAG_IDS.Replace("'", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                optionalTagList = (from tag in financeTagConfigs where !tagids.Contains(tag.Id) select tag).ToList();
                                usedTagList = (from tag in financeTagConfigs where tagids.Contains(tag.Id) select tag).ToList();
                            }
                            else
                            {
                                optionalTagList = financeTagConfigs;
                                usedTagList = null;
                            }
                        }
                        break;
                    default:
                        break;
                }

                dic.Add("OPTIONAL", optionalTagList);
                dic.Add("USED", usedTagList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dic;
        }

        /// <summary>
        /// 保存金融政策
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SavePolicyInfo(CarFinancePolicyDto dto, ref string msg)
        {
            bool flag = false;
            if (dto.BIZ_TYPE == "UC")//二手车
            {
                flag = SaveUCPolicy(dto, out msg);
            }
            else//新车
            {
                switch (dto.TAG_LEVEL)
                {
                    case 3: //车型
                        flag = InsertTYpeTag(dto, ref msg);
                        break;
                    case 4: //车型细分
                        flag = InsertSubTYpeTag(dto, ref msg);
                        break;
                    default:
                        msg = "参数传入有误";
                        break;
                }
            }

            return flag;
        }

        /// <summary>
        /// 保存二手车金融政策
        /// </summary>
        /// <returns></returns>
        private bool SaveUCPolicy(CarFinancePolicyDto info, out string msg)
        {
            bool flag = false;

            if (string.IsNullOrEmpty(info.UDF1))
            {
                msg = "车架号不能为空！";
                return flag;
            }

            try
            {
                if (string.IsNullOrEmpty(info.Id))
                {
                    var uclist = _carFinancePolicyRepository.GetAllList(m => m.UDF1 == info.UDF1);

                    if (uclist == null || uclist.Count == 0)
                    {
                        _initHelper.InitAdd(info, Convert.ToDecimal(AbpSession.USR_ID), AbpSession.ORG_NO, AbpSession.BG_NO);
                        info.Id = Guid.NewGuid().ToString("N");
                        flag = _carFinancePolicyRepository.Insert(info.ToEntity()) != null ? true : false;
                    }
                    else
                    {
                        CarFinancePolicy ucinfo = uclist.FirstOrDefault();
                        ucinfo.TAG_IDS = info.TAG_IDS;
                        ucinfo.TAG_JSON = info.TAG_JSON;
                        ucinfo.UPDATE_PSN = AbpSession.USR_ID;
                        ucinfo.UPDATE_DATE = DateTime.Now;

                        flag = _carFinancePolicyRepository.Update(info.ToEntity()) != null ? true : false;
                    }
                }
                else
                {
                    _initHelper.InitUpdate(info, AbpSession.USR_ID);
                    flag = _carFinancePolicyRepository.Update(info.ToEntity()) != null ? true : false;
                }
                msg = flag ? "保存成功" : "保存失败";
            }
            catch (Exception ex)
            {
                flag = false;
                msg = ex.Message;
            }

            return flag;
        }

        /// <summary>
        /// 新增车型标签
        /// </summary>
        /// <returns></returns>
        public bool InsertTYpeTag(CarFinancePolicyDto info, ref string msg)
        {
            bool flag = false;
            //查询车型信息
            var typelist = _carFinancePolicyRepository.GetAllList(m => m.TYPE_CODE == info.TYPE_CODE && m.TAG_LEVEL == 3);

            if (typelist == null || typelist.Count == 0)//新增
            {
                flag = InsertPolicyInfo(info,ref msg);
                if (!flag)
                {
                    msg = "新增车型金融政策失败";
                    return false;
                }
                string newIds = info.TAG_IDS;
                flag = UpdatePolicyInfo(info, newIds);
            }
            else //修改标签(1.修改车型下的标签,2.同时修改车型下已有的车型细分标签)
            {
                bool subflag = false;

                CarFinancePolicy pInfo = typelist.FirstOrDefault();

                //修改车型下已有车型细分的标签
                //string oriIds = pInfo.TAG_IDS;
                string newIds = info.TAG_IDS;

                subflag = UpdatePolicyInfo(pInfo.ToDto(), newIds);

                if (subflag)
                {
                    var obj = JsonConvert.DeserializeObject<List<TagJson>>(info.TAG_JSON).OrderBy(c => c.SORT_NO);
                    pInfo.TAG_IDS = info.TAG_IDS;
                    pInfo.TAG_JSON = JsonConvert.SerializeObject(obj);
                    _initHelper.InitUpdate(pInfo, AbpSession.USR_ID);
                    flag = _carFinancePolicyRepository.Update(pInfo) != null ? true : false;
                }
            }

            msg = flag ? "操作成功" : "操作失败";
            return flag;
        }

        /// <summary>
        /// 新增车型细分标签
        /// </summary>
        /// <returns></returns>
        public bool InsertSubTYpeTag(CarFinancePolicyDto info, ref string msg)
        {
            bool flag = false;
            try
            {
                var typeList = _carFinancePolicyRepository.GetAllList(m => m.TYPE_CODE == info.TYPE_CODE && m.TAG_LEVEL == 3);

                flag = CheckSubTypeTag(typeList, ref info, out msg);
                if (!flag) return false;
                var list = _carFinancePolicyRepository.GetAllList(m => m.SUBTYPE_CODE == info.SUBTYPE_CODE && m.TAG_LEVEL == 4);
                if (list == null || list.Count == 0)//新增
                {
                    flag = InsertPolicyInfo(info, ref msg);
                }
                else if (string.IsNullOrEmpty(info.Id))//修改标签
                {
                    CarFinancePolicy pInfo = list.FirstOrDefault();
                    var oldTags = pInfo.TAG_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var newTags = info.TAG_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var result = oldTags.Except<string>(newTags).ToList();
                    if (result.Count > 0)
                    {
                        var newTagIds = string.Join(",", result) + "," + info.TAG_IDS;

                        var financeTagConfigs = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO);
                        string[] arr = (from tag in financeTagConfigs select tag.Id).ToArray();
                        var tagList = (from tag in financeTagConfigs where arr.Contains(newTagIds) select tag).ToList();

                        List<object> jsonList = new List<object>();
                        foreach (var tag in tagList)
                        {
                            jsonList.Add(new { TAG_ID = tag.Id, TAG_NAME = tag.TAG_NAME, TAG_DESCRIBE = tag.TAG_DESCRIBE, SORT_NO = Convert.ToInt32(tag.SORT_NO) });
                        }
                        info.TAG_JSON = JsonConvert.SerializeObject(jsonList);
                        info.TAG_IDS = newTagIds;
                    }
                    pInfo.TAG_IDS = info.TAG_IDS;
                    pInfo.TAG_JSON = info.TAG_JSON;
                    _initHelper.InitUpdate(pInfo, AbpSession.USR_ID);
                    flag = _carFinancePolicyRepository.Update(pInfo) != null ? true : false;
                }
                else
                {
                    CarFinancePolicy pInfo = list.FirstOrDefault();
                    pInfo.TAG_IDS = info.TAG_IDS;
                    pInfo.TAG_JSON = info.TAG_JSON;
                    _initHelper.InitUpdate(pInfo, AbpSession.USR_ID);
                    flag = _carFinancePolicyRepository.Update(pInfo) != null ? true : false;
                }
                msg = flag ? "操作成功" : "操作失败";
            }
            catch (Exception ex)
            {
                flag = false;
                msg = "错误消息：" + ex.Message;
            }
            return flag;
        }

        public bool CheckSubTypeTag(List<CarFinancePolicy> typeList, ref CarFinancePolicyDto info, out string msg)
        {
            var flag = true;
            msg = "";
            if (typeList.Count > 0)
            {
                var typeTags = typeList.FirstOrDefault().TAG_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var subTags = info.TAG_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result = subTags.Except<string>(typeTags).ToList();
                if (result.Count > 0)
                {
                    var tagIds = string.Join(",", result) + "," + typeList.FirstOrDefault().TAG_IDS;

                    var financeTagConfigs = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO);
                    string[] arr = (from tag in financeTagConfigs select tag.Id).ToArray();
                    var tagList = (from tag in financeTagConfigs where arr.Contains(tagIds) select tag).ToList().OrderBy(s => s.SORT_NO);

                    List<object> jsonList = new List<object>();
                    foreach (var tag in tagList)
                    {
                        jsonList.Add(new { TAG_ID = tag.Id, TAG_NAME = tag.TAG_NAME, TAG_DESCRIBE = tag.TAG_DESCRIBE, SORT_NO = Convert.ToInt32(tag.SORT_NO) });
                    }
                    info.TAG_JSON = JsonConvert.SerializeObject(jsonList);
                    info.TAG_IDS = tagIds;
                }
                else
                {
                    msg = "已存在该金融政策的车型";
                    return false;
                }
            }
            return flag;

        }

        /// <summary>
        /// 新增金融政策
        /// </summary>
        /// <returns></returns>
        public bool InsertPolicyInfo(CarFinancePolicyDto info,ref string msg)
        {
            bool flag = false;
            try
            {
                var financeTagConfigs = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO && m.DEL_FLAG == 1);
                var tagIds = info.TAG_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var taglist = financeTagConfigs.Where(c => tagIds.Contains(c.Id)).ToList().OrderBy(s => s.SORT_NO);
                //var taglist = (from tag in financeTagConfigs where arr.Contains(info.TAG_IDS) select tag).ToList().OrderBy(s => s.SORT_NO);

                List<object> list = new List<object>();
                foreach (var tag in taglist)
                {
                    list.Add(new { TAG_ID = tag.Id, TAG_NAME = tag.TAG_NAME, TAG_DESCRIBE = tag.TAG_DESCRIBE, SORT_NO = Convert.ToInt32(tag.SORT_NO) });
                }

                _initHelper.InitAdd(info, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                info.Id = Guid.NewGuid().ToString("N");
                info.TAG_JSON = JsonConvert.SerializeObject(list);

                flag = _carFinancePolicyRepository.Insert(info.ToEntity()) != null ? true : false;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 修改车型下已有车型细分标签
        /// </summary>
        /// <param name="pInfo"></param>
        /// <param name="tagids"></param>
        /// <returns></returns>
        public bool UpdatePolicyInfo(CarFinancePolicyDto pInfo, string tagids)
        {
            bool subflag = true;
            //修改车型下已有车型细分的标签
            string oriIds = pInfo.TAG_IDS;
            string newIds = tagids;

            //车型细分
            var sublist = _carFinancePolicyRepository.GetAllList(m => m.TYPE_CODE == pInfo.TYPE_CODE && m.TAG_LEVEL == 4);
            if (sublist.Count > 0)
            {
                foreach (var item in sublist)
                {
                    string ids = item.TAG_IDS;//去掉原车型的标签id,加上车型新标签的id
                    string[] orisubTags = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] oritypeTags = oriIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] newtypeTags = newIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var isDel = orisubTags.Except<string>(newtypeTags).ToList();
                    if (isDel.Count == 0)
                    {
                        //client.DeleteCAR_FINANCE_POLICYByPrimaryKey(item.FINANCE_ID);
                        _carFinancePolicyRepository.Delete(item.Id);
                        return subflag;
                    }
                    var result = orisubTags.Except<string>(oritypeTags).ToList();

                    string newsubids = "";
                    if (result != null && result.Count > 0)
                    {
                        newsubids = string.Join(",", result) + "," + newIds;
                    }
                    //{"TAG_NAME":"需加精品","TAG_DESCRIBE":"装饰为豪车","SORT_NO":1}

                    //车型细分标签
                    var financeTagConfigs = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO&&m.DEL_FLAG==1);
                    string[] arr = (from tag in financeTagConfigs select tag.Id).ToArray();

                    var tagIds = newsubids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var taglist = financeTagConfigs.Where(c => tagIds.Contains(c.Id)).ToList().OrderBy(s => s.SORT_NO);

                    List<object> list = new List<object>();
                    foreach (var tag in taglist)
                    {
                        list.Add(new { TAG_ID = tag.Id, TAG_NAME = tag.TAG_NAME, TAG_DESCRIBE = tag.TAG_DESCRIBE, SORT_NO = Convert.ToInt32(tag.SORT_NO) });
                    }

                    item.TAG_IDS = newsubids;
                    item.TAG_JSON = JsonConvert.SerializeObject(list);
                    _initHelper.InitUpdate(item, AbpSession.USR_ID);

                    subflag = _carFinancePolicyRepository.Update(item) != null ? true : false;
                    if (!subflag)
                    {
                        break;
                    }
                }
            }
            return subflag;
        }

        /// <summary>
        /// 删除金融政策
        /// </summary>
        /// <param name="ids"></param>
        public void DeletePolicy(string ids)
        {
            try
            {
                if (string.IsNullOrEmpty(ids))
                {
                    throw new Exception("id不允许为空");
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    var entity = _carFinancePolicyRepository.Get(arr[i]);
                    _carFinancePolicyRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TagJson
    {
        public string TAG_ID { get; set; }
        public string TAG_NAME { get; set; }
        public string TAG_DESCRIBE { get; set; }
        public int SORT_NO { get; set; }
    }
}
