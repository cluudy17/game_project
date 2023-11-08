using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace game
{
    public class Doggo
    {
        public bool GoLeft, GoRight, GoUp,fall;
        int Speed = 7;
        public string Where;
        public int doggoLeft, doggoWidth, doggoHeight, doggoTop, force, jumpSpeed;
        public PictureBox doggo = new PictureBox();
        private Form1 mainForm;
        public Doggo()
        {

        }
        public Doggo(Form1 form)
        {
            mainForm = form;
        }

        public void MakeDoggo(Form form)
        {
            doggo.Left = 54;
            doggo.Top = 554;
            doggoLeft = doggo.Left;
            doggoTop = doggo.Top;
            doggo.SizeMode = PictureBoxSizeMode.Zoom;
            doggo.Image = Properties.Resources.sit_right;
            doggo.Size = new Size(100, 70);
            doggoWidth = doggo.Size.Width;
            doggoHeight = doggo.Size.Height;
            doggo.Left = doggoLeft;
            doggo.Top = doggoTop;
            doggo.BringToFront();
            form.Controls.Add(doggo);

        }
        public void move(Form1 form)
        {
           
            if (GoLeft == true && doggo.Left > 0)
            {
                doggo.Image = Properties.Resources.walk_left;
                Where = "left";
                doggo.Left -= Speed;
                doggoLeft = doggo.Left;
            }
          
            if (GoRight == true && (doggo.Left + doggo.Width) < form.Width)
            {
                doggo.Image = Properties.Resources.walk_right;
                doggo.Left += Speed;
                doggoLeft = doggo.Left;
                Where = "right";
            }

            if(GoUp==true && (doggo.Top + doggo.Height > 50))
            {
                doggo.Top -= Speed;
                doggoTop = doggo.Top;
                force = Speed;
                if (Where == "left")
                {
                    doggo.Image = Properties.Resources.jump_left;
                }
               else
               {
                   doggo.Image = Properties.Resources.jump_right;
               }
            }
            else
            { if (doggo.Top < 554 )
                { 
                 doggo.Top += force;
                 doggoTop = doggo.Top;

                }
            }


            if (GoRight == false && GoLeft == false && GoUp == false)
            {
                if (Where == "left")
                {
                    doggo.Image = Properties.Resources.stand_left;
                }
                else
                {
                    doggo.Image = Properties.Resources.stand_right;
                }
            }

            foreach (Control x in form.Controls)
            { if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (doggo.Bounds.IntersectsWith(x.Bounds) && !GoUp)
                    {
                        doggo.Top = x.Top - doggo.Height;
                        force = 0;
                    }
                    if(!doggo.Bounds.IntersectsWith(x.Bounds)&& GoRight||GoLeft)
                    {
                        force = 7;
                    }
                    if (doggo.Bounds.IntersectsWith(x.Bounds) && GoUp)
                    {
                        doggo.Top = x.Top + doggo.Height;
                        GoUp = false;
                    }
                    



                }

                }
            
            }
        }


    }





