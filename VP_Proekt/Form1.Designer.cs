
namespace VP_Proekt
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.lbPlayer1Points = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPlayer2Points = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerWall = new System.Windows.Forms.Timer(this.components);
            this.timerBall = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbPlayer1Points
            // 
            this.lbPlayer1Points.AutoSize = true;
            this.lbPlayer1Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayer1Points.ForeColor = System.Drawing.Color.Red;
            this.lbPlayer1Points.Location = new System.Drawing.Point(361, 9);
            this.lbPlayer1Points.Name = "lbPlayer1Points";
            this.lbPlayer1Points.Size = new System.Drawing.Size(30, 32);
            this.lbPlayer1Points.TabIndex = 1;
            this.lbPlayer1Points.Text = "0";
            this.lbPlayer1Points.Click += new System.EventHandler(this.lbPlayer1Points_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(398, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // lbPlayer2Points
            // 
            this.lbPlayer2Points.AutoSize = true;
            this.lbPlayer2Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayer2Points.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbPlayer2Points.Location = new System.Drawing.Point(428, 9);
            this.lbPlayer2Points.Name = "lbPlayer2Points";
            this.lbPlayer2Points.Size = new System.Drawing.Size(30, 32);
            this.lbPlayer2Points.TabIndex = 3;
            this.lbPlayer2Points.Text = "0";
            this.lbPlayer2Points.Click += new System.EventHandler(this.lbPlayer2Points_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerWall
            // 
            this.timerWall.Interval = 10;
            this.timerWall.Tick += new System.EventHandler(this.timerWall_Tick);
            // 
            // timerBall
            // 
            this.timerBall.Interval = 2;
            this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbPlayer2Points);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPlayer1Points);
            this.Name = "Form";
            this.Text = "PongGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPlayer1Points;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPlayer2Points;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerWall;
        private System.Windows.Forms.Timer timerBall;
    }
}

