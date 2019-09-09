
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctMenuMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctMenuMstr ToEntity( this WctMenuMstrDto dto ) {
            if( dto == null )
                return new WctMenuMstr();
            return new WctMenuMstr() {
                Id = dto.Id,
                MENU_ID_NO = dto.MENU_ID_NO,
                MENU_NAME = dto.MENU_NAME,
                MENU_KEY = dto.MENU_KEY,
                MENU_TYPE = dto.MENU_TYPE,
                MENU_LEVEL = dto.MENU_LEVEL,
                MENU_DISPLAYINDEX = dto.MENU_DISPLAYINDEX,
                MENU_MATERIALTYPEID = dto.MENU_MATERIALTYPEID,
                MENU_PARENTID = dto.MENU_PARENTID,
                MENU_TEXT = dto.MENU_TEXT,
                MENU_MENUURL = dto.MENU_MENUURL,
                MENU_MODULEID = dto.MENU_MODULEID,
                MENU_PAGEPARAMJSON = dto.MENU_PAGEPARAMJSON,
                MENU_ISAUTH = dto.MENU_ISAUTH,
                MENU_STATUS = dto.MENU_STATUS,
                MENU_BELINKEDTYPE = dto.MENU_BELINKEDTYPE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                UDF6 = dto.UDF6,
                UDF7 = dto.UDF7,
                UDF8 = dto.UDF8,
                UDF9 = dto.UDF9,
                UDF10 = dto.UDF10,
                DEL_FLAG = dto.DEL_FLAG,
                MATERIAL_IDS = dto.MATERIAL_IDS,
                MEDIA_ID = dto.MEDIA_ID,
                BG_NO = dto.BG_NO,
                MENU_ISSECOND = dto.MENU_ISSECOND,
                MENU_APPLET_ID=dto.MENU_APPLET_ID,
                MENU_APPLET_APP_ID=dto.MENU_APPLET_APP_ID
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctMenuMstrDto ToDto( this WctMenuMstr entity ) {
             if( entity == null )
                return new WctMenuMstrDto();
            return new WctMenuMstrDto {
                Id = entity.Id,
                MENU_ID_NO = entity.MENU_ID_NO,      
                MENU_NAME = entity.MENU_NAME,      
                MENU_KEY = entity.MENU_KEY,      
                MENU_TYPE = entity.MENU_TYPE,      
                MENU_LEVEL = entity.MENU_LEVEL,      
                MENU_DISPLAYINDEX = entity.MENU_DISPLAYINDEX,      
                MENU_MATERIALTYPEID = entity.MENU_MATERIALTYPEID,      
                MENU_PARENTID = entity.MENU_PARENTID,      
                MENU_TEXT = entity.MENU_TEXT,      
                MENU_MENUURL = entity.MENU_MENUURL,      
                MENU_MODULEID = entity.MENU_MODULEID,      
                MENU_PAGEPARAMJSON = entity.MENU_PAGEPARAMJSON,      
                MENU_ISAUTH = entity.MENU_ISAUTH,      
                MENU_STATUS = entity.MENU_STATUS,      
                MENU_BELINKEDTYPE = entity.MENU_BELINKEDTYPE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                UDF6 = entity.UDF6,      
                UDF7 = entity.UDF7,      
                UDF8 = entity.UDF8,      
                UDF9 = entity.UDF9,      
                UDF10 = entity.UDF10,      
                DEL_FLAG = entity.DEL_FLAG,      
                MATERIAL_IDS = entity.MATERIAL_IDS,      
                MEDIA_ID = entity.MEDIA_ID,      
                BG_NO = entity.BG_NO,      
                MENU_ISSECOND = entity.MENU_ISSECOND,
                MENU_APPLET_ID = entity.MENU_APPLET_ID,
                MENU_APPLET_APP_ID = entity.MENU_APPLET_APP_ID
            };
        }
    }
}