using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.InformationActivitie.Dtos;

namespace SCRM.Application.InformationActivitie.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICmsMaterialTypeService : IApplicationService {
        /// <summary>
        /// 保存素材类型信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveMaterialTypeInfo(CmsMaterialTypeDto dto);
        /// <summary>
        /// 批量删除素材类型信息
        /// </summary>
        /// <param name="materialTypeIds"></param>
        /// <returns></returns>
        ReturnMsg BatchDelMaterialTypeInfo(string materialTypeIds);
    }
}
