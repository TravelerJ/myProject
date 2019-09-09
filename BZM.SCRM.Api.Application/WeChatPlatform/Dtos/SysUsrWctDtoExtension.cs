
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class SysUsrWctDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static SysUsrWct ToEntity( this SysUsrWctDto dto ) {
            if( dto == null )
                return new SysUsrWct();
            return new SysUsrWct() {
                Id = dto.Id,
                BU_NO = dto.BU_NO,
                USR_ID = dto.USR_ID,
                OPEN_ID = dto.OPEN_ID,
                CUS_SVC_CODE = dto.CUS_SVC_CODE,
                FOLLOW_STATUS = dto.FOLLOW_STATUS,
                USR_SOURCE = dto.USR_SOURCE,
                REG_DATE = dto.REG_DATE,
                REFEREE_USR_ID = dto.REFEREE_USR_ID,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                UDF6 = dto.UDF6,
                UDF7 = dto.UDF7,
                UDF8 = dto.UDF8,
                UDF9 = dto.UDF9,
                UDF10 = dto.UDF10,
                DEL_FLAG = dto.DEL_FLAG,
                WX_AVATAR_URL = dto.WX_AVATAR_URL,
                APP_ID = dto.APP_ID,
                TAG_NAME = dto.TAG_NAME,
                TICKET = dto.TICKET,
                BG_NO = dto.BG_NO,
                AFTER_SALE_CODE = dto.AFTER_SALE_CODE
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static SysUsrWctDto ToDto( this SysUsrWct entity ) {
             if( entity == null )
                return new SysUsrWctDto();
            return new SysUsrWctDto {
                Id = entity.Id,
                BU_NO = entity.BU_NO,      
                USR_ID = entity.USR_ID,      
                OPEN_ID = entity.OPEN_ID,      
                CUS_SVC_CODE = entity.CUS_SVC_CODE,      
                FOLLOW_STATUS = entity.FOLLOW_STATUS,      
                USR_SOURCE = entity.USR_SOURCE,      
                REG_DATE = entity.REG_DATE,      
                REFEREE_USR_ID = entity.REFEREE_USR_ID,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                UDF6 = entity.UDF6,      
                UDF7 = entity.UDF7,      
                UDF8 = entity.UDF8,      
                UDF9 = entity.UDF9,      
                UDF10 = entity.UDF10,      
                DEL_FLAG = entity.DEL_FLAG,      
                WX_AVATAR_URL = entity.WX_AVATAR_URL,      
                APP_ID = entity.APP_ID,      
                TAG_NAME = entity.TAG_NAME,      
                TICKET = entity.TICKET,      
                BG_NO = entity.BG_NO,      
                AFTER_SALE_CODE = entity.AFTER_SALE_CODE
            };
        }
    }
}