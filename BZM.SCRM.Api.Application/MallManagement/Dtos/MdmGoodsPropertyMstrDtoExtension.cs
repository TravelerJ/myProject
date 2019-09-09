using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmGoodsPropertyMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmGoodsPropertyMstr ToEntity( this MdmGoodsPropertyMstrDto dto ) {
            if( dto == null )
                return new MdmGoodsPropertyMstr();
            return new MdmGoodsPropertyMstr() {
                Id = dto.Id,
                PROPERTY_NAME = dto.PROPERTY_NAME,
                PROPERTY_EN_NAME = dto.PROPERTY_EN_NAME,
                PROPERTY_TYPE = dto.PROPERTY_TYPE,
                PROPERTY_PARENTID = dto.PROPERTY_PARENTID,
                PROPERTY_LEVEL = dto.PROPERTY_LEVEL,
                PROPERTY_DOMAIN = dto.PROPERTY_DOMAIN,
                PROPERTY_INPUT_FLAG = dto.PROPERTY_INPUT_FLAG,
                PROPERTY_MAX_LENGTH = dto.PROPERTY_MAX_LENGTH,
                PROPERTY_DEFAULT_VALUE = dto.PROPERTY_DEFAULT_VALUE,
                PROPERTY_STATUS = dto.PROPERTY_STATUS,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmGoodsPropertyMstrDto ToDto( this MdmGoodsPropertyMstr entity ) {
             if( entity == null )
                return new MdmGoodsPropertyMstrDto();
            return new MdmGoodsPropertyMstrDto {
                Id = entity.Id,
                PROPERTY_NAME = entity.PROPERTY_NAME,      
                PROPERTY_EN_NAME = entity.PROPERTY_EN_NAME,      
                PROPERTY_TYPE = entity.PROPERTY_TYPE,      
                PROPERTY_PARENTID = entity.PROPERTY_PARENTID,      
                PROPERTY_LEVEL = entity.PROPERTY_LEVEL,      
                PROPERTY_DOMAIN = entity.PROPERTY_DOMAIN,      
                PROPERTY_INPUT_FLAG = entity.PROPERTY_INPUT_FLAG,      
                PROPERTY_MAX_LENGTH = entity.PROPERTY_MAX_LENGTH,      
                PROPERTY_DEFAULT_VALUE = entity.PROPERTY_DEFAULT_VALUE,      
                PROPERTY_STATUS = entity.PROPERTY_STATUS,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG
            };
        }
    }
}