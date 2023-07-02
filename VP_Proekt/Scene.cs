using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
        Ball ball;
        bool UpDown;
        int i = 0;
        public double ballVelocityX { get; set; }
        public double ballVelocityY { get; set; }
        int nextX;
        int nextY;
        static float MAXBOUNCEANGLE = 75;
        Random random;
        public bool IsWallInGame { get; set; }
        public bool IsBallInGame { get; set; }
        public int FirstPlayerPoints { get; set; }
        public int SecondPlayerPoints { get; set; }
        public bool Pause { get; set; } = false;

        public Scene(int width, int height)
        {
            Width = width;
            Height = height;
            Up = new Line(new Point((int)(Width / 12), (int)(Height / 8)), new Point((int)(Width / 12 * 11), (int)(Height / 8)));
            Down = new Line(new Point((int)(Width / 12), (int)(Height / 10 * 8)), new Point((int)(Width / 12 * 11), (int)(Height / 10 * 8)));
            Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
            Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
            Wall = new Player(new Point((int)((Player1.Center.X + Player2.Center.X) / 2), (int)(Player1.Center.Y)), 3);
            random = new Random();
            ballVelocityX = 4;
            ballVelocityY = 4;
            nextX = random.Next(2) == 0 ? -2 : 2;
            nextY = random.Next(2) == 0 ? -2 : 2;
            IsWallInGame = false;
            IsBallInGame = false;
            FirstPlayerPoints = 0;
            SecondPlayerPoints = 0;
        }

        internal void Draw(Graphics graphics)
        {
            Player1.Draw(graphics);
            Player2.Draw(graphics);
            if (IsWallInGame)
            {
                Wall.Draw(graphics);
            }
            Up.Draw(graphics);
            Down.Draw(graphics);
            if (IsBallInGame)
            {
                ball.Draw(graphics);
            }
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
                else if (Wall.Center.Y - (int)(Wall.Height / 2) == Up.Left.Y)
                {
                    UpDown = false;
                }
            }


        }

        internal void MoveBall()
        {
            if (ball.Center.X < Player1.Center.X && !Pause)
            {
                IsBallInGame = false;
                IsWallInGame = false;
                SecondPlayerPoints++;
                if (SecondPlayerPoints == 3)
                {
                    Pause = true;
                    DialogResult dialog = MessageBox.Show("Player 2 won! \n Do you want to restart the game?", "pong", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        FirstPlayerPoints = 0;
                        SecondPlayerPoints = 0;
                        Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
                        Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
                        Pause = false;

                    }
                    else
                        Application.Exit();
                }
                resetMovementValues();
                return;
            }
            else if (ball.Center.X > Player2.Center.X && !Pause)
            {
                IsBallInGame = false;
                IsWallInGame = false;
                FirstPlayerPoints++;
                if (FirstPlayerPoints == 3)
                {
                    Pause = true;
                    DialogResult dialog = MessageBox.Show("Player 1 won! \n Do you want to restart the game?", "pong", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        FirstPlayerPoints = 0;
                        SecondPlayerPoints = 0;
                        Player1 = new Player(new Point((int)(Width / 10), (int)((Up.Left.Y + Down.Left.Y) / 2)), 1);
                        Player2 = new Player(new Point((int)(Width / 10 * 9), (int)((Up.Left.Y + Down.Left.Y) / 2)), 2);
                        Pause = false;
                    }
                    else
                        Application.Exit();

                }
                resetMovementValues();
                return;
            }

            Rectangle rectangleBall = new Rectangle(ball.Center.X - Ball.Radius, ball.Center.Y - Ball.Radius, 2 * Ball.Radius, 2 * Ball.Radius); ;
            Rectangle rectanglePlayer1 = new Rectangle(Player1.Center.X - Player1.Width / 2, Player1.Center.Y - Player1.Height / 2, Player1.Width, Player1.Height);
            Rectangle rectanglePlayer2 = new Rectangle(Player2.Center.X - Player2.Width / 2, Player2.Center.Y - Player2.Height / 2, Player2.Width, Player2.Height);
            Rectangle rectangleWall = new Rectangle(Wall.Center.X - Wall.Width / 2, Wall.Center.Y - Wall.Height / 2, Wall.Width, Wall.Height);


            if (rectangleBall.IntersectsWith(rectanglePlayer1))
            {
                var bounceAngle = CalculateBounceDirection(ball.Center.Y, Player1.Center.Y - Player1.Height / 2, Player1.Height);
                var angleInRad = bounceAngle * (Math.PI / 180);

                //Calculate new ball speeds based on the bounce angle
                nextX = (int)(ballVelocityX * Math.Cos(angleInRad));
                nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
            }
            else if (rectangleBall.IntersectsWith(rectanglePlayer2))
            {
                var bounceAngle = CalculateBounceDirection(ball.Center.Y, Player2.Center.Y - Player2.Height / 2, Player2.Height);
                var angleInRad = bounceAngle * (Math.PI / 180);

                nextX = -(int)(ballVelocityX * Math.Cos(angleInRad));
                nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
            }
            else if (IsWallInGame && rectangleBall.IntersectsWith(rectangleWall))
            {
                var bounceAngle = CalculateBounceDirection(ball.Center.Y, Wall.Center.Y - Wall.Height / 2, Wall.Height);
                var angleInRad = bounceAngle * (Math.PI / 180);
                int sign = 1;
                if (nextX > 0)
                {
                    sign = -1;
                }
                nextX = (int)(ballVelocityX * Math.Cos(angleInRad)) * sign;
                nextY = (int)(ballVelocityY * -Math.Sin(angleInRad));
            }

            if (ball.Center.Y - Ball.Radius <= Height / 8 || ball.Center.Y + Ball.Radius > Height / 10 * 8)
            {
                nextY *= -1;
            }

            ball.Move(nextX, nextY);
        }

        static float CalculateBounceDirection(int ballY, int paddleY, int paddleHeight)
        {
            float relativeIntersectY = (paddleY + (paddleHeight / 2)) - ballY;
            float normalizedIntersectY = relativeIntersectY / (paddleHeight / 2);
            float bounceAngle = normalizedIntersectY * MAXBOUNCEANGLE;
            bounceAngle = Math.Max(-75, Math.Min(75, bounceAngle));
            return bounceAngle;
        }

        public void createBall()
        {
            ball = new Ball(new Point((Player1.Center.X + Player2.Center.X) / 2, (int)random.Next((int)(Height / 8) + Ball.Radius, (int)(Height / 10 * 8) - Ball.Radius)), Color.Yellow);
        }

        public void resetMovementValues()
        {
            ballVelocityX = 4;
            ballVelocityY = 4;
            nextX = random.Next(2) == 0 ? -2 : 2;
            nextY = random.Next(2) == 0 ? -2 : 2;
        }
    }
}
