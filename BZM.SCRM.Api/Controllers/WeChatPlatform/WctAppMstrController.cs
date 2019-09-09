
using Abp.Domain.Uow;
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.WeChatPlatform
{
    /// <summary>
    /// 微信app控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class WctAppMstrController :SCRMControllerBase  {

        /// <summary>
        /// 微信app服务
        /// </summary>
        private readonly IWctAppMstrService _wctAppMstrService;
        /// <summary>
        /// 微信app仓储
        /// </summary>
        private readonly IWctAppMstrRepository _wctAppMstrRepository;
        /// <summary>
        /// 系统模块仓储
        /// </summary>
        private readonly IWctSysmoduleMstrRepository _wctSysmoduleMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctAppMstrService">微信app服务</param>
        /// <param name="wctAppMstrRepository">微信app仓储</param>
        /// <param name="wctSysmoduleMstrRepository">系统模块仓储</param>
        /// </summary>
        public WctAppMstrController( IWctAppMstrService wctAppMstrService,
            IWctAppMstrRepository wctAppMstrRepository,
            IWctSysmoduleMstrRepository wctSysmoduleMstrRepository) {
            _wctAppMstrService = wctAppMstrService;
            _wctAppMstrRepository = wctAppMstrRepository;
            _wctSysmoduleMstrRepository = wctSysmoduleMstrRepository;
        }

        /// <summary>
        /// 获取门店app应用
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctAppMstr/GetAppMstrInfo"), MapToApiVersion("1.1")]
        public ActionResult GetAppMstrInfo()
        {
            try
            {
                var appInfo = _wctAppMstrRepository.GetAllList(c => c.BU_NO == AbpSession.ORG_NO && c.DEL_FLAG == 1).OrderBy(c => c.APP_SORT);
                return Success("获取成功", appInfo);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取门店app子应用
        /// </summary>
        /// <param name="appId">app应用id</param>
        /// <returns></returns>
        [HttpGet("WctAppMstr/GetAppItemInfo"), MapToApiVersion("1.1")]
        public ActionResult GetAppItemInfo(string appId)
        {
            try
            {
                var appInfo = _wctAppMstrService.GetAppItemInfo(appId);
                if (!appInfo.IsSuccess)
                    return Fail(appInfo.msg);
                return Success("获取成功", appInfo.result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取一级app应用
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctAppMstr/GetFirstModuleInfo"), MapToApiVersion("1.1")]
        public ActionResult GetFirstModuleInfo()
        {
            try
            {
                var firstModule = _wctSysmoduleMstrRepository.GetAllList(c => c.SYSM_CODE == "primary" && c.DEL_FLAG == 1);
                return Success("获取成功", firstModule);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存app菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("WctAppMstr/SaveAppInfo"), MapToApiVersion("1.1")]
        public ActionResult SaveAppInfo([FromBody]WctAppMstrDto dto)
        {
            try
            {
                var result = _wctAppMstrService.SaveAppInfo(dto);
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
        /// 删除app菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctAppMstr/DelAppInfo"), MapToApiVersion("1.1")]
        public ActionResult DelAppInfo(string appId)
        {
            try
            {
                var delApp = _wctAppMstrService.DelAppInfo(appId);
                if(!delApp.IsSuccess)
                    return Fail(delApp.msg);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

    }
}
