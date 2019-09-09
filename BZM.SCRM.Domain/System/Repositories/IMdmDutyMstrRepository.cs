using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 职务仓储
    /// </summary>
    public interface IMdmDutyMstrRepository : IRepository<MdmDutyMstr,decimal> {

        /// <summary>
        /// 获取职务分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMdmDutyPageList(MdmDutyMstrQuery query);
        /// <summary>
        /// 批量删除职务信息
        /// </summary>
        /// <param name="dutyIds"></param>
        void BatchDelMdmDutyInfo(string dutyIds);
        /// <summary>
        /// 获取职务列表
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMdmDutyList();
    }
}
