using Abp.Domain.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.System.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface ISysUsrMstrRepository : IRepository<SysUsrMstr,decimal> {
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetSysUsrPageList(SysUsrMstrQuery query);
        /// <summary>
        /// 批量删除员工信息
        /// </summary>
        /// <param name="userIds"></param>
        void BatchDelSysUsrInfo(string userIds);
    }
}
