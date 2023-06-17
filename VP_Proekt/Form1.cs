using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Proekt
{
    public partial class Form : System.Windows.Forms.Form
    {
        Scene scene;
        public bool MoveUpward1 { get; set; } = false;
        public bool MoveUpward2 { get; set; } = false;
        public bool MoveDownward1 { get; set; } = false;
        public bool MoveDownward2 { get; set; } = false;
        int tickCounterForBall = 0;
        int tickCounterForNewBall = 0;
        int tickCounterForWall = 0;

        public Form()
        {
            InitializeComponent();
            scene = new Scene(this.Width, this.Height);
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            //timerWall.Start();
            timerBall.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            lbPlayer1Points.Text = scene.FirstPlayerPoints.ToString();
            lbPlayer2Points.Text = scene.SecondPlayerPoints.ToString();
            scene.Draw(e.Graphics);
        }

        private void lbPlayer2Points_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveDownward2 = false;
                MoveUpward2 = true; 
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveUpward2 = false;
                MoveDownward2 = true;
            }
            else if (e.KeyCode == Keys.W)
            {
                MoveDownward1 = false;
                MoveUpward1 = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                MoveUpward1 = false;
                MoveDownward1 = true;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MoveUpward1)
            {
                scene.MoveUpPlayer1();
            }
            else if(MoveDownward1)
            {
                scene.MoveDownPlayer1();
            }
            Invalidate();
            this.DoubleBuffered = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (MoveUpward2)
            {
                scene.MoveUpPlayer2();
            }
            else if (MoveDownward2)
            {
                scene.MoveDownPlayer2();
            }
            Invalidate();
            this.DoubleBuffered = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveUpward2 = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveDownward2 = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                MoveUpward1 = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                MoveDownward1 = false;
            }
        }

        private void timerWall_Tick(object sender, EventArgs e)
        {
            if (!scene.IsWallInGame)
            {
                tickCounterForWall++;
                if (tickCounterForWall == 300)
                {
                    scene.IsWallInGame = true;
                    tickCounterForWall = 0;
                }
                return;
            }
            scene.MoveWall();
            Invalidate();
        }

        private void lbPlayer1Points_Click(object sender, EventArgs e)
        {

        }

        private void timerBall_Tick(object sender, EventArgs e)
        {
            if (!scene.IsBallInGame)
            {
                timerWall.Stop();
                tickCounterForNewBall++;
                if(tickCounterForNewBall == 300)
                {
                    scene.IsBallInGame = true;
                    scene.createBall();
                    timerWall.Start();
                    tickCounterForNewBall = 0;
                }
                return;
            }
            tickCounterForBall++;
            if (tickCounterForBall == 1000)
            {
                scene.ballVelocityX += 0.5;
                scene.ballVelocityY += 0.5;
                tickCounterForBall = 0;
            }
            scene.MoveBall();
            Invalidate();
        }
    }
}
