using Abp.Domain.Uow;
using BT.BPMLIVE.Common;
using BZM.SCRM.Api.Controllers;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Infrastructure.CommonHelper;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Oracle.ManagedDataAccess.Client;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class SysUsrMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 用户表服务
        /// </summary>
        private readonly ISysUsrMstrService _sysUsrMstrService;
        /// <summary>
        /// 用户表仓储
        /// </summary>
        private readonly ISysUsrMstrRepository _sysUsrMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="sysUsrMstrService">用户表服务</param>
        /// <param name="sysUsrMstrRepository">用户表仓储</param>
        /// </summary>
        public SysUsrMstrController( ISysUsrMstrService sysUsrMstrService,
            ISysUsrMstrRepository sysUsrMstrRepository) {
            _sysUsrMstrService = sysUsrMstrService;
            _sysUsrMstrRepository = sysUsrMstrRepository;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("SysUsrMstr/Login"), MapToApiVersion("1.0")]       
        [AllowAnonymous]
        public ActionResult Login(SysUsrMstrQuery query)
        {
            try
            {
                var result = _sysUsrMstrService.Login(query);
                if (!result.IsSuccess)
                    return Fail(result.msg);

                return Success(result.msg, result.result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
            
        }

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        [AllowAnonymous]
        [HttpGet("SysUsrMstr/CreateCaptcha"), MapToApiVersion("1.0")]
        public async Task<ActionResult> CreateCaptcha(CreateCaptcha captcha)
        {
            GetBaseInfo.Log.Write("aaa");
            CaptchaHelper vch = new CaptchaHelper();
            try
            {
                var model = await vch.CreateCaptcha(captcha.codeNum, captcha.width, captcha.height);
                return Success("获取成功", model);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
           
        }

        /// <summary>
        /// 获取员工分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("SysUsrMstr/GetSysUsrPageList"), MapToApiVersion("1.0")]
        public ActionResult GetSysUsrPageList(SysUsrMstrQuery query)
        {
            try
            {
                var result = _sysUsrMstrRepository.GetSysUsrPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpGet("SysUsrMstr/GetSysUsrInfo"), MapToApiVersion("1.0")]
        public ActionResult GetSysUsrInfo(decimal userId)
        {
            try
            {
                if (userId == 0)
                    return Fail("数据传输异常");
                var result = _sysUsrMstrRepository.FirstOrDefault(c => c.Id == userId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SysUsrMstr/SaveSysUsrInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveSysUsrInfo([FromBody]SysUsrMstrDto dto)
        {
            try
            {
                var result = _sysUsrMstrService.SaveSysUsrInfo(dto);
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
        /// 删除用户信息
        /// </summary>
        /// <param name="userIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("SysUsrMstr/DelSysUsrInfo"), MapToApiVersion("1.0")]
        public ActionResult DelSysUsrInfo(string userIds)
        {
            try
            {
                var result = _sysUsrMstrService.DelSysUsrInfo(userIds);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("SysUsrMstr/ResetPassWord"), MapToApiVersion("1.0")]
        public ActionResult ResetPassWord(decimal? userId)
        {
            try
            {
                var reset = _sysUsrMstrService.ResetPassWord(userId);
                if(!reset.IsSuccess)
                    return Fail(reset.msg);
                return Success("重置密码成功");
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("SysUsrMstr/GetSysUsrMstrNavTree"), MapToApiVersion("1.0")]
        public ActionResult GetSysUsrMstrNavTree()
        {
            try
            {
                var tree = _sysUsrMstrService.GetSysUsrMstrNavTree();
                return Success("获取成功", tree.result);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }
    }
}
