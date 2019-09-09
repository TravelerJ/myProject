
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System;
using System.Linq;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 系统模块服务
    /// </summary>
    public class WctSysmoduleMstrService : SCRMAppServiceBase, IWctSysmoduleMstrService {
    
        /// <summary>
        /// 系统模块仓储
        /// </summary>
        private readonly IWctSysmoduleMstrRepository _wctSysmoduleMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctSysmoduleMstrService( IWctSysmoduleMstrRepository wctSysmoduleMstrRepository,
            InitHelper initHelper) {
            _wctSysmoduleMstrRepository = wctSysmoduleMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 校验公众号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckSysMoudleInfo(WctSysmoduleMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.SYSM_KEY))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入模块唯一标识";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.SYSM_TITLE))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入模块标题";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.SYSM_URL_TEMPLATE))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入模块页面地址";
                return rm;
            }
            var result = string.IsNullOrEmpty(dto.Id) ? _wctSysmoduleMstrRepository.GetAllList(c => c.SYSM_KEY == dto.SYSM_KEY&&c.DEL_FLAG==1 && c.BG_NO == AbpSession.BG_NO)
                : _wctSysmoduleMstrRepository.GetAllList(c => c.SYSM_KEY == dto.SYSM_KEY && c.Id != dto.Id & c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "页面唯一标识已存在,请重新输入";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 保存系统模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveSysMoudleInfo(WctSysmoduleMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new WctSysmoduleMstr();
            var isOk = CheckSysMoudleInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                _initHelper.InitAdd(dto, AbpSession.USR_ID,AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _wctSysmoduleMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _wctSysmoduleMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除系统模块信息
        /// </summary>
        /// <param name="sysMoudleIds"></param>
        /// <returns></returns>
        public ReturnMsg DelSysMoudleInfo(string sysMoudleIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(sysMoudleIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的模块信息";
                return rm;
            }
            var sqlStr = "'" + sysMoudleIds.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _wctSysmoduleMstrRepository.BatchDelSysMoudleInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
