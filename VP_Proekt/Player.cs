using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Proekt
{
    public class Player
    {
        public int Width { get; set; } = 15;
        public int Height { get; set; } = 70;
        public int ColorNumber { get; set; }
        public Point Center { get; set; }

        public Player(Point center, int colorNumber)
        {
            Center = center;
            ColorNumber = colorNumber;
        }

        public void Draw(Graphics g)
        {
            Brush b;
            if(ColorNumber == 1)
            {
                b = new SolidBrush(Color.Red);
            }
            else if(ColorNumber == 2)
            {
                b = new SolidBrush(Color.Blue);
            }
            else
            {
                b = new SolidBrush(Color.Black);
            }
            g.FillRectangle(b, Center.X - Width/2, Center.Y - Height/2, Width, Height);
            b.Dispose();
        }


        internal void MoveUp(Point Up)
        {
            if (Center.Y - Height/2 > Up.Y)
            {
                Center = new Point(Center.X, Center.Y - 2);
            }
        }

        internal void MoveDown(Point Down)
        {
            if (Center.Y + Height/2 < Down.Y)
            {
                Center = new Point(Center.X, Center.Y + 2);
            }
        }
    }
}
