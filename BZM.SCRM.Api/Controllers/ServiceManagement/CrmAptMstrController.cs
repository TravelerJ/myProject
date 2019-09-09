
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 预约管理控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmAptMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmAptMstrService _crmAptMstrService;

        private readonly ICrmAptMstrRepository _crmAptMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmAptMstrService">服务</param>
        /// </summary>
        public CrmAptMstrController(ICrmAptMstrService crmAptMstrService, ICrmAptMstrRepository iCrmAptMstrRepository)
        {
            _crmAptMstrService = crmAptMstrService;
            _crmAptMstrRepository = iCrmAptMstrRepository;
        }

        /// <summary>
        /// 获取客户预约分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmAptMstr/GetCrmAptMstrPageList"), MapToApiVersion("1.2")]
        public ActionResult GetCrmAptMstrPageList(CrmAptMstrQuery query)
        {
            try
            {
                var result = _crmAptMstrRepository.GetCrmAptMstrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新状态为已完成(弃用)
        /// </summary>
        /// <returns></returns>
        [HttpPost("CrmAptMstr/UpdateStausToComplete"), MapToApiVersion("1.2")]
        public ActionResult UpdateStausToComplete(string id)
        {
            try
            {
                var result = _crmAptMstrService.UpdateStatusToComplete(id);
                return Success("更新成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
