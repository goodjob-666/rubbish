using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Drawing.Text;
namespace FrameWork
{
    /// <summary>
    /// 图片处理类
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 构造函数: 默认
        /// </summary>
        public ImageHelper()
        { }
     

        #region 下载网络图片到本地
        public void DownloadImage(string url, string path)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = "GET";
            req.KeepAlive = true;
            req.ContentType = "image/*";
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            System.IO.Stream stream = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                Image.FromStream(stream).Save(path);
            }
            finally
            {
                // 释放资源
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        } 
        #endregion


        #region 给图片或文字加水印

        /// <summary>
        /// 给文字加水印
        /// </summary>
        /// <param name="sImage"></param>
        /// <param name="WaterText"></param>
        /// <param name="familyName"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontColor"></param>
        /// <param name="fontStyle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Bitmap WriteString(Bitmap sImage, string WaterText, string familyName, int fontSize, string fontColor, string fontStyle, float x, float y, int width, int height, int rotate)
        {
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(sImage))
            {
                if (WaterText != "")
                {
                    //fontSize = Convert.ToInt32(Convert.ToDouble(fontSize) / 96 * 72);   //像素转换为磅为单位
                    FontStyle fs = getFontStyle(fontStyle);
                    Font f;
                    Brush b;
                    if (familyName.IndexOf(".ttf") != -1)
                    {
                        PrivateFontCollection pfc = new PrivateFontCollection();
                        pfc.AddFontFile(familyName);
                        f = new Font(pfc.Families[0], fontSize, fs, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        f = new Font(familyName, fontSize, fs, GraphicsUnit.Pixel);
                    }
                    if (fontColor.IndexOf("#") != -1)
                    {
                        b = new SolidBrush(ColorTranslator.FromHtml(fontColor));
                    }
                    else
                    {
                        string[] arr = fontColor.Split(',');
                        b = new SolidBrush(Color.FromArgb(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2])));
                    }

                    var size = g.MeasureString(WaterText, f);
                    if (x == -1)
                    {
                        x = (sImage.Width - size.Width) / 2;
                    }

                    if (y == -1)
                    {
                        y = (sImage.Height - size.Height) / 2;
                    }
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    if (rotate > 0)
                    {
                        // 绘制围绕点旋转的文本  
                        StringFormat fmt = new StringFormat();
                        fmt.Alignment = StringAlignment.Center;
                        fmt.LineAlignment = StringAlignment.Center;

                        //设定文本打印区域 b是左上角坐标，Size是打印区域（矩形）
                        Point p = new Point((int)x, (int)y);
                        Rectangle r = new Rectangle(p, new Size(width, height));

                        Matrix mtxSave = g.Transform;
                        Matrix mtxRotate = g.Transform;
                        mtxRotate.RotateAt(180, p);
                        g.Transform = mtxRotate;

                        g.DrawString(WaterText, f, b, r, fmt);
                        g.Transform = mtxSave;
                    }
                    else
                    {
                        if (width > 0 && height > 0)
                        {
                            StringFormat fmt = new StringFormat();
                            fmt.LineAlignment = StringAlignment.Near;//左对齐
                            fmt.FormatFlags = StringFormatFlags.LineLimit;//自动换行

                            //设定文本打印区域 b是左上角坐标，Size是打印区域（矩形）
                            Point p = new Point((int)x, (int)y);
                            Rectangle r = new Rectangle(p, new Size(width, height));
                            // r.Y = r.Y - Convert.ToInt32(2 * mmtopt);
                            g.DrawString(WaterText, f, b, r, fmt);
                        }
                        else
                        {
                            //Brush b = new SolidBrush(ColorTranslator.FromHtml(fontColor));
                            g.DrawString(WaterText, f, b, x, y);
                        }
                    }
                }
                return sImage;
            }
        }

        private FontStyle getFontStyle(string fontStyle)
        {
            FontStyle f = FontStyle.Regular;
            switch (fontStyle)
            {
                case "Bold":
                    f = FontStyle.Bold;
                    break;
                case "Italic":
                    f = FontStyle.Italic;
                    break;
                case "Regular":
                    f = FontStyle.Regular;
                    break;
                case "Strikeout":
                    f = FontStyle.Strikeout;
                    break;
                case "Underline":
                    f = FontStyle.Underline;
                    break;
                default:
                    break;
            }
            return f;
        }

        /// <summary>
        /// 给图片加水印
        /// </summary>
        /// <param name="wBitmap">原图</param>
        /// <param name="xZb">X轴</param>
        /// <param name="yZb">Y轴</param>
        /// <returns></returns>
        public Bitmap CreateWatermark(Bitmap sBitmap, string fileName, int width, int height, int xZb, int yZb, bool isCircle)
        {
            Bitmap wBitmap = null;
            wBitmap = CutImage(fileName, width, height);
            if (isCircle)
            {
                wBitmap = CutEllipse(wBitmap, new Rectangle(0, 0, width, height), new Size(width, height));
            }

            Graphics graphics = GetGraphics(sBitmap);
            if (xZb == -1)
            {
                xZb = (sBitmap.Width - width) / 2;
            }

            if (yZb == -1)
            {
                yZb = (sBitmap.Height - height) / 2;
            }

            graphics.DrawImage(wBitmap, new Rectangle(xZb, yZb, wBitmap.Width, wBitmap.Height));
            graphics.Dispose();
            wBitmap.Dispose();
            return sBitmap;
        }

        /// <summary>
        /// 指定宽度和高度缩放并裁剪
        /// </summary>
        /// <param name="fromFile"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public Bitmap CutImage(string fromFile, int maxWidth, int maxHeight)
        {
            //从文件获取原始图片，并使用流中嵌入的颜色管理信息
            Bitmap initImage = new Bitmap(fromFile);

            //原图宽高均小于模版，不作处理，直接保存
            if (initImage.Width <= maxWidth && initImage.Height <= maxHeight)
            {
                return initImage;
            }
            else
            {
                //模版的宽高比例
                double templateRate = (double)maxWidth / maxHeight;
                //原图片的宽高比例
                double initRate = (double)initImage.Width / initImage.Height;

                //原图与模版比例相等，直接缩放
                if (templateRate == initRate)
                {
                    //按模版大小生成最终图片
                    Bitmap templateImage = new Bitmap(maxWidth, maxHeight);
                    Graphics templateG = GetGraphics(templateImage);
                    templateG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);

                    initImage.Dispose();
                    return templateImage;
                }
                //原图与模版比例不等，裁剪后缩放
                else
                {
                    //裁剪对象
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //定位
                    Rectangle fromR = new Rectangle(0, 0, 0, 0);//原图裁剪定位
                    Rectangle toR = new Rectangle(0, 0, 0, 0);//目标定位

                    //宽为标准进行裁剪
                    if (templateRate > initRate)
                    {
                        //裁剪对象实例化
                        pickedImage = new Bitmap(initImage.Width, (int)System.Math.Floor(initImage.Width / templateRate));
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);

                        //裁剪源定位
                        fromR.X = 0;
                        fromR.Y = (int)System.Math.Floor((initImage.Height - initImage.Width / templateRate) / 2);
                        fromR.Width = initImage.Width;
                        fromR.Height = (int)System.Math.Floor(initImage.Width / templateRate);

                        //裁剪目标定位
                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = initImage.Width;
                        toR.Height = (int)System.Math.Floor(initImage.Width / templateRate);
                    }
                    //高为标准进行裁剪
                    else
                    {
                        pickedImage = new Bitmap((int)System.Math.Floor(initImage.Height * templateRate), initImage.Height);
                        pickedG = GetGraphics(pickedImage);

                        fromR.X = (int)System.Math.Floor((initImage.Width - initImage.Height * templateRate) / 2);
                        fromR.Y = 0;
                        fromR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                        fromR.Height = initImage.Height;

                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                        toR.Height = initImage.Height;
                    }

                    //裁剪
                    pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);

                    //按模版大小生成最终图片
                    Bitmap templateImage = new Bitmap(maxWidth, maxHeight);
                    Graphics templateG = GetGraphics(templateImage);
                    templateG.DrawImage(pickedImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, pickedImage.Width, pickedImage.Height), System.Drawing.GraphicsUnit.Pixel);

                    //释放资源
                    templateG.Dispose();

                    pickedG.Dispose();
                    pickedImage.Dispose();
                    initImage.Dispose();
                    return templateImage;
                }
            }
        }

        /// <summary>
        /// 圆形图片处理
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rec"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Bitmap CutEllipse(Image img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            img.Dispose();
            return bitmap;
        }

        /// <summary>
        /// 获取高清的Graphics
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Graphics GetGraphics(Image img)
        {
            var g = Graphics.FromImage(img);
            //设置质量
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //InterpolationMode不能使用High或者HighQualityBicubic,如果是灰色或者部分浅色的图像是会在边缘处出一白色透明的线
            //用HighQualityBilinear却会使图片比其他两种模式模糊（需要肉眼仔细对比才可以看出）
            g.InterpolationMode = InterpolationMode.Default;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            return g;
        }
        #endregion
    }
}
