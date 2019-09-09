using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BZM.SCRM.Domain.Common.FileLogHelper
{
    /// <summary>
    /// 日志helper
    /// </summary>
    public class FileLog
    {
        #region property
        /// <summary>
        /// 文件名称
        /// </summary>
        private string FilePath { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string LogRoutePath { private set; get; }
        #endregion

        #region constructor
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="pathname"></param>
        public FileLog(string pathname)
        {
            LogRoutePath = pathname;
            if (string.IsNullOrEmpty(pathname))
            {
                throw new Exception("没有初始化 Log 类的 PathName 变量");
            }

            FilePath = AppDomain.CurrentDomain.BaseDirectory + $"App_Log/{pathname}";
            CreateDirectory(FilePath);
        }


        #endregion

        #region method
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fileType"></param>
        public void Write(string msg, string fileType = "")
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                var _FilePath = FilePath;
                if (!string.IsNullOrEmpty(fileType))
                {
                    _FilePath += $"/{fileType}";
                    CreateDirectory(FilePath);
                }
                _FilePath += $"/{DateTime.Now.ToString("yyyy-MM-dd")}.log";
                using (FileStream fileStream = new FileStream(_FilePath, FileMode.Append, FileAccess.Write, FileShare.Write))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding("GBK"));
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"));
                        stringBuilder.Append("\t\t");
                        stringBuilder.Append(msg);
                        stringBuilder.Append("\r\n");

                        streamWriter.WriteLine(stringBuilder.ToString());
                    }
                    catch
                    {
                        // ignored
                    }

                    streamWriter.Close();
                }
            }
        }
        #endregion

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateDirectory(string fileName)
        {
            if (Directory.Exists(fileName)) return;
            try
            {
                Directory.CreateDirectory(fileName);
            }
            catch
            {
                // ignored
            }
        }
    }
}
