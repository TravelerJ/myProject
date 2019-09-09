using System;

namespace SCRM.Domain.WeChatPlatform.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SysUsrWctQuery {
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        public string realName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string orgNo { get; set; }
        /// <summary>
        /// 父级机构编码
        /// </summary>
        public string parentorgNo { get; set; }
        /// <summary>
        /// 是否拉黑(1是,0否)
        /// </summary>
        public bool IsBlack { get; set; }
        /// <summary>
        /// 开始注册日期
        /// </summary>
        public DateTime? BEGIN_REG_DATE { get; set; }
        /// <summary>
        /// 结束注册日期
        /// </summary>
        public DateTime? END_REG_DATE { get; set; }
    }
}