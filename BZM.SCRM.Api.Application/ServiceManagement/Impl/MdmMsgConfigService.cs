
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Util;
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
    public class MdmMsgConfigService : SCRMAppServiceBase, IMdmMsgConfigService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmMsgConfigRepository _mdmMsgConfigRepository;

        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmMsgConfigService(IMdmMsgConfigRepository mdmMsgConfigRepository, InitHelper initHelper)
        {
            _mdmMsgConfigRepository = mdmMsgConfigRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 获取已选消息配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<MdmMsgConfig>> GetSectedMsgConfig()
        {
            var basConfig = new WxHelper().GetBasConfig(AbpSession.BG_NO);
            if (basConfig == null)
            {
                throw new Exception("请维护集团基础配置");
            }
            string buNo = basConfig.IS_APT_GROUP == 1 ? AbpSession.BG_NO : AbpSession.ORG_NO;
            var list = _mdmMsgConfigRepository.GetAllList(m => m.BU_NO == buNo);
            if (list == null || list.Count == 0)
            {
                throw new Exception("暂无消息提醒");
            }

            var lookup = list.ToLookup(m => m.APT_TYPE);

            Dictionary<string, IEnumerable<MdmMsgConfig>> dic = new Dictionary<string, IEnumerable<MdmMsgConfig>>();
            foreach (var item in lookup)
            {
                string n = item.Key + "";
                dic.Add(n, item.AsEnumerable());
            }
            return dic;
        }

        /// <summary>
        /// 保存消息配置
        /// </summary>
        /// <param name="msgList"></param>
        public bool SaveMsgConfig(List<MdmMsgConfigDto> msgList)
        {
            bool flag = false;
            #region 基础验证
            if (msgList?.Count == null || msgList.Count == 0)
            {
                throw new ArgumentNullException("未选择任何提醒事项");
            }

            var basConfig = new WxHelper().GetBasConfig(AbpSession.BG_NO);
            if (basConfig == null)
            {
                throw new ArgumentNullException("未配置集团基础信息");
            }

            if (basConfig.IS_APT_REMIND != 1)
            {
                throw new ArgumentNullException("该集团未设置消息提醒");
            }
            #endregion

            string buNo = basConfig.IS_APT_GROUP == 1 ? AbpSession.BG_NO : AbpSession.ORG_NO;
            //删除门店已保存的配置
            var list = _mdmMsgConfigRepository.GetAllList(m => m.BU_NO == buNo);
            foreach (var item in list)
            {
                _mdmMsgConfigRepository.Delete(item);
            }

            foreach (var item in msgList)
            {
                flag = SaveConfig(item);
                if (!flag)
                {
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// 保存提醒事项
        /// </summary>
        /// <returns></returns>
        private bool SaveConfig(MdmMsgConfigDto info)
        {
            try
            {
                MdmMsgConfigDto model = new MdmMsgConfigDto();
                _initHelper.InitAdd(model, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                model.Id = Guid.NewGuid().ToString("N");
                model.APT_TYPE = info.APT_TYPE;
                model.MSG_REMIND_TYPE = 1;
                model.REMIND_EVENT_TYPE = info.REMIND_EVENT_TYPE;
                model.REMIND_MODE = info.REMIND_MODE;
                switch (info.REMIND_MODE)
                {
                    case 1:
                        break;
                    case 2:
                        model.APT_REMIND_DATE = info.APT_REMIND_DATE;
                        break;
                    case 3:
                        model.APT_REMIND_TIME = info.APT_REMIND_TIME;
                        break;
                    default:
                        break;
                }
                return _mdmMsgConfigRepository.Insert(model.ToEntity()) != null ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
