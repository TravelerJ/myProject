
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;

namespace SCRM.Controllers.WeChatPlatform
{

    /// <summary>
    /// 微信粉丝控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class SysUsrWctController :SCRMControllerBase  {

        /// <summary>
        /// 微信粉丝服务
        /// </summary>
        private readonly ISysUsrWctService _sysUsrWctService;
        /// <summary>
        /// 微信粉丝仓储
        /// </summary>
        private readonly ISysUsrWctRepository _sysUsrWctRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="sysUsrWctService">微信粉丝服务</param>
        /// <param name="sysUsrWctRepository">微信粉丝仓储</param>
        /// </summary>
        public SysUsrWctController( ISysUsrWctService sysUsrWctService,
            ISysUsrWctRepository sysUsrWctRepository) {
            _sysUsrWctService = sysUsrWctService;
            _sysUsrWctRepository = sysUsrWctRepository;
        }

        /// <summary>
        /// 分页获取粉丝信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("SysUsrWct/GetWctInfoPageList"),MapToApiVersion("1.1")]
        public ActionResult GetWctInfoPageList(SysUsrWctQuery query)
        {
            try
            {
                query.BG_NO = AbpSession.BG_NO;
                var result = _sysUsrWctRepository.GetWctInfoPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 粉丝打标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SysUsrWct/WctMakeTag"), MapToApiVersion("1.1")]
        public ActionResult WctMakeTag([FromBody]SysUsrWctDto dto)
        {
            try
            {
                var wct = _sysUsrWctService.WctMakeTag(dto);
                if (!wct.IsSuccess)
                    return Fail(wct.msg);
                return Success("操作成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更改粉丝黑名单状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("SysUsrWct/UpdateFansBlackStatus"), MapToApiVersion("1.1")]
        public ActionResult UpdateFansBlackStatus([FromBody]SysUsrWctQuery query)
        {
            try
            {
                var wct = _sysUsrWctService.UpdateFansBlackStatus(query);
                if (!wct.IsSuccess)
                    return Fail(wct.msg);
                return Success("操作成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
