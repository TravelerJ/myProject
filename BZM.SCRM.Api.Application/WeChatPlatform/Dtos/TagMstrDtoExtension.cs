
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class TagMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static TagMstr ToEntity( this TagMstrDto dto ) {
            if( dto == null )
                return new TagMstr();
            return new TagMstr() {
                Id = dto.Id,
                TAG_MSTR_DESC = dto.TAG_MSTR_DESC,
                TAG_TYPE = dto.TAG_TYPE,
                TAG_REF_DB_ID = dto.TAG_REF_DB_ID,
                TAG_REF_TABLE_ID = dto.TAG_REF_TABLE_ID,
                TAG_REF_FIELD_ID = dto.TAG_REF_FIELD_ID,
                TAG_STATUS = dto.TAG_STATUS,
                WORKFLOW_NO = dto.WORKFLOW_NO,
                DEL_FLAG = dto.DEL_FLAG,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                TAG_NAME = dto.TAG_NAME,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static TagMstrDto ToDto( this TagMstr entity ) {
             if( entity == null )
                return new TagMstrDto();
            return new TagMstrDto {
                Id = entity.Id,
                TAG_MSTR_DESC = entity.TAG_MSTR_DESC,      
                TAG_TYPE = entity.TAG_TYPE,      
                TAG_REF_DB_ID = entity.TAG_REF_DB_ID,      
                TAG_REF_TABLE_ID = entity.TAG_REF_TABLE_ID,      
                TAG_REF_FIELD_ID = entity.TAG_REF_FIELD_ID,      
                TAG_STATUS = entity.TAG_STATUS,      
                WORKFLOW_NO = entity.WORKFLOW_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                TAG_NAME = entity.TAG_NAME,      
                BG_NO = entity.BG_NO
            };
        }
    }
}