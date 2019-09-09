
using BZM.SCRM.Application;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Repositories;
using System;

namespace SCRM.Application.TxnSoMstrs
{
    /// <summary>
    /// 服务
    /// </summary>
    public class TxnSoMstrService : SCRMAppServiceBase, ITxnSoMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ITxnSoMstrRepository _txnSoMstrRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public TxnSoMstrService(ITxnSoMstrRepository txnSoMstrRepository)
        {
            _txnSoMstrRepository = txnSoMstrRepository;
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="soNo"></param>
        /// <param name="expressNo"></param>
        /// <returns></returns>
        public TxnSoMstrDto UpdateExpressNo(string soNo, string expressNo = "")
        {
            if (!string.IsNullOrEmpty(soNo))
            {
                var soInfo = _txnSoMstrRepository.Get(soNo);
                if (soInfo == null)
                {
                    throw new Exception("订单编号有误");
                }
                soInfo.EXPRESS_NO = expressNo;
                soInfo.UPDATE_DATE = DateTime.Now;
                soInfo.UPDATE_PSN = AbpSession.USR_ID;

                var dto = _txnSoMstrRepository.Update(soInfo).ToDto();
                return dto;
            }
            else
            {
                throw new Exception("订单编号有误");
            }
        }

        /// <summary>
        /// 订单收货
        /// </summary>
        /// <param name="soNo"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public TxnSoMstrDto UpdateOrderStatus(string soNo, string orderStatus = "")
        {
            //待发货
            if (orderStatus != "卖家已发货" && orderStatus != "买家已收货")
            {
                string msg = orderStatus == "买家已付款" ? "卖家已发货" : "买家已收货";
                throw new Exception(msg);
            }

            var entity = _txnSoMstrRepository.Get(soNo);
            if (entity.STATUS == "买家已付款" || entity.STATUS == "卖家已发货")
            {
                entity.STATUS = orderStatus;
                TxnSoMstrDto dto = _txnSoMstrRepository.Update(entity).ToDto();
                return dto;
            }
            else
            {
                string msg = orderStatus == "买家已付款" ? "卖家已发货" : "卖家已发货";
                throw new Exception(msg);
            }
        }
    }
}
