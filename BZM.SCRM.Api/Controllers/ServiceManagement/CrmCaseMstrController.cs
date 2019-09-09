
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 客户反馈控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmCaseMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmCaseMstrService _crmCaseMstrService;

        private readonly ICrmCaseMstrRepository _crmCaseMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmCaseMstrService">服务</param>
        /// </summary>
        public CrmCaseMstrController( ICrmCaseMstrService crmCaseMstrService, ICrmCaseMstrRepository crmCaseMstrRepository ) {
            _crmCaseMstrService = crmCaseMstrService;
            _crmCaseMstrRepository = crmCaseMstrRepository;
        }

        /// <summary>
        /// 获取客户反馈列表分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmCaseMstr/GetCrmCasePageList"),MapToApiVersion("1.2")]
        public ActionResult GetCrmCasePageList(CrmCaseMstrQuery query)
        {
            try
            {
                var result = _crmCaseMstrRepository.GetCrmCasePageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail("获取失败："+ex.Message);
            }
        }

        /// <summary>
        /// 删除客户反馈
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("CrmCaseMstr/DeleteCrmCaseInfo"), MapToApiVersion("1.2")]
        public ActionResult DeleteCrmCaseInfo(string ids)
        {
            try
            {
                _crmCaseMstrService.DeleteCrmCaseInfo(ids);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("删除失败：" + ex.Message);
            }
        }
    }
}
