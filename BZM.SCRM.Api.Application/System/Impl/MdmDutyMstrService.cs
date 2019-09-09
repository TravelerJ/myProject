
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.MdmDutyMstrs {
    /// <summary>
    /// 职务服务
    /// </summary>
    public class MdmDutyMstrService : SCRMAppServiceBase, IMdmDutyMstrService {
    
        /// <summary>
        /// 职务仓储
        /// </summary>
        private readonly IMdmDutyMstrRepository _mdmDutyMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmDutyMstrService( IMdmDutyMstrRepository mdmDutyMstrRepository,
            InitHelper initHelper) {
            _mdmDutyMstrRepository = mdmDutyMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存职务信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveMdmDutyInfo(MdmDutyMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new MdmDutyMstr();
            var isOk = CheckMdmDutyInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (dto.Id==0)
            {
                dto.ORG_NO = AbpSession.ORG_NO;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _mdmDutyMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _mdmDutyMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验职务信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckMdmDutyInfo(MdmDutyMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.DUTY_NO))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入职务编号";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.DUTY_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入职务名称";
                return rm;
            }
            var result = new List<MdmDutyMstr>();
            result = dto.Id == 0 ? _mdmDutyMstrRepository.GetAllList(c => c.DUTY_NO == dto.DUTY_NO&& c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO)
                : _mdmDutyMstrRepository.GetAllList(c => c.DUTY_NO == dto.DUTY_NO && c.Id != dto.Id & c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "职务编号已存在,请重新输入";
                return rm;
            }
            result = dto.Id == 0 ? _mdmDutyMstrRepository.GetAllList(c => c.DUTY_NAME == dto.DUTY_NAME && c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO)
                : _mdmDutyMstrRepository.GetAllList(c => c.DUTY_NAME == dto.DUTY_NAME && c.Id != dto.Id & c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "职务名称已存在,请重新输入";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除职务信息
        /// </summary>
        /// <param name="dutyIds"></param>
        /// <returns></returns>
        public ReturnMsg DelMdmDutyInfo(string dutyIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(dutyIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的职务信息";
                return rm;
            }
            _mdmDutyMstrRepository.BatchDelMdmDutyInfo(dutyIds);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
