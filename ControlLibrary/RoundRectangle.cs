using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControlLibrary
{
    /// <summary>
    /// 圆角矩形
    /// </summary>
    class RoundRectangle
    {

        public RoundRectangle(Rectangle rect, int radius) : this(rect, new CornerRadius(radius))
        {

        }
        public RoundRectangle(Rectangle rect, CornerRadius cornerRadius)
        {
            Rect = rect;
            CornerRadius = cornerRadius;
        }

        /// <summary>
        /// 获取或者设置矩形区域
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// 获取或者设置圆角值
        /// </summary>
        public CornerRadius CornerRadius { get; set; }

        /// <summary>
        /// 获取该圆角矩形的GraphicsPath对象(圆角使用Bezier曲线实现)
        /// </summary>
        /// <returns></returns>
        public GraphicsPath ToGraphicsBezierPath()
        {
            GraphicsPath path = new GraphicsPath();
            int x = Rect.X;
            int y = Rect.Y;
            int w = Rect.Width;
            int h = Rect.Height;
            path.AddBezier(x, y + CornerRadius.TopLeft, x, y, x + CornerRadius.TopLeft, y, x + CornerRadius.TopLeft, y);
            path.AddLine(x + CornerRadius.TopLeft, y, x + w - CornerRadius.TopRight, y);
            path.AddBezier(x + w - CornerRadius.TopRight, y, x + w, y, x + w, y + CornerRadius.TopRight, x + w, y + CornerRadius.TopRight);
            path.AddLine(x + w, y + CornerRadius.TopRight, x + w, y + h - CornerRadius.BottomRigth);
            path.AddBezier(x + w, y + h - CornerRadius.BottomRigth, x + w, y + h, x + w - CornerRadius.BottomRigth, y + h, x + w - CornerRadius.BottomRigth, y + h);
            path.AddLine(x + w - CornerRadius.BottomRigth, y + h, x + CornerRadius.BottomLeft, y + h);
            path.AddBezier(x + CornerRadius.BottomLeft, y + h, x, y + h, x, y + h - CornerRadius.BottomLeft, x, y + h - CornerRadius.BottomLeft);
            path.AddLine(x, y + h - CornerRadius.BottomLeft, x, y + CornerRadius.TopLeft);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 获取该圆角矩形的GraphicsPath对象(圆角使用矩形圆弧曲线曲线实现)
        /// </summary>
        /// <returns></returns>
        public GraphicsPath ToGraphicsArcPath()
        {
            GraphicsPath path = new GraphicsPath();
            int x = Rect.X;
            int y = Rect.Y;
            int w = Rect.Width;
            int h = Rect.Height;
            path.AddArc(x, y, CornerRadius.TopLeft, CornerRadius.TopLeft, 180, 90);
            path.AddArc(x + w - CornerRadius.TopRight, y, CornerRadius.TopRight, CornerRadius.TopRight, 270, 90);
            path.AddArc(x + w - CornerRadius.BottomRigth, y + h - CornerRadius.BottomRigth,
                CornerRadius.BottomRigth, CornerRadius.BottomRigth,
                0, 90);
            path.AddArc(x, y + h - CornerRadius.BottomLeft, CornerRadius.BottomLeft, CornerRadius.BottomLeft, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 获取该圆角矩形的GraphicsPath对象(主要用于Tabcontrol的标签样式)
        /// </summary>
        /// <returns></returns>
        public GraphicsPath ToGraphicsAnglesWingPath()
        {
            GraphicsPath path = new GraphicsPath();
            int x = Rect.X;
            int y = Rect.Y;
            int w = Rect.Width;
            int h = Rect.Height;
            path.AddBezier(x, y + CornerRadius.TopLeft, x, y, x + CornerRadius.TopLeft, y, x + CornerRadius.TopLeft, y);
            path.AddLine(x + CornerRadius.TopLeft, y, x + w - CornerRadius.TopRight, y);
            path.AddBezier(x + w - CornerRadius.TopRight, y, x + w, y, x + w, y + CornerRadius.TopRight, x + w, y + CornerRadius.TopRight);
            path.AddLine(x + w, y + CornerRadius.TopRight, x + w, y + h - CornerRadius.BottomRigth);
            path.AddBezier(x + w, y + h - CornerRadius.BottomRigth, x + w, y + h, x + w + CornerRadius.BottomRigth, y + h, x + w + CornerRadius.BottomRigth, y + h);
            path.AddLine(x + w + CornerRadius.BottomRigth, y + h, x - CornerRadius.BottomLeft, y + h);
            path.AddBezier(x - CornerRadius.BottomLeft, y + h, x, y + h, x, y + h - CornerRadius.BottomLeft, x, y + h - CornerRadius.BottomLeft);
            path.AddLine(x, y + h - CornerRadius.BottomLeft, x, y + CornerRadius.TopLeft);
            path.CloseFigure();
            return path;
        }

    }
}
