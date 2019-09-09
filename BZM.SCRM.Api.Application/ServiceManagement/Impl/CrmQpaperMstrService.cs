
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
    public class CrmQpaperMstrService : SCRMAppServiceBase, ICrmQpaperMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmQpaperMstrRepository _crmQpaperMstrRepository;

        private readonly ICrmQpaperQuRepository _crmQpaperQuRepository;

        private InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmQpaperMstrService(ICrmQpaperMstrRepository crmQpaperMstrRepository, ICrmQpaperQuRepository crmQpaperQuRepository, InitHelper initHelper)
        {
            _crmQpaperMstrRepository = crmQpaperMstrRepository;
            _crmQpaperQuRepository = crmQpaperQuRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 创建套卷
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public CrmQpaperMstr CreateQpaper(CrmQpaperMstrDto dto)
        {
            try
            {
                if (CheckPaperName(dto.Id, dto.PAPER_NAME, dto.PAPER_TYPE, AbpSession.ORG_NO))
                {
                    var strList = dto.INCLUDE_QUESTION_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var list = _crmQpaperQuRepository.GetAllList(c => c.DEL_FLAG == 1).Where(c => strList.Contains(c.Id)).ToList();
                    //将选择的题目设置为启用
                    foreach (var item in list)
                    {
                        item.QU_ENABLED = 1;
                        _crmQpaperQuRepository.Update(item);
                    }

                    if (string.IsNullOrEmpty(dto.Id))
                    {
                        dto.Id = Guid.NewGuid().ToString("N");
                        _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                        return _crmQpaperMstrRepository.Insert(dto.ToEntity());
                    }
                    else
                    {
                        _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                        return _crmQpaperMstrRepository.Update(dto.ToEntity());
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckPaperName(string paperId, string paperName, decimal? paperType, string orgNo)
        {
            List<CrmQpaperMstr> list = null;
            if (string.IsNullOrEmpty(paperName))
            {
                list = _crmQpaperMstrRepository.GetAllList(m => m.PAPER_NAME == paperName && m.PAPER_TYPE == paperType && m.DEL_FLAG == 1 && m.CREATE_ORG_NO == orgNo);
            }
            else
            {
                list = _crmQpaperMstrRepository.GetAllList(m => m.Id != paperId && m.PAPER_NAME == paperName && m.PAPER_TYPE == paperType && m.DEL_FLAG == 1 && m.CREATE_ORG_NO == orgNo);
            }

            return list == null || list?.Count == 0 ? true : false;
        }

        /// <summary>
        /// 启用/禁用套卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CrmQpaperMstr EnableQpaper(string id)
        {
            CrmQpaperMstr mstr = null;
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("id参数为空");
                }
                var entity = _crmQpaperMstrRepository.Get(id);
                switch (entity.PAPER_STATUS)
                {
                    case 0:
                        entity.PAPER_STATUS = 1;
                        break;
                    case 1:
                        entity.PAPER_STATUS = 0;
                        break;
                    default:
                        break;
                }
                entity.UPDATE_DATE = DateTime.Now;
                entity.UPDATE_PSN = AbpSession.USR_ID;

                mstr = _crmQpaperMstrRepository.Update(entity);
                return mstr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除套卷
        /// </summary>
        /// <param name="ids"></param>
        public void DelQpaper(string ids)
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
                    var entity = _crmQpaperMstrRepository.Get(arr[i]);
                    _crmQpaperMstrRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取套卷的题目信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<CrmQpaperQuDto> GetQuList(string ids)
        {
            List<CrmQpaperQuDto> list = new List<CrmQpaperQuDto>();
            if (!string.IsNullOrEmpty(ids))
            {
                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    string id = arr[i].ToString();
                    var dto = _crmQpaperQuRepository.FirstOrDefault(m => m.Id == id).ToDto();
                    if (!string.IsNullOrEmpty(dto.Id))
                    {
                        list.Add(dto);
                    }
                }
                return list;
            }
            return null;
        }
    }
}
