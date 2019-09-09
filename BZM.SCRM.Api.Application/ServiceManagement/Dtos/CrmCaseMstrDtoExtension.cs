
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class CrmCaseMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static CrmCaseMstr ToEntity( this CrmCaseMstrDto dto ) {
            if( dto == null )
                return new CrmCaseMstr();
            return new CrmCaseMstr() {
                Id = dto.Id,
                CASE_TYPE = dto.CASE_TYPE,
                CASE_CLASS = dto.CASE_CLASS,
                REF_BIZ_NO = dto.REF_BIZ_NO,
                REF_BIZ_DEPT = dto.REF_BIZ_DEPT,
                CUS_ORG_NAME = dto.CUS_ORG_NAME,
                CUS_FROM = dto.CUS_FROM,
                CUS_NAME = dto.CUS_NAME,
                CUS_MOBILE = dto.CUS_MOBILE,
                CAR_NO = dto.CAR_NO,
                CASE_FROM = dto.CASE_FROM,
                CASE_PRIORITY = dto.CASE_PRIORITY,
                CASE_CONTENT = dto.CASE_CONTENT,
                CASE_STATUS = dto.CASE_STATUS,
                CASE_OWNER = dto.CASE_OWNER,
                REF_CASE_NO = dto.REF_CASE_NO,
                FCST_FINISH_DATE = dto.FCST_FINISH_DATE,
                CONTRACT_MOBILE = dto.CONTRACT_MOBILE,
                CONTRACT_EMAIL = dto.CONTRACT_EMAIL,
                CSI_RESULT = dto.CSI_RESULT,
                CSI_RSN = dto.CSI_RSN,
                CASE_DATE = dto.CASE_DATE,
                CASE_WHERE = dto.CASE_WHERE,
                CASE_REASON = dto.CASE_REASON,
                CASE_RESULT = dto.CASE_RESULT,
                CUS_RESULT = dto.CUS_RESULT,
                CASE_SOLUTION = dto.CASE_SOLUTION,
                EXPENSE_ACCT_NO = dto.EXPENSE_ACCT_NO,
                EXPENSE_BANK = dto.EXPENSE_BANK,
                EXPENSE_ACCT_NAME = dto.EXPENSE_ACCT_NAME,
                EXPENSE_AMT = dto.EXPENSE_AMT,
                CHARGE_MOBILE = dto.CHARGE_MOBILE,
                GIFT_NAME = dto.GIFT_NAME,
                GIFT_ADDR = dto.GIFT_ADDR,
                RESPONSIBLE_PSN = dto.RESPONSIBLE_PSN,
                RESPONSIBLE_PSN_PAY = dto.RESPONSIBLE_PSN_PAY,
                ATTACHMENT_PATH1 = dto.ATTACHMENT_PATH1,
                ATTACHMENT_PATH2 = dto.ATTACHMENT_PATH2,
                ATTACHMENT_PATH3 = dto.ATTACHMENT_PATH3,
                ATTACHMENT_PATH4 = dto.ATTACHMENT_PATH4,
                ATTACHMENT_PATH5 = dto.ATTACHMENT_PATH5,
                WORKFLOW_NO = dto.WORKFLOW_NO,
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
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                DEL_FLAG = dto.DEL_FLAG,
                BG_NO = dto.BG_NO
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static CrmCaseMstrDto ToDto( this CrmCaseMstr entity ) {
             if( entity == null )
                return new CrmCaseMstrDto();
            return new CrmCaseMstrDto {
                Id = entity.Id,
                CASE_TYPE = entity.CASE_TYPE,      
                CASE_CLASS = entity.CASE_CLASS,      
                REF_BIZ_NO = entity.REF_BIZ_NO,      
                REF_BIZ_DEPT = entity.REF_BIZ_DEPT,      
                CUS_ORG_NAME = entity.CUS_ORG_NAME,      
                CUS_FROM = entity.CUS_FROM,      
                CUS_NAME = entity.CUS_NAME,      
                CUS_MOBILE = entity.CUS_MOBILE,      
                CAR_NO = entity.CAR_NO,      
                CASE_FROM = entity.CASE_FROM,      
                CASE_PRIORITY = entity.CASE_PRIORITY,      
                CASE_CONTENT = entity.CASE_CONTENT,      
                CASE_STATUS = entity.CASE_STATUS,      
                CASE_OWNER = entity.CASE_OWNER,      
                REF_CASE_NO = entity.REF_CASE_NO,      
                FCST_FINISH_DATE = entity.FCST_FINISH_DATE,      
                CONTRACT_MOBILE = entity.CONTRACT_MOBILE,      
                CONTRACT_EMAIL = entity.CONTRACT_EMAIL,      
                CSI_RESULT = entity.CSI_RESULT,      
                CSI_RSN = entity.CSI_RSN,      
                CASE_DATE = entity.CASE_DATE,      
                CASE_WHERE = entity.CASE_WHERE,      
                CASE_REASON = entity.CASE_REASON,      
                CASE_RESULT = entity.CASE_RESULT,      
                CUS_RESULT = entity.CUS_RESULT,      
                CASE_SOLUTION = entity.CASE_SOLUTION,      
                EXPENSE_ACCT_NO = entity.EXPENSE_ACCT_NO,      
                EXPENSE_BANK = entity.EXPENSE_BANK,      
                EXPENSE_ACCT_NAME = entity.EXPENSE_ACCT_NAME,      
                EXPENSE_AMT = entity.EXPENSE_AMT,      
                CHARGE_MOBILE = entity.CHARGE_MOBILE,      
                GIFT_NAME = entity.GIFT_NAME,      
                GIFT_ADDR = entity.GIFT_ADDR,      
                RESPONSIBLE_PSN = entity.RESPONSIBLE_PSN,      
                RESPONSIBLE_PSN_PAY = entity.RESPONSIBLE_PSN_PAY,      
                ATTACHMENT_PATH1 = entity.ATTACHMENT_PATH1,      
                ATTACHMENT_PATH2 = entity.ATTACHMENT_PATH2,      
                ATTACHMENT_PATH3 = entity.ATTACHMENT_PATH3,      
                ATTACHMENT_PATH4 = entity.ATTACHMENT_PATH4,      
                ATTACHMENT_PATH5 = entity.ATTACHMENT_PATH5,      
                WORKFLOW_NO = entity.WORKFLOW_NO,      
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
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                DEL_FLAG = entity.DEL_FLAG,      
                BG_NO = entity.BG_NO
            };
        }
    }
}