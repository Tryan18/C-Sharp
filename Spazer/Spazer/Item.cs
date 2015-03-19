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

namespace Spazer
{
    public class Item
    {
        public Image plaatje;
        public Rectangle rec;
        private Timer move_timer = new Timer();
        private Game spel;
        private Panel speelveld;
        public int punten = 0;
        private Tools ts;

        public Item(int x,int y,int breedte,int lengte,Tools tool,Game spel,Panel speelveld)
        {
            this.spel = spel;
            this.speelveld = speelveld;
            this.ts = tool;
            rec = new Rectangle(x,y,breedte,lengte);

            switch (tool)
            {
                case Tools.Fire:
                    Bitmap bm = Properties.Resources.fire_item;
                    bm.MakeTransparent(Color.White);
                    plaatje = bm;
                    break;
                case Tools.p100:
                    Bitmap bm2 = Properties.Resources.points_100;
                    bm2.MakeTransparent(Color.White);
                    plaatje = bm2;
                    punten = 100;
                    break;
                case Tools.p200:
                    Bitmap bm3 = Properties.Resources.points_200;
                    bm3.MakeTransparent(Color.White);
                    plaatje = bm3;
                    punten = 200;
                    break;
                case Tools.p300:
                    Bitmap bm4 = Properties.Resources.points_300;
                    bm4.MakeTransparent(Color.White);
                    plaatje = bm4;
                    punten = 300;
                    break;
            }

            Bitmap b = new Bitmap(rec.Width, rec.Height);
            Graphics g = Graphics.FromImage((Image)b);
            g.DrawImage(plaatje, new Rectangle(0, 0, b.Width, b.Height), new Rectangle(0, 0, plaatje.Width, plaatje.Height), GraphicsUnit.Pixel);
            plaatje = b;
            g.Dispose();

            move_timer.Interval = 100;
            move_timer.Tick += new EventHandler(move_timer_Tick);
            move_timer.Start();
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            if(rec.IntersectsWith(spel.speler.rec))
            {
                spel.RemoveItem(this);
                spel.PowerUp(ts);
                move_timer.Stop();
            }
            else if (rec.Y > speelveld.Bottom)
            {
                spel.RemoveItem(this);
                move_timer.Stop();
            }
            else
            {
                rec = new Rectangle(rec.X, rec.Y + spel.speed*5, rec.Width, rec.Height);
            }
        }
    }

    public enum Tools : int
    {
        Leeg,
        Fire,
        p100,
        p200,
        p300
    }
}
