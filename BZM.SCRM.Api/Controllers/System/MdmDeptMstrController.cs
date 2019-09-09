
using BZM.SCRM.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using System;
using System.Linq;

namespace SCRM.Controllers.System
{
    /// <summary>
    /// 部门控制器
    /// </summary>、
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class MdmDeptMstrController :SCRMControllerBase  {

        /// <summary>
        /// 部门服务
        /// </summary>
        private readonly IMdmDeptMstrService _mdmDeptMstrService;
        /// <summary>
        /// 部门仓储
        /// </summary>
        private readonly IMdmDeptMstrRepository _mdmDeptMstrRepository;

        /// <summary>
        /// 初始化控制器
        /// <param name="mdmDeptMstrService">部门服务</param>
        /// <param name="mdmDeptMstrRepository">部门仓储</param>
        /// </summary>
        public MdmDeptMstrController( IMdmDeptMstrService mdmDeptMstrService,
            IMdmDeptMstrRepository mdmDeptMstrRepository) {
            _mdmDeptMstrService = mdmDeptMstrService;
            _mdmDeptMstrRepository = mdmDeptMstrRepository;
        }

        /// <summary>
        /// 获取部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("MdmDeptMstr/GetMdmDeptPageList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDeptPageList(MdmDeptMstrQuery query)
        {
            try
            {
                var result = _mdmDeptMstrRepository.GetMdmDeptPageList(query);
                return Page(result.Data, result.Page);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("MdmDeptMstr/GetMdmDeptList"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDeptList()
        {
            try
            {
                var result = _mdmDeptMstrRepository.GetMdmDeptList();
                return Success("获取成功",result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取部门详情
        /// </summary>
        /// <param name="deptId">部门id</param>
        /// <returns></returns>
        [HttpGet("MdmDeptMstr/GetMdmDeptInfo"), MapToApiVersion("1.0")]
        public ActionResult GetMdmDeptInfo(decimal deptId)
        {
            try
            {
                if (deptId == 0)
                    return Fail("数据传输异常");
                var result = _mdmDeptMstrRepository.FirstOrDefault(c => c.Id == deptId && c.DEL_FLAG == 1).ToDto();
                return Success("获取成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("MdmDeptMstr/SaveMdmDeptInfo"), MapToApiVersion("1.0")]
        public ActionResult SaveMdmDeptfo([FromBody]MdmDeptMstrDto dto)
        {
            try
            {
                var result = _mdmDeptMstrService.SaveMdmDeptInfo(dto);
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
        /// 删除部门信息
        /// </summary>
        /// <param name="deptIds">主键,隔开</param>
        /// <returns></returns>
        [HttpPost("MdmDeptMstr/DelMdmDeptInfo"), MapToApiVersion("1.0")]
        public ActionResult DelMdmDeptInfo(string deptIds)
        {
            try
            {
                var result = _mdmDeptMstrService.DelMdmDeptInfo(deptIds);
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
