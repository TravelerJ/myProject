
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器(车型图片维护：RES_FILE_MSTR)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class ResFileMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IResFileMstrService _resFileMstrService;

        /// <summary>
        /// 初始化控制器
        /// <param name="resFileMstrService">服务</param>
        /// </summary>
        public ResFileMstrController(IResFileMstrService resFileMstrService)
        {
            _resFileMstrService = resFileMstrService;
        }

        /// <summary>
        /// 获取erp车型数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("ResFileMstr/GetErpCarList"), MapToApiVersion("1.2")]
        public ActionResult GetErpCarList()
        {
            try
            {
                var result = _resFileMstrService.GetErpCarList();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存车型关联图
        /// </summary>
        /// <returns></returns>
        [HttpPost("ResFileMstr/SaveResFileInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveResFileInfo(string fileId, string bizNo, string fileName)
        {
            try
            {
                _resFileMstrService.SaveCarResFile(fileId, bizNo, fileName);
                return Success("保存成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }
    }
}
