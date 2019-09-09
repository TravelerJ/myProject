
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器(题目表：CRM_QPAPER_QU)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CrmQpaperQuController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmQpaperQuService _crmQpaperQuService;

        private readonly ICrmQpaperQuRepository _crmQpaperQuRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="crmQpaperQuService">服务</param>
        /// </summary>
        public CrmQpaperQuController(ICrmQpaperQuService crmQpaperQuService, ICrmQpaperQuRepository crmQpaperQuRepository)
        {
            _crmQpaperQuService = crmQpaperQuService;
            _crmQpaperQuRepository = crmQpaperQuRepository;
        }

        /// <summary>
        /// 获取题目分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("CrmQpaperQu/GetQpaperQuPageList"), MapToApiVersion("1.2")]
        public ActionResult GetQpaperQuPageList(CrmQpaperQuQuery query)
        {
            try
            {
                var result = _crmQpaperQuRepository.GetCrmQpaperQuPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (global::System.Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取题目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CrmQpaperQu/GetQpaperQuInfoById"), MapToApiVersion("1.2")]
        public ActionResult GetQpaperQuInfoById(string id)
        {
            try
            {
                var result = _crmQpaperQuRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (global::System.Exception ex)
            {
                return Fail("获取信息失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 编辑/新增题目
        /// </summary>
        /// <param name="crmQpaperQuDto"></param>
        /// <returns></returns>
        [HttpPost("CrmQpaperQu/SaveQpaperQuInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveQpaperQuInfo([FromBody]CrmQpaperQuDto crmQpaperQuDto)
        {
            try
            {
                string msg = "";
                var result = _crmQpaperQuService.SaveQpaperQuInfo(crmQpaperQuDto, ref msg);
                if (result == null)
                {
                    return Fail("保存失败:" + msg);
                }
                return Success("保存成功", result);
            }
            catch (global::System.Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("CrmQpaperQu/DelQpaperQuInfo"), MapToApiVersion("1.2")]
        public ActionResult DelQpaperQuInfo(string ids)
        {
            try
            {
                _crmQpaperQuService.DelQpaperQuInfo(ids);
                return Success("删除成功");
            }
            catch (global::System.Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }
    }
}
