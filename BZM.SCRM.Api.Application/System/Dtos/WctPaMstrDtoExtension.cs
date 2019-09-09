using SCRM.Domain.System.Entitys;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctPaMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctPaMstr ToEntity( this WctPaMstrDto dto ) {
            if( dto == null )
                return new WctPaMstr();
            return new WctPaMstr() {
                Id = dto.Id,
                PA_NAME = dto.PA_NAME,
                PA_ORIGINAL_ID = dto.PA_ORIGINAL_ID,
                PA_APPID = dto.PA_APPID,
                PA_APPSECRET = dto.PA_APPSECRET,
                PA_USER = dto.PA_USER,
                PA_PASSWORD = dto.PA_PASSWORD,
                PA_ID_NO = dto.PA_ID_NO,
                PA_TYPE_ID = dto.PA_TYPE_ID,
                PA_AUTH_URL = dto.PA_AUTH_URL,
                PA_CUS_SVC_ENABLED = dto.PA_CUS_SVC_ENABLED,
                PA_ENCODINGAESKEY = dto.PA_ENCODINGAESKEY,
                PA_ACCESS_TOKEN = dto.PA_ACCESS_TOKEN,
                PA_ACCESS_TOKEN_EXP_TIME = dto.PA_ACCESS_TOKEN_EXP_TIME,
                PA_JSAPITICKET = dto.PA_JSAPITICKET,
                PA_JSAPITICKET_EXP_TIME = dto.PA_JSAPITICKET_EXP_TIME,
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
                PA_MANAGER_EMAIL = dto.PA_MANAGER_EMAIL,
                DEL_FLAG = dto.DEL_FLAG,
                BPMPAYCHANNELID = dto.BPMPAYCHANNELID,
                MCH_ID = dto.MCH_ID,
                SIGNKEY = dto.SIGNKEY,
                AUTHORIZER_ACCESS_TOKEN = dto.AUTHORIZER_ACCESS_TOKEN,
                AUTHORIZER_REFRESH_TOKEN = dto.AUTHORIZER_REFRESH_TOKEN,
                AUTHORIZER_TOKEN_TIME = dto.AUTHORIZER_TOKEN_TIME,
                OP_AUTH_STATUS = dto.OP_AUTH_STATUS,
                BG_NO = dto.BG_NO,
                APICLIENT_CERT = dto.APICLIENT_CERT,
                PA_FOLLOW_URL = dto.PA_FOLLOW_URL,
                PA_TEMPLATE_SERVICE = dto.PA_TEMPLATE_SERVICE,
                PA_TEMPLATE_TICKET_VERIFICA = dto.PA_TEMPLATE_TICKET_VERIFICA,
                PA_TEMPLATE_TICKET_ISSUE = dto.PA_TEMPLATE_TICKET_ISSUE,
                PA_TEMPLATE_APT = dto.PA_TEMPLATE_APT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctPaMstrDto ToDto( this WctPaMstr entity ) {
             if( entity == null )
                return new WctPaMstrDto();
            return new WctPaMstrDto {
                Id = entity.Id,
                PA_NAME = entity.PA_NAME,      
                PA_ORIGINAL_ID = entity.PA_ORIGINAL_ID,      
                PA_APPID = entity.PA_APPID,      
                PA_APPSECRET = entity.PA_APPSECRET,      
                PA_USER = entity.PA_USER,      
                PA_PASSWORD = entity.PA_PASSWORD,      
                PA_ID_NO = entity.PA_ID_NO,      
                PA_TYPE_ID = entity.PA_TYPE_ID,      
                PA_AUTH_URL = entity.PA_AUTH_URL,      
                PA_CUS_SVC_ENABLED = entity.PA_CUS_SVC_ENABLED,      
                PA_ENCODINGAESKEY = entity.PA_ENCODINGAESKEY,      
                PA_ACCESS_TOKEN = entity.PA_ACCESS_TOKEN,      
                PA_ACCESS_TOKEN_EXP_TIME = entity.PA_ACCESS_TOKEN_EXP_TIME,      
                PA_JSAPITICKET = entity.PA_JSAPITICKET,      
                PA_JSAPITICKET_EXP_TIME = entity.PA_JSAPITICKET_EXP_TIME,      
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
                PA_MANAGER_EMAIL = entity.PA_MANAGER_EMAIL,      
                DEL_FLAG = entity.DEL_FLAG,      
                BPMPAYCHANNELID = entity.BPMPAYCHANNELID,      
                MCH_ID = entity.MCH_ID,      
                SIGNKEY = entity.SIGNKEY,      
                AUTHORIZER_ACCESS_TOKEN = entity.AUTHORIZER_ACCESS_TOKEN,      
                AUTHORIZER_REFRESH_TOKEN = entity.AUTHORIZER_REFRESH_TOKEN,      
                AUTHORIZER_TOKEN_TIME = entity.AUTHORIZER_TOKEN_TIME,      
                OP_AUTH_STATUS = entity.OP_AUTH_STATUS,      
                BG_NO = entity.BG_NO,      
                APICLIENT_CERT = entity.APICLIENT_CERT,      
                PA_FOLLOW_URL = entity.PA_FOLLOW_URL,      
                PA_TEMPLATE_SERVICE = entity.PA_TEMPLATE_SERVICE,      
                PA_TEMPLATE_TICKET_VERIFICA = entity.PA_TEMPLATE_TICKET_VERIFICA,      
                PA_TEMPLATE_TICKET_ISSUE = entity.PA_TEMPLATE_TICKET_ISSUE,      
                PA_TEMPLATE_APT = entity.PA_TEMPLATE_APT
            };
        }
    }
}