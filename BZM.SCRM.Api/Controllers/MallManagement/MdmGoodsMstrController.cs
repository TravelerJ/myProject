
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Collections.Generic;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiVersion("1.4")]
    [Route("v{version:apiVersion}")]
    public class MdmGoodsMstrController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsMstrService _mdmGoodsMstrService;

        private readonly IMdmGoodsMstrRepository _mdmGoodsMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmGoodsMstrService">服务</param>
        /// </summary>
        public MdmGoodsMstrController(IMdmGoodsMstrService mdmGoodsMstrService, IMdmGoodsMstrRepository mdmGoodsMstrRepository)
        {
            _mdmGoodsMstrService = mdmGoodsMstrService;
            _mdmGoodsMstrRepository = mdmGoodsMstrRepository;
        }

        /// <summary>
        /// 获取秒杀商品数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsMstr/GetMsGoodsPageList"), MapToApiVersion("1.4")]
        public ActionResult GetMsGoodsPageList(MdmGoodsMstrQuery query)
        {
            try
            {
                var result = _mdmGoodsMstrRepository.GetMsGoodsPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取秒杀商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsMstr/GetMsGoodsInfo"), MapToApiVersion("1.4")]
        public ActionResult GetMsGoodsInfo(string id)
        {
            try
            {
                var result = _mdmGoodsMstrRepository.GetAllList(m => m.GL_ID == id && m.CREATE_ORG_NO == AbpSession.ORG_NO);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取商品规格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsMstr/GetGoodsSpecById"), MapToApiVersion("1.4")]
        public ActionResult GetGoodsSpecById(string id)
        {
            try
            {
                var result = _mdmGoodsMstrRepository.GetGoodsSpecById(id);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存秒杀商品
        /// </summary>
        /// <param name="mdmGoodsMstrDtos"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsMstr/SaveMsGoodsInfo"), MapToApiVersion("1.4")]
        public ActionResult SaveMsGoods([FromBody]List<MdmGoodsMstrDto> mdmGoodsMstrDtos)
        {
            try
            {
                _mdmGoodsMstrService.SaveMsGoodsInfo(mdmGoodsMstrDtos);
                return Success("保存成功");
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }
    }
}
