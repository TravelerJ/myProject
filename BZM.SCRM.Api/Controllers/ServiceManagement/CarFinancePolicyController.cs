
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
    /// 控制器(金融政策：CAR_FINANCE_POLICY)
    /// </summary>
    [ApiVersion("1.2")]
    [Route("v{version:apiVersion}")]
    public class CarFinancePolicyController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICarFinancePolicyService _carFinancePolicyService;

        private readonly ICarFinancePolicyRepository _carFinancePolicyRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="carFinancePolicyService">服务</param>
        /// </summary>
        public CarFinancePolicyController(ICarFinancePolicyService carFinancePolicyService, ICarFinancePolicyRepository carFinancePolicyRepository)
        {
            _carFinancePolicyService = carFinancePolicyService;
            _carFinancePolicyRepository = carFinancePolicyRepository;
        }

        /// <summary>
        /// 分页获取金融政策信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("CarFinancePolicy/GetFinancePolicyList"), MapToApiVersion("1.2")]
        public ActionResult GetFinancePolicyList(CarFinancePolicyQuery query)
        {
            try
            {
                var result = _carFinancePolicyRepository.GetFinancePolicyList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取已选和可选标签
        /// </summary>
        /// <param name="code"></param>
        /// <param name="level"></param>
        /// <param name="subCode"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet("CarFinancePolicy/GetOptionalTagList"), MapToApiVersion("1.2")]
        public ActionResult GetOptionalTagList(string code, int level, string subCode, string vin = "")
        {
            try
            {
                var result = _carFinancePolicyService.GetOptionalTagList(code, level, subCode, vin);
                return Success("获取标签成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取标签失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取金融政策信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CarFinancePolicy/GetCarPolicyInfo"), MapToApiVersion("1.2")]
        public ActionResult GetCarPolicyInfo(string id)
        {
            try
            {
                var result = _carFinancePolicyRepository.Get(id);
                return Success("获取政策成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取政策失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存金融政策信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CarFinancePolicy/SaveCarPolicyInfo"), MapToApiVersion("1.2")]
        public ActionResult SaveCarPolicyInfo([FromBody]CarFinancePolicyDto dto)
        {
            try
            {
                var msg = "";
                var result = _carFinancePolicyService.SavePolicyInfo(dto, ref  msg);
                if (!result)
                    return Fail(msg);
                return Success("保存政策成功");
            }
            catch (Exception ex)
            {
                return Fail("保存政策失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取金融政策信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("CarFinancePolicy/DeleteCarPolicyInfo"), MapToApiVersion("1.2")]
        public ActionResult DeleteCarPolicyInfo(string id)
        {
            try
            {
                _carFinancePolicyService.DeletePolicy(id);
                return Success("删除政策成功");
            }
            catch (Exception ex)
            {
                return Fail("删除政策失败：" + ex.Message);
            }
        }
    }
}
