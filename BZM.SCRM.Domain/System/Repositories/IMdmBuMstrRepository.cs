using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 机构仓储
    /// </summary>
    public interface IMdmBuMstrRepository : IRepository<MdmBuMstr,string> {
        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMdmBuMstrList(MdmBuMstrQuery query);
        /// <summary>
        /// 获取机构分页列表
        /// </summary>
        /// <returns></returns>
        PagerList<dynamic> GetMdmBuMstrPageList(MdmBuMstrQuery query);
        /// <summary>
        /// 批量删除机构信息
        /// </summary>
        /// <param name="buNos"></param>
        void BatchDelBuInfo(string buNos);
    }
}
