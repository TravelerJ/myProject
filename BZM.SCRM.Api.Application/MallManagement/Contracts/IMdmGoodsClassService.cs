using Abp.Application.Services;
using SCRM.Application.MallManagement.Dtos;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmGoodsClassService : IApplicationService
    {
        /// <summary>
        /// 保存删除分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        MdmGoodsClassDto SaveGoodsClass(MdmGoodsClassDto dto);

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        void DeleteGoodsClass(long id);
    }
}
