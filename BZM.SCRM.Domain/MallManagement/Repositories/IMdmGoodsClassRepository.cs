using Abp.Domain.Repositories;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Domain.MallManagement.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IMdmGoodsClassRepository : IRepository<MdmGoodsClass,long> {
        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <returns></returns>
        dynamic GetGoodClassList();

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool DelGoodsClass(string where);

        /// <summary>
        /// 查询分类是否被绑定
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool GetBindGoodsNum(string where);
    }
}
