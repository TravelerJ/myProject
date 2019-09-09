
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 救援服务
    /// </summary>
    public class WctHelpTelMstrService : SCRMAppServiceBase, IWctHelpTelMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IWctHelpTelMstrRepository _wctHelpTelMstrRepository;

        private InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctHelpTelMstrService(IWctHelpTelMstrRepository wctHelpTelMstrRepository, InitHelper initHelper)
        {
            _wctHelpTelMstrRepository = wctHelpTelMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 编辑/新增救援信息
        /// </summary>
        /// <param name="helpDto"></param>
        /// <returns></returns>
        public WctHelpTelMstr SaveHelpTelInfo(WctHelpTelMstrDto helpDto)
        {
            try
            {
                WctHelpTelMstr mstr = null;
                if (string.IsNullOrEmpty(helpDto.Id))
                {
                    #region 参数验证
                    if (string.IsNullOrEmpty(helpDto.TEL_NAME))
                    {
                        throw new Exception("号码归属不能为空");
                    }
                    if (string.IsNullOrEmpty(helpDto.TEL_NO))
                    {
                        throw new Exception("电话号码不能为空");
                    }
                    if (string.IsNullOrEmpty(helpDto.TEL_TYPE))
                    {
                        throw new Exception("电话类型不能为空");
                    }
                    #endregion

                    //新增
                    helpDto.Id = Guid.NewGuid().ToString("N");
                    helpDto.TEL_ID_NO = AbpSession.ORG_NO;
                    _initHelper.InitAdd<WctHelpTelMstrDto>(helpDto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);

                    mstr = _wctHelpTelMstrRepository.Insert(helpDto.ToEntity());
                }
                else
                {
                    //修改
                    _initHelper.InitUpdate<WctHelpTelMstrDto>(helpDto, AbpSession.USR_ID);
                    mstr = _wctHelpTelMstrRepository.Update(helpDto.ToEntity());
                }
                return mstr;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 删除救援信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DelHelpTelInfo(string ids)
        {
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    var arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in arr)
                    {
                        var entity = _wctHelpTelMstrRepository.Get(item);
                        _wctHelpTelMstrRepository.Delete(entity);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
