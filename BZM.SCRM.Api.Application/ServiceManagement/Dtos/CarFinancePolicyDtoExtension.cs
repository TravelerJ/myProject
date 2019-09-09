
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CarFinancePolicyDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CarFinancePolicy ToEntity( this CarFinancePolicyDto dto ) {
            if( dto == null )
                return new CarFinancePolicy();
            return new CarFinancePolicy() {
                Id = dto.Id,
                BRAND_CODE = dto.BRAND_CODE,
                BRAND_NAME = dto.BRAND_NAME,
                CLASS_CODE = dto.CLASS_CODE,
                CLASS_NAME = dto.CLASS_NAME,
                TYPE_CODE = dto.TYPE_CODE,
                TYPE_NAME = dto.TYPE_NAME,
                SUBTYPE_CODE = dto.SUBTYPE_CODE,
                SUBTYPE_NAME = dto.SUBTYPE_NAME,
                TAG_LEVEL = dto.TAG_LEVEL,
                BIZ_TYPE = dto.BIZ_TYPE,
                TAG_IDS = dto.TAG_IDS,
                TAG_JSON = dto.TAG_JSON,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CarFinancePolicyDto ToDto( this CarFinancePolicy entity ) {
             if( entity == null )
                return new CarFinancePolicyDto();
            return new CarFinancePolicyDto {
                Id = entity.Id,
                BRAND_CODE = entity.BRAND_CODE,      
                BRAND_NAME = entity.BRAND_NAME,      
                CLASS_CODE = entity.CLASS_CODE,      
                CLASS_NAME = entity.CLASS_NAME,      
                TYPE_CODE = entity.TYPE_CODE,      
                TYPE_NAME = entity.TYPE_NAME,      
                SUBTYPE_CODE = entity.SUBTYPE_CODE,      
                SUBTYPE_NAME = entity.SUBTYPE_NAME,      
                TAG_LEVEL = entity.TAG_LEVEL,      
                BIZ_TYPE = entity.BIZ_TYPE,      
                TAG_IDS = entity.TAG_IDS,      
                TAG_JSON = entity.TAG_JSON,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5
            };
        }
    }
}