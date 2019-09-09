
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmMsgConfigDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmMsgConfig ToEntity( this MdmMsgConfigDto dto ) {
            if( dto == null )
                return new MdmMsgConfig();
            return new MdmMsgConfig() {
                Id = dto.Id,
                APT_TYPE = dto.APT_TYPE,
                APT_REMIND_DATE = dto.APT_REMIND_DATE,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                BU_NO = dto.BU_NO,
                BG_NO = dto.BG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                MSG_REMIND_TYPE = dto.MSG_REMIND_TYPE,
                REMIND_EVENT_TYPE = dto.REMIND_EVENT_TYPE,
                REMIND_MODE = dto.REMIND_MODE,
                APT_REMIND_TIME = dto.APT_REMIND_TIME
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmMsgConfigDto ToDto( this MdmMsgConfig entity ) {
             if( entity == null )
                return new MdmMsgConfigDto();
            return new MdmMsgConfigDto {
                Id = entity.Id,
                APT_TYPE = entity.APT_TYPE,      
                APT_REMIND_DATE = entity.APT_REMIND_DATE,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                BU_NO = entity.BU_NO,      
                BG_NO = entity.BG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                MSG_REMIND_TYPE = entity.MSG_REMIND_TYPE,      
                REMIND_EVENT_TYPE = entity.REMIND_EVENT_TYPE,      
                REMIND_MODE = entity.REMIND_MODE,      
                APT_REMIND_TIME = entity.APT_REMIND_TIME
            };
        }
    }
}