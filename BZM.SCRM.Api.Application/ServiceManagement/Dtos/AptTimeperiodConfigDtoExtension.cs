
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class AptTimeperiodConfigDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static AptTimeperiodConfig ToEntity( this AptTimeperiodConfigDto dto ) {
            if( dto == null )
                return new AptTimeperiodConfig();
            return new AptTimeperiodConfig() {
                Id = dto.Id,
                APT_TYPE = dto.APT_TYPE,
                SORT_NO = dto.SORT_NO,
                PERIOD_STIME = dto.PERIOD_STIME,
                PERIOD_ETIME = dto.PERIOD_ETIME,
                DEL_FLAG = dto.DEL_FLAG,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
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
        public static AptTimeperiodConfigDto ToDto( this AptTimeperiodConfig entity ) {
             if( entity == null )
                return new AptTimeperiodConfigDto();
            return new AptTimeperiodConfigDto {
                Id = entity.Id,
                APT_TYPE = entity.APT_TYPE,      
                SORT_NO = entity.SORT_NO,      
                PERIOD_STIME = entity.PERIOD_STIME,      
                PERIOD_ETIME = entity.PERIOD_ETIME,      
                DEL_FLAG = entity.DEL_FLAG,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5
            };
        }
    }
}