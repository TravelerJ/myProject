
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;

namespace SCRM.Controllers.WeChatPlatform
{
    /// <summary>
    /// 微信菜单控制器
    /// </summary>
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}")]
    public class WctMenuMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 微信菜单服务
        /// </summary>
        private readonly IWctMenuMstrService _wctMenuMstrService;
        /// <summary>
        /// 微信菜单仓储
        /// </summary>
        private readonly IWctMenuMstrRepository _wctMenuMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="wctMenuMstrService">微信菜单服务</param>
        /// <param name="wctMenuMstrRepository">微信菜单仓储</param>
        /// </summary>
        public WctMenuMstrController( IWctMenuMstrService wctMenuMstrService,
            IWctMenuMstrRepository wctMenuMstrRepository) {
            _wctMenuMstrService = wctMenuMstrService;
            _wctMenuMstrRepository = wctMenuMstrRepository;
        }

        /// <summary>
        /// 获取微信菜单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("WctMenuMstr/GetWxMenuList"), MapToApiVersion("1.1")]
        public ActionResult GetWxMenuList(WctMenuMstrQuery query)
        {
            try
            {
                var result = _wctMenuMstrRepository.GetWxMenuList(query);
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
        /// <summary>
        /// 保存微信菜单列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("WctMenuMstr/SaveWxMenuInfo"), MapToApiVersion("1.1")]
        public ActionResult SaveWxMenuInfo([FromBody]WctMenuMstrDto dto)
        {
            try
            {
                var result = _wctMenuMstrService.SaveWxMenuInfo(dto);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("保存成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除微信菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpPost("WctMenuMstr/DelWxMenuInfo"), MapToApiVersion("1.1")]
        public ActionResult DelWxMenuInfo(string menuId)
        {
            try
            {
                _wctMenuMstrRepository.Delete(menuId);
                return Success("操作成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 发布微信菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("WctMenuMstr/PublishWxMenu"), MapToApiVersion("1.1")]
        public ActionResult PublishWxMenu()
        {
            try
            {
                var publish = _wctMenuMstrService.PublishWxMenu();
                if (!publish.IsSuccess)
                    return Fail(publish.msg);
                return Success("发布成功");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
