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

namespace Mario_ScreenSaver
{
    public class Sprite_Form
    {
        private Timer move_timer = new Timer();
        private Timer animation_timer = new Timer();
        private Timer draw_timer = new Timer();

        /// <summary>
        /// Move Speed in milliseconden
        /// </summary>
        public int move_speed
        {
            set { move_timer.Interval = value; }
        }

        /// <summary>
        /// Animation Speed in milliseconden
        /// </summary>
        public int animation_speed
        {
            set { animation_timer.Interval = value; }
        }

        /// <summary>
        /// Frame Rate in milliseconden
        /// </summary>
        public int draw_frame_rate
        {
            set { draw_timer.Interval = value; }
        }

        public bool Move
        {
            get { return move_timer.Enabled; }
            set { move_timer.Enabled = value; }
        }

        public bool Animation
        {
            get { return animation_timer.Enabled; }
            set { animation_timer.Enabled = value; } 
        }

        public Sprite_Form()
        {
            move_timer.Tick += new EventHandler(move_timer_Tick);
            animation_timer.Tick += new EventHandler(animation_timer_Tick);
            draw_timer.Tick += new EventHandler(draw_timer_Tick);
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            
        }

        void animation_timer_Tick(object sender, EventArgs e)
        {
            
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
