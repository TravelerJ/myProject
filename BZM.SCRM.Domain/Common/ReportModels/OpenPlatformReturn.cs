using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 开放平台token返回信息
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// 开放平台token
        /// </summary>
        public string component_access_token { get; set; }
        /// <summary>
        /// 时效
        /// </summary>

        public string expires_in { get; set; }
    }
    /// <summary>
    /// accestoken返回信息
    /// </summary>
    public class AccessTokenInfo
    {
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 时效
        /// </summary>
        public string expires_in { get; set; }
    }

    /// <summary>
    /// 创建标签
    /// </summary>
    public class CreateTag
    {
        /// <summary>
        /// 标签id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string name { get; set; }
    }
    /// <summary>
    /// 标签返回model
    /// </summary>
    public class TagObj
    {
        /// <summary>
        /// model
        /// </summary>
        public TagModel tag { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
    /// <summary>
    /// 标签body
    /// </summary>
    public class TagModel
    {
        /// <summary>
        /// tag编号
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string name { get; set; }
    }
}
