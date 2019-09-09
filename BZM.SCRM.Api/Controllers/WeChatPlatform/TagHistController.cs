
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;

namespace SCRM.Controllers.WeChatPlatform
{
    /// <summary>
    /// 粉丝标签记录控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class TagHistController :SCRMControllerBase  {

        /// <summary>
        /// 粉丝标签记录服务
        /// </summary>
        private readonly ITagHistService _tagHistService;
        /// <summary>
        /// 粉丝标签记录仓储
        /// </summary>
        private readonly ITagHistRepository _tagHistRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="tagHistService">粉丝标签记录服务</param>
        /// <param name="tagHistRepository">粉丝标签记录仓储</param>
        /// </summary>
        public TagHistController( ITagHistService tagHistService, ITagHistRepository tagHistRepository) {
            _tagHistService = tagHistService;
            _tagHistRepository = tagHistRepository;
        }

        /// <summary>
        /// 获取粉丝标签列表
        /// </summary>
        /// <param name="wctId"></param>
        /// <returns></returns>
        [HttpGet("TagHist/GetWctTagHistList"), MapToApiVersion("1.1")]
        public ActionResult GetWctTagHistList(string wctId)
        {
            try
            {
                if (string.IsNullOrEmpty(wctId))
                    return Fail("数据传输异常");
                var result = _tagHistRepository.GetAllList(c => c.TAG_REF_ROW_NO == wctId && c.DEL_FLAG == 1);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }

}
