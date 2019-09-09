using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IMdmBasRegionRepository : IRepository<MdmBasRegion,string> {
        /// <summary>
        /// 获取省市地列表
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMdmBasRegionList(MdmBasRegionQuery query);
    }
}
