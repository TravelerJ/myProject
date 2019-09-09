using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Application.InformationActivitie.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctCommentMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctCommentMstr ToEntity( this WctCommentMstrDto dto ) {
            if( dto == null )
                return new WctCommentMstr();
            return new WctCommentMstr() {
                Id = dto.Id,
                MATERIAL_ID = dto.MATERIAL_ID,
                COMMENT_OPENID = dto.COMMENT_OPENID,
                COMMENT_CONTENT = dto.COMMENT_CONTENT,
                COMMENT_DATE = dto.COMMENT_DATE,
                COMMENT_PARENTID = dto.COMMENT_PARENTID,
                USER_ID = dto.USER_ID,
                IS_READ = dto.IS_READ,
                DEL_FLAG = dto.DEL_FLAG,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                SUPPORT_COUNT = dto.SUPPORT_COUNT,
                MAIN_COMMENT_ID = dto.MAIN_COMMENT_ID
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctCommentMstrDto ToDto( this WctCommentMstr entity ) {
             if( entity == null )
                return new WctCommentMstrDto();
            return new WctCommentMstrDto {
                Id = entity.Id,
                MATERIAL_ID = entity.MATERIAL_ID,      
                COMMENT_OPENID = entity.COMMENT_OPENID,      
                COMMENT_CONTENT = entity.COMMENT_CONTENT,      
                COMMENT_DATE = entity.COMMENT_DATE,      
                COMMENT_PARENTID = entity.COMMENT_PARENTID,      
                USER_ID = entity.USER_ID,      
                IS_READ = entity.IS_READ,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                SUPPORT_COUNT = entity.SUPPORT_COUNT,      
                MAIN_COMMENT_ID = entity.MAIN_COMMENT_ID
            };
        }
    }
}