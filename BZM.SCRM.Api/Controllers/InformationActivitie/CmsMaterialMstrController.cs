
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
    /// 素材控制器
    /// </summary>
    [ApiVersion("1.3")]
    [Route("v{version:apiVersion}")]
    public class CmsMaterialMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 素材服务
        /// </summary>
        private readonly ICmsMaterialMstrService _cmsMaterialMstrService;
        /// <summary>
        /// 素材仓储
        /// </summary>
        private readonly ICmsMaterialMstrRepository _cmsMaterialMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="cmsMaterialMstrService">素材服务</param>
        /// <param name="cmsMaterialMstrRepository">素材仓储</param>
        /// </summary>
        public CmsMaterialMstrController( ICmsMaterialMstrService cmsMaterialMstrService,
            ICmsMaterialMstrRepository cmsMaterialMstrRepository) {
            _cmsMaterialMstrService = cmsMaterialMstrService;
            _cmsMaterialMstrRepository = cmsMaterialMstrRepository;
        }

        /// <summary>
        /// 获取素材分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/GetMaterialMstrPageList"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialMstrPageList(CmsMaterialMstrQuery query)
        {
            try
            {
                var result = _cmsMaterialMstrRepository.GetMaterialMstrPageList(query);
                return Page(result.Data,result.Page);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取素材详情
        /// </summary>
        /// <param name="materialId">主键</param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/GetMaterialMstrInfo"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialMstrInfo(string materialId)
        {
            try
            {
                if (string.IsNullOrEmpty(materialId))
                    return Fail("数据传输异常");
                var result = _cmsMaterialMstrRepository.FirstOrDefault(c => c.Id == materialId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }
        /// <summary>
        /// 保存素材信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/SaveMaterialInfo"),MapToApiVersion("1.3")]
        public ActionResult SaveMaterialInfo([FromBody]CmsMaterialMstrDto dto)
        {
            try
            {
                var result = _cmsMaterialMstrService.SaveMaterialInfo(dto);
                return Success("保存成功");
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除素材信息
        /// </summary>
        /// <param name="materialIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/DelMaterialInfo"), MapToApiVersion("1.3")]
        public ActionResult DelMaterialInfo(string materialIds)
        {
            try
            {
                var result = _cmsMaterialMstrService.BatchDelMaterialInfo(materialIds);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取资讯的评论未读信息数列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/GetMaterialCommentPageList"), MapToApiVersion("1.3")]
        public ActionResult GetMaterialCommentPageList(CmsMaterialMstrQuery query)
        {
            try
            {
                var result = _cmsMaterialMstrRepository.GetMaterialCommentPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更改资讯状态/轮播
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("MaterialMstr/UpdateMaterialInfoStatus"), MapToApiVersion("1.3")]
        public ActionResult UpdateMaterialInfoStatus([FromBody]CmsMaterialMstrQuery query)
        {
            try
            {
                var result = _cmsMaterialMstrService.UpdateMaterialInfoStatus(query);
                if(!result.IsSuccess)
                    return Fail(result.msg);
                return Success("操作成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
