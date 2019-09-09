
using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Application.InformationActivitie.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CmsMaterialTypeDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CmsMaterialType ToEntity( this CmsMaterialTypeDto dto ) {
            if( dto == null )
                return new CmsMaterialType();
            return new CmsMaterialType() {
                Id = dto.Id,
                MATERIAL_TYPE_NAME = dto.MATERIAL_TYPE_NAME,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                MATERIAL_ATTR = dto.MATERIAL_ATTR,
                BG_NO = dto.BG_NO,
                MATERIAL_INFO_TYPE = dto.MATERIAL_INFO_TYPE,
                HOT_PURPOSE = dto.HOT_PURPOSE,
                HOT_CONTENT = dto.HOT_CONTENT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CmsMaterialTypeDto ToDto( this CmsMaterialType entity ) {
             if( entity == null )
                return new CmsMaterialTypeDto();
            return new CmsMaterialTypeDto {
                Id = entity.Id,
                MATERIAL_TYPE_NAME = entity.MATERIAL_TYPE_NAME,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                MATERIAL_ATTR = entity.MATERIAL_ATTR,      
                BG_NO = entity.BG_NO,      
                MATERIAL_INFO_TYPE = entity.MATERIAL_INFO_TYPE,      
                HOT_PURPOSE = entity.HOT_PURPOSE,      
                HOT_CONTENT = entity.HOT_CONTENT
            };
        }
    }
}