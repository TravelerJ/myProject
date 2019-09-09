
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using System;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器(订单：txn_so_mstr)
    /// </summary>
    [ApiVersion("1.4")]
    [Route("v{version:apiVersion}")]
    public class TxnSoMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ITxnSoMstrService _txnSoMstrService;

        private readonly ITxnSoMstrRepository _txnSoMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="txnSoMstrService">服务</param>
        /// </summary>
        public TxnSoMstrController(ITxnSoMstrService txnSoMstrService, ITxnSoMstrRepository txnSoMstrRepository)
        {
            _txnSoMstrService = txnSoMstrService;
            _txnSoMstrRepository = txnSoMstrRepository;
        }

        /// <summary>
        /// 获取订单分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("TxnSoMstr/GetOrderPageList"), MapToApiVersion("1.4")]
        public ActionResult GetOrderPageList(TxnSoMstrQuery query)
        {
            try
            {
                var result = _txnSoMstrRepository.GetOrderPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 查看数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("TxnSoMstr/GetOrderInfoById"), MapToApiVersion("1.4")]
        public ActionResult GetOrderInfoById(string id)
        {
            try
            {
                var result = _txnSoMstrRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="soNo">订单编号</param>
        /// <param name="expressNo">快递单号</param>
        /// <returns></returns>
        [HttpPost("TxnSoMstr/OrderDelivery"), MapToApiVersion("1.4")]
        public ActionResult OrderDelivery(string soNo, string expressNo = "")
        {
            try
            {
                var result = _txnSoMstrService.UpdateExpressNo(soNo, expressNo);
                return Success("发货成功", result);
            }
            catch (Exception ex)
            {
                return Fail("发货失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 订单收货
        /// </summary>
        /// <param name="soNo">订单编号</param>
        /// <param name="orderStatus">订单状态</param>
        /// <returns></returns>
        [HttpPost("TxnSoMstr/OrderTake"), MapToApiVersion("1.4")]
        public ActionResult OrderTake(string soNo, string orderStatus = "")
        {
            try
            {
                var result = _txnSoMstrService.UpdateOrderStatus(soNo, orderStatus);
                return Success("收货成功", result);
            }
            catch (Exception ex)
            {
                return Fail("收货失败：" + ex.Message);
            }
        }
    }
}
