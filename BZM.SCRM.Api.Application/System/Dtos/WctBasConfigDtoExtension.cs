using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctBasConfigDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctBasConfig ToEntity( this WctBasConfigDto dto ) {
            if( dto == null )
                return new WctBasConfig();
            return new WctBasConfig() {
                Id = dto.Id,
                SMS_APP_KEY = dto.SMS_APP_KEY,
                SMS_MASTER_SECRET = dto.SMS_MASTER_SECRET,
                SMS_CODE_ID = dto.SMS_CODE_ID,
                IS_TOERP = dto.IS_TOERP,
                CREATOR = dto.CREATOR,
                OPRATOR_NO = dto.OPRATOR_NO,
                MEMBER_LEVEL = dto.MEMBER_LEVEL,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                OPEN_IS_ENABLED = dto.OPEN_IS_ENABLED,
                OPEN_APP_ID = dto.OPEN_APP_ID,
                OPEN_APP_SECRET = dto.OPEN_APP_SECRET,
                OPEN_APP_TOKEN = dto.OPEN_APP_TOKEN,
                OPEN_SECRET_KEY = dto.OPEN_SECRET_KEY,
                CLIENT_IP = dto.CLIENT_IP,
                ERP_API_OURL = dto.ERP_API_OURL,
                ERP_API_NURL = dto.ERP_API_NURL,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO,
                IS_GROUP = dto.IS_GROUP,
                IS_APPCONFIG = dto.IS_APPCONFIG,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                IS_ONLYSTORE = dto.IS_ONLYSTORE,
                IS_IRIS = dto.IS_IRIS,
                ERP_APP_ID = dto.ERP_APP_ID,
                ERP_APP_KEY = dto.ERP_APP_KEY,
                ERP_APP_SECRET = dto.ERP_APP_SECRET,
                WXPAY_RETURNURL = dto.WXPAY_RETURNURL,
                IRIS_APT_URL = dto.IRIS_APT_URL,
                IRIS_CHAT_URL = dto.IRIS_CHAT_URL,
                APT_URL = dto.APT_URL,
                IS_TRANSFER = dto.IS_TRANSFER,
                IS_SEND_MSG = dto.IS_SEND_MSG,
                SMS_MSG_CODE = dto.SMS_MSG_CODE,
                IS_EXCHANGE_TICKET = dto.IS_EXCHANGE_TICKET,
                REDIS_NUM = dto.REDIS_NUM,
                SALE_APT = dto.SALE_APT,
                AFTER_SALE_APT = dto.AFTER_SALE_APT,
                IS_BZT = dto.IS_BZT,
                TOKEN_USR_NAME = dto.TOKEN_USR_NAME,
                TOKEN_USR_PWD = dto.TOKEN_USR_PWD,
                GRANT_TYPE = dto.GRANT_TYPE,
                CLIENT_ID = dto.CLIENT_ID,
                CLIENT_SECRET = dto.CLIENT_SECRET,
                IBZT_URL = dto.IBZT_URL,
                GOODS_FROM = dto.GOODS_FROM,
                CAR_FROM = dto.CAR_FROM,
                BZT_TOKEN = dto.BZT_TOKEN,
                BZT_TOKEN_TIME = dto.BZT_TOKEN_TIME,
                IS_RANDOMSALE = dto.IS_RANDOMSALE,
                IS_CAR_BIND = dto.IS_CAR_BIND,
                IS_APT_REMIND = dto.IS_APT_REMIND,
                IS_APT_GROUP = dto.IS_APT_GROUP
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctBasConfigDto ToDto( this WctBasConfig entity ) {
             if( entity == null )
                return new WctBasConfigDto();
            return new WctBasConfigDto {
                Id = entity.Id,
                SMS_APP_KEY = entity.SMS_APP_KEY,      
                SMS_MASTER_SECRET = entity.SMS_MASTER_SECRET,      
                SMS_CODE_ID = entity.SMS_CODE_ID,      
                IS_TOERP = entity.IS_TOERP,      
                CREATOR = entity.CREATOR,      
                OPRATOR_NO = entity.OPRATOR_NO,      
                MEMBER_LEVEL = entity.MEMBER_LEVEL,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                OPEN_IS_ENABLED = entity.OPEN_IS_ENABLED,      
                OPEN_APP_ID = entity.OPEN_APP_ID,      
                OPEN_APP_SECRET = entity.OPEN_APP_SECRET,      
                OPEN_APP_TOKEN = entity.OPEN_APP_TOKEN,      
                OPEN_SECRET_KEY = entity.OPEN_SECRET_KEY,      
                CLIENT_IP = entity.CLIENT_IP,      
                ERP_API_OURL = entity.ERP_API_OURL,      
                ERP_API_NURL = entity.ERP_API_NURL,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO,      
                IS_GROUP = entity.IS_GROUP,      
                IS_APPCONFIG = entity.IS_APPCONFIG,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                IS_ONLYSTORE = entity.IS_ONLYSTORE,      
                IS_IRIS = entity.IS_IRIS,      
                ERP_APP_ID = entity.ERP_APP_ID,      
                ERP_APP_KEY = entity.ERP_APP_KEY,      
                ERP_APP_SECRET = entity.ERP_APP_SECRET,      
                WXPAY_RETURNURL = entity.WXPAY_RETURNURL,      
                IRIS_APT_URL = entity.IRIS_APT_URL,      
                IRIS_CHAT_URL = entity.IRIS_CHAT_URL,      
                APT_URL = entity.APT_URL,      
                IS_TRANSFER = entity.IS_TRANSFER,      
                IS_SEND_MSG = entity.IS_SEND_MSG,      
                SMS_MSG_CODE = entity.SMS_MSG_CODE,      
                IS_EXCHANGE_TICKET = entity.IS_EXCHANGE_TICKET,      
                REDIS_NUM = entity.REDIS_NUM,      
                SALE_APT = entity.SALE_APT,      
                AFTER_SALE_APT = entity.AFTER_SALE_APT,      
                IS_BZT = entity.IS_BZT,      
                TOKEN_USR_NAME = entity.TOKEN_USR_NAME,      
                TOKEN_USR_PWD = entity.TOKEN_USR_PWD,      
                GRANT_TYPE = entity.GRANT_TYPE,      
                CLIENT_ID = entity.CLIENT_ID,      
                CLIENT_SECRET = entity.CLIENT_SECRET,      
                IBZT_URL = entity.IBZT_URL,      
                GOODS_FROM = entity.GOODS_FROM,      
                CAR_FROM = entity.CAR_FROM,      
                BZT_TOKEN = entity.BZT_TOKEN,      
                BZT_TOKEN_TIME = entity.BZT_TOKEN_TIME,      
                IS_RANDOMSALE = entity.IS_RANDOMSALE,      
                IS_CAR_BIND = entity.IS_CAR_BIND,      
                IS_APT_REMIND = entity.IS_APT_REMIND,      
                IS_APT_GROUP = entity.IS_APT_GROUP
            };
        }
    }
}