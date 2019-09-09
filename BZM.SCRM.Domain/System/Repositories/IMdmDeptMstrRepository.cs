using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 部门仓储
    /// </summary>
    public interface IMdmDeptMstrRepository : IRepository<MdmDeptMstr,decimal> {

        /// <summary>
        /// 获取部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMdmDeptPageList(MdmDeptMstrQuery query);
        /// <summary>
        /// 批量删除部门信息
        /// </summary>
        /// <param name="deptIds"></param>
        void BatchDelMdmDeptInfo(string deptIds);
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMdmDeptList();
    }
}
