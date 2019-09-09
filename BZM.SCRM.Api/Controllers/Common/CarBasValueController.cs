using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BZM.SCRM.Domain.Common.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BZM.SCRM.Api.Controllers.Common
{
    /// <summary>
    /// 车型基础数据
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class CarBasValueController : SCRMControllerBase
    {
        /// <summary>
        /// 获取车型基础数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("CarBasValue/GetCarInfo"), MapToApiVersion("1.0")]
        public ActionResult GetCarInfo(int level, string parentids = "", string ids = "")
        {
            string msg = "";
            try
            {
                var result = CarHelper.GetCarInfo(AbpSession.BG_NO, level, ref msg, parentids, ids);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取车型数据失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取二手车库存信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("CarBasValue/GetUseCarStockInfo"), MapToApiVersion("1.0")]
        public ActionResult GetUseCarStockInfo()
        {
            string msg = "";
            try
            {
                var result = CarHelper.GetUseCarStockInfo(AbpSession.BG_NO, AbpSession.ORG_NO, ref msg);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取车型数据失败：" + ex.Message);
            }
        }
    }
}