
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using System;
using System.Collections.Generic;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmQpaperQuService : SCRMAppServiceBase, ICrmQpaperQuService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmQpaperQuRepository _crmQpaperQuRepository;

        private InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmQpaperQuService(ICrmQpaperQuRepository crmQpaperQuRepository, InitHelper initHelper)
        {
            _crmQpaperQuRepository = crmQpaperQuRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 编辑/新增题目
        /// </summary>
        /// <param name="crmQpaperQuDto"></param>
        /// <returns></returns>
        public CrmQpaperQu SaveQpaperQuInfo(CrmQpaperQuDto crmQpaperQuDto, ref string msg)
        {
            try
            {
                CrmQpaperQu qu = null;
                if (CheckQuestion(crmQpaperQuDto.Id, crmQpaperQuDto.QU_NAME, crmQpaperQuDto.QU_SN, AbpSession.BG_NO, ref msg))
                {
                    if (string.IsNullOrEmpty(crmQpaperQuDto.Id))
                    {
                        //新增
                        crmQpaperQuDto.Id = Guid.NewGuid().ToString("N");
                        _initHelper.InitAdd(crmQpaperQuDto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                        qu = _crmQpaperQuRepository.Insert(crmQpaperQuDto.ToEntity());
                    }
                    else
                    {
                        //修改
                        _initHelper.InitUpdate(crmQpaperQuDto, AbpSession.USR_ID);
                        qu = _crmQpaperQuRepository.Update(crmQpaperQuDto.ToEntity());
                    }
                }

                return qu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool CheckQuestion(string QuId, string QueName, decimal? QU_SN, string bgNo, ref string msg)
        {
            List<CrmQpaperQu> result;
            if (string.IsNullOrEmpty(QuId))
            {
                result = _crmQpaperQuRepository.GetAllList(m => m.QU_SN == QU_SN && m.DEL_FLAG == 1 && m.BG_NO == bgNo);
            }
            else
            {
                result = _crmQpaperQuRepository.GetAllList(m => m.Id != QuId && m.QU_SN == QU_SN && m.DEL_FLAG == 1 && m.BG_NO == bgNo);
            }
            if (result != null && result.Count > 0)
            {
                msg = "该题号已存在";
                return false;
            }

            if (string.IsNullOrEmpty(QuId))
            {
                result = _crmQpaperQuRepository.GetAllList(m => m.QU_NAME == QueName && m.DEL_FLAG == 1 && m.BG_NO == bgNo);
            }
            else
            {
                result = _crmQpaperQuRepository.GetAllList(m => m.Id != QuId && m.QU_NAME == QueName && m.DEL_FLAG == 1 && m.BG_NO == bgNo);
            }
            if (result != null && result.Count > 0)
            {
                msg = "该题目名称已存在";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="ids"></param>
        public void DelQpaperQuInfo(string ids)
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
                    var entity = _crmQpaperQuRepository.Get(arr[i]);
                    _crmQpaperQuRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
