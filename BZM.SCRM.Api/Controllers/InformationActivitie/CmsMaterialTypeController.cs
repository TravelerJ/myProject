
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.InformationActivitie.Contracts;
using SCRM.Application.InformationActivitie.Dtos;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.InformationActivitie
{
    /// <summary>
    /// 素材类型控制器
    /// </summary>
    [ApiVersion("1.3")]
    [Route("v{version:apiVersion}")]
    public class CmsMaterialTypeController :SCRMControllerBase  {
        
        /// <summary>
        /// 素材类型服务
        /// </summary>
        private readonly ICmsMaterialTypeService _cmsMaterialTypeService;
        /// <summary>
        /// 素材类型仓储
        /// </summary>
        private readonly ICmsMaterialTypeRepository _cmsMaterialTypeRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="cmsMaterialTypeService">素材类型服务</param>
        /// <param name="cmsMaterialTypeRepository">素材类型仓储</param>
        /// </summary>
        public CmsMaterialTypeController( ICmsMaterialTypeService cmsMaterialTypeService,
           ICmsMaterialTypeRepository cmsMaterialTypeRepository) {
            _cmsMaterialTypeService = cmsMaterialTypeService;
            _cmsMaterialTypeRepository = cmsMaterialTypeRepository;
        }

        /// <summary>
        /// 获取素材类型分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CmsMaterialType/GetMaterialTypePageList"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialTypePageList(CmsMaterialTypeQuery query)
        {
            try
            {
                var result = _cmsMaterialTypeRepository.GetMaterialTypePageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取素材类型列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CmsMaterialType/GetMaterialTypeList"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialTypeList(CmsMaterialTypeQuery query)
        {
            try
            {
                var result = _cmsMaterialTypeRepository.GetMaterialTypeList(query);
                return Success("获取成功",result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取素材类型详情
        /// </summary>
        /// <param name="materialTypeId">主键</param>
        /// <returns></returns>
        [HttpGet("CmsMaterialType/GetMaterialTypeInfo"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialTypeInfo(string materialTypeId)
        {
            try
            {
                if (string.IsNullOrEmpty(materialTypeId))
                    return Fail("数据传输异常");
                var result = _cmsMaterialTypeRepository.FirstOrDefault(c => c.Id == materialTypeId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存素材类型信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CmsMaterialType/SaveMaterialTypeInfo"), MapToApiVersion("1.3")]
        public ActionResult SaveMaterialTypeInfo([FromBody]CmsMaterialTypeDto dto)
        {
            try
            {
                var result = _cmsMaterialTypeService.SaveMaterialTypeInfo(dto);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("保存成功");
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除素材类型信息
        /// </summary>
        /// <param name="materialTypeIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("CmsMaterialType/DelMaterialTypeInfo"), MapToApiVersion("1.3")]
        public ActionResult DelMaterialTypeInfo(string materialTypeIds)
        {
            try
            {
                var result = _cmsMaterialTypeService.BatchDelMaterialTypeInfo(materialTypeIds);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
