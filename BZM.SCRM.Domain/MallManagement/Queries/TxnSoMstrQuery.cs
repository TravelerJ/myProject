namespace SCRM.Domain.MallManagement.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TxnSoMstrQuery {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string ERP_MEMBER_NO { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string START_DATE { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string END_DATE { get; set; }
    }
}