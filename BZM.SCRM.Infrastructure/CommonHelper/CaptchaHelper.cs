using BZM.SCRM.Domain.Common.ReportModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BZM.SCRM.Infrastructure.CommonHelper
{
   public class CaptchaHelper
    {
        private static List<char> _characters;
        private const string ContentType = "image/jpeg";
        public CaptchaHelper()
        {
            //去掉0、o、O
            _characters = new List<char>();
            for (var i ='0'; i<='9'; i++)
            {
                if (i == '0')
                    continue;
                _characters.Add(i);
            }
            for (var i = 'a'; i <= 'z'; i++)
            {
                if (i == 'o')
                    continue;
                _characters.Add(i);
            }
            for (var i = 'A'; i <= 'Z'; i++)
            {
                if (i == 'O')
                    continue;
                _characters.Add(i);
            }
        }

        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="captchaCount"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public async Task<CaptchaInfo> CreateCaptcha(int captchaCount, int width, int height)
        {
            var model = new CaptchaInfo
            {
                ContentType = ContentType
            };
            var chars = new char[captchaCount];
            var len = _characters.Count;
            var random = new Random();
            //随机生成验证码
            for (var i = 0; i < chars.Length; i++)
            {
                var val = random.Next(len);
                chars[i] = _characters[val];
            }
            var captcha = string.Join(string.Empty, chars);//取出验证码
            model.Answer = await Des.Encrypt(captcha);//加密
            //定义字体集合
            var fontNames = new List<string>
            { "Helvetica", "Arial", "Lucida Family", "Verdana", "Tahoma", "Trebuchet MS", "Georgia", "Times" };

            // Bitmap 类 封装 GDI + 包含图形图像和其属性的像素数据的位图。 一个 Bitmap 是用来处理图像像素数据所定义的对象。
            //Bitmap 类 继承自 抽象基类 Image 类
            using (var bitmap = new Bitmap(width,height))
            {
                //Graphics 类 封装一个 GDI+ 绘图图面。
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    ///填充背景色
                    graphics.Clear(Color.White);
                    Disturb(random, bitmap, graphics, width / 2, height);

                    //添加灰色边框
                    var pen = new Pen(Color.Silver);
                    graphics.DrawRectangle(pen, 0, 0, width, height);

                    var x = 1;
                    var y = 5;
                    //定义一个矩形
                    var rectanngle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                    //随机颜色
                    //var color = Color.FromArgb(random.Next(110, 122), random.Next(110, 122), random.Next(110, 122));

                    foreach (var i in chars)
                    {
                        //随机选择字符 字体 大小
                        var fontName = fontNames[random.Next(0, fontNames.Count - 1)];
                        var font = new Font(fontName, random.Next(15, 20),FontStyle.Bold | FontStyle.Italic);

                        ///渐变字符颜色
                        using (var brush = new LinearGradientBrush(rectanngle,Color.Blue, Color.DarkRed, 1.2f, true))
                        {
                            brush.SetSigmaBellShape(0.5f);
                            graphics.DrawString(i.ToString(), font, brush, x + random.Next(-2, 2), y+random.Next(-5, 5));
                            x = x + width / captchaCount;
                        }
                    }
                    using (var ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Jpeg);
                        model.Image = ms.ToArray();
                        return model;
                    }
                }
            }
        }


        public bool VerifyCode(string cookie, string code)
        {
            var isOk = false;
            try
            {
                if (string.IsNullOrEmpty(cookie) || string.IsNullOrEmpty(code))
                {
                    isOk = false;
                    return isOk;
                }

                var result = Des.Decrypt(cookie);
                if (string.Equals(result.Result, code, StringComparison.CurrentCultureIgnoreCase))//忽略大小写比较
                {
                    isOk = true;
                }
            }
            catch (Exception)
            {
                return isOk;
            }
            return isOk;
        }
        /// <summary>
        /// 绘制干扰线
        /// </summary>
        /// <param name="random"></param>
        /// <param name="bitmap"></param>
        /// <param name="graphics"></param>
        /// <param name="linCount"></param>
        /// <param name="pointCount"></param>
        public void Disturb(Random random, Bitmap bitmap, Graphics graphics, int linCount, int pointCount)
        {
            
            var colors = new List<Color>
            {
                Color.AliceBlue,
                Color.Azure,
                Color.CadetBlue,
                Color.Beige,
                Color.Chartreuse
            };
            //干扰线
            for (var i = 0; i < linCount; i++)
            {
                var x1 = random.Next(bitmap.Width);
                var y1 = random.Next(bitmap.Height);
                var x2 = random.Next(bitmap.Width);
                var y2 = random.Next(bitmap.Height);
                //Pen 类 定义用于绘制直线和曲线的对象
                var pen = new Pen(colors[random.Next(0, colors.Count - 1)]);
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
            //干扰点
            for (var i = 0; i < pointCount; i++)
            {
                var x = random.Next(bitmap.Width);
                var y = random.Next(bitmap.Height);
                bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

        }
    }
}
