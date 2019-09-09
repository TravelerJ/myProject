
using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmDutyMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmDutyMstr ToEntity( this MdmDutyMstrDto dto ) {
            if( dto == null )
                return new MdmDutyMstr();
            return new MdmDutyMstr() {
                Id = dto.Id,
                DUTY_NO = dto.DUTY_NO,
                DUTY_NAME = dto.DUTY_NAME,
                DUTY_PARENT_ID = dto.DUTY_PARENT_ID,
                DUTY_LEVEL = dto.DUTY_LEVEL,
                DUTY_STATUS = dto.DUTY_STATUS,
                ORG_NO = dto.ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmDutyMstrDto ToDto( this MdmDutyMstr entity ) {
             if( entity == null )
                return new MdmDutyMstrDto();
            return new MdmDutyMstrDto {
                Id = entity.Id,
                DUTY_NO = entity.DUTY_NO,      
                DUTY_NAME = entity.DUTY_NAME,      
                DUTY_PARENT_ID = entity.DUTY_PARENT_ID,      
                DUTY_LEVEL = entity.DUTY_LEVEL,      
                DUTY_STATUS = entity.DUTY_STATUS,      
                ORG_NO = entity.ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}