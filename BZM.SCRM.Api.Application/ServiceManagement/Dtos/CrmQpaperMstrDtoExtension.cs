
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmQpaperMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmQpaperMstr ToEntity( this CrmQpaperMstrDto dto ) {
            if( dto == null )
                return new CrmQpaperMstr();
            return new CrmQpaperMstr() {
                Id = dto.Id,
                PAPER_NAME = dto.PAPER_NAME,
                PAPER_TYPE = dto.PAPER_TYPE,
                INCLUDE_QUESTION_IDS = dto.INCLUDE_QUESTION_IDS,
                PAPER_SDATE = dto.PAPER_SDATE,
                PAPER_EDATE = dto.PAPER_EDATE,
                PAPER_DESC = dto.PAPER_DESC,
                PAPER_STATUS = dto.PAPER_STATUS,
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
        public static CrmQpaperMstrDto ToDto( this CrmQpaperMstr entity ) {
             if( entity == null )
                return new CrmQpaperMstrDto();
            return new CrmQpaperMstrDto {
                Id = entity.Id,
                PAPER_NAME = entity.PAPER_NAME,      
                PAPER_TYPE = entity.PAPER_TYPE,      
                INCLUDE_QUESTION_IDS = entity.INCLUDE_QUESTION_IDS,      
                PAPER_SDATE = entity.PAPER_SDATE,      
                PAPER_EDATE = entity.PAPER_EDATE,      
                PAPER_DESC = entity.PAPER_DESC,      
                PAPER_STATUS = entity.PAPER_STATUS,      
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