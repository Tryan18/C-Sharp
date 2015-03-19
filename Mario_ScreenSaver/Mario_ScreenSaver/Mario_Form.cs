/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mario_ScreenSaver
{
    public partial class Mario_Form : Form
    {
        private Timer draw_timer = new Timer();
        private Timer move_timer = new Timer();
        private Timer animation_timer = new Timer();
        private Timer pause_timer = new Timer();
        private int breedte = Properties.Resources.mario_stand.Width;
        private int lengte = Properties.Resources.mario_stand.Height;
        private Mario mario;
        private Graphics g;
        private int moveType = 1;
        private direction richting;
        private moveMode MoveMode;
        private Message mes;
        private Random r = new Random();

        public Mario_Form()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            this.Location = new Point(-50, Screen.PrimaryScreen.WorkingArea.Bottom - Properties.Resources.mario_stand.Height);
            //this.ClientSize = new Size(breedte, lengte);
            mario = new Mario(0, 0);
            richting = direction.right;
            MoveMode = moveMode.stand;

            move_timer.Interval = 40;
            move_timer.Tick += new EventHandler(move_timer_Tick);
            move_timer.Start();

            draw_timer.Interval = 10;
            draw_timer.Tick += new EventHandler(draw_timer_Tick);
            draw_timer.Enabled = true;

            animation_timer.Interval = 100;
            animation_timer.Tick += new EventHandler(animated_timer_Tick);
            animation_timer.Start();

            pause_timer.Interval = 60000;
            pause_timer.Tick += new EventHandler(pause_timer_Tick);
        }

        void pause_timer_Tick(object sender, EventArgs e)
        {
            move_timer.Start();
            animation_timer.Start();
            draw_timer.Start();
            pause_timer.Interval = (60000 * r.Next(1,61));
            pause_timer.Stop();
        }

        void animated_timer_Tick(object sender, EventArgs e)
        {
            if (moveType == 1)
            {
                moveType = 2;
                MoveMode = moveMode.stand;
                mario.StopMario(richting);
            }
            else if (moveType == 2)
            {
                if (MoveMode == moveMode.stand)
                    moveType = 3;

                else if(MoveMode == moveMode.run)
                    moveType = 1;
                mario.walk(richting);
            }
            else if (moveType == 3)
            {
                moveType = 2;
                MoveMode = moveMode.run;
                mario.run(richting);
            }
            Refresh();
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            //this.ClientSize = new Size(breedte, lengte);
            
            if (this.Left > Screen.PrimaryScreen.WorkingArea.Right + (breedte*8))
            {
                richting = direction.left;
                move_timer.Stop();
                animation_timer.Stop();
                draw_timer.Stop();
                pause_timer.Start();
            }
            else if (this.Left < Screen.PrimaryScreen.WorkingArea.Left - (breedte*8))
            {
                richting = direction.right;
                move_timer.Stop();
                animation_timer.Stop();
                draw_timer.Stop();
                pause_timer.Start();
            }
            if (richting == direction.right)
            {
                this.Left += breedte / 3;
            }
            else
            {
                this.Left -= breedte / 3;
            }
            if(this.Left == (Screen.PrimaryScreen.WorkingArea.Width/2)-2)
            {
                StartMessage();
            }
        }

        private void StartMessage()
        {
            move_timer.Stop();
            animation_timer.Stop();
            mario.ShowMessage();
            mes = new Message();
            mes.Location = new Point(this.Left+breedte, this.Top - lengte*2);
            mes.Show();
            Timer message_timer = new Timer();
            message_timer.Interval = 3000;
            message_timer.Tick += new EventHandler(message_timer_Tick);
            message_timer.Start();
        }

        void message_timer_Tick(object sender, EventArgs e)
        {
            move_timer.Start();
            animation_timer.Start();
            if(!mes.IsDisposed)
                mes.Close();
            (sender as Timer).Stop();
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(breedte+10, lengte);
            g = this.CreateGraphics();
            Graphics gg = Graphics.FromImage((Image)b);
            gg.DrawImage(mario.screen, 0, 0);
            g.DrawImage(b, 0, 0);
            gg.Dispose();
            g.Dispose();
            Application.DoEvents();
        }
    }

    public enum direction
    {
        right,
        left
    }

    public enum moveMode
    {
        stand,
        walk,
        run
    }
}
