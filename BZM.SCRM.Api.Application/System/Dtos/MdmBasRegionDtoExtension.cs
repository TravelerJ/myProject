
using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmBasRegionDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmBasRegion ToEntity( this MdmBasRegionDto dto ) {
            if( dto == null )
                return new MdmBasRegion();
            return new MdmBasRegion() {
                Id = dto.Id,
                REGION_NO = dto.REGION_NO,
                REGION_NAME = dto.REGION_NAME,
                REGION_LEVEL = dto.REGION_LEVEL,
                PARENT_REGION_NO = dto.PARENT_REGION_NO,
                REGION_FLAG1 = dto.REGION_FLAG1,
                REGION_FLAG2 = dto.REGION_FLAG2,
                REGION_FLAG3 = dto.REGION_FLAG3,
                REGION_FLAG4 = dto.REGION_FLAG4,
                REGION_FLAG5 = dto.REGION_FLAG5,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmBasRegionDto ToDto( this MdmBasRegion entity ) {
             if( entity == null )
                return new MdmBasRegionDto();
            return new MdmBasRegionDto {
                Id = entity.Id,
                REGION_NO = entity.REGION_NO,      
                REGION_NAME = entity.REGION_NAME,      
                REGION_LEVEL = entity.REGION_LEVEL,      
                PARENT_REGION_NO = entity.PARENT_REGION_NO,      
                REGION_FLAG1 = entity.REGION_FLAG1,      
                REGION_FLAG2 = entity.REGION_FLAG2,      
                REGION_FLAG3 = entity.REGION_FLAG3,      
                REGION_FLAG4 = entity.REGION_FLAG4,      
                REGION_FLAG5 = entity.REGION_FLAG5,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG
            };
        }
    }
}