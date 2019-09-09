
using Abp.Dependency;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System.Linq;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class SysRoleMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static SysRoleMstr ToEntity( this SysRoleMstrDto dto ) {
            if( dto == null )
                return new SysRoleMstr();
            return new SysRoleMstr() {
                Id = dto.Id,
                ROLE_NAME = dto.ROLE_NAME,
                ROLE_SCOPE = dto.ROLE_SCOPE,
                ROLE_STATUS = dto.ROLE_STATUS,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                ROLE_DESC = dto.ROLE_DESC,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static SysRoleMstrDto ToDto( this SysRoleMstr entity ) {
             if( entity == null )
                return new SysRoleMstrDto();
            return new SysRoleMstrDto {
                Id = entity.Id,
                ROLE_NAME = entity.ROLE_NAME,      
                ROLE_SCOPE = entity.ROLE_SCOPE,      
                ROLE_STATUS = entity.ROLE_STATUS,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                ROLE_DESC = entity.ROLE_DESC,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                BG_NO = entity.BG_NO,
                menuIds= GetMenuIds(entity.Id)
            };
        }

        private static string GetMenuIds(decimal roleId)
        {
            var menuIds = "";
            if (roleId == 0)
                return menuIds;
            var menuPermissions = IocManager.Instance.IocContainer.Resolve<ISysRoleMenuPermissionRepository>().GetAllList(c => c.ROLE_ID == roleId).OrderBy(c => c.Id).ToList();
            if (menuPermissions.Count > 0)
            {
                menuIds = string.Join(',', menuPermissions.Select(c => c.PERMISSION).ToList());
            }
            return menuIds;
        }
    }
}