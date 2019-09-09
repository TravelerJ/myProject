
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using Newtonsoft.Json;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SCRM.Application.CrmAptConfigMstrs
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmAptConfigMstrService : SCRMAppServiceBase, ICrmAptConfigMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmAptConfigMstrRepository _crmAptConfigMstrRepository;

        private readonly IAptTimeperiodConfigRepository _aptTimeperiodConfigRepository;

        private InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmAptConfigMstrService(ICrmAptConfigMstrRepository crmAptConfigMstrRepository, InitHelper initHelper, IAptTimeperiodConfigRepository aptTimeperiodConfigRepository)
        {
            _crmAptConfigMstrRepository = crmAptConfigMstrRepository;
            _initHelper = initHelper;
            _aptTimeperiodConfigRepository = aptTimeperiodConfigRepository;
        }

        /// <summary>
        /// 新增/编辑预约配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public CrmAptConfigMstr SaveCrmAptConfig(CrmAptConfigMstrDto dto, out string msg)
        {
            bool flag = false;

            #region 参数验证
            if (dto.APT_TYPE == 2 && dto.DIS_TYPE == null)
            {
                throw new Exception("请选择优惠方式");
            }

            if (string.IsNullOrEmpty(dto.APT_CONFIG_JSON))
            {
                throw new Exception("时间段参数不允许为空");
            }

            if (!CheckPeriod(dto.APT_CONFIG_JSON, out msg))
            {
                throw new Exception(msg);
            }
            #endregion

            if (!CheckDate(dto.APT_CONFIG_SDATE, dto.APT_CONFIG_EDATE, dto.Id, dto.APT_TYPE))
            {
                msg = "该时段已经存在配置，请修改后重试!";
                throw new Exception(msg);
            }

            //新增
            if (string.IsNullOrEmpty(dto.Id))
            {
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                dto.Id = Guid.NewGuid().ToString("N");
                dto.APT_CONFIG_SDATE = Convert.ToDateTime(Convert.ToDateTime(dto.APT_CONFIG_SDATE).ToString("yyyy-MM-dd") + " 00:00:00");
                dto.APT_CONFIG_EDATE = Convert.ToDateTime(Convert.ToDateTime(dto.APT_CONFIG_EDATE).ToString("yyyy-MM-dd") + " 23:59:59");

                return _crmAptConfigMstrRepository.Insert(dto.ToEntity());
            }
            else//修改
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                dto.APT_CONFIG_SDATE = Convert.ToDateTime(Convert.ToDateTime(dto.APT_CONFIG_SDATE).ToString("yyyy-MM-dd") + " 00:00:00");
                dto.APT_CONFIG_EDATE = Convert.ToDateTime(Convert.ToDateTime(dto.APT_CONFIG_EDATE).ToString("yyyy-MM-dd") + " 23:59:59");

                return _crmAptConfigMstrRepository.Update(dto.ToEntity());
            }
        }

        /// <summary>
        /// 检查时间段是否输入正确
        /// </summary>
        /// <returns></returns>
        private bool CheckPeriod(string json, out string errMsg)
        {
            //[{"SORT_NO":1,"PERIOD_STIME":"08:00:00","PERIOD_ETIME":"09:59:59","MaxNum":10,"DIS_TYPE":1,DISCOUNT:8.8},{"SORT_NO":2,"PERIOD_STIME":"12:00:00","PERIOD_ETIME":"13:59:59","MaxNum":10,"DIS_TYPE":1,DISCOUNT:7}]

            string pattern = "^([0-2]{1}[0-9]{1}:00-[0-2]{1}[0-9]{1}:00)|([0-2]{1}[0-9]{1}:30-[0-2]{1}[0-9]{1}:30)$";
            List<PeriodModel> list = JsonConvert.DeserializeObject<List<PeriodModel>>(json);
            if (list == null || list.Count > 8)
            {
                errMsg = "时间段个数超过最大条数限制！";
                return false;
            }

            int i = 0; bool flag = true; string msg = "";
            foreach (var item in list)
            {
                i++;
                //时间格式验证
                if (!Regex.IsMatch(item.PERIOD_STIME + "-" + item.PERIOD_ETIME, pattern))
                {
                    msg += string.Format("第{0}个时间段格式设置不正确\r\n", i);
                    flag = false;
                }

                //时间间隔验证
                DateTime stime, etime;
                int n;
                stime = DateTime.Parse(item.PERIOD_STIME);
                etime = DateTime.Parse(item.PERIOD_ETIME);

                if (!int.TryParse((stime - etime).TotalHours + "", out n))
                {
                    msg += string.Format("第{0}个时间段设置有误,间隔为非整数\r\n", i);
                    flag = false;
                }
            }
            if (!flag)
            {
                errMsg = msg;
                return false;
            }
            errMsg = "验证通过";
            return true;
        }

        /// <summary>
        /// 核对该时间段是否已存在配置
        /// </summary>
        /// <returns></returns>
        private bool CheckDate(DateTime? begin, DateTime? end, string configId, decimal type)
        {
            string where = "";
            if (string.IsNullOrEmpty(configId))
            {
                where = "((APT_CONFIG_SDATE<=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_EDATE>=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss')) or (APT_CONFIG_SDATE>=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_SDATE<=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss')) or (APT_CONFIG_EDATE>=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_EDATE<=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss'))) and APT_TYPE=" + type + " and CREATE_ORG_NO='" + AbpSession.ORG_NO + "'";
            }
            else
            {
                where = "((APT_CONFIG_SDATE<=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_EDATE>=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss')) or (APT_CONFIG_SDATE>=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_SDATE<=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss')) or (APT_CONFIG_EDATE>=TO_DATE('" + begin + "','yyyy-MM-dd hh24:mi:ss') and APT_CONFIG_EDATE<=TO_DATE('" + end + "','yyyy-MM-dd hh24:mi:ss'))) and APT_TYPE=" + type + " and CREATE_ORG_NO='" + AbpSession.ORG_NO + "' and APT_CONFIG_ID!='" + configId + "'";
            }

            var list = _crmAptConfigMstrRepository.GetAptConfigList(where);
            return list != null && list.Count > 0 ? false : true;
        }

        /// <summary>
        /// 删除预约配置
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteCrmAptConfig(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                throw new Exception("id不允许为空");
            }

            string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                var entity = _crmAptConfigMstrRepository.Get(arr[i]);
                _crmAptConfigMstrRepository.Delete(entity);
            }
        }

        /// <summary>
        /// 验证时间段是否配置
        /// </summary>
        /// <param name="apt_type"></param>
        /// <returns></returns>
        public IList<AptTimeperiodConfig> VerifyPeriodIsConfig(int apt_type)
        {
            var list = _aptTimeperiodConfigRepository.GetAllList(m => m.BG_NO == AbpSession.BG_NO && m.APT_TYPE == apt_type);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return (from item in list orderby item.SORT_NO select item).ToList<AptTimeperiodConfig>();
        }
    }

    public class PeriodModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int SORT_NO { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string PERIOD_STIME { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string PERIOD_ETIME { get; set; }
        /// <summary>
        /// 最大人数
        /// </summary>
        public int MaxNum { get; set; }
        /// <summary>
        /// 预约类型
        /// </summary>
        public int? DIS_TYPE { get; set; }
        /// <summary>
        /// 折扣额度
        /// </summary>
        public decimal? DISCOUNT { get; set; }
    }
}
