
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmSurveyRsltMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmSurveyRsltMstr ToEntity( this CrmSurveyRsltMstrDto dto ) {
            if( dto == null )
                return new CrmSurveyRsltMstr();
            return new CrmSurveyRsltMstr() {
                Id = dto.Id,
                SURVEY_ID = dto.SURVEY_ID,
                SURVEY_TITLE = dto.SURVEY_TITLE,
                ANSWER_JSON = dto.ANSWER_JSON,
                ANSWER_SCORE = dto.ANSWER_SCORE,
                REPORT_PSN = dto.REPORT_PSN,
                REPORT_NAME = dto.REPORT_NAME,
                REPORT_OPENID = dto.REPORT_OPENID,
                REPORT_DATE = dto.REPORT_DATE,
                REPORT_IP = dto.REPORT_IP,
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
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmSurveyRsltMstrDto ToDto( this CrmSurveyRsltMstr entity ) {
             if( entity == null )
                return new CrmSurveyRsltMstrDto();
            return new CrmSurveyRsltMstrDto {
                Id = entity.Id,
                SURVEY_ID = entity.SURVEY_ID,      
                SURVEY_TITLE = entity.SURVEY_TITLE,      
                ANSWER_JSON = entity.ANSWER_JSON,      
                ANSWER_SCORE = entity.ANSWER_SCORE,      
                REPORT_PSN = entity.REPORT_PSN,      
                REPORT_NAME = entity.REPORT_NAME,      
                REPORT_OPENID = entity.REPORT_OPENID,      
                REPORT_DATE = entity.REPORT_DATE,      
                REPORT_IP = entity.REPORT_IP,      
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
                BG_NO = entity.BG_NO
            };
        }
    }
}