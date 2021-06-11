using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;


namespace ControlLibrary
{
    internal class GDIHelper
    {
        /// <summary>
        /// 初始化Graphics对象为高质量的绘制
        /// </summary>
        /// <param name="g"></param>
        public static void InitializeGraphics(Graphics g)
        {
            if (g != null)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
            }
        }

        /// <summary>
        /// 设置图片透明度
        /// </summary>
        /// <param name="imgAttributes"></param>
        /// <param name="opacity">透明度，0完全透明，1不透明</param>
        public static void SetImageOpacity(ImageAttributes imgAttributes, float opacity)
        {
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, opacity, 0},
                                new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            imgAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        /// <summary>
        /// 在指定区域绘制图片(平铺)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="img"></param>
        public static void DrawImage(Graphics g, Rectangle rect, Image img)
        {
            Rectangle imageRect = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
            g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 在指定区域绘制图片(平铺)，可设置透明度
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="img">要绘制的图片</param>
        /// <param name="opacity">图片透明度(0~1小数)</param>
        public static void DrawImage(Graphics g, Rectangle rect, Image img, float opacity)
        {
            if (opacity <= 0)
            {
                return;
            }
            using (ImageAttributes imgAttributes = new ImageAttributes())
            {
                GDIHelper.SetImageOpacity(imgAttributes, opacity >= 1 ? 1 : opacity);
                Rectangle imageRect = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
                g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttributes);
            }
        }

        /// <summary>
        /// 在指定区域按指定大小绘制图片
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="img">要绘制的图片</param>
        /// <param name="imgSize">要绘制的大小</param>
        public static void DrawImage(Graphics g, Rectangle rect, Image img, Size imgSize)
        {
            int x = rect.X + rect.Width / 2 - imgSize.Width / 2, y = rect.Y;
            Rectangle imageRect = new Rectangle(x, y + rect.Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
            g.DrawImage(img, imageRect);
        }

        /// <summary>
        /// 在指定区域绘制图像和文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="image">图像</param>
        /// <param name="imageSize">图像大小</param>
        /// <param name="text">文本</param>
        /// <param name="font">文本字体</param>
        /// <param name="forceColor">文本颜色</param>
        public static void DrawImageAndString(Graphics g, Rectangle rect, Image image, Size imageSize, string text, Font font, Color forceColor)
        {
            int x = rect.X, y = rect.Y, len;
            SizeF sf = g.MeasureString(text, font);
            len = Convert.ToInt32(sf.Width);
            x += rect.Width / 2 - len / 2;
            if (image != null)
            {
                x -= imageSize.Width / 2;
                Rectangle imageRect = new Rectangle(x, y + rect.Height / 2 - imageSize.Height / 2, imageSize.Width, imageSize.Height);
                g.DrawImage(image, imageRect);
                x += imageSize.Width + 2;
            }

            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using (SolidBrush brush = new SolidBrush(forceColor))
            {
                g.DrawString(text, font, brush, x, y + rect.Height / 2 - Convert.ToInt32(sf.Height) / 2 + 2);
            }
        }

        #region 矩形或椭圆
        /// <summary>
        /// 单色填充矩形或椭圆
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="color">颜色</param>
        /// <param name="isEllipse">是否是椭圆</param>
        public static void FillRectangle(Graphics g, Rectangle rect, Color color, bool isEllipse)
        {
            if (rect.Width <= 0 || rect.Height <= 0 || g == null)
            {
                return;
            }
            using (Brush brush = new SolidBrush(color))
            {
                if (isEllipse)
                    g.FillEllipse(brush, rect);
                else
                    g.FillRectangle(brush, rect);
            }
        }

        /// <summary>
        /// 渐变色填充矩形或椭圆
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect">矩形区域</param>
        /// <param name="color">颜色</param>
        /// <param name="isEllipse">是否是椭圆</param>
        public static void FillRectangle(Graphics g, Rectangle rect, GradientColor color, bool isEllipse)
        {
            if (rect.Width <= 0 || rect.Height <= 0 || g == null)
            {
                return;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
            {
                brush.Blend.Factors = color.Factors;
                brush.Blend.Positions = color.Positions;
                if (isEllipse)
                    g.FillEllipse(brush, rect);
                else
                    g.FillRectangle(brush, rect);
            }
        }
        #endregion

        #region 圆角矩形
        /// <summary>
        /// 单色填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="roundRect">矩形区域</param>
        /// <param name="color">颜色</param>
        public static void FillRoundRectangle(Graphics g, RoundRectangle roundRect, Color color)
        {
            if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
            {
                return;
            }

            using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
            {
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillPath(brush, path);
                }
            }
        }
        /// <summary>
        /// 渐变色填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="roundRect">矩形区域</param>
        /// <param name="color">颜色</param>
        public static void FillRoundRectangle(Graphics g, RoundRectangle roundRect, GradientColor color)
        {
            if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
            {
                return;
            }

            using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(roundRect.Rect, color.First, color.Second, LinearGradientMode.Vertical))
                {
                    brush.Blend.Factors = color.Factors;
                    brush.Blend.Positions = color.Positions;
                    g.FillPath(brush, path);
                }
            }
        }

        /// <summary>
        /// 渐变色填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="roundRect"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public static void FillRoundRectangle(Graphics g, RoundRectangle roundRect, Color color1, Color color2)
        {
            if (roundRect.Rect.Width <= 0 || roundRect.Rect.Height <= 0)
            {
                return;
            }

            using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(roundRect.Rect, color1, color2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }
            }
        }
        #endregion

        #region 三角形
        /// <summary>
        /// 单色填充三角形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="triangle"></param>
        /// <param name="color"></param>
        public static void FillTriangle(Graphics g, Triangle triangle, Color color)
        {
            using (Brush brush = new SolidBrush(color))
            {
                g.FillPath(brush, triangle.GraphicsPath);
            }
        }
        /// <summary>
        /// 单色填充三角形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="color"></param>
        /// <param name="dir"></param>
        public static void FillTriangle(Graphics g, Rectangle rect, EnumButtonDirection dir, Color color)
        {
            Triangle triangle = new Triangle(rect, dir);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillPath(brush, triangle.GraphicsPath);
            }
        }
        /// <summary>
        /// 渐变色填充三角形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="triangle"></param>
        /// <param name="color"></param>
        public static void FillTriangle(Graphics g, Triangle triangle, GradientColor color)
        {
            FillPath(g, triangle.GraphicsPath, new Rectangle(triangle.point1, new Size(triangle.point2)), color);
        }

        /// <summary>
        /// 渐变色填充三角形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="dir"></param>
        public static void FillTriangle(Graphics g, Rectangle rect, GradientColor color, EnumButtonDirection dir)
        {
            Triangle triangle = new Triangle(rect, dir);
            FillPath(g, triangle.GraphicsPath, rect, color);
        }
        #endregion



        /// <summary>
        /// 单色填充图形区域
        /// </summary>
        /// <param name="g"></param>
        /// <param name="path"></param>
        /// <param name="color"></param>
        public static void FillPath(Graphics g, GraphicsPath path, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillPath(brush, path);
            }
        }

        /// <summary>
        /// 渐变色填充图形区域
        /// </summary>
        /// <param name="g"></param>
        /// <param name="path"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        public static void FillPath(Graphics g, GraphicsPath path, Rectangle rect, GradientColor color)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
            {
                brush.Blend.Factors = color.Factors;
                brush.Blend.Positions = color.Positions;
                g.FillPath(brush, path);
            }
        }


        /// <summary>
        /// 绘制一个图形区域的边框(向外绘制)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="path"></param>
        /// <param name="color"></param>
        public static void DrawPathBorder(Graphics g, GraphicsPath path, Pen pen)
        {
            g.DrawPath(pen, path);
            
        }

        /// <summary>
        /// 绘制圆角矩形的边框(向外绘制)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="roundRect"></param>
        /// <param name="color"></param>
        /// <param name="borderWidth"></param>
        public static void DrawPathBorder(Graphics g, RoundRectangle roundRect, Pen pen)
        {
            using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
            {
                DrawPathBorder(g, path, pen);
            }
        }

        /// <summary>
        /// 绘制三角形的边框(向外绘制)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="Triangle"></param>
        /// <param name="pen"></param>
        public static void DrawPathBorder(Graphics g, Triangle Triangle, Pen pen)
        {
            DrawPathBorder(g, Triangle.GraphicsPath, pen);
        }

        /// <summary>
        /// 绘制圆角矩形的边框(向内绘制)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="roundRect">圆角矩形区域</param>
        /// <param name="color">边框颜色</param>
        public static void DrawPathInnerBorder(Graphics g, RoundRectangle roundRect, Color color, float width)
        {
            Rectangle rect = roundRect.Rect;
            rect.X++; rect.Y++; rect.Width -= 2; rect.Height -= 2;
            DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), new Pen(color, width));
        }

        /// <summary>
        /// 绘制阶梯渐变的线条，可以在参数Blend对象中设置色彩混合规则
        /// </summary>
        /// <param name="g"></param>
        /// <param name="lineColor">起始颜色</param>
        /// <param name="blend"></param>
        /// <param name="angle">方向角度</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="x1">第一个点的x坐标</param>
        /// <param name="y1">第一个点的y坐标</param>
        /// <param name="x2">第二个点的x坐标</param>
        /// <param name="y2">第二个点的y坐标</param>
        public static void DrawGradientLine(Graphics g, Color lineColor, Blend blend, int angle, int lineWidth, int x1, int y1, int x2, int y2)
        {
            Color c1 = lineColor;
            Color c2 = Color.FromArgb(10, c1);
            Rectangle rect = new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, c1, c2, angle))
            {
                brush.Blend = blend;
                using (Pen pen = new Pen(brush, lineWidth))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        /// <summary>
        /// 绘制向两边阶梯渐变的线条
        /// </summary>
        /// <param name="g"></param>
        /// <param name="lineColor"></param>
        /// <param name="angle"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public static void DrawGradientLine(Graphics g, Color lineColor, int angle, int lineWidth, int x1, int y1, int x2, int y2)
        {
            Blend blend = new Blend();
            blend.Positions = new float[] { 0f, .15f, .5f, .85f, 1f };
            blend.Factors = new float[] { 1f, .4f, 0f, .4f, 1f };
            DrawGradientLine(g, lineColor, blend, angle, lineWidth, x1, y1, x2, y2);
        }












    }
}
