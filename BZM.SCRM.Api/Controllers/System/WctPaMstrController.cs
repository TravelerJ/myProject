
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
    /// 公众号控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class WctPaMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 公众号服务
        /// </summary>
        private readonly IWctPaMstrService _wctPaMstrService;
        /// <summary>
        /// 公众号仓储
        /// </summary>
        private readonly IWctPaMstrRepository _wctPaMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctPaMstrService">公众号服务</param>
        /// <param name="wctPaMstrRepository">公众号仓储</param>
        /// </summary>
        public WctPaMstrController( IWctPaMstrService wctPaMstrService,
            IWctPaMstrRepository wctPaMstrRepository) {
            _wctPaMstrService = wctPaMstrService;
            _wctPaMstrRepository = wctPaMstrRepository;
        }

        /// <summary>
        /// 获取公众号分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("WctPaMstr/GetWctPaMstrPageList"), MapToApiVersion("1.0")]
        public ActionResult GetWctPaMstrPageList(WctPaMstrQuery query)
        {
            try
            {
                var result = _wctPaMstrRepository.GetWctPaMstrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取公众号详情
        /// </summary>
        /// <param name="paId">主键</param>
        /// <returns></returns>
        [HttpGet("WctPaMstr/GetPaMstrInfo"), MapToApiVersion("1.0")]
        public ActionResult GetPaMstrInfo(string paId)
        {
            try
            {
                if (string.IsNullOrEmpty(paId))
                    return Fail("数据传输异常");
                var result = _wctPaMstrRepository.FirstOrDefault(c => c.Id == paId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存公众号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("WctPaMstr/SavePaInfo"), MapToApiVersion("1.0")]
        public ActionResult SavePaInfo([FromBody]WctPaMstrDto dto)
        {
            try
            {
                var result = _wctPaMstrService.SavePaInfo(dto);
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
        /// 删除公众号信息
        /// </summary>
        /// <param name="paIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("WctPaMstr/DelPaInfo"), MapToApiVersion("1.0")]
        public ActionResult DelPaInfo(string paIds)
        {
            try
            {
                var result = _wctPaMstrService.DelPaInfo(paIds);
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
