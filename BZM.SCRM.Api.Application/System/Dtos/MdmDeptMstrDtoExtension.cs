
using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmDeptMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmDeptMstr ToEntity( this MdmDeptMstrDto dto ) {
            if( dto == null )
                return new MdmDeptMstr();
            return new MdmDeptMstr() {
                Id = dto.Id,
                DEPT_NO = dto.DEPT_NO,
                DEPT_NAME = dto.DEPT_NAME,
                DEPT_PARENT_ID = dto.DEPT_PARENT_ID,
                ORG_NO = dto.ORG_NO,
                DEPT_STATUS = dto.DEPT_STATUS,
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
        public static MdmDeptMstrDto ToDto( this MdmDeptMstr entity ) {
             if( entity == null )
                return new MdmDeptMstrDto();
            return new MdmDeptMstrDto {
                Id = entity.Id,
                DEPT_NO = entity.DEPT_NO,      
                DEPT_NAME = entity.DEPT_NAME,      
                DEPT_PARENT_ID = entity.DEPT_PARENT_ID,      
                ORG_NO = entity.ORG_NO,      
                DEPT_STATUS = entity.DEPT_STATUS,      
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