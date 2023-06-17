using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Proekt
{
    public class Ball
    {
        public Point Center { get; set; }
        public static int Radius { get; set; } = 8;
        public Color Color { get; set; }

        public Ball(Point center, Color color)
        {
            Center = center;
            Color = color;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            brush.Dispose();
        }

        public void Move(int x, int y)
        {
            Center = new Point(Center.X + x, Center.Y + y);
        }

    }
}
