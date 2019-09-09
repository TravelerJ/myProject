using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common
{
    /// <summary>
    /// 权限helper
    /// </summary>
    public class PermissionHelper
    {
        /// <summary>
        /// 根据用户类型获取查询条件
        /// </summary>
        /// <param name="userType">用户类型(微信客户:0普通管理员:2集团账号:1超级管理员:9)</param>
        /// <param name="userScope">用户角色权限(集团JT,区域QY,门店MD)</param>
        /// <param name="orgColumn">表中机构列名</param>
        /// <param name="orgNo">机构编码</param>
        /// <param name="bgNo">集团编码</param>
        /// <returns></returns>
        public string GetCondition(string userType, string userScope,string orgColumn, string orgNo, string bgNo)
        {
            string where = string.Empty;

            switch (userType)
            {
                case "2":
                    switch (userScope)
                    {
                        case "JT":
                            orgColumn = orgColumn.IndexOf(".") > -1 ? orgColumn.Split('.')[0] + "." : "";
                            where = "" + orgColumn + "BG_NO='" + bgNo + "'";
                            break;
                        case "QY":
                            where = string.Format(" {0}  IN(select bu_no from mdm_bu_mstr where PARENT_BU_NO='{1}' or bu_no='{1}')", orgColumn, orgNo);
                            break;
                        case "MD":
                            where = "" + orgColumn + "='" + orgNo + "'";
                            break;
                    }                    
                    break;
                case "1":
                    orgColumn = orgColumn.IndexOf(".") > -1 ? orgColumn.Split('.')[0] + "." : "";
                    where = "" + orgColumn + "BG_NO='" + bgNo + "'";
                    break;
                case "9":
                    where = "";
                    break;
                default:
                    where = "" + orgColumn + "='" + orgNo + "'";
                    break;
            }
            return where;
        }

        /// <summary>
        /// 获取角色规则sql
        /// </summary>
        /// <param name="userType">用户类型(微信客户:0普通管理员:2集团账号:1超级管理员:9)</param>
        /// <param name="userScope">用户角色权限(集团JT,区域QY,门店MD)</param>
        /// <param name="orgNo">机构编码</param>
        /// <param name="bgNo">集团编码</param>
        /// <param name="orgColumn">标识</param>
        /// <returns></returns>
        public string GetRoleSql(string userType, string userScope, string orgNo, string bgNo,string orgColumn="")
        {
            var where = string.IsNullOrEmpty(orgColumn) ? "1=1 and ROLE_STATUS=1 and DEL_FLAG=1" : "1=1 and " + orgColumn + "ROLE_STATUS=1 and " + orgColumn + "DEL_FLAG=1";
            switch (userType)
            {
                case "2":
                    switch (userScope)
                    {
                        case "JT":
                            where += " and " + orgColumn + "BG_NO='" + bgNo + "'";
                            break;
                        case "QY":
                            where += string.Format("  and ROLE_SCOPE IN('QY','MD') and CREATE_ORG_NO IN(select bu_no from mdm_bu_mstr where PARENT_BU_NO='{0}' or bu_no='{0}') and BG_NO='{1}'", orgNo, bgNo);
                            break;
                        case "MD":
                            where += "  and " + orgColumn + "ROLE_SCOPE='MD' and " + orgColumn + "CREATE_ORG_NO='" + orgNo + "'";
                            break;
                    }
                    break;
                case "1":
                    where += " and " + orgColumn + "BG_NO='" + bgNo + "'";
                    break;
                case "9":
                    break;
                default:
                    where += " and " + orgColumn + "ROLE_SCOPE='MD' and " + orgColumn + "CREATE_ORG_NO='" + orgNo + "'";
                    break;
            }
            return where;
        }
    }
}
