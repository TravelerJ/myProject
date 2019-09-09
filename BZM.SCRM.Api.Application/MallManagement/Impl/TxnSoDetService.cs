
using BZM.SCRM.Application;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Domain.MallManagement.Repositories;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class TxnSoDetService : SCRMAppServiceBase, ITxnSoDetService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ITxnSoDetRepository _txnSoDetRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public TxnSoDetService( ITxnSoDetRepository txnSoDetRepository ) {
            _txnSoDetRepository = txnSoDetRepository;
        }
    }
}
