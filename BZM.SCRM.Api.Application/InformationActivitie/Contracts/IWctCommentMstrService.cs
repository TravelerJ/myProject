using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Domain.InformationActivitie.Queries;

namespace SCRM.Application.InformationActivitie.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IWctCommentMstrService : IApplicationService {
        /// <summary>
        /// 获取评论分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg GetCommentListByPage(WctCommentMstrQuery query);
        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg ReplyComment(WctCommentMstrQuery query);
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg DelCommentInfo(WctCommentMstrQuery query);
    }
}
