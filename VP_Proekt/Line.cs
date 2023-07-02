using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Proekt
{
    public class Line
    {
        public Point Left { get; set; }
        public Point Right { get; set; }

        public Line(Point left, Point right)
        {
            Left = left;
            Right = right;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, Left, Right);
            pen.Dispose();
        }
    }
}
