
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using Newtonsoft.Json;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using Spring.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class SysRoleMstrService : SCRMAppServiceBase, ISysRoleMstrService {
    
        /// <summary>
        /// 角色仓储
        /// </summary>
        private readonly ISysRoleMstrRepository _sysRoleMstrRepository;
        /// <summary>
        /// 角色与用户关系仓储
        /// </summary>
        private readonly ISysUsrAuthRepository _sysUsrAuthRepository;
        /// <summary>
        /// 角色菜单
        /// </summary>
        private readonly ISysRoleMenuPermissionRepository _sysRoleMenuPermissionRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 菜单仓储
        /// </summary>
        private readonly ISysNavTreeRepository _sysNavTreeRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public SysRoleMstrService( ISysRoleMstrRepository sysRoleMstrRepository,
            ISysUsrAuthRepository sysUsrAuthRepository,
            InitHelper initHelper,
            ISysRoleMenuPermissionRepository sysRoleMenuPermissionRepository,
            ISysNavTreeRepository sysNavTreeRepository) {
            _sysRoleMstrRepository = sysRoleMstrRepository;
            _sysUsrAuthRepository = sysUsrAuthRepository;
            _initHelper = initHelper;
            _sysRoleMenuPermissionRepository = sysRoleMenuPermissionRepository;
            _sysNavTreeRepository = sysNavTreeRepository;
        }

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ReturnMsg GetRoleList(decimal? userId)
        {
            var rm = new ReturnMsg();
            var sql = "";
            if (userId == null)
                userId = AbpSession.USR_ID;
            var auth = _sysUsrAuthRepository.FirstOrDefault(c => c.USR_ID == userId && c.DEL_FLAG == 1);
            if (auth != null)
                sql = " or ROLE_ID=" + auth.ROLE_ID + "";
            var roleList = _sysRoleMstrRepository.GetRoleList(sql);
            rm.IsSuccess = true;
            rm.result = JsonConvert.SerializeObject(roleList);

            return rm;
        }

        /// <summary>
        /// 获取角色权限分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetRolePageList(SysRoleMstrQuery query)
        {
            var rm = new ReturnMsg();
            var auth = _sysUsrAuthRepository.FirstOrDefault(c => c.USR_ID == AbpSession.USR_ID && c.DEL_FLAG == 1);
            if (auth != null)
                query.sql = " or role.ROLE_ID=" + auth.ROLE_ID + "";
            var roleList = _sysRoleMstrRepository.GetRolePageList(query);
            return roleList;
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveSysRoleInfo(SysRoleMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new SysRoleMstr();
            if (string.IsNullOrEmpty(dto.ROLE_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入角色名称";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.ROLE_SCOPE))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择角色范围";
                return rm;
            }
            if (dto.Id == 0)
            {
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _sysRoleMstrRepository.InsertAndGetId(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _sysRoleMstrRepository.Update(entity);
            }
            if (!string.IsNullOrEmpty(dto.menuIds))
            {
                if (dto.Id != 0)
                {
                    _sysRoleMenuPermissionRepository.DelSysRoleMenuInfo(dto.Id.ToString());
                }
                var list = dto.menuIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var menuList = _sysNavTreeRepository.GetAllList(c => c.DEL_FLAG == 1).Where(c => list.Contains(c.NAV_PARENT_NO)||list.Contains(c.Id)).ToList();

                foreach (var item in menuList)
                {
                    var model = new SysRoleMenuPermission
                    {
                        ROLE_ID = (int)entity.Id,
                        PERMISSION = item.Id,
                        DEL_FLAG = 1
                    };
                    _sysRoleMenuPermissionRepository.Insert(model);
                }
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public ReturnMsg DelSysRoleInfo(string roleIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(roleIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的角色信息";
                return rm;
            }
            _sysRoleMstrRepository.BatchDelSysRoleInfo(roleIds);
            _sysRoleMenuPermissionRepository.DelSysRoleMenuInfo(roleIds);
            rm.IsSuccess = true;
            return rm;

        }
    }
}
