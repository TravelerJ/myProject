
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Controllers.ServiceManagement
{
    /// <summary>
    /// 控制器(门店宣传：store_advertise_mstr)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class StoreAdvertiseMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IStoreAdvertiseMstrService _storeAdvertiseMstrService;

        private readonly IStoreAdvertiseMstrRepository _storeAdvertiseMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="storeAdvertiseMstrService">服务</param>
        /// </summary>
        public StoreAdvertiseMstrController(IStoreAdvertiseMstrService storeAdvertiseMstrService, IStoreAdvertiseMstrRepository storeAdvertiseMstrRepository)
        {
            _storeAdvertiseMstrService = storeAdvertiseMstrService;
            _storeAdvertiseMstrRepository = storeAdvertiseMstrRepository;
        }

        /// <summary>
        /// 获取保险续保分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("StoreAdvertiseMstr/GetStoreAdvertisePageList"), MapToApiVersion("1.2")]
        public ActionResult GetStoreAdvertisePageList(StoreAdvertiseMstrQuery query)
        {
            try
            {
                var result = _storeAdvertiseMstrRepository.GetStoreAdvertisePageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取保险续保信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("StoreAdvertiseMstr/GetStoreAdvertiseInfoById"), MapToApiVersion("1.2")]
        public ActionResult GetStoreAdvertiseInfoById(string id)
        {
            try
            {
                var result = _storeAdvertiseMstrRepository.Get(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取信息失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 启用/禁用保险续保
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("StoreAdvertiseMstr/EnableAdvertise"), MapToApiVersion("1.2")]
        public ActionResult EnableAdvertise(string id)
        {
            try
            {
                var result = _storeAdvertiseMstrService.EnableAdvertise(id);
                if (result == null)
                {
                    return Fail("操作失败");
                }
                string str = result.ADVERTISE_STATUS == 2 ? "禁用" : "启用";

                return Success($"{str}成功", result);
            }
            catch (Exception ex)
            {
                return Fail("操作失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除保险续保
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("StoreAdvertiseMstr/DeleteAdvertise"), MapToApiVersion("1.2")]
        public ActionResult DeleteAdvertise(string ids)
        {
            try
            {
                _storeAdvertiseMstrService.DeleteAdvertise(ids);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 创建保险续保
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("StoreAdvertiseMstr/InsertAdvertise"), MapToApiVersion("1.2")]
        public ActionResult InsertAdvertise([FromBody]StoreAdvertiseMstrDto dto)
        {
            try
            {
                var result = _storeAdvertiseMstrService.InsertAdvertise(dto);
                if (result == null)
                {
                    return Fail("保存失败");
                }
                return Success("保存成功", result);
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }
    }
}
