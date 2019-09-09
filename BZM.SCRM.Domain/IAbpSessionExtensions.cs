using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain
{
    public interface IAbpSessionExtensions : IAbpSession
    {
        /// <summary>
        /// 主键
        /// </summary>
        int USR_ID { get; }
        /// <summary>
        /// 用户名
        /// </summary>
        string USR_NAME { get; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        string USR_REAL_NAME { get; }
        /// <summary>
        /// 手机
        /// </summary>
        string USR_MOBILE { get; }
        /// <summary>
        /// 头像
        /// </summary>
        string USR_AVATAR_PATH { get; }
        /// <summary>
        /// erp员工编码
        /// </summary>
        string ERP_EMP_ID { get; }
        /// <summary>
        /// 用户类型0游客1集团管理员2普通管理员9超级管理员
        /// </summary>
        string USR_TYPE { get; }
        /// <summary>
        /// erp客户编号
        /// </summary>
        string ERP_CUS_NO { get; }
        /// <summary>
        /// erp会员编号
        /// </summary>
        string ERP_MEMBER_NO { get; }
        /// <summary>
        /// 用户角色范围
        /// </summary>
        string USR_SCOPE { get; }
        /// <summary>
        /// openId
        /// </summary>
        string OPEN_ID { get; }
        /// <summary>
        /// 机构编码
        /// </summary>
        string ORG_NO { get; }
        /// <summary>
        /// 集团编码
        /// </summary>
        string BG_NO { get; }
    }
}
