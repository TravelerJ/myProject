
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
    /// 控制器(套卷管理表：CRM_QPAPER_MSTR)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmQpaperMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmQpaperMstrService _crmQpaperMstrService;

        private readonly ICrmQpaperMstrRepository _crmQpaperMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmQpaperMstrService">服务</param>
        /// </summary>
        public CrmQpaperMstrController(ICrmQpaperMstrService crmQpaperMstrService, ICrmQpaperMstrRepository crmQpaperMstrRepository)
        {
            _crmQpaperMstrService = crmQpaperMstrService;
            _crmQpaperMstrRepository = crmQpaperMstrRepository;
        }

        /// <summary>
        /// 获取套卷分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmQpaperMstr/GetQpaperMstrPageList"), MapToApiVersion("1.2")]
        public ActionResult GetQpaperMstrPageList(CrmQpaperMstrQuery query)
        {
            try
            {
                var result = _crmQpaperMstrRepository.GetCrmQpaperMstrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取套卷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CrmQpaperMstr/GetQpaperMstrInfoById"), MapToApiVersion("1.2")]
        public ActionResult GetQpaperQuInfoById(string id)
        {
            try
            {
                var result = _crmQpaperMstrRepository.Get(id).ToDto();
                result.QuList = _crmQpaperMstrService.GetQuList(result.INCLUDE_QUESTION_IDS);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取信息失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 启用/禁用套卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("CrmQpaperMstr/EnableQpaperInfo"), MapToApiVersion("1.2")]
        public ActionResult EnableQpaperInfo(string id)
        {
            try
            {
                var result = _crmQpaperMstrService.EnableQpaper(id);
                if (result == null)
                {
                    return Fail("操作失败");
                }
                string str = result.PAPER_STATUS == 0 ? "禁用" : "启用";

                return Success($"{str}成功", result);
            }
            catch (Exception ex)
            {
                return Fail("操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除套卷
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("CrmQpaperMstr/DelQpaperMstrInfo"), MapToApiVersion("1.2")]
        public ActionResult DelQpaperMstrInfo(string ids)
        {
            try
            {
                _crmQpaperMstrService.DelQpaper(ids);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 创建套卷
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CrmQpaperMstr/CreateQpaperMstrInfo"), MapToApiVersion("1.2")]
        public ActionResult CreateQpaperMstrInfo([FromBody]CrmQpaperMstrDto dto)
        {
            try
            {
                var result = _crmQpaperMstrService.CreateQpaper(dto);
                if (result == null)
                {
                    return Fail("保存失败");
                }
                return Success("保存成功", result);
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }
    }
}
