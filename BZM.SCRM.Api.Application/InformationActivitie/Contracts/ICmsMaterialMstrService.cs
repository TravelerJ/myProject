using Abp.Application.Services;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.InformationActivitie.Dtos;
using SCRM.Domain.InformationActivitie.Queries;

namespace SCRM.Application.InformationActivitie.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICmsMaterialMstrService : IApplicationService {
        /// <summary>
        /// 保存素材信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ReturnMsg SaveMaterialInfo(CmsMaterialMstrDto dto);
        /// <summary>
        /// 批量删除素材信息
        /// </summary>
        /// <param name="materialIds"></param>
        /// <returns></returns>
        ReturnMsg BatchDelMaterialInfo(string materialIds);
        /// <summary>
        /// 更改资讯状态/轮播
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ReturnMsg UpdateMaterialInfoStatus(CmsMaterialMstrQuery query);
    }
}
