
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.WeChatPlatform
{
    /// <summary>
    /// 标签控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class TagMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 标签服务
        /// </summary>
        private readonly ITagMstrService _tagMstrService;
        /// <summary>
        /// 标签仓储
        /// </summary>
        private readonly ITagMstrRepository _tagMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="tagMstrService">标签服务</param>
        /// <param name="tagMstrRepository">标签仓储</param>
        /// </summary>
        public TagMstrController( ITagMstrService tagMstrService,
            ITagMstrRepository tagMstrRepository) {
            _tagMstrService = tagMstrService;
            _tagMstrRepository = tagMstrRepository;
        }

        /// <summary>
        /// 获取标签分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("TagMstr/GetTagMstrPageList"), MapToApiVersion("1.1")]
        public ActionResult GetTagMstrPageList(TagMstrQuery query)
        {
            try
            {
                var result = _tagMstrRepository.GetTagMstrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("TagMstr/GetTagMstrList"), MapToApiVersion("1.1")]
        public ActionResult GetTagMstrList(TagMstrQuery query)
        {
            try
            {
                var result = _tagMstrRepository.GetTagMstrList(query);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取标签信息详情
        /// </summary>
        /// <param name="tagId">标签id</param>
        /// <returns></returns>
        [HttpGet("TagMstr/GetTagInfo"), MapToApiVersion("1.1")]
        public ActionResult GetTagInfo(string tagId)
        {
            try
            {
                if (string.IsNullOrEmpty(tagId))
                    return Fail("数据传输异常");
                var result = _tagMstrRepository.FirstOrDefault(c => c.Id == tagId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存标签信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("TagMstr/SaveTagInfo"), MapToApiVersion("1.1")]
        public ActionResult SaveTagInfo([FromBody]TagMstrDto dto)
        {
            try
            {
                var result = _tagMstrService.SaveTagInfo(dto);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("保存成功");
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除标签信息
        /// </summary>
        /// <param name="tagId">主键</param>
        /// <returns></returns>
        [HttpPost("TagMstr/DelTagInfo"), MapToApiVersion("1.1")]
        public ActionResult DelTagInfo(string tagId)
        {
            try
            {
                var result = _tagMstrService.DelTagInfo(tagId);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
