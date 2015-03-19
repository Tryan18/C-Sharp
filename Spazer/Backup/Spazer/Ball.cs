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
    public class Ball
    {
        public Rectangle rec;
        public Color kleur;
        private Timer move_timer = new Timer();
        private int stapx;
        private int stapy;
        private Random r = new Random();
        private Panel speelveld;
        private int niveau;
        private Player speler;
        private Game spel;
        private bool random = false;

        public Ball(int x,int y,int breedte,int lengte,Panel speelveld,int niveau,Player speler,Game spel)
        {
            this.spel = spel;
            this.speler = speler;
            this.niveau = niveau;
            this.speelveld = speelveld;
            rec = new Rectangle(x, y, breedte, lengte);
            stapx = 2 * niveau;
            stapy = 2 * niveau;
            kleur = Color.LightGray;
            move_timer.Interval = 1;
            move_timer.Tick += new EventHandler(move_timer_Tick);
            move_timer.Start();
        }

        void move_timer_Tick(object sender, EventArgs e)
        {
            spel.CheckBlokken(ref rec,ref stapx,ref stapy,niveau,random);

            if (rec.IntersectsWith(speler.rec))
            {
                //speler restrictie
                if (speler.rec.Top < rec.Bottom && stapy > 0)
                {
                    int x = rec.Left - speler.rec.Left;
                    int t = ((x - (speler.rec.Width / 2)) / 5);
                    if (t == 0)
                        t = 1;
                    
                    if (x > (speler.rec.Width / 2))
                    {
                        stapx = t;
                            //(((speler.rec.Width / 2) - x) / 5);
                    }
                    else
                    {
                        stapx = t;
                    }

                    stapy = stapy - (stapy + stapy);
                }
                else if (speler.rec.Left < rec.Right && stapx > 0)
                {
                    if (random)
                        stapx = r.Next(1, niveau + 1);
                    stapx = stapx - (stapx + stapx);
                }
                else if (speler.rec.Right < rec.Left && stapx < 0)
                {
                    if (random)
                        stapx = -(r.Next(1, niveau + 1));
                    stapx = stapx - (stapx + stapx);
                }
            }
            if (rec.Bottom > (speelveld.Bottom-rec.Height) && stapy > 0)
            {
                //onder restrictie
                move_timer.Stop();
                spel.DisposeGame();
                MessageBox.Show("GameOver!");
                spel.ClearSpeelveld();
            }
            else if (rec.Top < (speelveld.Top-rec.Height) && stapy < 0)
            {
                //boven restrictie
                if (random)
                    stapy = -(r.Next(1, niveau + 1));
                stapy = stapy - (stapy + stapy);
            }
            if (rec.Left < (speelveld.Left-rec.Width) && stapx < 0)
            {
                //linker restrictie
                if (random)
                    stapx = -(r.Next(1, niveau + 1));
                stapx = stapx - (stapx + stapx);
            }
            else if (rec.Right > (speelveld.Right-rec.Width) && stapx > 0)
            {
                //rechtse restrictie
                if (random)
                    stapx = r.Next(1, niveau + 1);
                stapx = stapx - (stapx + stapx);
            }

            rec.Y += stapy;
            rec.X += stapx;
            Application.DoEvents();
        }
    }
}
