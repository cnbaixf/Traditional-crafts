using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary
{
    class Triangle
    {
        public Point point1, point2, point3;
        public GraphicsPath GraphicsPath { get; set; }

        public Triangle(Rectangle rect, EnumButtonDirection dir)
        {
            if (rect.Width == 0 || rect.Height == 0)
            {
                point1 = new Point(0, 0);
                point2 = new Point(0, 0);
                point3 = new Point(0, 0);
            }
            else
                switch (dir)
                {
                    case EnumButtonDirection.Left:
                        point1 = new Point(0, rect.Height / 2);
                        point2 = new Point(rect.Width, 0);
                        point3 = new Point(rect.Width, rect.Height);
                        break;
                    case EnumButtonDirection.Right:
                        point1 = new Point(0, 0);
                        point2 = new Point(rect.Width, rect.Height / 2);
                        point3 = new Point(0, rect.Height);
                        break;
                    case EnumButtonDirection.Top:
                        point1 = new Point(rect.Width / 2, 0);
                        point2 = new Point(0, rect.Height);
                        point3 = new Point(rect.Width, rect.Height);
                        break;
                    case EnumButtonDirection.Bottom:
                        point1 = new Point(0, 0);
                        point2 = new Point(rect.Width, 0);
                        point3 = new Point(rect.Width / 2, rect.Height);
                        break;
                }
            byte[] bytes = { (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line };
            GraphicsPath= new GraphicsPath(new Point[] { point1, point2, point3 }, bytes);
        }

        public Triangle(Point p1, Point p2, Point p3)
        {
            point1 = p1;
            point2 = p2;
            point3 = p3;
            byte[] bytes = { (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line };
            GraphicsPath = new GraphicsPath(new Point[] { point1, point2, point3 }, bytes);
        }

        public Triangle(int width, int height, EnumButtonDirection dir) : this(new Rectangle(0, 0, width, height), dir)
        { }

    }
}
