
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 基础配置控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class WctBasConfigController :SCRMControllerBase  {
        
        /// <summary>
        /// 基础配置服务
        /// </summary>
        private readonly IWctBasConfigService _wctBasConfigService;
        /// <summary>
        /// 基础配置仓储
        /// </summary>
        private readonly IWctBasConfigRepository _wctBasConfigRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctBasConfigService">基础配置服务</param>
        /// <param name="wctBasConfigRepository">基础配置仓储</param>
        /// </summary>
        public WctBasConfigController( IWctBasConfigService wctBasConfigService,
            IWctBasConfigRepository wctBasConfigRepository) {
            _wctBasConfigService = wctBasConfigService;
            _wctBasConfigRepository = wctBasConfigRepository;
        }

        /// <summary>
        /// 获取基础配置详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctBasConfig/GetWctBasConfigInfo"), MapToApiVersion("1.0")]
        public ActionResult GetWctBasConfigInfo()
        {
            try
            {
                var result = _wctBasConfigRepository.FirstOrDefault(c => c.BG_NO == AbpSession.BG_NO && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存基础配置详情
        /// </summary>
        /// <returns></returns>
        [HttpPost("WctBasConfig/SaveWctBasConfigInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveWctBasConfigInfo([FromBody]WctBasConfigDto dto)
        {
            try
            {
                var result = _wctBasConfigService.SaveWctBasConfigInfo(dto);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("保存成功");
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

    }
}
