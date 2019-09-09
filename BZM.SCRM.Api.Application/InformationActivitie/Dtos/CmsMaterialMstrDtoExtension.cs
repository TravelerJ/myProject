
using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Application.InformationActivitie.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CmsMaterialMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CmsMaterialMstr ToEntity( this CmsMaterialMstrDto dto ) {
            if( dto == null )
                return new CmsMaterialMstr();
            return new CmsMaterialMstr() {
                Id = dto.Id,
                MATERIAL_TYPE_ID = dto.MATERIAL_TYPE_ID,
                MATERIAL_TITLE = dto.MATERIAL_TITLE,
                MATERIAL_AUTHOR = dto.MATERIAL_AUTHOR,
                MATERIAL_COVER_URL = dto.MATERIAL_COVER_URL,
                MATERIAL_CONTENT = dto.MATERIAL_CONTENT,
                MATERIAL_CONTENT_ORI_URL = dto.MATERIAL_CONTENT_ORI_URL,
                MATERIAL_SHOW_COVER = dto.MATERIAL_SHOW_COVER,
                MATERIAL_MEDIA_ID = dto.MATERIAL_MEDIA_ID,
                MATERIAL_DIGEST = dto.MATERIAL_DIGEST,
                MATERIAL_URL = dto.MATERIAL_URL,
                MATERIAL_MODULE_ID = dto.MATERIAL_MODULE_ID,
                MATERIAL_MODULE_PARAM_JSON = dto.MATERIAL_MODULE_PARAM_JSON,
                MATERIAL_IS_AUTH = dto.MATERIAL_IS_AUTH,
                RELEASE_DATE = dto.RELEASE_DATE,
                MATERIAL_IS_TOP = dto.MATERIAL_IS_TOP,
                MATERIAL_WCT_CONTENT = dto.MATERIAL_WCT_CONTENT,
                MATERIAL_WCT_COVER_URL = dto.MATERIAL_WCT_COVER_URL,
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
                MATERIAL_ALIGN_TYPE = dto.MATERIAL_ALIGN_TYPE,
                MATERIAL_TITLE_EN = dto.MATERIAL_TITLE_EN,
                MATERIAL_SORT_NO = dto.MATERIAL_SORT_NO,
                MATERIAL_THUMB_MEDIA_ID = dto.MATERIAL_THUMB_MEDIA_ID,
                READ_COUNT = dto.READ_COUNT,
                SHARE_COUNT = dto.SHARE_COUNT,
                FAV_COUNT = dto.FAV_COUNT,
                MATERIAL_STATUS = dto.MATERIAL_STATUS,
                BG_NO = dto.BG_NO,
                COMMENT_RULE = dto.COMMENT_RULE,
                IS_ROUND = dto.IS_ROUND,
                SLT_MODULE_TYPE = dto.SLT_MODULE_TYPE,
                MATERIAL_ACT_TYPE = dto.MATERIAL_ACT_TYPE,
                ACT_STARTDATE = dto.ACT_STARTDATE,
                ACT_ENDDATE = dto.ACT_ENDDATE,
                IS_APPLY = dto.IS_APPLY,
                APPLY_LIMIT = dto.APPLY_LIMIT,
                ACT_PARTICIPATOR = dto.ACT_PARTICIPATOR,
                SUPPORT_COUNT = dto.SUPPORT_COUNT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CmsMaterialMstrDto ToDto( this CmsMaterialMstr entity ) {
             if( entity == null )
                return new CmsMaterialMstrDto();
            return new CmsMaterialMstrDto {
                Id = entity.Id,
                MATERIAL_TYPE_ID = entity.MATERIAL_TYPE_ID,      
                MATERIAL_TITLE = entity.MATERIAL_TITLE,      
                MATERIAL_AUTHOR = entity.MATERIAL_AUTHOR,      
                MATERIAL_COVER_URL = entity.MATERIAL_COVER_URL,      
                MATERIAL_CONTENT = entity.MATERIAL_CONTENT,      
                MATERIAL_CONTENT_ORI_URL = entity.MATERIAL_CONTENT_ORI_URL,      
                MATERIAL_SHOW_COVER = entity.MATERIAL_SHOW_COVER,      
                MATERIAL_MEDIA_ID = entity.MATERIAL_MEDIA_ID,      
                MATERIAL_DIGEST = entity.MATERIAL_DIGEST,      
                MATERIAL_URL = entity.MATERIAL_URL,      
                MATERIAL_MODULE_ID = entity.MATERIAL_MODULE_ID,      
                MATERIAL_MODULE_PARAM_JSON = entity.MATERIAL_MODULE_PARAM_JSON,      
                MATERIAL_IS_AUTH = entity.MATERIAL_IS_AUTH,      
                RELEASE_DATE = entity.RELEASE_DATE,      
                MATERIAL_IS_TOP = entity.MATERIAL_IS_TOP,      
                MATERIAL_WCT_CONTENT = entity.MATERIAL_WCT_CONTENT,      
                MATERIAL_WCT_COVER_URL = entity.MATERIAL_WCT_COVER_URL,      
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
                MATERIAL_ALIGN_TYPE = entity.MATERIAL_ALIGN_TYPE,      
                MATERIAL_TITLE_EN = entity.MATERIAL_TITLE_EN,      
                MATERIAL_SORT_NO = entity.MATERIAL_SORT_NO,      
                MATERIAL_THUMB_MEDIA_ID = entity.MATERIAL_THUMB_MEDIA_ID,      
                READ_COUNT = entity.READ_COUNT,      
                SHARE_COUNT = entity.SHARE_COUNT,      
                FAV_COUNT = entity.FAV_COUNT,      
                MATERIAL_STATUS = entity.MATERIAL_STATUS,      
                BG_NO = entity.BG_NO,      
                COMMENT_RULE = entity.COMMENT_RULE,      
                IS_ROUND = entity.IS_ROUND,      
                SLT_MODULE_TYPE = entity.SLT_MODULE_TYPE,      
                MATERIAL_ACT_TYPE = entity.MATERIAL_ACT_TYPE,      
                ACT_STARTDATE = entity.ACT_STARTDATE,      
                ACT_ENDDATE = entity.ACT_ENDDATE,      
                IS_APPLY = entity.IS_APPLY,      
                APPLY_LIMIT = entity.APPLY_LIMIT,      
                ACT_PARTICIPATOR = entity.ACT_PARTICIPATOR,      
                SUPPORT_COUNT = entity.SUPPORT_COUNT
            };
        }
    }
}