
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Application.MallManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class InvInventoryDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static InvInventory ToEntity( this InvInventoryDto dto ) {
            if( dto == null )
                return new InvInventory();
            return new InvInventory() {
                Id = dto.Id,
                ORG_NO = dto.ORG_NO,
                WH_ID = dto.WH_ID,
                LC_ID = dto.LC_ID,
                GOODS_NO = dto.GOODS_NO,
                BATCH_NO = dto.BATCH_NO,
                QTY = dto.QTY,
                DATA_FLAG = dto.DATA_FLAG,
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
        public static InvInventoryDto ToDto( this InvInventory entity ) {
             if( entity == null )
                return new InvInventoryDto();
            return new InvInventoryDto {
                Id = entity.Id,
                ORG_NO = entity.ORG_NO,      
                WH_ID = entity.WH_ID,      
                LC_ID = entity.LC_ID,      
                GOODS_NO = entity.GOODS_NO,      
                BATCH_NO = entity.BATCH_NO,      
                QTY = entity.QTY,      
                DATA_FLAG = entity.DATA_FLAG,      
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