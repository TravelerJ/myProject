
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmQpaperQuDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmQpaperQu ToEntity( this CrmQpaperQuDto dto ) {
            if( dto == null )
                return new CrmQpaperQu();
            return new CrmQpaperQu() {
                Id = dto.Id,
                QU_SN = dto.QU_SN,
                QU_TYPE = dto.QU_TYPE,
                QU_NAME = dto.QU_NAME,
                QU_ENABLED = dto.QU_ENABLED,
                QU_ANSWER = dto.QU_ANSWER,
                PAPER_TYPE = dto.PAPER_TYPE,
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
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmQpaperQuDto ToDto( this CrmQpaperQu entity ) {
             if( entity == null )
                return new CrmQpaperQuDto();
            return new CrmQpaperQuDto {
                Id = entity.Id,
                QU_SN = entity.QU_SN,      
                QU_TYPE = entity.QU_TYPE,      
                QU_NAME = entity.QU_NAME,      
                QU_ENABLED = entity.QU_ENABLED,      
                QU_ANSWER = entity.QU_ANSWER,      
                PAPER_TYPE = entity.PAPER_TYPE,      
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
                BG_NO = entity.BG_NO
            };
        }
    }
}