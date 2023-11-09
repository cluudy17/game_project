using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
namespace game
{
    public class Friend
    {
       
        private PictureBox friend = new PictureBox();
        private Timer friendTimer = new Timer();
        private Form1 Form;
        public int FriendLeft, FriendTop;
        bool message;
        public string question;
        string correct_answer;

        public Friend(Form1 form, int FriendLeft, int FriendTop, string question, string correct_answer)
        {
            this.correct_answer = correct_answer;
            this.question = question;
            this.Form = form;
            this.FriendLeft = FriendLeft;
            this.FriendTop = FriendTop;
            friend.Left = FriendLeft;
            friend.Top = FriendTop;
            friend.Tag = "friend";
            friend.SizeMode = PictureBoxSizeMode.Zoom;
            friend.Image = Properties.Resources.ball;
            friend.Size = new Size(100, 100);
            friend.BringToFront();
            form.Controls.Add(friend);         
            friendTimer.Tick += new EventHandler(FriendTimerEvent);
            friendTimer.Start();
        }

        public void FriendTimerEvent(object sender, EventArgs e)
        {  
            string answer;

            foreach (Control x in Form.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ball")
                {
                    if (friend.Bounds.IntersectsWith(x.Bounds)&& !message)
                    {
                        string caption = "Pytanie";
                        DialogResult result;
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        result =  MessageBox.Show(question, caption, buttons);
                        message = true;

                        if (result == DialogResult.Yes)
                        { answer = "Y"; }
                        else { answer = "N"; }

                        if (answer == correct_answer)
                        {
                            MessageBox.Show("Poprawna odpowiedz");
                        }
                        else 
                        { 
                            MessageBox.Show("Gave Over"); 
                        }
                    }
                   
                 }
                
            }

        }
    }
}
    

