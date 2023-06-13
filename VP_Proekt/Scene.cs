using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Proekt
{
    public class Scene
    {
        float Width;
        float Height;
        Player Player1;
        Player Player2;
        Player Wall;
        Line Up;
        Line Down;
        bool UpDown;
        int i = 0;

        public Scene(int width, int height)
        {
            Width = width;
            Height = height;
            Up = new Line(new Point((int)(Width / 12), (int)(Height / 8)), new Point((int)(Width / 12 * 11), (int)(Height / 8)));
            Down = new Line(new Point((int)(Width / 12), (int)(Height / 10 * 8)), new Point((int)(Width / 12 * 11), (int)(Height / 10 * 8)));
            Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
            Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
            Wall = new Player(new Point((int)((Player1.Center.X + Player2.Center.X) / 2), (int)(Player1.Center.Y)), 3);
            
        }

        internal void Draw(Graphics graphics)
        {
            Player1.Draw(graphics);
            Player2.Draw(graphics);
            Wall.Draw(graphics);
            Up.Draw(graphics);
            Down.Draw(graphics);

        }

        internal void MoveUpPlayer1()
        {
            Player1.MoveUp(Up.Left);
        }

        internal void MoveDownPlayer1()
        {
            Player1.MoveDown(Down.Left);
        }

        internal void MoveUpPlayer2()
        {
            Player2.MoveUp(Up.Left);
        }

        internal void MoveDownPlayer2()
        {
            Player2.MoveDown(Down.Left);
        }

        internal void MoveWall()
        {
            if (i == 0)
            {
                UpDown = false;
                i++;
            }
            else
            {
                if (!UpDown)
                {
                    Wall.MoveDown(Down.Left);
                }
                else
                {
                    Wall.MoveUp(Up.Left);
                }

                if (Wall.Center.Y + (int)(Wall.Height / 2) == Down.Left.Y)
                {
                    UpDown = true;
                }
                else if(Wall.Center.Y - (int)(Wall.Height / 2) == Up.Left.Y)
                {
                    UpDown = false;
                }
            }
           
            
        }
    }
}
