
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.InformationActivitie.Contracts;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using System;

namespace SCRM.Controllers.InformationActivitie
{
    /// <summary>
    /// 评论控制器
    /// </summary>
    [ApiVersion("1.3")]
    [Route("v{version:apiVersion}")]
    public class WctCommentMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 评论服务
        /// </summary>
        private readonly IWctCommentMstrService _wctCommentMstrService;
        /// <summary>
        /// 评论仓储
        /// </summary>
        private readonly IWctCommentMstrRepository _wctCommentMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctCommentMstrService">评论服务</param>
        /// <param name="wctCommentMstrRepository">评论仓储</param>
        /// </summary>
        public WctCommentMstrController( IWctCommentMstrService wctCommentMstrService,
            IWctCommentMstrRepository wctCommentMstrRepository) {
            _wctCommentMstrService = wctCommentMstrService;
            _wctCommentMstrRepository = wctCommentMstrRepository;
        }

        /// <summary>
        /// 获取评论分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("WctCommentMstr/GetCommentListByPage"), MapToApiVersion("1.3")]
        public ActionResult GetCommentListByPage(WctCommentMstrQuery query)
        {
            try
            {
                query.BU_NO = AbpSession.ORG_NO;
                query.CREATE_PSN = AbpSession.USR_ID.ToString();
                var commentList = _wctCommentMstrService.GetCommentListByPage(query);
                return Success("获取成功", new { CommentList = commentList.result, query.TotalCount });
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("WctCommentMstr/ReplyComment"), MapToApiVersion("1.3")]
        public ActionResult ReplyComment([FromBody]WctCommentMstrQuery query)
        {
            try
            {
                var reply = _wctCommentMstrService.ReplyComment(query);
                return Success("评论成功", reply.result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("WctCommentMstr/DelCommentInfo"), MapToApiVersion("1.3")]
        public ActionResult DelCommentInfo(WctCommentMstrQuery query)
        {
            try
            {
                var del = _wctCommentMstrService.DelCommentInfo(query);
                if (!del.IsSuccess)
                    return Fail(del.msg);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新评论状态
        /// </summary>
        /// <param name="materialId">资讯id</param>
        /// <returns></returns>
        [HttpPost("WctCommentMstr/UpdateCommentStatus"), MapToApiVersion("1.3")]
        public ActionResult UpdateCommentStatus(string materialId)
        {
            try
            {
                if (string.IsNullOrEmpty(materialId))
                    return Fail("数据传输异常");
                _wctCommentMstrRepository.UpdateCommentStatus(materialId);
                return Success("更新成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
