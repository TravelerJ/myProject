
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using System;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class SysRoleMstrController :SCRMControllerBase  {
        
        /// <summary>
        /// 角色服务
        /// </summary>
        private readonly ISysRoleMstrService _sysRoleMstrService;
        /// <summary>
        /// 角色仓储
        /// </summary>
        private readonly ISysRoleMstrRepository _sysRoleMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="sysRoleMstrService">角色服务</param>
        /// <param name="sysRoleMstrRepository">角色仓储</param>
        /// </summary>
        public SysRoleMstrController( ISysRoleMstrService sysRoleMstrService,
            ISysRoleMstrRepository sysRoleMstrRepository) {
            _sysRoleMstrService = sysRoleMstrService;
            _sysRoleMstrRepository = sysRoleMstrRepository;
        }

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpGet("SysRoleMstr/GetRoleList"), MapToApiVersion("1.0")]
        public ActionResult GetRoleList(decimal? userId)
        {
            try
            {
                var roleList = _sysRoleMstrService.GetRoleList(userId);
                return Success("获取成功", roleList.result);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        [HttpGet("SysRoleMstr/GetRoleInfo"), MapToApiVersion("1.0")]
        public ActionResult GetRoleInfo(decimal? roleId)
        {
            try
            {
                if (roleId == null)
                    return Fail("数据传输异常");
                var role = _sysRoleMstrRepository.FirstOrDefault(c => c.Id == roleId).ToDto();
                return Success("获取成功", role);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取角色权限分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("SysRoleMstr/GetRolePageList"), MapToApiVersion("1.0")]
        public ActionResult GetRolePageList(SysRoleMstrQuery query)
        {
            try
            {
                var result = _sysRoleMstrService.GetRolePageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {

                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SysRoleMstr/SaveSysRoleInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveSysRoleInfo([FromBody]SysRoleMstrDto dto)
        {
            try
            {
                var result = _sysRoleMstrService.SaveSysRoleInfo(dto);
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
        /// 删除角色信息
        /// </summary>
        /// <param name="roleIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("MdmDutyMstr/DelSysRoleInfo"), MapToApiVersion("1.0")]
        public ActionResult DelSysRoleInfo(string roleIds)
        {
            try
            {
                var result = _sysRoleMstrService.DelSysRoleInfo(roleIds);
                if (!result.IsSuccess)
                    return Fail(result.msg);
                return Success("删除成功");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
