
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器（问卷表：CRM_SURVEY_RSLT_MSTR）
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmSurveyRsltMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmSurveyRsltMstrService _crmSurveyRsltMstrService;

        private readonly ICrmSurveyRsltMstrRepository _crmSurveyRsltMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmSurveyRsltMstrService">服务</param>
        /// </summary>
        public CrmSurveyRsltMstrController(ICrmSurveyRsltMstrService crmSurveyRsltMstrService, ICrmSurveyRsltMstrRepository crmSurveyRsltMstrRepository)
        {
            _crmSurveyRsltMstrService = crmSurveyRsltMstrService;
            _crmSurveyRsltMstrRepository = crmSurveyRsltMstrRepository;
        }

        /// <summary>
        /// 分页获取问卷信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("CrmSurveyRsltMstr/GetSurveyRsltPageList"), MapToApiVersion("1.2")]
        public ActionResult GetSurveyRsltPageList(CrmSurveyRsltMstrQuery query)
        {
            try
            {
                query.CREATE_ORG_NO = AbpSession.ORG_NO;
                var result = _crmSurveyRsltMstrRepository.GetSurveyRsltPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取问卷详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CrmSurveyRsltMstr/GetSurveyRsltInfoById"), MapToApiVersion("1.2")]
        public ActionResult GetSurveyRsltInfoById(string id)
        {
            try
            {
                var result = _crmSurveyRsltMstrRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
