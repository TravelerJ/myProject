
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmAptMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmAptMstr ToEntity( this CrmAptMstrDto dto ) {
            if( dto == null )
                return new CrmAptMstr();
            return new CrmAptMstr() {
                Id = dto.Id,
                APT_NO = dto.APT_NO,
                APT_TYPE = dto.APT_TYPE,
                APT_CLASS = dto.APT_CLASS,
                APT_CHANNEL = dto.APT_CHANNEL,
                CUS_NO = dto.CUS_NO,
                CUS_NAME = dto.CUS_NAME,
                CUS_PHONE_NO = dto.CUS_PHONE_NO,
                MEMBER_NO = dto.MEMBER_NO,
                CAR_ID = dto.CAR_ID,
                VIN = dto.VIN,
                APT_DATE = dto.APT_DATE,
                APT_TIMESPAN = dto.APT_TIMESPAN,
                APT_SVC_ITEM = dto.APT_SVC_ITEM,
                APT_CONTENT = dto.APT_CONTENT,
                APT_BU_NO = dto.APT_BU_NO,
                EST_TOTAL_AMT = dto.EST_TOTAL_AMT,
                EST_TOTAL_QTY = dto.EST_TOTAL_QTY,
                EST_MH_AMT = dto.EST_MH_AMT,
                EST_MATERIAL_AMT = dto.EST_MATERIAL_AMT,
                APT_RMK = dto.APT_RMK,
                CONSIGNER = dto.CONSIGNER,
                CONSIGNER_PHONE = dto.CONSIGNER_PHONE,
                IS_SA_APPOINT = dto.IS_SA_APPOINT,
                SERVICE_DESK = dto.SERVICE_DESK,
                APT_STATUS = dto.APT_STATUS,
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
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO,
                BOOKING_TYPE = dto.BOOKING_TYPE,
                OPENID = dto.OPENID,
                IS_INSHOP = dto.IS_INSHOP,
                IS_TIMEOUT = dto.IS_TIMEOUT
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmAptMstrDto ToDto( this CrmAptMstr entity ) {
             if( entity == null )
                return new CrmAptMstrDto();
            return new CrmAptMstrDto {
                Id = entity.Id,
                APT_NO = entity.APT_NO,      
                APT_TYPE = entity.APT_TYPE,      
                APT_CLASS = entity.APT_CLASS,      
                APT_CHANNEL = entity.APT_CHANNEL,      
                CUS_NO = entity.CUS_NO,      
                CUS_NAME = entity.CUS_NAME,      
                CUS_PHONE_NO = entity.CUS_PHONE_NO,      
                MEMBER_NO = entity.MEMBER_NO,      
                CAR_ID = entity.CAR_ID,      
                VIN = entity.VIN,      
                APT_DATE = entity.APT_DATE,      
                APT_TIMESPAN = entity.APT_TIMESPAN,      
                APT_SVC_ITEM = entity.APT_SVC_ITEM,      
                APT_CONTENT = entity.APT_CONTENT,      
                APT_BU_NO = entity.APT_BU_NO,      
                EST_TOTAL_AMT = entity.EST_TOTAL_AMT,      
                EST_TOTAL_QTY = entity.EST_TOTAL_QTY,      
                EST_MH_AMT = entity.EST_MH_AMT,      
                EST_MATERIAL_AMT = entity.EST_MATERIAL_AMT,      
                APT_RMK = entity.APT_RMK,      
                CONSIGNER = entity.CONSIGNER,      
                CONSIGNER_PHONE = entity.CONSIGNER_PHONE,      
                IS_SA_APPOINT = entity.IS_SA_APPOINT,      
                SERVICE_DESK = entity.SERVICE_DESK,      
                APT_STATUS = entity.APT_STATUS,      
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
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO,      
                BOOKING_TYPE = entity.BOOKING_TYPE,      
                OPENID = entity.OPENID,      
                IS_INSHOP = entity.IS_INSHOP,      
                IS_TIMEOUT = entity.IS_TIMEOUT
            };
        }
    }
}