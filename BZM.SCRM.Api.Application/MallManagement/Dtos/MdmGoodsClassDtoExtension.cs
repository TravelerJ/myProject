using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmGoodsClassDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmGoodsClass ToEntity( this MdmGoodsClassDto dto ) {
            if( dto == null )
                return new MdmGoodsClass();
            return new MdmGoodsClass() {
                Id = dto.Id,
                CLASS_NO = dto.CLASS_NO,
                CLASS_LEVEL = dto.CLASS_LEVEL,
                CLASS_NAME = dto.CLASS_NAME,
                PARENT_ID = dto.PARENT_ID,
                CLASS_STATUS = dto.CLASS_STATUS,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CLASS_ATTR = dto.CLASS_ATTR,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmGoodsClassDto ToDto( this MdmGoodsClass entity ) {
             if( entity == null )
                return new MdmGoodsClassDto();
            return new MdmGoodsClassDto {
                Id = entity.Id,
                CLASS_NO = entity.CLASS_NO,      
                CLASS_LEVEL = entity.CLASS_LEVEL,      
                CLASS_NAME = entity.CLASS_NAME,      
                PARENT_ID = entity.PARENT_ID,      
                CLASS_STATUS = entity.CLASS_STATUS,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CLASS_ATTR = entity.CLASS_ATTR,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}