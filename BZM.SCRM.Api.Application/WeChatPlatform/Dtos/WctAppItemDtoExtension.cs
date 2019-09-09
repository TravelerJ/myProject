
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctAppItemDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctAppItem ToEntity( this WctAppItemDto dto ) {
            if( dto == null )
                return new WctAppItem();
            return new WctAppItem() {
                Id = dto.Id,
                MSTR_ID = dto.MSTR_ID,
                ITEM_NAME = dto.ITEM_NAME,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                WCT_APP_URL = dto.WCT_APP_URL,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                ITEM_SORT = dto.ITEM_SORT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctAppItemDto ToDto( this WctAppItem entity ) {
             if( entity == null )
                return new WctAppItemDto();
            return new WctAppItemDto {
                Id = entity.Id,
                MSTR_ID = entity.MSTR_ID,      
                ITEM_NAME = entity.ITEM_NAME,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                WCT_APP_URL = entity.WCT_APP_URL,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                ITEM_SORT = entity.ITEM_SORT
            };
        }
    }
}