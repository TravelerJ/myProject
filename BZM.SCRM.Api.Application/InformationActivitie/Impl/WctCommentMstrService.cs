
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.InformationActivitie.ReportModels;
using Newtonsoft.Json;
using SCRM.Application.InformationActivitie.Contracts;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.InformationActivitie.Impl
{
    /// <summary>
    /// 评论服务
    /// </summary>
    public class WctCommentMstrService : SCRMAppServiceBase, IWctCommentMstrService {
    
        /// <summary>
        /// 评论仓储
        /// </summary>
        private readonly IWctCommentMstrRepository _wctCommentMstrRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctCommentMstrService( IWctCommentMstrRepository wctCommentMstrRepository ) {
            _wctCommentMstrRepository = wctCommentMstrRepository;
        }


        /// <summary>
        /// 获取评论分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg GetCommentListByPage(WctCommentMstrQuery query)
        {
            var rm = new ReturnMsg();
            var commentList = new List<CommentInfo>();
            var childList = new List<GetCommentModel>();
            var parentList = new List<GetCommentModel>();
            var allCommentList = _wctCommentMstrRepository.GetCommentList(query);
            if (allCommentList.Count > 0)
            {
                parentList = allCommentList.Where(c => c.COMMENT_PARENTID == null || c.COMMENT_PARENTID == "").OrderByDescending(c => c.COMMENT_DATE).ToList();
                query.TotalCount = parentList.Count;
                foreach (var item in parentList)
                {
                    childList = allCommentList.Where(c => c.MAIN_COMMENT_ID == item.COMMENT_ID).OrderBy(c => c.COMMENT_DATE).ToList();
                    commentList.Add(new CommentInfo
                    {
                        CommentId = item.COMMENT_ID,
                        WxUrl = item.WX_AVATAR_URL,
                        NickName = item.NICK_NAME,
                        CommentContent = item.COMMENT_CONTENT,
                        CommentDate = item.COMMENT_DATE,
                        SupportNum = item.SUPPORT_COUNT,
                        IsMore = childList.Count > 3,
                        IsReply = GetIsReply(item.COMMENT_RULE, item.COMMENT_ID, childList),
                        ChildCommentList = GetChildCommentList(item.COMMENT_ID, childList, allCommentList, query.MATERIAL_ID)
                    });
                }
            }
            commentList = commentList.Skip(query.Page - 1 * query.PageSize).Take(query.PageSize).ToList();
            rm.IsSuccess = true;
            rm.result = JsonConvert.SerializeObject(commentList);

            return rm;
        }

        /// <summary>
        /// 是否回复
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="commentId"></param>
        /// <param name="childList"></param>
        /// <returns></returns>
        public bool GetIsReply(decimal? rule,string commentId, List<GetCommentModel> childList)
        {
            var isReply = false;
            switch (rule)
            {
                case 0:
                    isReply = false;
                    break;
                case 1:
                    isReply = false;
                    break;
                case 2:
                    var result = childList.Where(c => c.USER_ID == AbpSession.USR_ID).ToList();
                    if (result.Count > 0)
                        return isReply;
                    isReply = true;
                    break;
                case 3:
                    isReply = true;
                    break;
                default:
                    isReply = false;
                    break;
            }
            return isReply;
        }

        /// <summary>
        /// 获取子评论集合
        /// </summary>
        /// <param name="mainCommentId"></param>
        /// <param name="childList"></param>
        /// <param name="commentList"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public List<ChildCommentInfo> GetChildCommentList(string mainCommentId, List<GetCommentModel> childList, List<GetCommentModel> commentList, string commentId)
        {
            var list = new List<ChildCommentInfo>();
            foreach (var item in childList)
            {
                var parentCommentInfo = commentList.Single(c => c.COMMENT_ID == item.COMMENT_PARENTID);
                list.Add(new ChildCommentInfo
                {
                    ChildCommentId = item.COMMENT_ID,
                    WxUrl = item.USER_ID != 0 ? AbpSession.USR_AVATAR_PATH : item.WX_AVATAR_URL,
                    NickName = item.NICK_NAME,
                    CommentContent = item.COMMENT_CONTENT,
                    CommentDate = item.COMMENT_DATE,
                    MainCommentId = mainCommentId,
                    UserId = item.USER_ID,
                    ParentCommentId = item.COMMENT_PARENTID,
                    ParentUserId = parentCommentInfo.USER_ID,
                    ParentCommentPersonName = parentCommentInfo.NICK_NAME
                });
            }
            return list;
        }

        /// <summary>
        /// 校验评论内容
        /// </summary>
        /// <param name="query"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckCommentInfo(WctCommentMstrQuery query, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(query.COMMENT_PARENTID))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择回复的评论";
            }
            if (string.IsNullOrEmpty(query.COMMENT_CONTENT)|| string.IsNullOrEmpty(query.COMMENT_CONTENT.Trim()))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入回复的内容";
            }
            if (string.IsNullOrEmpty(query.MATERIAL_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "资讯id不可为空";
            }
            if (string.IsNullOrEmpty(query.MAIN_COMMENT_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "资讯id不可为空";
            }

            rm.IsSuccess = true;

            return rm;
        }
        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg ReplyComment(WctCommentMstrQuery query)
        {
            var rm = new ReturnMsg();
            var isOk = CheckCommentInfo(query, rm);
            if (!isOk.IsSuccess)
                return rm;
            var comment = new WctCommentMstr()
            {
                Id=Guid.NewGuid().ToString("N"),
                MATERIAL_ID=query.MATERIAL_ID,
                COMMENT_CONTENT=query.COMMENT_CONTENT,
                COMMENT_DATE=DateTime.Now,
                COMMENT_PARENTID=query.COMMENT_PARENTID,
                USER_ID=AbpSession.USR_ID,
                IS_READ=1,
                MAIN_COMMENT_ID=query.MAIN_COMMENT_ID,
                DEL_FLAG=1,
                BU_NO=AbpSession.ORG_NO,
                BG_NO=AbpSession.BG_NO
            };
            _wctCommentMstrRepository.Insert(comment);

            rm.IsSuccess = true;
            rm.result = comment.Id;

            return rm;
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg DelCommentInfo(WctCommentMstrQuery query)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(query.COMMENT_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的评论";
                return rm;
            }
            var result = _wctCommentMstrRepository.DelCommentInfo(query);
            if (result == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "删除评论失败";
                return rm;
            }

            rm.IsSuccess = true;

            return rm;
        }

    }
}
