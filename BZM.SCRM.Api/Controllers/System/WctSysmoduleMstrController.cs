
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
    /// 系统模块控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class WctSysmoduleMstrController :SCRMControllerBase  {

        /// <summary>
        /// 
        /// </summary>
        private readonly IWctSysmoduleMstrService _wctSysmoduleMstrService;
        /// <summary>
        /// 系统模块仓储
        /// </summary>
        private readonly IWctSysmoduleMstrRepository _wctSysmoduleMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctSysmoduleMstrService">系统模块服务</param>
        /// <param name="wctSysmoduleMstrRepository">系统模块仓储</param>
        /// </summary>
        public WctSysmoduleMstrController( IWctSysmoduleMstrService wctSysmoduleMstrService,
            IWctSysmoduleMstrRepository wctSysmoduleMstrRepository) {
            _wctSysmoduleMstrService = wctSysmoduleMstrService;
            _wctSysmoduleMstrRepository = wctSysmoduleMstrRepository;
        }

        /// <summary>
        /// 获取系统模块分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("WctSysmoduleMstr/GetSysModulePageList"), MapToApiVersion("1.0")]
        public ActionResult GetSysModulePageList(WctSysmoduleMstrQuery query)
        {
            try
            {
                var result = _wctSysmoduleMstrRepository.GetSysModulePageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取系统模块列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctSysmoduleMstr/GetSysModuleList"), MapToApiVersion("1.0")]
        public ActionResult GetSysModuleList()
        {
            try
            {
                var result = _wctSysmoduleMstrRepository.GetSysModuleList();
                return Success("获取成功",result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取系统模块详情
        /// </summary>
        /// <param name="sysModuleId">系统模块id</param>
        /// <returns></returns>
        [HttpGet("WctSysmoduleMstr/GetSysModuleInfo"), MapToApiVersion("1.0")]
        public ActionResult GetSysModuleInfo(string sysModuleId)
        {
            try
            {
                if (string.IsNullOrEmpty(sysModuleId))
                    return Fail("数据传输异常");
                var result = _wctSysmoduleMstrRepository.FirstOrDefault(c => c.Id == sysModuleId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存系统模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("WctSysmoduleMstr/SaveSysMoudleInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveSysMoudleInfo([FromBody]WctSysmoduleMstrDto dto)
        {
            try
            {
                var result = _wctSysmoduleMstrService.SaveSysMoudleInfo(dto);
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
        /// 删除系统模块信息
        /// </summary>
        /// <param name="sysModuleIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("WctSysmoduleMstr/DelSysMoudleInfo"), MapToApiVersion("1.0")]
        public ActionResult DelSysMoudleInfo(string sysModuleIds)
        {
            try
            {
                var result = _wctSysmoduleMstrService.DelSysMoudleInfo(sysModuleIds);
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
