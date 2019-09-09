
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using System;
using System.Collections.Generic;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器(预约试驾：apt_drive_config)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class AptDriveConfigController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IAptDriveConfigService _aptDriveConfigService;

        /// <summary>
        /// 初始化控制器
        /// <param name="aptDriveConfigService">服务</param>
        /// </summary>
        public AptDriveConfigController(IAptDriveConfigService aptDriveConfigService)
        {
            _aptDriveConfigService = aptDriveConfigService;
        }

        /// <summary>
        /// 获取试驾车型数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("AptDriveConfig/GetAptDriveCarList"), MapToApiVersion("1.2")]
        public ActionResult GetAptDriveCarList()
        {
            try
            {
                var result = _aptDriveConfigService.GetAptDriveCarList();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存试驾车型
        /// </summary>
        /// <returns></returns>
        [HttpPost("AptDriveConfig/SaveDriveCarSubtypeInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveDriveCarSubtypeInfo([FromBody]List<AptDriveConfigDto> driveList)
        {
            try
            {
                _aptDriveConfigService.SaveDriveInfo(driveList);
                return Success("获取成功");
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }
    }
}
