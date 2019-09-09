
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctAppMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctAppMstr ToEntity( this WctAppMstrDto dto ) {
            if( dto == null )
                return new WctAppMstr();
            return new WctAppMstr() {
                Id = dto.Id,
                APP_KEY = dto.APP_KEY,
                APP_NAME = dto.APP_NAME,
                WCT_MODULE_ID = dto.WCT_MODULE_ID,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                WCT_APP_URL = dto.WCT_APP_URL,
                WCT_MODULE_TYPE = dto.WCT_MODULE_TYPE,
                SYS_MODULE_IDS = dto.SYS_MODULE_IDS,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                APP_SORT = dto.APP_SORT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctAppMstrDto ToDto( this WctAppMstr entity ) {
             if( entity == null )
                return new WctAppMstrDto();
            return new WctAppMstrDto {
                Id = entity.Id,
                APP_KEY = entity.APP_KEY,      
                APP_NAME = entity.APP_NAME,      
                WCT_MODULE_ID = entity.WCT_MODULE_ID,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                WCT_APP_URL = entity.WCT_APP_URL,      
                WCT_MODULE_TYPE = entity.WCT_MODULE_TYPE,      
                SYS_MODULE_IDS = entity.SYS_MODULE_IDS,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                APP_SORT = entity.APP_SORT
            };
        }
    }
}