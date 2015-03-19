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

namespace colorPower
{
    public class blokje
    {
        private Timer power;
        private Timer move;
        private Timer moverichting;
        public Rectangle r;
        private int w = 1;
        private int h = 1;
        private int x = 0;
        private int y = 0;
        private richting rich = richting.rechtsonder;
        public SolidBrush b;
        private Random rd = new Random();
        private int stapx = 1;
        private int stapy = 1;
        private int speed;
        private const int maxwidth = 15;
        private const int maxheight = 15;
        private Color[] kleuren = new Color[] { Color.Red,Color.Orange, Color.Green, Color.Yellow, Color.Magenta,
            Color.Blue, Color.Crimson, Color.Gold};

        public blokje(int speed,int x,int y)
        {
            this.speed = speed;
            //b = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
            b = new SolidBrush(kleuren[rd.Next(0, kleuren.Length)]);
            StartColorPower(x,y);
            StartRandomMovement();
        }

        private void StartRandomMovement()
        {
            move = new Timer();
            move.Interval = 10;
            move.Tick += new EventHandler(move_Tick);
            //moverichting = new Timer();
            //moverichting.Interval = 1000;
            //moverichting.Tick += new EventHandler(moverichting_Tick);
            //moverichting.Start();
            move.Start();
        }

        void moverichting_Tick(object sender, EventArgs e)
        {
            stapx = rd.Next(0, speed);
            stapx = stapx - (stapx + stapx);
            stapy = rd.Next(0, speed);
            stapy = stapy - (stapy + stapy);
        }

        void move_Tick(object sender, EventArgs e)
        {
            if (r.Bottom > Screen.PrimaryScreen.Bounds.Bottom && stapy > 0)
            {
                stapy = rd.Next(1, speed);
                stapy = stapy - (stapy + stapy);
            }
            else if (r.Top < Screen.PrimaryScreen.Bounds.Top && stapy < 0)
            {
                stapy = -(rd.Next(1, speed));
                stapy = stapy - (stapy + stapy);
            }
            if (r.Left < Screen.PrimaryScreen.Bounds.Left && stapx < 0)
            {
                stapx = -(rd.Next(1, speed));
                stapx = stapx - (stapx + stapx);
            }
            else if (r.Right > Screen.PrimaryScreen.Bounds.Right && stapx > 0)
            {
                stapx = rd.Next(1, speed);
                stapx = stapx - (stapx + stapx);
            }
            r.Location = new Point(r.Left + stapx, r.Top + stapy);
        }

        private void StartColorPower(int x,int y)
        {
            power = new Timer();
            power.Interval = 1;
            power.Tick += new EventHandler(power_Tick);
            r = new Rectangle(x, y, 1, 1);
            power.Start();
        }

        void power_Tick(object sender, EventArgs e)
        {
            switch (rich)
            {
                case richting.rechtsonder:
                    if (r.Width == 0)
                    {
                        x = 1;
                        y = 1;
                        w = 1;
                        //b = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
                        b = new SolidBrush(kleuren[rd.Next(0, kleuren.Length)]);
                        rich = richting.linksonder;
                        return;
                    }
                    if (r.Height == maxheight / 2)
                    {
                        w = -1;
                        h = 0;
                    }
                    r.Width += w;
                    r.Height += h;
                    r.Location = new Point(r.Left + x, r.Top + y);
                    break;
                case richting.linksonder:
                    if (r.Height == 0)
                    {
                        y = 1;
                        //b = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
                        b = new SolidBrush(kleuren[rd.Next(0, kleuren.Length)]);
                        rich = richting.linksboven;
                        return;
                    }
                    if (r.Width == maxwidth / 2)
                    {
                        w = 0;
                        x = 0;
                        h = 1;
                    }
                    r.Height -= h;
                    r.Width += w;
                    r.Location = new Point(r.Left - x, r.Top);
                    break;
                case richting.linksboven:
                    if (r.Width == 0)
                    {
                        x = 0;
                        //b = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
                        b = new SolidBrush(kleuren[rd.Next(0, kleuren.Length)]);
                        rich = richting.rechtsboven;
                        return;
                    }
                    if (r.Height == maxheight / 2)
                    {
                        h = 0;
                        w = 1;
                        x = 1;
                        y = 0;
                    }
                    r.Width -= w;
                    r.Height += h;
                    r.Location = new Point(r.Left + x, r.Top - y);
                    break;
                case richting.rechtsboven:
                    if (r.Height == 0)
                    {
                        w = 1;
                        h = 1;
                        x = 0;
                        y = 0;
                        //b = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
                        b = new SolidBrush(kleuren[rd.Next(0, kleuren.Length)]);
                        rich = richting.rechtsonder;
                        return;
                    }
                    if (r.Width == maxwidth / 2)
                    {
                        x = 0;
                        y = 1;
                        w = 0;
                        h = 1;
                    }
                    r.Width += w;
                    r.Height -= h;
                    r.Location = new Point(r.Left + x, r.Top + y);
                    break;
            }
        }
    }
}
