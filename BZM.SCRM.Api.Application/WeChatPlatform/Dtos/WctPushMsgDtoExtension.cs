
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Application.WeChatPlatform.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class WctPushMsgDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static WctPushMsg ToEntity( this WctPushMsgDto dto ) {
            if( dto == null )
                return new WctPushMsg();
            return new WctPushMsg() {
                Id = dto.Id,
                MSG_TYPE = dto.MSG_TYPE,
                MSG_RMK = dto.MSG_RMK,
                FANS_TAG = dto.FANS_TAG,
                WCT_SERVICE_NO = dto.WCT_SERVICE_NO,
                WCT_SSPT_NO = dto.WCT_SSPT_NO,
                MSG_CONTENT = dto.MSG_CONTENT,
                MSG_STATUS = dto.MSG_STATUS,
                PUSH_DATE = dto.PUSH_DATE,
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
                MEDIA_ID = dto.MEDIA_ID,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static WctPushMsgDto ToDto( this WctPushMsg entity ) {
             if( entity == null )
                return new WctPushMsgDto();
            return new WctPushMsgDto {
                Id = entity.Id,
                MSG_TYPE = entity.MSG_TYPE,      
                MSG_RMK = entity.MSG_RMK,      
                FANS_TAG = entity.FANS_TAG,      
                WCT_SERVICE_NO = entity.WCT_SERVICE_NO,      
                WCT_SSPT_NO = entity.WCT_SSPT_NO,      
                MSG_CONTENT = entity.MSG_CONTENT,      
                MSG_STATUS = entity.MSG_STATUS,      
                PUSH_DATE = entity.PUSH_DATE,      
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
                MEDIA_ID = entity.MEDIA_ID,      
                BG_NO = entity.BG_NO
            };
        }
    }
}