using Abp.Application.Services;
using SCRM.Application.MallManagement.Dtos;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmGoodsPropertyMstrService : IApplicationService
    {
        /// <summary>
        /// 获取商品分类属性
        /// </summary>
        /// <param name="goodsClassId"></param>
        /// <returns></returns>
        string GetPropertyList(string goodsClassId);

        /// <summary>
        /// 保存商品分类属性
        /// </summary>
        /// <param name="dto"></param>
        void SaveGoodsProperty(MdmGoodsPropertyMstrDto dto);

        /// <summary>
        /// 删除商品分类属性
        /// </summary>
        /// <param name="id"></param>
        void DelGoodsProperty(string id);
    }
}
