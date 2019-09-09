using Abp.Dependency;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System.Linq;

namespace SCRM.Application.System.Dtos {
    /// <summary>
    /// 数据传输对象扩展
    /// </summary>
    public static class SysUsrMstrDtoExtension {    
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public static SysUsrMstr ToEntity( this SysUsrMstrDto dto ) {
            if( dto == null )
                return new SysUsrMstr();
            return new SysUsrMstr() {
                Id = dto.Id,
                USR_NAME = dto.USR_NAME,
                USR_PWD = dto.USR_PWD,
                USR_STATUS = dto.USR_STATUS,
                USR_AVATAR_STATUS = dto.USR_AVATAR_STATUS,
                USR_REG_DATE = dto.USR_REG_DATE,
                ORG_NO = dto.ORG_NO,
                CREATE_PSN = dto.CREATE_PSN,
                CREATE_DATE = dto.CREATE_DATE,
                UPDATE_PSN = dto.UPDATE_PSN,
                UPDATE_DATE = dto.UPDATE_DATE,
                CREATE_ORG_NO = dto.CREATE_ORG_NO,
                USR_REAL_NAME = dto.USR_REAL_NAME,
                USR_MOBILE = dto.USR_MOBILE,
                USR_EMAIL = dto.USR_EMAIL,
                USR_MOBILE_PASS = dto.USR_MOBILE_PASS,
                USR_AVATAR_PATH = dto.USR_AVATAR_PATH,
                USR_ALIPAY = dto.USR_ALIPAY,
                INVITATION_CODE = dto.INVITATION_CODE,
                FROM_CHANNEL = dto.FROM_CHANNEL,
                FROM_INVITATION_CODE = dto.FROM_INVITATION_CODE,
                UDF1 = dto.UDF1,
                UDF2 = dto.UDF2,
                UDF3 = dto.UDF3,
                UDF4 = dto.UDF4,
                UDF5 = dto.UDF5,
                USR_NICKNAME = dto.USR_NICKNAME,
                USR_REGION = dto.USR_REGION,
                DEL_FLAG = dto.DEL_FLAG,
                ERP_ORG_NO = dto.ERP_ORG_NO,
                ERP_EMP_ID = dto.ERP_EMP_ID,
                USR_DEVICE_ID = dto.USR_DEVICE_ID,
                USR_EMP_NO = dto.USR_EMP_NO,
                USR_TYPE = dto.USR_TYPE,
                DEPT_ID = dto.DEPT_ID,
                USR_BIZ_FROM = dto.USR_BIZ_FROM,
                USR_ASSIGN_SPAN = dto.USR_ASSIGN_SPAN,
                USR_ASSIGN_AUTO = dto.USR_ASSIGN_AUTO,
                USR_CURRENT_STATUS = dto.USR_CURRENT_STATUS,
                BEAT_DATE = dto.BEAT_DATE,
                LOGIN_DATE = dto.LOGIN_DATE,
                LOGOUT_DATE = dto.LOGOUT_DATE,
                SUP_NO = dto.SUP_NO,
                USR_GRADE = dto.USR_GRADE,
                USR_ROLE_NAMES = dto.USR_ROLE_NAMES,
                USR_DESC = dto.USR_DESC,
                USR_JOB = dto.USR_JOB,
                USR_FIELD = dto.USR_FIELD,
                USR_HOBBY = dto.USR_HOBBY,
                USR_LOCATION = dto.USR_LOCATION,
                USR_QRCODE_PATH = dto.USR_QRCODE_PATH,
                LAST_REC_ORDER_DATE = dto.LAST_REC_ORDER_DATE,
                ERP_CUS_NO = dto.ERP_CUS_NO,
                ERP_MEMBER_NO = dto.ERP_MEMBER_NO,
                USR_SPELL = dto.USR_SPELL,
                BG_NO = dto.BG_NO,
                OPEN_ID = dto.OPEN_ID,
                SALE_BRANDS = dto.SALE_BRANDS,
                DUTY_ID=dto.DUTY_ID
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        public static SysUsrMstrDto ToDto( this SysUsrMstr entity ) {
             if( entity == null )
                return new SysUsrMstrDto();
            return new SysUsrMstrDto {
                Id = entity.Id,
                USR_NAME = entity.USR_NAME,      
                USR_PWD = entity.USR_PWD,      
                USR_STATUS = entity.USR_STATUS,      
                USR_AVATAR_STATUS = entity.USR_AVATAR_STATUS,      
                USR_REG_DATE = entity.USR_REG_DATE,      
                ORG_NO = entity.ORG_NO,      
                CREATE_PSN = entity.CREATE_PSN,      
                CREATE_DATE = entity.CREATE_DATE,      
                UPDATE_PSN = entity.UPDATE_PSN,      
                UPDATE_DATE = entity.UPDATE_DATE,      
                CREATE_ORG_NO = entity.CREATE_ORG_NO,      
                USR_REAL_NAME = entity.USR_REAL_NAME,      
                USR_MOBILE = entity.USR_MOBILE,      
                USR_EMAIL = entity.USR_EMAIL,      
                USR_MOBILE_PASS = entity.USR_MOBILE_PASS,      
                USR_AVATAR_PATH = entity.USR_AVATAR_PATH,      
                USR_ALIPAY = entity.USR_ALIPAY,      
                INVITATION_CODE = entity.INVITATION_CODE,      
                FROM_CHANNEL = entity.FROM_CHANNEL,      
                FROM_INVITATION_CODE = entity.FROM_INVITATION_CODE,      
                UDF1 = entity.UDF1,      
                UDF2 = entity.UDF2,      
                UDF3 = entity.UDF3,      
                UDF4 = entity.UDF4,      
                UDF5 = entity.UDF5,      
                USR_NICKNAME = entity.USR_NICKNAME,      
                USR_REGION = entity.USR_REGION,      
                DEL_FLAG = entity.DEL_FLAG,      
                ERP_ORG_NO = entity.ERP_ORG_NO,      
                ERP_EMP_ID = entity.ERP_EMP_ID,      
                USR_DEVICE_ID = entity.USR_DEVICE_ID,      
                USR_EMP_NO = entity.USR_EMP_NO,      
                USR_TYPE = entity.USR_TYPE,      
                DEPT_ID = entity.DEPT_ID,      
                USR_BIZ_FROM = entity.USR_BIZ_FROM,      
                USR_ASSIGN_SPAN = entity.USR_ASSIGN_SPAN,      
                USR_ASSIGN_AUTO = entity.USR_ASSIGN_AUTO,      
                USR_CURRENT_STATUS = entity.USR_CURRENT_STATUS,      
                BEAT_DATE = entity.BEAT_DATE,      
                LOGIN_DATE = entity.LOGIN_DATE,      
                LOGOUT_DATE = entity.LOGOUT_DATE,      
                SUP_NO = entity.SUP_NO,      
                USR_GRADE = entity.USR_GRADE,      
                USR_ROLE_NAMES = entity.USR_ROLE_NAMES,      
                USR_DESC = entity.USR_DESC,      
                USR_JOB = entity.USR_JOB,      
                USR_FIELD = entity.USR_FIELD,      
                USR_HOBBY = entity.USR_HOBBY,      
                USR_LOCATION = entity.USR_LOCATION,      
                USR_QRCODE_PATH = entity.USR_QRCODE_PATH,      
                LAST_REC_ORDER_DATE = entity.LAST_REC_ORDER_DATE,      
                ERP_CUS_NO = entity.ERP_CUS_NO,      
                ERP_MEMBER_NO = entity.ERP_MEMBER_NO,      
                USR_SPELL = entity.USR_SPELL,      
                BG_NO = entity.BG_NO,      
                OPEN_ID = entity.OPEN_ID,      
                SALE_BRANDS = entity.SALE_BRANDS,
                DUTY_ID=entity.DUTY_ID,
                RoleIds= GetRoleIds(entity.Id)
            };
        }
        private static string GetRoleIds(decimal userId)
        {
            var roleId = "";
            if (userId == 0)
                return roleId;
            var auth = IocManager.Instance.IocContainer.Resolve<ISysUsrAuthRepository>().GetAllList(c => c.USR_ID == userId).OrderBy(c => c.ROLE_ID).ToList();
            if (auth.Count > 0)
            {
                roleId = string.Join(',', auth.Select(c => c.ROLE_ID).ToList());
            }
            return roleId;
        }
    }
}