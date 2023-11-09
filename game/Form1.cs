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
        Doggo doggo = new Doggo();

        public Form1()
        {
            InitializeComponent();
            doggo.MakeDoggo(this);
            Friend friend1 = new Friend(this, 300, 500, "xyz", "Y");
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
            
            if (e.KeyCode == Keys.A)
            {
                Ball throwaball = new Ball(doggo);
                throwaball.MakeBall(this);
            }

        }
    }
}



