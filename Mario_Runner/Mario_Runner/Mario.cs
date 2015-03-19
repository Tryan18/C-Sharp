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
using System.Drawing;
using System.Windows.Forms;

namespace Mario_Runner
{
    public class Mario
    {
        public Bitmap screen;
        public Rectangle mario_bounds;
        private Game spel;

        private Bitmap mario_stand;
        private Bitmap mario_walk;
        private Bitmap mario_run;
        private Bitmap mario_jump;

        private Bitmap mario_stand_left;
        private Bitmap mario_walk_left;
        private Bitmap mario_run_left;
        private Bitmap mario_jump_left;

        private bool walking_right = false;
        private bool walking_left = false;
        public bool stand = true;
        public bool looking_right = true;
        public bool jumping = false;

        public Mario(int x, int y,Game spel)
        {
            this.spel = spel;
            CreateBitmaps();
            screen = (Bitmap)mario_stand.Clone();
            mario_bounds = new Rectangle(x, y, screen.Width, screen.Height);
        }

        private void CreateBitmaps()
        {
            mario_stand = Properties.Resources.mario_stand;
            mario_stand.MakeTransparent(Color.White);
            mario_walk = Properties.Resources.mario_walk;
            mario_walk.MakeTransparent(Color.White);
            mario_run = Properties.Resources.mario_run;
            mario_run.MakeTransparent(Color.White);
            mario_jump = Properties.Resources.mario_jump;
            mario_jump.MakeTransparent(Color.White);

            Bitmap temp = (Bitmap)mario_stand.Clone();
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            mario_stand_left = temp;

            temp = (Bitmap)mario_walk.Clone();
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            mario_walk_left = temp;

            temp = (Bitmap)mario_run.Clone();
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            mario_run_left = temp;

            temp = (Bitmap)mario_jump.Clone();
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            mario_jump_left = temp;
        }

        public void walk_right(bool animated)
        {
            if (!walking_right)
            {
                if (jumping)
                    screen = mario_jump;
                else
                    screen = mario_walk;
                walking_right = true;
            }
            else
            {
                if(jumping)
                    screen = mario_jump;
                else
                    screen = mario_stand;
                walking_right = false;
            }
        }

        public void walk_right()
        {
            looking_right = true;
            mario_bounds.X += (mario_bounds.Width / 4);
        }

        public void walk_left(bool animated)
        {
            
            if (!walking_left)
            {
                if (jumping)
                    screen = mario_jump_left;
                else
                    screen = mario_walk_left;
                walking_left = true;
            }
            else
            {
                if (jumping)
                    screen = mario_jump_left;
                else
                    screen = mario_stand_left;
                walking_left = false;
            }
        }

        public void walk_left()
        {
            looking_right = false;
            mario_bounds.X -= (mario_bounds.Width / 4);
        }

        internal void StopMario()
        {
            if (looking_right && (!jumping ||stand))
            {
                screen = mario_stand;
            }
            else if (!jumping || stand)
            {
                screen = mario_stand_left;
            }
            else if (looking_right && !stand)
            {
                screen = mario_jump;
            }
            else
            {
                screen = mario_jump_left;
            }
        }

        internal bool jump(int jumplengte,int jumpmax)
        {
            if (jumplengte > jumpmax)
            {
                jumping = false;
                if (looking_right)
                    screen = mario_stand;
                else
                    screen = mario_stand_left;
                //stand = true;
                spel.move_timer.Stop();
                spel.move_animated_timer.Stop();
                return true;
            }
            else if (jumplengte <= (jumpmax / 2))
            {
                if (looking_right && !stand)
                {
                    mario_bounds.X += (mario_bounds.Width / 4);
                    mario_bounds.Y -= (mario_bounds.Height / 4);
                }
                else if (!looking_right && !stand)
                {
                    mario_bounds.X -= (mario_bounds.Width / 4);
                    mario_bounds.Y -= (mario_bounds.Height / 4);
                }
                else
                    mario_bounds.Y -= (mario_bounds.Height / 4);
            }
            else if (jumplengte > (jumpmax / 2))
            {
                if (looking_right && !stand)
                {
                    mario_bounds.X += (mario_bounds.Width / 4);
                    mario_bounds.Y += (mario_bounds.Height / 4);
                }
                else if (!looking_right && !stand)
                {
                    mario_bounds.X -= (mario_bounds.Width / 4);
                    mario_bounds.Y += (mario_bounds.Height / 4);
                }
                else
                    mario_bounds.Y += (mario_bounds.Height / 4);
            }
            return false;
        }
    }
}
