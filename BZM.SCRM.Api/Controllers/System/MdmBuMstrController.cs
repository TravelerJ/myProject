
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
    /// 机构控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class MdmBuMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 机构服务
        /// </summary>
        private readonly IMdmBuMstrService _mdmBuMstrService;
        /// <summary>
        /// 机构仓储
        /// </summary>
        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmBuMstrService">机构服务</param>
        /// <param name="mdmBuMstrRepository">机构仓储</param>
        /// </summary>
        public MdmBuMstrController( IMdmBuMstrService mdmBuMstrService,
            IMdmBuMstrRepository mdmBuMstrRepository) {
            _mdmBuMstrService = mdmBuMstrService;
            _mdmBuMstrRepository = mdmBuMstrRepository;
        }


        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmBuMstr/GetMdmBuMstrList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmBuMstrList(MdmBuMstrQuery query)
        {
            try
            {
                var result = _mdmBuMstrRepository.GetMdmBuMstrList(query);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmBuMstr/GetMdmBuMstrPageList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmBuMstrPageList(MdmBuMstrQuery query)
        {
            try
            {
                var result = _mdmBuMstrRepository.GetMdmBuMstrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构详情
        /// </summary>
        /// <param name="buNo">机构编码</param>
        /// <returns></returns>
        [HttpGet("MdmBuMstr/GetMdmBuInfo"), MapToApiVersion("1.0")]
        public ActionResult GetMdmBuInfo(string buNo)
        {
            try
            {
                if (string.IsNullOrEmpty(buNo))
                    return Fail("数据传输异常");
                var result = _mdmBuMstrRepository.FirstOrDefault(c => c.Id == buNo && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存机构信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("MdmBuMstr/SaveMdmBuInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveMdmBuInfo([FromBody]MdmBuMstrDto dto)
        {
            try
            {
                var result = _mdmBuMstrService.SaveMdmBuInfo(dto);
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
        /// 删除机构信息
        /// </summary>
        /// <param name="buNos">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("MdmBuMstr/DelBuInfo"), MapToApiVersion("1.0")]
        public ActionResult DelBuInfo(string buNos)
        {
            try
            {
                var result = _mdmBuMstrService.DelBuInfo(buNos);
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
