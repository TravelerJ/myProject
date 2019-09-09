
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 职务控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class MdmDutyMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 职务服务
        /// </summary>
        private readonly IMdmDutyMstrService _mdmDutyMstrService;
        /// <summary>
        /// 职务仓储
        /// </summary>
        private readonly IMdmDutyMstrRepository _mdmDutyMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmDutyMstrService">职务服务</param>
        /// <param name="mdmDutyMstrRepository">职务仓储</param>
        /// </summary>
        public MdmDutyMstrController( IMdmDutyMstrService mdmDutyMstrService,
            IMdmDutyMstrRepository mdmDutyMstrRepository) {
            _mdmDutyMstrService = mdmDutyMstrService;
            _mdmDutyMstrRepository = mdmDutyMstrRepository;
        }

        /// <summary>
        /// 获取职务分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("MdmDutyMstr/GetMdmDutyPageList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDutyPageList(MdmDutyMstrQuery query)
        {
            try
            {
                var result = _mdmDutyMstrRepository.GetMdmDutyPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取职务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmDutyMstr/GetMdmDutyList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDutyList()
        {
            try
            {
                var result = _mdmDutyMstrRepository.GetMdmDutyList();
                return Success("获取成功",result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取职务详情
        /// </summary>
        /// <param name="dutyId">职务id</param>
        /// <returns></returns>
        [HttpGet("MdmDutyMstr/GetMdmDutyInfo"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDutyInfo(decimal dutyId)
        {
            try
            {
                if (dutyId==0)
                    return Fail("数据传输异常");
                var result = _mdmDutyMstrRepository.FirstOrDefault(c => c.Id == dutyId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存职务信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("MdmDutyMstr/SaveMdmDutyInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveMdmDutyInfo([FromBody]MdmDutyMstrDto dto)
        {
            try
            {
                var result = _mdmDutyMstrService.SaveMdmDutyInfo(dto);
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
        /// 删除职务信息
        /// </summary>
        /// <param name="dutyIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("MdmDutyMstr/DelMdmDutyInfo"), MapToApiVersion("1.0")]
        public ActionResult DelMdmDutyInfo(string dutyIds)
        {
            try
            {
                var result = _mdmDutyMstrService.DelMdmDutyInfo(dutyIds);
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
