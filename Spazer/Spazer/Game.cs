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

namespace Spazer
{
    public class Game
    {
        private Form1 form;
        public Player speler;
        private Ball bal;
        public int speed;
        private int stapspeed;
        private Niveau niveau;
        private Timer draw_timer = new Timer();
        private Timer move_timer = new Timer();
        private KeyEventArgs kea;
        private List<Block> blokken;
        private List<Item> items = new List<Item>();
        private Random r = new Random();

        public Game(Form1 form,Niveau niveau)
        {
            this.niveau = niveau;
            this.form = form;
            int breedte = 0;
            int lengte = 12;
            speed = 1;
            stapspeed = 10;
            switch(niveau)
            {
                case Niveau.Easy:
                    breedte = 90;
                    speed = 1;
                    break;
                case Niveau.Normal:
                    breedte = 60;
                    speed = 2;
                    break;
                case Niveau.Hard:
                    breedte = 30;
                    speed = 3;
                    break;
            }
            //Blokken
            CreateBlokken();
            //speler
            speler = new Player((form.panel_speelveld.Width/2)-(breedte/2), 397, breedte, lengte,form.panel_speelveld);
            // 1 ball
            bal = new Ball((form.panel_speelveld.Width / 2), 397 - 20, 10, 10, form.panel_speelveld, speed, speler,this);
            //besturing
            CreateBesturing();
            

            //frame rate
            draw_timer.Interval = (1000 / 60);
            draw_timer.Tick += new EventHandler(draw_timer_Tick);
            draw_timer.Start();
        }

        private void CreateBlokken()
        {
            blokken = Level.StartLevel(1, form.panel_speelveld,niveau);
        }

        private void CreateBesturing()
        {
            move_timer.Interval = speed;
            move_timer.Tick += new EventHandler(move_timer_Tick);
            form.T_besturing.KeyDown += new KeyEventHandler(besturing_KeyDown);
            form.T_besturing.KeyUp += new KeyEventHandler(besturing_KeyUp);
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            switch (kea.KeyCode)
            {
                case Keys.Right:
                    speler.moveRechts(stapspeed);
                    break;
                case Keys.Left:
                    speler.moveLinks(stapspeed);
                    break;
                case Keys.Space:

                    break;
            }
        }

        void besturing_KeyDown(object sender, KeyEventArgs e)
        {
            kea = e;
            move_timer.Start();
        }

        void besturing_KeyUp(object sender, KeyEventArgs e)
        {
            move_timer.Stop();
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            Graphics g = form.panel_speelveld.CreateGraphics();
            Bitmap b = new Bitmap(form.panel_speelveld.Width, form.panel_speelveld.Height);
            Graphics gg = Graphics.FromImage((Image)b);
            gg.FillRectangle(Brushes.White, new Rectangle(0, 0, b.Width, b.Height));
            gg.FillRectangle(new SolidBrush(speler.kleur), speler.rec);
            gg.FillEllipse(new SolidBrush(bal.kleur), bal.rec);
            gg.DrawEllipse(new Pen(Color.Black), bal.rec);
            gg.DrawRectangle(new Pen(Color.Black), speler.rec);
            foreach (Block bb in blokken)
            {
                if (bb.plaatje != null)
                {
                    gg.DrawImage(bb.plaatje, bb.rec.X, bb.rec.Y);
                }
            }
            foreach (Item i in items)
            {
                gg.DrawImage(i.plaatje, new Point(i.rec.X, i.rec.Y));
            }
            g.DrawImage((Image)b, new Point(0, 0));
            g.Dispose();
            gg.Dispose();
        }

        public void CheckBlokken(ref Rectangle rec, ref int stapx, ref int stapy,int S_niveau,bool random)
        {
            foreach (Block b in blokken)
            {
                if (b.BT != BlockType.Leeg && b.rec.IntersectsWith(rec))
                {
                    if (b.rec.Bottom <= rec.Bottom && stapy > 0)
                    {
                        if (random)
                            stapy = r.Next(1, S_niveau + 1);
                        stapy = stapy - (stapy + stapy);
                    }
                    else if (b.rec.Bottom >= rec.Top && stapy < 0)
                    {
                        if (random)
                            stapy = -(r.Next(1, S_niveau + 1));
                        stapy = stapy - (stapy + stapy);
                    }
                    else if (b.rec.Left <= rec.Right && stapx > 0)
                    {
                        if (random)
                            stapx = r.Next(1, S_niveau + 1);
                        stapx = stapx - (stapx + stapx);
                    }
                    else if (b.rec.Right >= rec.X && stapx < 0)
                    {
                        if (random)
                            stapx = -(r.Next(1, S_niveau + 1));
                        stapx = stapx - (stapx + stapx);
                    }
                    b.BT = BlockType.Leeg;
                    if (b.ts != Tools.Leeg)
                    {
                        items.Add(new Item(b.rec.X + (b.rec.Width/2), b.rec.Y + b.rec.Height, 20, 20, b.ts, this, form.panel_speelveld));
                    }
                    blokken.Remove(b);
                    break;
                }
            }
        }

        internal void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        internal void DisposeGame()
        {
            draw_timer.Stop();
            draw_timer.Dispose();
            move_timer.Stop();
            move_timer.Dispose();
            blokken.Clear();
            items.Clear();
        }

        internal void PowerUp(Tools ts)
        {
            switch (ts)
            {
                case Tools.p100:
                    form.score += 100;
                    break;
                case Tools.p200:
                    form.score += 200;
                    break;
                case Tools.p300:
                    form.score += 300;
                    break;
            }
            form.UpdateScore();
        }

        internal void ClearSpeelveld()
        {
            Graphics g = form.panel_speelveld.CreateGraphics();
            g.Clear(Color.White);
            g.Dispose();
        }
    }

    public enum Niveau : int
    {
        Easy,
        Normal,
        Hard
    }
}
