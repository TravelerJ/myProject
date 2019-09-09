
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 客户评价控制器
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmEvaMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmEvaMstrService _crmEvaMstrService;

        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ICrmEvaMstrRepository _crmEvaMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmEvaMstrService">服务</param>
        /// <param name="iCrmEvaMstrRepository">仓储</param>
        /// </summary>
        public CrmEvaMstrController(ICrmEvaMstrService crmEvaMstrService, ICrmEvaMstrRepository iCrmEvaMstrRepository)
        {
            _crmEvaMstrService = crmEvaMstrService;
            _crmEvaMstrRepository = iCrmEvaMstrRepository;
        }

        #region 评价管理
        /// <summary>
        /// 获取客户评价分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmEvaMstr/GetCrmEvaPageList"), MapToApiVersion("1.2")]
        public ActionResult GetCrmEvaPageList(CrmEvaMstrQuery query)
        {
            try
            {
                var result = _crmEvaMstrRepository.GetCrmEvaPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 导出评价数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmEvaMstr/ExportCrmEvaData"), MapToApiVersion("1.2")]
        public ActionResult ExportCrmEvaData(CrmEvaMstrQuery query)
        {
            try
            {
                _crmEvaMstrService.ExportCrmEvaData(query);
                return Success();
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="id">主键id</param>
        /// <param name="evaContent">回复内容</param>
        /// <returns></returns>
        [HttpPost("CrmEvaMstr/ReplyCrmEvaInfo"), MapToApiVersion("1.2")]
        public ActionResult ReplyCrmEvaInfo(string id, string evaContent)
        {
            try
            {
                var result = _crmEvaMstrService.ReplyEvaInfo(id, evaContent);
                if (result == null)
                {
                    return Fail("回复失败,参数有误");
                }
                return Success("回复成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除评价
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("CrmEvaMstr/DelCrmEvaInfo"), MapToApiVersion("1.2")]
        public ActionResult DelCrmEvaInfo(string id)
        {
            try
            {
                _crmEvaMstrService.DelCrmEvaInfo(id);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
        #endregion

        #region 信息中心
        /// <summary>
        /// 获取客户评价分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmEvaMstr/GetMessageCenterPageList"), MapToApiVersion("1.2")]
        public ActionResult GetMessageCenterPageList(CrmEvaMstrQuery query)
        {
            try
            {
                query.CREATE_ORG_NO = AbpSession.ORG_NO;
                var result = _crmEvaMstrRepository.GetMessageCenterPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="id">主键id</param>
        /// <param name="evaContent">回复内容</param>
        /// <returns></returns>
        [HttpPost("CrmEvaMstr/SendMessage"), MapToApiVersion("1.2")]
        public ActionResult ReplyMessage(string id, string evaContent)
        {
            try
            {
                _crmEvaMstrService.SendMessage(id, evaContent);
                return Success("回复成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
        #endregion
    }
}
