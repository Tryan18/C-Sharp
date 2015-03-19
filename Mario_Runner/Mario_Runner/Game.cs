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
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mario_Runner
{
    //
    //gelieve de auteurs rechten voor  mij behouden ,dank uw bij deze
    //Auteur:Terence Slot I5
    //School:Hogeschool Zuyd Heerlen
    //
    public class Game
    {
        //achtergrond
        private Background bg;
        //level
        private Map map;
        //speler
        private Mario mario;
        //bewegen
        public Timer move_timer = new Timer();
        //animatie bewegen
        public Timer move_animated_timer = new Timer();
        //voor te springen
        private Timer jump_timer = new Timer();
        //framerate
        private Timer draw_timer = new Timer();
        //low-API keyboard-hook (algemene key-down en key-up event opvanger)
        private KeyboardHook.KeyboardHookEventArgs moveData;
        private bool fullscreenmode = false;
        private object parent;
        private int jumplengte = 0;
        private int jumpmax = 20;
        //low-API keyboard-hook (algemene key-down en key-up event opvanger)
        private KeyboardHook kh = new KeyboardHook(KeyboardHook.Parameters.None);

        public Game(object sender)
        {
            parent = sender;
            moveData = new KeyboardHook.KeyboardHookEventArgs(0, true);
            kh.KeyDown += new KeyboardHook.KeyboardHookEventHandler(kh_KeyDown);
            kh.KeyUp += new KeyboardHook.KeyboardHookEventHandler(kh_KeyUp);
            Start();
        }

        void kh_KeyUp(KeyboardHook.KeyboardHookEventArgs e)
        {
            Fullscreenmode((parent as Form1), e);
            StopMario(null, e);
        }

        void kh_KeyDown(KeyboardHook.KeyboardHookEventArgs e)
        {
            MoveMario(e);
            JumpMario(null, e);
        }

        private void Start()
        {
            CreateBackground();
            CreateMap();
            CreateMario();

            //60 fps
            draw_timer.Interval = (1000 / 60);
            draw_timer.Tick += new EventHandler(draw_timer_Tick);
            draw_timer.Enabled = true;
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            Image temp = new Bitmap(bg.screen.Width, bg.screen.Height);
            Graphics g = (parent as Form1).CreateGraphics();
            Graphics gg = Graphics.FromImage(temp);

            gg.DrawImage(bg.screen, 0, 0);
            gg.DrawImage(map.screen, 0, 0);
            gg.DrawImage(mario.screen, mario.mario_bounds.Location);

            if (fullscreenmode)
            {
                Image temp2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics ggg = Graphics.FromImage(temp2);
                GraphicsUnit gu = GraphicsUnit.Pixel;
                ggg.DrawImage(temp, temp2.GetBounds(ref gu), temp.GetBounds(ref gu), GraphicsUnit.Pixel);
                g.DrawImage(temp2, 0, 0);
                ggg.Dispose();
                temp2.Dispose();
            }
            else
            {
                g.DrawImage(temp, 0, 0);
            }
            g.Dispose();
            gg.Dispose();
            temp.Dispose();
            //Application.DoEvents();
        }

        private void CreateBackground()
        {
            bg = new Background();
        }

        private void CreateMap()        
        {
            //level1 map_bounds
            //384 y
            //511 x

            map = new Map(new Rectangle(0, 384, 511, 432));
        }

        private void CreateMario()
        {
            mario = new Mario(map.map_bounds.Width / 2, map.map_bounds.Top - Properties.Resources.mario_stand.Height,this);
            move_timer.Interval = 50;
            move_timer.Tick += new EventHandler(move_timer_Tick);

            move_animated_timer.Interval = 150;
            move_animated_timer.Tick += new EventHandler(animated_timer_Tick);

            jump_timer.Interval = 50;
            jump_timer.Tick += new EventHandler(jump_timer_Tick);
        }

        void jump_timer_Tick(object sender, EventArgs e)
        {
            jumplengte += 1;
            if (mario.jump(jumplengte, jumpmax))
            {
                mario.jumping = false;
                jumplengte = 0;
                jump_timer.Stop();
            }
        }

        void animated_timer_Tick(object sender, EventArgs e)
        {
            switch ((Keys)moveData.KeyCode)
            {
                case Keys.Right:
                    mario.walk_right(true);
                    break;
                case Keys.Left:
                    mario.walk_left(true);
                    break;
            }
        }

        public void MoveMario(KeyboardHook.KeyboardHookEventArgs e)
        {
            if (!move_timer.Enabled && ((Keys)e.KeyCode == Keys.Up || (Keys)e.KeyCode == Keys.Down || (Keys)e.KeyCode == Keys.Left || (Keys)e.KeyCode == Keys.Right))
            {
                moveData = e;
                mario.stand = false;
                move_timer.Start();
                move_animated_timer.Start();
            }
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            switch ((Keys)moveData.KeyCode)
            {
                case Keys.Right:
                    mario.walk_right();
                    break;
                case Keys.Left:
                    mario.walk_left();
                    break;
            }
        }

        private void T_controls_KeyDown(object sender, KeyEventArgs e)
        {
            //MoveMario(e);
        }

        public void StopMario(object sender, KeyboardHook.KeyboardHookEventArgs e)
        {
            if (!mario.jumping)
            {
                moveData = e;
                move_timer.Stop();
                move_animated_timer.Stop();
                mario.StopMario();
            }
        }

        public void Fullscreenmode(object sender, KeyboardHook.KeyboardHookEventArgs e)
        {
            if ((Keys)moveData.KeyCode == Keys.F11)
            {
                if (fullscreenmode == false)
                {
                    fullscreenmode = true;
                    Form2 f = new Form2();
                    (sender as Form1).Owner = f;
                    (sender as Form1).FormBorderStyle = FormBorderStyle.None;
                    (sender as Form1).Left = Screen.PrimaryScreen.Bounds.Left;
                    (sender as Form1).Top = Screen.PrimaryScreen.Bounds.Top;

                    f.Show();

                    (sender as Form1).Scale(new SizeF(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                }
                else
                {
                    fullscreenmode = false;
                    Form f = (parent as Form1).Owner;
                    (sender as Form1).Owner = null;
                    f.Close();
                    (sender as Form1).Size = new Size(511, 432);
                    (sender as Form1).FormBorderStyle = FormBorderStyle.Fixed3D;

                }
            }
        }

        internal void JumpMario(object sender, KeyboardHook.KeyboardHookEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Space)
            {
                mario.jumping = true;
                jump_timer.Start();
            }
        }
    }
}
