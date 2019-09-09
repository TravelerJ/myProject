using Abp.Application.Services;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;

namespace SCRM.Application.ServiceManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICrmEvaMstrService : IApplicationService {
        /// <summary>
        /// 导出评价数据
        /// </summary>
        /// <param name="query"></param>
        void ExportCrmEvaData(CrmEvaMstrQuery query);

        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="evaContent">回复内容</param>
        /// <returns></returns>
        CrmEvaMstr ReplyEvaInfo(string id,string evaContent);

        /// <summary>
        /// 删除评价
        /// </summary>
        void DelCrmEvaInfo(string id);


        /// <summary>
        /// 回复消息
        /// </summary>
        void SendMessage(string id, string evaContent);
    }
}
