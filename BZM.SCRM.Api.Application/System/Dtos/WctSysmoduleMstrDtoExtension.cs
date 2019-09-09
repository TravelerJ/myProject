using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctSysmoduleMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctSysmoduleMstr ToEntity( this WctSysmoduleMstrDto dto ) {
            if( dto == null )
                return new WctSysmoduleMstr();
            return new WctSysmoduleMstr() {
                Id = dto.Id,
                SYSM_KEY = dto.SYSM_KEY,
                SYSM_TITLE = dto.SYSM_TITLE,
                SYSM_URL_TEMPLATE = dto.SYSM_URL_TEMPLATE,
                SYSM_JSON_VALUE = dto.SYSM_JSON_VALUE,
                SYSM_CODE = dto.SYSM_CODE,
                SYSM_IS_AUTH = dto.SYSM_IS_AUTH,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO,
                SYSM_MODULE_TYPE = dto.SYSM_MODULE_TYPE,
                SYSM_MODULE_LOGO = dto.SYSM_MODULE_LOGO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctSysmoduleMstrDto ToDto( this WctSysmoduleMstr entity ) {
             if( entity == null )
                return new WctSysmoduleMstrDto();
            return new WctSysmoduleMstrDto {
                Id = entity.Id,
                SYSM_KEY = entity.SYSM_KEY,      
                SYSM_TITLE = entity.SYSM_TITLE,      
                SYSM_URL_TEMPLATE = entity.SYSM_URL_TEMPLATE,      
                SYSM_JSON_VALUE = entity.SYSM_JSON_VALUE,      
                SYSM_CODE = entity.SYSM_CODE,      
                SYSM_IS_AUTH = entity.SYSM_IS_AUTH,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO,      
                SYSM_MODULE_TYPE = entity.SYSM_MODULE_TYPE,      
                SYSM_MODULE_LOGO = entity.SYSM_MODULE_LOGO
            };
        }
    }
}