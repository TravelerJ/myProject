
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
    /// 控制器(预约配置：CRM_APT_CONFIG_MSTR)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmAptConfigMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmAptConfigMstrService _crmAptConfigMstrService;

        private readonly ICrmAptConfigMstrRepository _crmAptConfigMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmAptConfigMstrService">服务</param>
        /// </summary>
        public CrmAptConfigMstrController(ICrmAptConfigMstrService crmAptConfigMstrService, ICrmAptConfigMstrRepository crmAptConfigMstrRepository)
        {
            _crmAptConfigMstrService = crmAptConfigMstrService;
            _crmAptConfigMstrRepository = crmAptConfigMstrRepository;
        }

        /// <summary>
        /// 分页获取预约配置信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("CrmAptConfigMstr/GetAptConfigPageList"), MapToApiVersion("1.2")]
        public ActionResult GetAptConfigPageList(CrmAptConfigMstrQuery query)
        {
            try
            {
                query.CREATE_ORG_NO = AbpSession.ORG_NO;
                var result = _crmAptConfigMstrRepository.GetAptConfigPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取预约配置信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CrmAptConfigMstr/GetCrmAptConfigInfo"), MapToApiVersion("1.2")]
        public ActionResult GetCrmAptConfigInfo(string id)
        {
            try
            {
                var result = _crmAptConfigMstrRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 验证集团是否已配置预约时间段
        /// </summary>
        /// <param name="aptType">预约类型</param>
        /// <returns></returns>
        [HttpGet("CrmAptConfigMstr/VerifyPeriodIsConfig"), MapToApiVersion("1.2")]
        public ActionResult VerifyPeriodIsConfig(int aptType)
        {
            try
            {
                var result = _crmAptConfigMstrService.VerifyPeriodIsConfig(aptType);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 编辑/新增预约配置信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CrmAptConfigMstr/SaveCrmAptConfig"), MapToApiVersion("1.2")]
        public ActionResult SaveCrmAptConfig([FromBody]CrmAptConfigMstrDto dto)
        {
            try
            {
                var result = _crmAptConfigMstrService.SaveCrmAptConfig(dto, out string msg);
                if (result != null)
                {
                    return Success(msg, result);
                }
                return Fail("保存失败:" + msg);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除预约配置信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("CrmAptConfigMstr/DeleteCrmAptConfig"), MapToApiVersion("1.2")]
        public ActionResult DeleteCrmAptConfig(string ids)
        {
            try
            {
                _crmAptConfigMstrService.DeleteCrmAptConfig(ids);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
