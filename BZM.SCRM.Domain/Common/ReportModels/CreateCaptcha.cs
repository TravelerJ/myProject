using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.ReportModels
{
   public class CreateCaptcha
    {
        /// <summary>
        /// 验证码位数
        /// </summary>
        public int codeNum { get; set; }
        /// <summary>
        /// 图片长
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 图片高
        /// </summary>
        public int height { get; set; }
    }
}
