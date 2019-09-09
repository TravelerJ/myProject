
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmEvaMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmEvaMstr ToEntity( this CrmEvaMstrDto dto ) {
            if( dto == null )
                return new CrmEvaMstr();
            return new CrmEvaMstr() {
                Id = dto.Id,
                EVA_TYPE = dto.EVA_TYPE,
                EVA_SERVICE_VALUE = dto.EVA_SERVICE_VALUE,
                EVA_ATTITUDE_VALUE = dto.EVA_ATTITUDE_VALUE,
                EVA_ENV_VALUE = dto.EVA_ENV_VALUE,
                EVA_OTR_VALUE1 = dto.EVA_OTR_VALUE1,
                EVA_OTR_VALUE2 = dto.EVA_OTR_VALUE2,
                EVA_OTR_VALUE3 = dto.EVA_OTR_VALUE3,
                EVA_OTR_VALUE4 = dto.EVA_OTR_VALUE4,
                EVA_OTR_VALUE5 = dto.EVA_OTR_VALUE5,
                EVA_OTR_VALUE6 = dto.EVA_OTR_VALUE6,
                EVA_OTR_VALUE7 = dto.EVA_OTR_VALUE7,
                EVA_OTR_VALUE8 = dto.EVA_OTR_VALUE8,
                EVA_OTR_VALUE9 = dto.EVA_OTR_VALUE9,
                EVA_OTR_VALUE10 = dto.EVA_OTR_VALUE10,
                EVA_TOTAL_VALUE = dto.EVA_TOTAL_VALUE,
                EVA_OBJ_TYPE = dto.EVA_OBJ_TYPE,
                EVA_OBJ_NO = dto.EVA_OBJ_NO,
                EVA_OBJ_NAME = dto.EVA_OBJ_NAME,
                EVA_DATE = dto.EVA_DATE,
                EVA_CONTENT = dto.EVA_CONTENT,
                EVA_RMK = dto.EVA_RMK,
                EVA_REF_NO = dto.EVA_REF_NO,
                EVA_REF_NO1 = dto.EVA_REF_NO1,
                EVA_REF_NO2 = dto.EVA_REF_NO2,
                EVA_REF_NO3 = dto.EVA_REF_NO3,
                EVA_REF_NO4 = dto.EVA_REF_NO4,
                EVA_REF_NO5 = dto.EVA_REF_NO5,
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
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO,
                BRAND_ID = dto.BRAND_ID,
                BRAND_NAME = dto.BRAND_NAME,
                CLASS_ID = dto.CLASS_ID,
                CLASS_NAME = dto.CLASS_NAME,
                CAR_TYPE_ID = dto.CAR_TYPE_ID,
                CAR_TYPE_NAME = dto.CAR_TYPE_NAME
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmEvaMstrDto ToDto( this CrmEvaMstr entity ) {
             if( entity == null )
                return new CrmEvaMstrDto();
            return new CrmEvaMstrDto {
                Id = entity.Id,
                EVA_TYPE = entity.EVA_TYPE,      
                EVA_SERVICE_VALUE = entity.EVA_SERVICE_VALUE,      
                EVA_ATTITUDE_VALUE = entity.EVA_ATTITUDE_VALUE,      
                EVA_ENV_VALUE = entity.EVA_ENV_VALUE,      
                EVA_OTR_VALUE1 = entity.EVA_OTR_VALUE1,      
                EVA_OTR_VALUE2 = entity.EVA_OTR_VALUE2,      
                EVA_OTR_VALUE3 = entity.EVA_OTR_VALUE3,      
                EVA_OTR_VALUE4 = entity.EVA_OTR_VALUE4,      
                EVA_OTR_VALUE5 = entity.EVA_OTR_VALUE5,      
                EVA_OTR_VALUE6 = entity.EVA_OTR_VALUE6,      
                EVA_OTR_VALUE7 = entity.EVA_OTR_VALUE7,      
                EVA_OTR_VALUE8 = entity.EVA_OTR_VALUE8,      
                EVA_OTR_VALUE9 = entity.EVA_OTR_VALUE9,      
                EVA_OTR_VALUE10 = entity.EVA_OTR_VALUE10,      
                EVA_TOTAL_VALUE = entity.EVA_TOTAL_VALUE,      
                EVA_OBJ_TYPE = entity.EVA_OBJ_TYPE,      
                EVA_OBJ_NO = entity.EVA_OBJ_NO,      
                EVA_OBJ_NAME = entity.EVA_OBJ_NAME,      
                EVA_DATE = entity.EVA_DATE,      
                EVA_CONTENT = entity.EVA_CONTENT,      
                EVA_RMK = entity.EVA_RMK,      
                EVA_REF_NO = entity.EVA_REF_NO,      
                EVA_REF_NO1 = entity.EVA_REF_NO1,      
                EVA_REF_NO2 = entity.EVA_REF_NO2,      
                EVA_REF_NO3 = entity.EVA_REF_NO3,      
                EVA_REF_NO4 = entity.EVA_REF_NO4,      
                EVA_REF_NO5 = entity.EVA_REF_NO5,      
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
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO,      
                BRAND_ID = entity.BRAND_ID,      
                BRAND_NAME = entity.BRAND_NAME,      
                CLASS_ID = entity.CLASS_ID,      
                CLASS_NAME = entity.CLASS_NAME,      
                CAR_TYPE_ID = entity.CAR_TYPE_ID,      
                CAR_TYPE_NAME = entity.CAR_TYPE_NAME
            };
        }
    }
}