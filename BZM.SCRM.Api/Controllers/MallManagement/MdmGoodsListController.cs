
using BZM.SCRM.Api.Controllers;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using System;

namespace SCRM.Controllers.MallManagement
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiVersion("1.4")]
    [Route("v{version:apiVersion}")]
    public class MdmGoodsListController : SCRMControllerBase
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IMdmGoodsListService _mdmGoodsListService;
        private readonly IMdmGoodsListRepository _mdmGoodsListRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmGoodsListService">服务</param>
        /// </summary>
        public MdmGoodsListController(IMdmGoodsListService mdmGoodsListService, IMdmGoodsListRepository mdmGoodsListRepository)
        {
            _mdmGoodsListService = mdmGoodsListService;
            _mdmGoodsListRepository = mdmGoodsListRepository;
        }

        #region erp商品管理
        /// <summary>
        /// 获取erp商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsList/GetErpGoodsInfoList"), MapToApiVersion("1.4")]
        public ActionResult GetErpGoodsInfoList(GoodsInfoInputModel model)
        {
            try
            {
                var result = _mdmGoodsListService.GetGoodsInfoList(model);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 保存erp商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsList/SaveErpGoodsInfo"), MapToApiVersion("1.4")]
        public ActionResult SaveErpGoodsInfo([FromBody]GoodsInfoListModel model)
        {
            try
            {
                var result = _mdmGoodsListService.SaveErpGoodsInfo(model);
                return Success("保存成功", result);
            }
            catch (Exception ex)
            {
                return Fail("保存失败:" + ex.Message);
            }
        }

        /// <summary>
        /// erp商品上架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsList/PutAwayGoods"), MapToApiVersion("1.4")]
        public ActionResult PutAwayGoods(GoodsInfoListModel model)
        {
            try
            {
                _mdmGoodsListService.PutAwayGoods(model);
                return Success("上架成功");
            }
            catch (Exception ex)
            {
                return Fail("上架失败:" + ex.Message);
            }
        }

        /// <summary>
        /// erp商品下架
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsList/OffRackGoods"), MapToApiVersion("1.4")]
        public ActionResult OffRackGoods(string goodsId)
        {
            try
            {
                _mdmGoodsListService.OffRackGoods(goodsId);
                return Success("下架成功");
            }
            catch (Exception ex)
            {
                return Fail("下架失败:" + ex.Message);
            }
        }

        #endregion

        #region 商品管理
        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsList/GetGoodsInfoPageList"), MapToApiVersion("1.4")]
        public ActionResult GetGoodsInfoPageList(MdmGoodsListQuery query)
        {
            try
            {
                var result = _mdmGoodsListRepository.GetGoodsInfoPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MdmGoodsList/GetGoodsInfoById"), MapToApiVersion("1.4")]
        public ActionResult GetGoodsInfoById(string id)
        {
            try
            {
                var result = _mdmGoodsListRepository.FirstOrDefault(c => c.Id == id && c.DEL_FLAG == 1);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail("获取失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 商品上架/下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("MdmGoodsList/SetGoodsInfoStatus"), MapToApiVersion("1.4")]
        public ActionResult SetGoodsInfoStatus(string id)
        {
            try
            {
                var result = _mdmGoodsListService.SetGoodsInfoStatus(id);
                if(!result.IsSuccess)
                    return Fail(result.msg);
                return Success(result.msg);
            }
            catch (Exception ex)
            {
                return Fail("error：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("MdmGoodsList/SaveGoodsInfo"), MapToApiVersion("1.4")]
        public ActionResult SaveGoodsInfo([FromBody]MdmGoodsListDto mdmGoodsListDto)
        {
            string msg = "";
            try
            {
                _mdmGoodsListService.SaveGoodsInfo(mdmGoodsListDto, ref msg);
                return Success("保存成功" + msg);
            }
            catch (Exception ex)
            {
                return Fail("error：" + ex.Message + msg);
            }
        }
        #endregion
    }
}
