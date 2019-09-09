using Abp.Domain.Repositories;
using BZM.SCRM.Domain.InformationActivitie.ReportModels;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using System.Collections.Generic;

namespace SCRM.Domain.InformationActivitie.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IWctCommentMstrRepository : IRepository<WctCommentMstr,string> {
        /// <summary>
        /// 获取评论集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<GetCommentModel> GetCommentList(WctCommentMstrQuery query);
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        int DelCommentInfo(WctCommentMstrQuery query);
        /// <summary>
        /// 更新评论状态
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        void UpdateCommentStatus(string materialId);
    }
}
