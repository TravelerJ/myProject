using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class AptDriveConfigDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static AptDriveConfig ToEntity( this AptDriveConfigDto dto ) {
            if( dto == null )
                return new AptDriveConfig();
            return new AptDriveConfig() {
                Id = dto.Id,
                BRAND_ID = dto.BRAND_ID,
                BRAND_NAME = dto.BRAND_NAME,
                CLASS_ID = dto.CLASS_ID,
                CLASS_NAME = dto.CLASS_NAME,
                TYPE_ID = dto.TYPE_ID,
                TYPE_NAME = dto.TYPE_NAME,
                SUBTYPE_ID = dto.SUBTYPE_ID,
                SUBTYPE_NAME = dto.SUBTYPE_NAME,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static AptDriveConfigDto ToDto( this AptDriveConfig entity ) {
             if( entity == null )
                return new AptDriveConfigDto();
            return new AptDriveConfigDto {
                Id = entity.Id,
                BRAND_ID = entity.BRAND_ID,      
                BRAND_NAME = entity.BRAND_NAME,      
                CLASS_ID = entity.CLASS_ID,      
                CLASS_NAME = entity.CLASS_NAME,      
                TYPE_ID = entity.TYPE_ID,      
                TYPE_NAME = entity.TYPE_NAME,      
                SUBTYPE_ID = entity.SUBTYPE_ID,      
                SUBTYPE_NAME = entity.SUBTYPE_NAME,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3
            };
        }
    }
}