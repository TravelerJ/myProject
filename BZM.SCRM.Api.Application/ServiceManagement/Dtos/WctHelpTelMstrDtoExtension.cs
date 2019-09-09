using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctHelpTelMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctHelpTelMstr ToEntity( this WctHelpTelMstrDto dto ) {
            if( dto == null )
                return new WctHelpTelMstr();
            return new WctHelpTelMstr() {
                Id = dto.Id,
                TEL_NAME = dto.TEL_NAME,
                TEL_NO = dto.TEL_NO,
                TEL_TYPE = dto.TEL_TYPE,
                TEL_ID_NO = dto.TEL_ID_NO,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
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
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctHelpTelMstrDto ToDto( this WctHelpTelMstr entity ) {
             if( entity == null )
                return new WctHelpTelMstrDto();
            return new WctHelpTelMstrDto {
                Id = entity.Id,
                TEL_NAME = entity.TEL_NAME,      
                TEL_NO = entity.TEL_NO,      
                TEL_TYPE = entity.TEL_TYPE,      
                TEL_ID_NO = entity.TEL_ID_NO,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
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
                BG_NO = entity.BG_NO
            };
        }
    }
}