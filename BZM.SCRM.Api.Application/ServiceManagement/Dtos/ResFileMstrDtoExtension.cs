
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class ResFileMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static ResFileMstr ToEntity( this ResFileMstrDto dto ) {
            if( dto == null )
                return new ResFileMstr();
            return new ResFileMstr() {
                Id = dto.Id,
                FILE_NAME = dto.FILE_NAME,
                FILE_SIZE = dto.FILE_SIZE,
                FILE_CLASS = dto.FILE_CLASS,
                BIZ_NO = dto.BIZ_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                FILE_PATH = dto.FILE_PATH,
                FILE_SORT = dto.FILE_SORT,
                FILE_SDATE = dto.FILE_SDATE,
                FILE_EDATE = dto.FILE_EDATE,
                FILE_ATTR1 = dto.FILE_ATTR1,
                FILE_ATTR2 = dto.FILE_ATTR2,
                FILE_ATTR3 = dto.FILE_ATTR3,
                FILE_ATTR4 = dto.FILE_ATTR4,
                FILE_ATTR5 = dto.FILE_ATTR5
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static ResFileMstrDto ToDto( this ResFileMstr entity ) {
             if( entity == null )
                return new ResFileMstrDto();
            return new ResFileMstrDto {
                Id = entity.Id,
                FILE_NAME = entity.FILE_NAME,      
                FILE_SIZE = entity.FILE_SIZE,      
                FILE_CLASS = entity.FILE_CLASS,      
                BIZ_NO = entity.BIZ_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                FILE_PATH = entity.FILE_PATH,      
                FILE_SORT = entity.FILE_SORT,      
                FILE_SDATE = entity.FILE_SDATE,      
                FILE_EDATE = entity.FILE_EDATE,      
                FILE_ATTR1 = entity.FILE_ATTR1,      
                FILE_ATTR2 = entity.FILE_ATTR2,      
                FILE_ATTR3 = entity.FILE_ATTR3,      
                FILE_ATTR4 = entity.FILE_ATTR4,      
                FILE_ATTR5 = entity.FILE_ATTR5
            };
        }
    }
}