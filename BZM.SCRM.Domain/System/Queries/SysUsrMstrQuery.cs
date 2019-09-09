namespace SCRM.Domain.System.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SysUsrMstrQuery {
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 加密验证码
        /// </summary>
        public string cookie { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string DUTY_NAME { get; set; }
    }
}