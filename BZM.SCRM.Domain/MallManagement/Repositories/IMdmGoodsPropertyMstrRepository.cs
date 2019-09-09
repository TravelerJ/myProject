using Abp.Domain.Repositories;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Domain.MallManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IMdmGoodsPropertyMstrRepository : IRepository<MdmGoodsPropertyMstr,string> {
        /// <summary>
        /// 验证属性是否存在
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ValidateProperty(string parentId, string value);

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyId"></param>
        /// <param name="where"></param>
        bool DelProValue(string propertyId, string where);
    }
}
