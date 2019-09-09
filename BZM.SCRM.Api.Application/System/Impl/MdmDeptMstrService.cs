
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System.Collections.Generic;

namespace SCRM.Application.MdmDeptMstrs {
    /// <summary>
    /// 部门服务
    /// </summary>
    public class MdmDeptMstrService : SCRMAppServiceBase, IMdmDeptMstrService {
    
        /// <summary>
        /// 部门仓储
        /// </summary>
        private readonly IMdmDeptMstrRepository _mdmDeptMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmDeptMstrService( IMdmDeptMstrRepository mdmDeptMstrRepository,
            InitHelper initHelper) {
            _mdmDeptMstrRepository = mdmDeptMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveMdmDeptInfo(MdmDeptMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new MdmDeptMstr();
            var isOk = CheckMdmDeptInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (dto.Id == 0)
            {
                dto.ORG_NO = AbpSession.ORG_NO;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _mdmDeptMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _mdmDeptMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckMdmDeptInfo(MdmDeptMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.DEPT_NO))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入部门编号";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.DEPT_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入部门名称";
                return rm;
            }
            var result = new List<MdmDeptMstr>();
            result = dto.Id==0 ? _mdmDeptMstrRepository.GetAllList(c => c.DEPT_NO == dto.DEPT_NO && c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO)
                : _mdmDeptMstrRepository.GetAllList(c => c.DEPT_NO == dto.DEPT_NO && c.Id != dto.Id & c.DEL_FLAG == 1 && c.BG_NO == AbpSession.BG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "部门编号已存在,请重新输入";
                return rm;
            }
            result = dto.Id == 0 ? _mdmDeptMstrRepository.GetAllList(c => c.DEPT_NAME == dto.DEPT_NAME && c.DEL_FLAG == 1&&c.BG_NO==AbpSession.BG_NO)
                : _mdmDeptMstrRepository.GetAllList(c => c.DEPT_NAME == dto.DEPT_NAME && c.Id != dto.Id & c.DEL_FLAG == 1&&c.BG_NO == AbpSession.BG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "部门名称已存在,请重新输入";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除部门信息
        /// </summary>
        /// <param name="deptIds"></param>
        /// <returns></returns>
        public ReturnMsg DelMdmDeptInfo(string deptIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(deptIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的部门信息";
                return rm;
            }
            _mdmDeptMstrRepository.BatchDelMdmDeptInfo(deptIds);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
