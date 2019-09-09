using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
    /// <summary>
    /// 预约参数输入
    /// </summary>
    public class AptMessageInput
    {
        /// <summary>
        /// 预约
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 预约结果
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// remark
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// openid
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>

        public string orgNo { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        public string bgNo { get; set; }
    }

    /// <summary>
    /// 预约成功参数输入
    /// </summary>
    public class AptTemplateInfo
    {
        /// <summary>
        /// 头部内容
        /// </summary>
        public string first { get; set; }
        /// <summary>
        /// 预约人
        /// </summary>
        public string cusName { get; set; }
        /// <summary>
        /// 预约项目
        /// </summary>
        public string aptServiceName { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string aptDate { get; set; }
        /// <summary>
        /// 预约手机
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// openid
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 跳转路径
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string orgNo { get; set; }
        /// <summary>
        /// 集团编码
        /// </summary>
        public string bgNo { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string orgName { get; set; }
    }

}
