using Abp.Domain.Repositories;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Domain.InformationActivitie.Repositories
{
    /// <summary>
    /// 素材类型仓储
    /// </summary>
    public interface ICmsMaterialTypeRepository : IRepository<CmsMaterialType,string> {
        /// <summary>
        /// 获取素材类型分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagerList<dynamic> GetMaterialTypePageList(CmsMaterialTypeQuery query);
        /// <summary>
        /// 获取素材类型列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<dynamic> GetMaterialTypeList(CmsMaterialTypeQuery query);
        /// <summary>
        /// 批量删除素材类型信息
        /// </summary>
        /// <param name="materialTypeIds"></param>
        void BatchDelMaterialTypeInfo(string materialTypeIds);
    }
}
