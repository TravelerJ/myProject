
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctReplyMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctReplyMstr ToEntity( this WctReplyMstrDto dto ) {
            if( dto == null )
                return new WctReplyMstr();
            return new WctReplyMstr() {
                Id = dto.Id,
                REPLY_KEYWORD = dto.REPLY_KEYWORD,
                REPLY_CONTENT_TYPE = dto.REPLY_CONTENT_TYPE,
                REPLY_TEXT = dto.REPLY_TEXT,
                REPLY_ID_NO = dto.REPLY_ID_NO,
                REPLY_TYPE = dto.REPLY_TYPE,
                REPLY_DISPLAY_INDEX = dto.REPLY_DISPLAY_INDEX,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
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
                MATERIAL_IDS = dto.MATERIAL_IDS,
                REPLY_STATUS = dto.REPLY_STATUS,
                MEDIA_ID = dto.MEDIA_ID,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctReplyMstrDto ToDto( this WctReplyMstr entity ) {
             if( entity == null )
                return new WctReplyMstrDto();
            return new WctReplyMstrDto {
                Id = entity.Id,
                REPLY_KEYWORD = entity.REPLY_KEYWORD,      
                REPLY_CONTENT_TYPE = entity.REPLY_CONTENT_TYPE,      
                REPLY_TEXT = entity.REPLY_TEXT,      
                REPLY_ID_NO = entity.REPLY_ID_NO,      
                REPLY_TYPE = entity.REPLY_TYPE,      
                REPLY_DISPLAY_INDEX = entity.REPLY_DISPLAY_INDEX,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
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
                MATERIAL_IDS = entity.MATERIAL_IDS,      
                REPLY_STATUS = entity.REPLY_STATUS,      
                MEDIA_ID = entity.MEDIA_ID,      
                BG_NO = entity.BG_NO
            };
        }
    }
}