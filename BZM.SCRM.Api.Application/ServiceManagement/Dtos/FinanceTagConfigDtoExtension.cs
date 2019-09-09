
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class FinanceTagConfigDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static FinanceTagConfig ToEntity( this FinanceTagConfigDto dto ) {
            if( dto == null )
                return new FinanceTagConfig();
            return new FinanceTagConfig() {
                Id = dto.Id,
                TAG_NAME = dto.TAG_NAME,
                TAG_DESCRIBE = dto.TAG_DESCRIBE,
                SORT_NO = dto.SORT_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
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
        public static FinanceTagConfigDto ToDto( this FinanceTagConfig entity ) {
             if( entity == null )
                return new FinanceTagConfigDto();
            return new FinanceTagConfigDto {
                Id = entity.Id,
                TAG_NAME = entity.TAG_NAME,      
                TAG_DESCRIBE = entity.TAG_DESCRIBE,      
                SORT_NO = entity.SORT_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3
            };
        }
    }
}