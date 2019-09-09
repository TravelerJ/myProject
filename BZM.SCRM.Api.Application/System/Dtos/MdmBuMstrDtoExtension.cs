
using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class MdmBuMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static MdmBuMstr ToEntity( this MdmBuMstrDto dto ) {
            if( dto == null )
                return new MdmBuMstr();
            return new MdmBuMstr() {
                Id = dto.Id,
                BU_NAME = dto.BU_NAME,
                BU_SHORT_NAME = dto.BU_SHORT_NAME,
                BU_REGISTERED_NAME = dto.BU_REGISTERED_NAME,
                BG_NO = dto.BG_NO,
                BU_PHONE = dto.BU_PHONE,
                BU_TYPE = dto.BU_TYPE,
                BU_AREA = dto.BU_AREA,
                STATION_COUNT = dto.STATION_COUNT,
                BU_BRAND = dto.BU_BRAND,
                OPEN_DATE = dto.OPEN_DATE,
                OPEN_TYPE = dto.OPEN_TYPE,
                BU_LEVEL = dto.BU_LEVEL,
                BU_ADDR_PROVINCE = dto.BU_ADDR_PROVINCE,
                BU_ADDR_CITY = dto.BU_ADDR_CITY,
                BU_ADDR_DISTRICT = dto.BU_ADDR_DISTRICT,
                BU_ADDR = dto.BU_ADDR,
                MNEMONIC_CODE = dto.MNEMONIC_CODE,
                BU_STATUS = dto.BU_STATUS,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                UDF10 = dto.UDF10,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                UDF6 = dto.UDF6,
                UDF7 = dto.UDF7,
                UDF8 = dto.UDF8,
                UDF9 = dto.UDF9,
                DEL_FLAG = dto.DEL_FLAG,
                ERP_API_URL = dto.ERP_API_URL,
                ERP_ORG_NO = dto.ERP_ORG_NO,
                APP_API_URL = dto.APP_API_URL,
                BRAND_NO = dto.BRAND_NO,
                BRAND_NAME = dto.BRAND_NAME,
                BU_KEY = dto.BU_KEY,
                BU_BRANCH_NOS = dto.BU_BRANCH_NOS,
                PARENT_BU_NO = dto.PARENT_BU_NO,
                PARENT_BU_NAME = dto.PARENT_BU_NAME,
                USR_QRCODE_PATH = dto.USR_QRCODE_PATH,
                CARBRAND_IDS = dto.CARBRAND_IDS,
                CARCLASS_IDS = dto.CARCLASS_IDS,
                CARCLASS_NO = dto.CARCLASS_NO,
                CARCLASS_NAME = dto.CARCLASS_NAME
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static MdmBuMstrDto ToDto( this MdmBuMstr entity ) {
             if( entity == null )
                return new MdmBuMstrDto();
            return new MdmBuMstrDto {
                Id = entity.Id,
                BU_NAME = entity.BU_NAME,      
                BU_SHORT_NAME = entity.BU_SHORT_NAME,      
                BU_REGISTERED_NAME = entity.BU_REGISTERED_NAME,      
                BG_NO = entity.BG_NO,      
                BU_PHONE = entity.BU_PHONE,      
                BU_TYPE = entity.BU_TYPE,      
                BU_AREA = entity.BU_AREA,      
                STATION_COUNT = entity.STATION_COUNT,      
                BU_BRAND = entity.BU_BRAND,      
                OPEN_DATE = entity.OPEN_DATE,      
                OPEN_TYPE = entity.OPEN_TYPE,      
                BU_LEVEL = entity.BU_LEVEL,      
                BU_ADDR_PROVINCE = entity.BU_ADDR_PROVINCE,      
                BU_ADDR_CITY = entity.BU_ADDR_CITY,      
                BU_ADDR_DISTRICT = entity.BU_ADDR_DISTRICT,      
                BU_ADDR = entity.BU_ADDR,      
                MNEMONIC_CODE = entity.MNEMONIC_CODE,      
                BU_STATUS = entity.BU_STATUS,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                UDF10 = entity.UDF10,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                UDF6 = entity.UDF6,      
                UDF7 = entity.UDF7,      
                UDF8 = entity.UDF8,      
                UDF9 = entity.UDF9,      
                DEL_FLAG = entity.DEL_FLAG,      
                ERP_API_URL = entity.ERP_API_URL,      
                ERP_ORG_NO = entity.ERP_ORG_NO,      
                APP_API_URL = entity.APP_API_URL,      
                BRAND_NO = entity.BRAND_NO,      
                BRAND_NAME = entity.BRAND_NAME,      
                BU_KEY = entity.BU_KEY,      
                BU_BRANCH_NOS = entity.BU_BRANCH_NOS,      
                PARENT_BU_NO = entity.PARENT_BU_NO,      
                PARENT_BU_NAME = entity.PARENT_BU_NAME,      
                USR_QRCODE_PATH = entity.USR_QRCODE_PATH,      
                CARBRAND_IDS = entity.CARBRAND_IDS,      
                CARCLASS_IDS = entity.CARCLASS_IDS,      
                CARCLASS_NO = entity.CARCLASS_NO,      
                CARCLASS_NAME = entity.CARCLASS_NAME
            };
        }
    }
}