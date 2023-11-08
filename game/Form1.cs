using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{       
    public partial class Form1 : Form
    {
        bool jump;
        Doggo doggo = new Doggo();
        public Form1()
        {
            InitializeComponent();
            doggo.MakeDoggo(this);
         

        }

        public void MainTimerEvent(object sender, EventArgs e)
        {   
            doggo.move(this);

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                doggo.GoLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                doggo.GoRight = false;
            }

            if (e.KeyCode==Keys.Up)
            {
                doggo.GoUp = false;
            }

        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                doggo.GoLeft = true;
                doggo.Where = "left";
            }

            if (e.KeyCode == Keys.Right)
            {
                doggo.GoRight = true;
                doggo.Where = "right";
            }

            if (e.KeyCode == Keys.Up)
            {
                doggo.GoUp = true;
            }
            

           


            if (e.KeyCode == Keys.Space)
            {
                Ball throwaball = new Ball(doggo.Where);
                throwaball.ballLeft = doggo.doggoLeft +(doggo.doggoWidth / 2);
                throwaball.ballTop = doggo.doggoTop + (doggo.doggoHeight / 2);
                throwaball.MakeBall(this);
            }

        }
    }
}



