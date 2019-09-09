

using BT.BPMLIVE.Common._IO;

namespace BZM.SCRM.Application.Common.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// 获取七牛token
        /// </summary>
        /// <returns></returns>
        string GetQiNiuToken();
        /// <summary>
        /// 获取微信跳转链接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="appId"></param>
        /// <param name="code"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        string GetWeChatUrl(string url, string appId, string code, Log log);
    }
}
