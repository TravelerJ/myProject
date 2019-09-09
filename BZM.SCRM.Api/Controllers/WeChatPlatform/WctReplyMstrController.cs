
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
    /// 回复控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class WctReplyMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 回复服务
        /// </summary>
        private readonly IWctReplyMstrService _wctReplyMstrService;
        /// <summary>
        /// 回复仓储
        /// </summary>
        private readonly IWctReplyMstrRepository _wctReplyMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctReplyMstrService">回复服务</param>
        /// <param name="wctReplyMstrRepository">回复仓储</param>
        /// </summary>
        public WctReplyMstrController( IWctReplyMstrService wctReplyMstrService,
            IWctReplyMstrRepository wctReplyMstrRepository) {
            _wctReplyMstrService = wctReplyMstrService;
            _wctReplyMstrRepository = wctReplyMstrRepository;
        }

        /// <summary>
        /// 获取回复信息分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("WctReplyMstr/GetReplyPageList"), MapToApiVersion("1.1")]
        public ActionResult GetReplyPageList(WctReplyMstrQuery query)
        {
            try
            {
                var result = _wctReplyMstrRepository.GetReplyPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取回复信息详情
        /// </summary>
        /// <param name="replyId">系统模块id</param>
        /// <returns></returns>
        [HttpGet("WctReplyMstr/GetReplyInfo"), MapToApiVersion("1.1")]
        public ActionResult GetReplyInfo(string replyId)
        {
            try
            {
                if (string.IsNullOrEmpty(replyId))
                    return Fail("数据传输异常");
                var result = _wctReplyMstrRepository.FirstOrDefault(c => c.Id == replyId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存回复信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("WctReplyMstr/SaveReplyInfo"), MapToApiVersion("1.1")]
        public ActionResult SaveReplyInfo([FromBody]WctReplyMstrDto dto)
        {
            try
            {
                var result = _wctReplyMstrService.SaveReplyInfo(dto);
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
        /// 删除回复信息
        /// </summary>
        /// <param name="replyIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("WctReplyMstr/DelReplyInfo"), MapToApiVersion("1.1")]
        public ActionResult DelReplyInfo(string replyIds)
        {
            try
            {
                var result = _wctReplyMstrService.DelReplyInfo(replyIds);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新回复信息状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("WctReplyMstr/UpdateReplyStatus"), MapToApiVersion("1.1")]
        public ActionResult UpdateReplyStatus([FromBody]WctReplyMstrQuery query)
        {
            try
            {
                var upReply = _wctReplyMstrService.UpdateReplyStatus(query);
                if (!upReply.IsSuccess)
                    return Fail(upReply.msg);
                return Success("操作成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
