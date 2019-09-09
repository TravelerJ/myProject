
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmAptConfigMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmAptConfigMstr ToEntity( this CrmAptConfigMstrDto dto ) {
            if( dto == null )
                return new CrmAptConfigMstr();
            return new CrmAptConfigMstr() {
                Id = dto.Id,
                APT_CONFIG_SDATE = dto.APT_CONFIG_SDATE,
                APT_CONFIG_EDATE = dto.APT_CONFIG_EDATE,
                APT_TYPE = dto.APT_TYPE,
                APT_CONFIG_JSON = dto.APT_CONFIG_JSON,
                APT_MIN_DISCOUNT = dto.APT_MIN_DISCOUNT,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                UDF6 = dto.UDF6,
                UDF7 = dto.UDF7,
                UDF8 = dto.UDF8,
                UDF9 = dto.UDF9,
                BU_NO = dto.BU_NO,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO,
                DIS_TYPE = dto.DIS_TYPE,
                APT_LIMIT = dto.APT_LIMIT,
                IS_DEFAULT = dto.IS_DEFAULT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmAptConfigMstrDto ToDto( this CrmAptConfigMstr entity ) {
             if( entity == null )
                return new CrmAptConfigMstrDto();
            return new CrmAptConfigMstrDto {
                Id = entity.Id,
                APT_CONFIG_SDATE = entity.APT_CONFIG_SDATE,      
                APT_CONFIG_EDATE = entity.APT_CONFIG_EDATE,      
                APT_TYPE = entity.APT_TYPE,      
                APT_CONFIG_JSON = entity.APT_CONFIG_JSON,      
                APT_MIN_DISCOUNT = entity.APT_MIN_DISCOUNT,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                UDF6 = entity.UDF6,      
                UDF7 = entity.UDF7,      
                UDF8 = entity.UDF8,      
                UDF9 = entity.UDF9,      
                BU_NO = entity.BU_NO,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO,      
                DIS_TYPE = entity.DIS_TYPE,      
                APT_LIMIT = entity.APT_LIMIT,      
                IS_DEFAULT = entity.IS_DEFAULT
            };
        }
    }
}