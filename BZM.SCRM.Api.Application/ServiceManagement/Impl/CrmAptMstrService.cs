
using BZM.SCRM.Application;
using BZM.SCRM.Domain;
using BZM.SCRM.Domain.Common.Util;
using Microsoft.Extensions.Configuration;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmAptMstrService : SCRMAppServiceBase, ICrmAptMstrService
    {
        /// <summary>
        /// 当前会话
        /// </summary>
        public new IAbpSessionExtensions AbpSession { get; set; }

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmAptMstrRepository _crmAptMstrRepository;
        private readonly ISysUsrWctRepository _sysUsrWctRepository;
        private readonly IWctPaMstrRepository _wctPaMstrRepository;
        private readonly ICrmQpaperQuRepository _crmQpaperQuRepository;
        private readonly WxHelper _wxHelper;

        public IConfiguration _configuration { get; }

        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmAptMstrService(ICrmAptMstrRepository crmAptMstrRepository, ISysUsrWctRepository sysUsrWctRepository, IWctPaMstrRepository wctPaMstrRepository, IConfiguration configuration, ICrmQpaperQuRepository crmQpaperQuRepository, WxHelper wxHelper)
        {
            _crmAptMstrRepository = crmAptMstrRepository;
            _sysUsrWctRepository = sysUsrWctRepository;
            _wctPaMstrRepository = wctPaMstrRepository;
            _configuration = configuration;
            _crmQpaperQuRepository = crmQpaperQuRepository;
            _wxHelper = wxHelper;
        }

        /// <summary>
        /// 更新预约单状态为已完成并推送服务评价
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CrmAptMstr UpdateStatusToComplete(string id)
        {
            var msg = "";
            var aptInfo = _crmAptMstrRepository.Get(id);
            var evaluation = _crmQpaperQuRepository.GetAllList(m => m.PAPER_TYPE == 3);
            if (evaluation != null)
            {
                //var isOK = ServiceEvaluationToCustomer(aptInfo.OPENID, aptInfo.CUS_NO, aptInfo.APT_BU_NO, aptInfo.BG_NO, "", "", aptInfo.APT_CLASS, ref msg);

                aptInfo.APT_STATUS = "已完成";
                aptInfo.SERVICE_DESK = AbpSession.USR_NAME;
                aptInfo.UPDATE_DATE = DateTime.Now;
                aptInfo.UPDATE_PSN = AbpSession.USR_ID;

                _crmAptMstrRepository.Update(aptInfo);
            }
            return null;
        }

        /// <summary>
        /// 预约完成推送服务评价
        /// </summary>
        /// <returns></returns>
        private bool ServiceEvaluationToCustomer(string openId, string cusNo, string orgNo, string bgNo, string buName, string operationPsn, string project, ref string msg)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// 根据机构编码获取token
        /// </summary>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="tId"></param>
        /// <returns></returns>
        private bool GetWxConfigByOrgNo(string orgNo, string bgNo, ref string appId, ref string appSecret, ref string tId)
        {
            try
            {
                var list = _wctPaMstrRepository.GetAllList(m => m.PA_ID_NO == orgNo && m.PA_TYPE_ID == 1);
                if (list.Count == 0)
                {
                    list = _wctPaMstrRepository.GetAllList(m => m.PA_ID_NO == bgNo && m.PA_TYPE_ID == 1);
                }
                appSecret = list.Count > 0 ? list[0].PA_APPSECRET : "";
                appId = list.Count > 0 ? list[0].PA_APPID : "";
                tId = list.Count > 0 ? list[0].UDF8 : "";//续保模版id
                return list.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
