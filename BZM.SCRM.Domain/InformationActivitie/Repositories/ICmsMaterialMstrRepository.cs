using Abp.Domain.Repositories;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using Spring.Domains.Repositories;

namespace SCRM.Domain.InformationActivitie.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface ICmsMaterialMstrRepository : IRepository<CmsMaterialMstr,string> {
        /// <summary>
        /// 获取素材分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMaterialMstrPageList(CmsMaterialMstrQuery query);
        /// <summary>
        /// 批量删除素材信息
        /// </summary>
        /// <param name="materialIds"></param>
        void BatchDelMaterialInfo(string materialIds);
        /// <summary>
        /// 获取资讯的评论未读信息数列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMaterialCommentPageList(CmsMaterialMstrQuery query);
    }
}
