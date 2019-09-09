
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.System.Contracts;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using System;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 省市地控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class MdmBasRegionController :SCRMControllerBase  {

        /// <summary>
        /// 省市地服务
        /// </summary>
        private readonly IMdmBasRegionService _mdmBasRegionService;
        /// <summary>
        /// 省市地仓储
        /// </summary>
        private readonly IMdmBasRegionRepository _mdmBasRegionRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmBasRegionService">省市地服务</param>
        /// <param name="mdmBasRegionRepository">省市地仓储</param>
        /// </summary>
        public MdmBasRegionController( IMdmBasRegionService mdmBasRegionService,
            IMdmBasRegionRepository mdmBasRegionRepository) {
            _mdmBasRegionService = mdmBasRegionService;
            _mdmBasRegionRepository = mdmBasRegionRepository;
        }

        /// <summary>
        /// 获取省市地列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmBasRegion/GetMdmBasRegionList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmBasRegionList(MdmBasRegionQuery query)
        {
            try
            {
                var result = _mdmBasRegionRepository.GetMdmBasRegionList(query);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }
    }
}
