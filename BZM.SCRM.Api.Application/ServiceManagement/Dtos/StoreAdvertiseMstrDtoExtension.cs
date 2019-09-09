using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class StoreAdvertiseMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static StoreAdvertiseMstr ToEntity( this StoreAdvertiseMstrDto dto ) {
            if( dto == null )
                return new StoreAdvertiseMstr();
            return new StoreAdvertiseMstr() {
                Id = dto.Id,
                ADVERTISE_THEME = dto.ADVERTISE_THEME,
                ADVERTISE_TYPE = dto.ADVERTISE_TYPE,
                ADVERTISE_CONTENT = dto.ADVERTISE_CONTENT,
                ADVERTISE_POSTER_URL = dto.ADVERTISE_POSTER_URL,
                STORE_CONTRACT = dto.STORE_CONTRACT,
                ADVERTISE_STATUS = dto.ADVERTISE_STATUS,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                ADVERTISE_CATEGORY = dto.ADVERTISE_CATEGORY
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static StoreAdvertiseMstrDto ToDto( this StoreAdvertiseMstr entity ) {
             if( entity == null )
                return new StoreAdvertiseMstrDto();
            return new StoreAdvertiseMstrDto {
                Id = entity.Id,
                ADVERTISE_THEME = entity.ADVERTISE_THEME,      
                ADVERTISE_TYPE = entity.ADVERTISE_TYPE,      
                ADVERTISE_CONTENT = entity.ADVERTISE_CONTENT,      
                ADVERTISE_POSTER_URL = entity.ADVERTISE_POSTER_URL,      
                STORE_CONTRACT = entity.STORE_CONTRACT,      
                ADVERTISE_STATUS = entity.ADVERTISE_STATUS,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                ADVERTISE_CATEGORY = entity.ADVERTISE_CATEGORY
            };
        }
    }
}