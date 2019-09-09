
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class TagHistDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static TagHist ToEntity( this TagHistDto dto ) {
            if( dto == null )
                return new TagHist();
            return new TagHist() {
                Id = dto.Id,
                TAG_CODE = dto.TAG_CODE,
                TAG_MSTR_ID = dto.TAG_MSTR_ID,
                TAG_VERSION = dto.TAG_VERSION,
                TAG_VALUE = dto.TAG_VALUE,
                TAG_VALUE_DESC = dto.TAG_VALUE_DESC,
                TAG_REF_DB_ID = dto.TAG_REF_DB_ID,
                TAG_REF_TABLE_ID = dto.TAG_REF_TABLE_ID,
                TAG_REF_FIELD_ID = dto.TAG_REF_FIELD_ID,
                TAG_REF_ROW_NO = dto.TAG_REF_ROW_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_TIME = dto.CREATE_TIME,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                TAG_SDATE = dto.TAG_SDATE,
                TAG_EDATE = dto.TAG_EDATE,
                TAG_FROM = dto.TAG_FROM,
                TAG_RULE_ID = dto.TAG_RULE_ID,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static TagHistDto ToDto( this TagHist entity ) {
             if( entity == null )
                return new TagHistDto();
            return new TagHistDto {
                Id = entity.Id,
                TAG_CODE = entity.TAG_CODE,      
                TAG_MSTR_ID = entity.TAG_MSTR_ID,      
                TAG_VERSION = entity.TAG_VERSION,      
                TAG_VALUE = entity.TAG_VALUE,      
                TAG_VALUE_DESC = entity.TAG_VALUE_DESC,      
                TAG_REF_DB_ID = entity.TAG_REF_DB_ID,      
                TAG_REF_TABLE_ID = entity.TAG_REF_TABLE_ID,      
                TAG_REF_FIELD_ID = entity.TAG_REF_FIELD_ID,      
                TAG_REF_ROW_NO = entity.TAG_REF_ROW_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_TIME = entity.CREATE_TIME,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                TAG_SDATE = entity.TAG_SDATE,      
                TAG_EDATE = entity.TAG_EDATE,      
                TAG_FROM = entity.TAG_FROM,      
                TAG_RULE_ID = entity.TAG_RULE_ID,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}