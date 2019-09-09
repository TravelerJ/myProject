namespace SCRM.Domain.InformationActivitie.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WctCommentMstrQuery {
        /// <summary>
        /// 文章创建人
        /// </summary>
        public string CREATE_PSN { get; set; }
        /// <summary>
        /// 是否主评论
        /// </summary>
        public bool IsMainComment { get; set; }
    }
}