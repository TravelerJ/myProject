using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class SysUsrAuthDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static SysUsrAuth ToEntity( this SysUsrAuthDto dto ) {
            if( dto == null )
                return new SysUsrAuth();
            return new SysUsrAuth() {
                Id = dto.Id,
                USR_ID = dto.USR_ID,
                ROLE_ID = dto.ROLE_ID,
                SP_MENU_RIGHT = dto.SP_MENU_RIGHT,
                SP_DATA_RIGHT = dto.SP_DATA_RIGHT,
                SP_SYS_RIGHT = dto.SP_SYS_RIGHT,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static SysUsrAuthDto ToDto( this SysUsrAuth entity ) {
             if( entity == null )
                return new SysUsrAuthDto();
            return new SysUsrAuthDto {
                Id = entity.Id,
                USR_ID = entity.USR_ID,      
                ROLE_ID = entity.ROLE_ID,      
                SP_MENU_RIGHT = entity.SP_MENU_RIGHT,      
                SP_DATA_RIGHT = entity.SP_DATA_RIGHT,      
                SP_SYS_RIGHT = entity.SP_SYS_RIGHT,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}