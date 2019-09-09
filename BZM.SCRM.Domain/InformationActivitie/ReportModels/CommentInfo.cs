using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.InformationActivitie.ReportModels
{
    /// <summary>
    /// 评论model
    /// </summary>
    public class CommentInfo
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public string CommentId { get; set; }
        /// <summary>
        /// 微信头像
        /// </summary>
        public string WxUrl { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string MemberLevel { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? CommentDate { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public string SupportNum { get; set; }
        /// <summary>
        /// 是否点赞
        /// </summary>
        public bool IsSupport { get; set; }
        /// <summary>
        /// 是否更多
        /// </summary>
        public bool IsMore { get; set; }
        /// <summary>
        /// 是否可回复
        /// </summary>
        public bool IsReply { get; set; }
        /// <summary>
        /// 子评论集合
        /// </summary>
        public List<ChildCommentInfo> ChildCommentList { get; set; }
    }
    /// <summary>
    /// 子评论
    /// </summary>
    public class ChildCommentInfo
    {
        /// <summary>
        /// 子评论id
        /// </summary>
        public string ChildCommentId { get; set; }
        /// <summary>
        /// 微信头像
        /// </summary>
        public string WxUrl { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string MemberLevel { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? CommentDate { get; set; }
        /// <summary>
        /// 被评论人
        /// </summary>
        public string ParentCommentPersonName { get; set; }
        /// <summary>
        /// 被评论id
        /// </summary>
        public string ParentCommentId { get; set; }
        /// <summary>
        /// 主评论id
        /// </summary>
        public string MainCommentId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 父级用户id
        /// </summary>
        public int ParentUserId { get; set; }
    }
}
