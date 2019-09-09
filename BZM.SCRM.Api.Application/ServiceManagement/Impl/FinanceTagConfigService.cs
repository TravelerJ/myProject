
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
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
    public class FinanceTagConfigService : SCRMAppServiceBase, IFinanceTagConfigService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IFinanceTagConfigRepository _financeTagConfigRepository;

        private readonly ICarFinancePolicyRepository _carFinancePolicyRepository;

        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public FinanceTagConfigService(IFinanceTagConfigRepository financeTagConfigRepository, ICarFinancePolicyRepository carFinancePolicyRepository, InitHelper initHelper)
        {
            _financeTagConfigRepository = financeTagConfigRepository;
            _carFinancePolicyRepository = carFinancePolicyRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 获取门店配置标签
        /// </summary>
        /// <returns></returns>
        public List<FinanceTagConfig> GetFinTagList()
        {
            var list = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO && m.DEL_FLAG==1);
            var result = (from item in list orderby item.SORT_NO ascending select item).ToList();
            return result;
        }

        /// <summary>
        /// 保存金融标签
        /// </summary>
        /// <param name="dto"></param>
        public void SaveTag(FinanceTagConfigDto dto)
        {
            if (CheckTag(dto.TAG_NAME, dto.SORT_NO))
            {
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                dto.Id = Guid.NewGuid().ToString("N");
                _financeTagConfigRepository.Insert(dto.ToEntity());
            }
        }

        private bool CheckTag(string tagName, long sortNo)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                throw new Exception("标签名称不允许为空 !");
            }

            var list = _financeTagConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO && m.DEL_FLAG==1);
            if (list == null || list.Count == 0)
            {
                return true;
            }

            int count = list.FindAll(m => m.SORT_NO == sortNo).Count;
            if (count > 0)
            {
                throw new Exception("序号不允许重复!");
            }

            if (list.Count >= 10)
            {
                throw new Exception("已达到最大标签条数限制!");
            }

            if (list.ToList().Exists(m => m.TAG_NAME == tagName))
            {
                throw new Exception("该门店已存在该标签,请检查后重试！");
            }
            return true;
        }
        
        /// <summary>
        /// 删除金融标签
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTag(string id)
        {
            var entity = _financeTagConfigRepository.Get(id);
            if (entity == null)
            {
                throw new Exception("id参数有误");
            }

            //删除前判断标签是否正在使用
            var list = _carFinancePolicyRepository.GetAllList(m => m.TAG_IDS.Contains(id));
            if (list?.Count > 0)
            {
                throw new Exception("该标签正在使用,不允许删除");
            }
            _financeTagConfigRepository.Delete(id);
        }
    }
}
