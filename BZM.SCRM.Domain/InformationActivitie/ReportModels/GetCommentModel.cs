using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.InformationActivitie.ReportModels
{
    /// <summary>
    /// 获取评论
    /// </summary>
    public class GetCommentModel
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public string COMMENT_ID { get; set; }
        /// <summary>
        /// 关联资讯
        /// </summary>
        public string MATERIAL_ID { get; set; }
        /// <summary>
        /// 评论人openId
        /// </summary>
        public string COMMENT_OPENID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string COMMENT_CONTENT { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? COMMENT_DATE { get; set; }
        /// <summary>
        /// 父级评论id
        /// </summary>
        public string COMMENT_PARENTID { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public string SUPPORT_COUNT { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NICK_NAME { get; set; }
        /// <summary>
        /// 微信头像
        /// </summary>
        public string WX_AVATAR_URL { get; set; }
        /// <summary>
        /// 主评论id
        /// </summary>
        public string MAIN_COMMENT_ID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int USER_ID { get; set; }
        /// <summary>
        /// 评论规则(0.不可评论，1.单向规则，2.双向规则，3.多向规则)
        /// </summary>
        public decimal? COMMENT_RULE { get; set; }
    }
}
