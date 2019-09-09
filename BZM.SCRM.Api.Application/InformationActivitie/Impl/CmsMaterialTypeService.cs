
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.InformationActivitie.Contracts;
using SCRM.Application.InformationActivitie.Dtos;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.InformationActivitie.Impl
{
    /// <summary>
    /// 素材类型服务
    /// </summary>
    public class CmsMaterialTypeService : SCRMAppServiceBase, ICmsMaterialTypeService {

        /// <summary>
        /// 素材类型仓储
        /// </summary>
        private readonly ICmsMaterialTypeRepository _cmsMaterialTypeRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CmsMaterialTypeService( ICmsMaterialTypeRepository cmsMaterialTypeRepository,
           InitHelper initHelper) {
            _cmsMaterialTypeRepository = cmsMaterialTypeRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存素材类型信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveMaterialTypeInfo(CmsMaterialTypeDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new CmsMaterialType();
            var isOk = CheckMaterialTypeInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _cmsMaterialTypeRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _cmsMaterialTypeRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验素材类型信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckMaterialTypeInfo(CmsMaterialTypeDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.MATERIAL_ATTR))
            {
                rm.IsSuccess = false;
                rm.msg = "请传入素材类型用途";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.MATERIAL_TYPE_NAME) && dto.MATERIAL_ATTR != "4")
            {
                rm.IsSuccess = false;
                rm.msg = "请输入素材类型名称";
                return rm;
            }
            if (dto.MATERIAL_ATTR=="2"&&dto.MATERIAL_INFO_TYPE==null)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择资讯功能模块";
                return rm;
            }
            if (dto.MATERIAL_ATTR == "4")
            {
                dto.MATERIAL_TYPE_NAME = "Hot";
                if (dto.HOT_PURPOSE == null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择热词用途";
                    return rm;
                }
                if (string.IsNullOrEmpty(dto.HOT_CONTENT)|| string.IsNullOrEmpty(dto.HOT_CONTENT.Trim()))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请输入热词内容";
                    return rm;
                }
            }                      
            var result = new List<CmsMaterialType>();
            if (dto.MATERIAL_ATTR != "4")
            {
                result = string.IsNullOrEmpty(dto.Id) ? _cmsMaterialTypeRepository.GetAllList(c => c.MATERIAL_TYPE_NAME == dto.MATERIAL_TYPE_NAME && c.MATERIAL_ATTR == dto.MATERIAL_ATTR && c.DEL_FLAG == 1)
    : _cmsMaterialTypeRepository.GetAllList(c => c.Id != dto.Id && c.MATERIAL_TYPE_NAME == dto.MATERIAL_TYPE_NAME && c.MATERIAL_ATTR == dto.MATERIAL_ATTR && c.DEL_FLAG == 1);
                if (result.Count > 0)
                {
                    rm.IsSuccess = false;
                    rm.msg = "该分类已存在,请重新输入";
                    return rm;
                }
            }
            else
            {
                result = string.IsNullOrEmpty(dto.Id) ? _cmsMaterialTypeRepository.GetAllList(c => c.HOT_CONTENT == dto.HOT_CONTENT && c.MATERIAL_ATTR == dto.MATERIAL_ATTR && c.HOT_PURPOSE == dto.HOT_PURPOSE && c.DEL_FLAG == 1)
    : _cmsMaterialTypeRepository.GetAllList(c => c.Id != dto.Id && c.HOT_CONTENT == dto.HOT_CONTENT && c.MATERIAL_ATTR == dto.MATERIAL_ATTR && c.HOT_PURPOSE == dto.HOT_PURPOSE && c.DEL_FLAG == 1);
                if (result.Count > 0)
                {
                    rm.IsSuccess = false;
                    rm.msg = "该热词已存在,请重新输入";
                    return rm;
                }
            }

            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除素材类型信息
        /// </summary>
        /// <param name="materialTypeIds"></param>
        /// <returns></returns>
        public ReturnMsg BatchDelMaterialTypeInfo(string materialTypeIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(materialTypeIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的分类信息";
                return rm;
            }
            var sqlStr = "'" + materialTypeIds.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _cmsMaterialTypeRepository.BatchDelMaterialTypeInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
