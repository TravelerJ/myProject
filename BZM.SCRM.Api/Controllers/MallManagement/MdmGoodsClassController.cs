
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Repositories;
using System;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiVersion("1.4")]
    [Route("v{version:apiVersion}")]
    public class MdmGoodsClassController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsClassService _mdmGoodsClassService;

        private readonly IMdmGoodsClassRepository _mdmGoodsClassRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmGoodsClassService">服务</param>
        /// </summary>
        public MdmGoodsClassController(IMdmGoodsClassService mdmGoodsClassService, IMdmGoodsClassRepository mdmGoodsClassRepository)
        {
            _mdmGoodsClassService = mdmGoodsClassService;
            _mdmGoodsClassRepository = mdmGoodsClassRepository;
        }

        /// <summary>
        /// 获取商品分类数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmGoodsClass/GetGoodClassList"), MapToApiVersion("1.4")]
        public ActionResult GetGoodClassList()
        {
            try
            {
                var result = _mdmGoodsClassRepository.GetGoodClassList();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取下级分类数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmGoodsClass/GetGoodClassByParentId"), MapToApiVersion("1.4")]
        public ActionResult GetGoodClassByParentId(int parentId)
        {
            try
            {
                var result = _mdmGoodsClassRepository.GetAllList(m => m.PARENT_ID == parentId && m.BG_NO == AbpSession.BG_NO);

                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("MdmGoodsClass/SaveGoodsClass"), MapToApiVersion("1.4")]
        public ActionResult SaveGoodsClass([FromBody]MdmGoodsClassDto dto)
        {
            try
            {
                var result = _mdmGoodsClassService.SaveGoodsClass(dto);
                return Success("保存成功", result);
            }
            catch (Exception ex)
            {
                return Fail("保存失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <returns></returns>
        [HttpPost("MdmGoodsClass/DeleteGoodsClass"), MapToApiVersion("1.4")]
        public ActionResult DeleteGoodsClass(int id)
        {
            try
            {
                _mdmGoodsClassService.DeleteGoodsClass(id);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                return Fail("删除失败：" + ex.Message);
            }
        }
    }
}
