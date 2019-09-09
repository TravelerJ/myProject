
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

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 机构服务
    /// </summary>
    public class MdmBuMstrService : SCRMAppServiceBase, IMdmBuMstrService {
    
        /// <summary>
        /// 机构仓储
        /// </summary>
        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public MdmBuMstrService( IMdmBuMstrRepository mdmBuMstrRepository,
            InitHelper initHelper) {
            _mdmBuMstrRepository = mdmBuMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存机构信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveMdmBuInfo(MdmBuMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new MdmBuMstr();
            var isOk = CheckMdmBuInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.BU_NO))
            {
                dto.BG_NO= dto.BU_TYPE == 1 ? dto.Id : dto.BG_NO;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _mdmBuMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _mdmBuMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验机构信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckMdmBuInfo(MdmBuMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.Id))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入机构编码";
                return rm;
            }

            if (string.IsNullOrEmpty(dto.BU_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入机构名称";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.BU_SHORT_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入机构简称";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.BU_REGISTERED_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择注册名";
                return rm;
            }
            if (dto.BU_TYPE == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择商家类型";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.BU_PHONE) && dto.BU_TYPE != 2)
            {
                rm.IsSuccess = false;
                rm.msg = "请输入联系电话";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.USR_QRCODE_PATH))
            {
                rm.IsSuccess = false;
                rm.msg = "请上传机构logo";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除机构信息
        /// </summary>
        /// <param name="buNos"></param>
        /// <returns></returns>
        public ReturnMsg DelBuInfo(string buNos)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(buNos))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的机构信息";
                return rm;
            }
            var sqlStr = "'" + buNos.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _mdmBuMstrRepository.BatchDelBuInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
