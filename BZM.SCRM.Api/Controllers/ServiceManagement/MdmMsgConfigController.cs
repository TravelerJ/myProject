
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using System;
using System.Collections.Generic;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class MdmMsgConfigController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmMsgConfigService _mdmMsgConfigService;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmMsgConfigService">服务</param>
        /// </summary>
        public MdmMsgConfigController(IMdmMsgConfigService mdmMsgConfigService)
        {
            _mdmMsgConfigService = mdmMsgConfigService;
        }

        /// <summary>
        /// 获取消息提醒
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmMsgConfig/GetSectedMsgConfig"), MapToApiVersion("1.2")]
        public ActionResult GetSectedMsgConfig()
        {
            try
            {
                var result = _mdmMsgConfigService.GetSectedMsgConfig();
                return Success("获取消息提醒成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取消息提醒失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存消息提醒配置
        /// </summary>
        /// <param name="msgList"></param>
        /// <returns></returns>
        [HttpPost("MdmMsgConfig/SaveMsgConfig"), MapToApiVersion("1.2")]
        public ActionResult SaveMsgConfig([FromBody]List<MdmMsgConfigDto> msgList)
        {
            try
            {
                var result = _mdmMsgConfigService.SaveMsgConfig(msgList);
                string msg = result ? "成功" : "失败";
                return Success($"获取消息提醒{msg}");
            }
            catch (Exception ex)
            {
                return Fail("获取消息提醒失败：" + ex.Message);
            }
        }
    }
}
