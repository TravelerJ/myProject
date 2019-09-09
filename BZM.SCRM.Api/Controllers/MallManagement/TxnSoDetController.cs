
using BZM.SCRM.Api.Controllers;
using SCRM.Application.MallManagement.Contracts;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class TxnSoDetController :SCRMControllerBase  {
        
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ITxnSoDetService _txnSoDetService;
        
        /// <summary>
        /// 初始化控制器
        /// <param name="txnSoDetService">服务</param>
        /// </summary>
        public TxnSoDetController( ITxnSoDetService txnSoDetService ) {
            _txnSoDetService = txnSoDetService;
        }
    }
}
