
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using System;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器(商品属性弃用)
    /// </summary>
    [ApiVersion("1.4")]
    [Route("v{version:apiVersion}")]
    public class MdmGoodsPropertyMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsPropertyMstrService _mdmGoodsPropertyMstrService;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmGoodsPropertyMstrService">服务</param>
        /// </summary>
        public MdmGoodsPropertyMstrController(IMdmGoodsPropertyMstrService mdmGoodsPropertyMstrService)
        {
            _mdmGoodsPropertyMstrService = mdmGoodsPropertyMstrService;
        }

        /// <summary>
        /// 获取商品分类属性
        /// </summary>
        /// <param name="goodsClassId"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsPropertyMstr/GetPropertyList"), MapToApiVersion("1.4")]
        public ActionResult GetPropertyList(string goodsClassId)
        {
            try
            {
                var result = _mdmGoodsPropertyMstrService.GetPropertyList(goodsClassId);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存商品属性
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsPropertyMstr/SaveGoodsProperty"), MapToApiVersion("1.4")]
        public ActionResult SaveGoodsProperty([FromBody]MdmGoodsPropertyMstrDto dto)
        {
            try
            {
                _mdmGoodsPropertyMstrService.SaveGoodsProperty(dto);
                return Success("保存成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除商品属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsPropertyMstr/DelGoodsProperty"), MapToApiVersion("1.4")]
        public ActionResult DelGoodsProperty(string id)
        {
            try
            {
                _mdmGoodsPropertyMstrService.DelGoodsProperty(id);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("删除失败：" + ex.Message);
            }
        }
    }
}
