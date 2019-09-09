
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class FinanceTagConfigController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly IFinanceTagConfigService _financeTagConfigService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="financeTagConfigService">服务</param>
        /// </summary>
        public FinanceTagConfigController( IFinanceTagConfigService financeTagConfigService ) {
            _financeTagConfigService = financeTagConfigService;
        }

        /// <summary>
        /// 获取门店配置标签
        /// </summary>
        /// <returns></returns>
        [HttpGet("FinanceTagConfig/GetFinaceTagList"), MapToApiVersion("1.2")]
        public ActionResult GetFinaceTagList()
        {
            try
            {
                var result = _financeTagConfigService.GetFinTagList();
                return Success("获取配置成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存金融标签
        /// </summary>
        /// <returns></returns>
        [HttpPost("FinanceTagConfig/SaveTagInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveTagInfo([FromBody]FinanceTagConfigDto dto)
        {
            try
            {
                _financeTagConfigService.SaveTag(dto);
                return Success("保存成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存金融标签
        /// </summary>
        /// <returns></returns>
        [HttpPost("FinanceTagConfig/DeleteTagInfo"), MapToApiVersion("1.2")]
        public ActionResult DeleteTagInfo(string id)
        {
            try
            {
                _financeTagConfigService.DeleteTag(id);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("删除失败：" + ex.Message);
            }
        }
    }
}
