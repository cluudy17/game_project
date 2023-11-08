using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
    


namespace game
{
    class Ball
    {
        public string direction;
        public int ballLeft;
        public int ballTop;
        private int Speed = 20;
        private PictureBox ball = new PictureBox();
        private Timer ballTimer = new Timer();


       public Ball(string direction)
        { this.direction = direction; }
        public void MakeBall(Form1 form)
        {
           ball.BackColor = Color.HotPink;
          //  ball.SizeMode = PictureBoxSizeMode.Zoom;
          //  ball.Image = Properties.Resources.ball;
            ball.Size = new Size(10, 10);
            ball.Left = ballLeft;
            ball.Top = ballTop;
            ball.BringToFront();
            form.Controls.Add(ball);
            ballTimer.Interval = Speed;
            ballTimer.Tick += new EventHandler(BallTimerEvent);
            ballTimer.Start();
        }

        public void BallTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                ball.Left -= Speed;

            }
            if (direction == "right")
            {
                ball.Left += Speed;
            }

            if (ball.Left < 10 || ball.Left > 860 || ball.Top < 10 || ball.Top > 600)
            {
                ballTimer.Stop();
                ballTimer.Dispose();
                ball.Dispose();
                ballTimer = null;
                ball = null;
            }
        
        }







    }
}
