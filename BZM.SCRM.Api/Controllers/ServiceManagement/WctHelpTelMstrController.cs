
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 紧急救援控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class WctHelpTelMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IWctHelpTelMstrService _wctHelpTelMstrService;

        /// <summary>
        /// 救援仓储
        /// </summary>
        private readonly IWctHelpTelMstrRepository _iWctHelpTelMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctHelpTelMstrService">服务</param>
        /// <param name="iWctHelpTelMstrRepository">救援仓储</param>
        /// </summary>
        public WctHelpTelMstrController(IWctHelpTelMstrService wctHelpTelMstrService, IWctHelpTelMstrRepository iWctHelpTelMstrRepository)
        {
            _wctHelpTelMstrService = wctHelpTelMstrService;
            _iWctHelpTelMstrRepository = iWctHelpTelMstrRepository;
        }

        /// <summary>
        /// 分页获取救援信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctHelpTelMstr/GetHelpTelPageList"), MapToApiVersion("1.2")]
        public ActionResult GetHelpTelPageList(WctHelpTelMstrQuery query)
        {
            try
            {
                query.CREATE_ORG_NO = AbpSession.ORG_NO;
                var result = _iWctHelpTelMstrRepository.GetHelpInfoPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取救援信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("WctHelpTelMstr/GetHelpTelInfoById"), MapToApiVersion("1.2")]
        public ActionResult GetHelpTelInfoById(string id)
        {
            try
            {
                var result = _iWctHelpTelMstrRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 编辑/新增救援信息
        /// </summary>
        /// <param name="helpDto"></param>
        /// <returns></returns>
        [HttpPost("WctHelpTelMstr/SaveHelpTelInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveHelpTelInfo([FromBody]WctHelpTelMstrDto helpDto)
        {
            try
            {
                var result = _wctHelpTelMstrService.SaveHelpTelInfo(helpDto);
                return Success("保存成功", result);
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除救援信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("WctHelpTelMstr/DelHelpTelInfo"), MapToApiVersion("1.2")]
        public ActionResult DelHelpTelInfo(string id)
        {
            try
            {
                bool flag = _wctHelpTelMstrService.DelHelpTelInfo(id);
                if (flag)
                {
                    return Success("删除成功");
                }
                return Fail("删除失败");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
