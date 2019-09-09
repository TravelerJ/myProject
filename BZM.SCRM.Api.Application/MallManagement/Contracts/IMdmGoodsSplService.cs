using Abp.Application.Services;
using System.Collections.Generic;

namespace SCRM.Application.MallManagement.Contracts
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface IMdmGoodsSplService : IApplicationService {
        /// <summary>
        /// 插入销售价格方案
        /// </summary>
        /// <param name="dic"></param>
        void AddSalePrice(Dictionary<string, object> dic);

        /// <summary>
        /// 修改价格销售方案
        /// </summary>
        void UpdateSalePrice(Dictionary<string, object> dic,string goodsNo);
    }
}
