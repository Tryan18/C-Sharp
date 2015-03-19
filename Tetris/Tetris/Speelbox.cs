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

namespace Tetris
{
    public class Speelbox
    {
        private Random r;
        private Form1 F;
        private List<Image> images;
        private List<Rectangle> drawblocks;
        private blokje[,] raster;
        private Timer T;
        private int x = 172;
        private int y = 12;
        private int groote = 40;
        private Boolean Switched = false;
        private Boolean canceldraw = false;
        private string bloktype = "SnakeLeft";
        private int kleur = 0;
        private List<blokje> huidigeBlok;

        public Speelbox(int niveau,object sender)
        {
            drawblocks = new List<Rectangle>();
            r = new Random();
            images = new drawImages().GetImages();
            F = (sender as Form1);
            F.pb1.Image = images[4];
            T = new Timer();
            T.Interval = 1000 - (250 * (niveau + 1));
            T.Tick += new EventHandler(T_Tick);
            T.Start();
        }

        void T_Tick(object sender, EventArgs e)
        {
            int hulp;
            if (ControleY(out hulp))
            {
                
                foreach(blokje b in huidigeBlok)
                {
                    int indexRij = 14 - (b.blok.Y / groote);
                    int indexKolom = 0 + (b.blok.X / groote);
                    b.kleur = kleur;
                    raster[indexRij, indexKolom] = b;
                    F.Refresh();
                }

                if (Controleerlijn(hulp))
                {
                    
                    canceldraw = true;
                    
                    Verwijderlijn(hulp);
                }
                y = 12;
                x = 172;
                F.Refresh();
                kleur = r.Next(0, 4);
                Application.DoEvents();
            }
            else
            y += groote;
            F.Refresh();
            Application.DoEvents();
        }

        private void Verwijderlijn(int lijn)
        {
            
            foreach (blokje rr in raster)
            {
                if (lijn == rr.blok.Y)
                {
                        //rr.plaatje = images[4];
                        rr.kleur = 4;
                        F.Refresh();
                        System.Threading.Thread.Sleep(100);
                        rr.plaatje = new Bitmap(10, 10);
                        rr.kleur = -1;
                        F.Refresh();
                }
            }

            foreach (blokje rrr in raster)
            {
                if (lijn == rrr.blok.Y)
                {
                    int indexRij = 14 - (rrr.blok.Y / groote);
                    int indexKolom = 0 + (rrr.blok.X / groote);
                    for (int i = indexRij; i < 14; i++)
                    {
                        //if (raster[i +1, indexKolom].kleur == -1) break;
                        //raster[i, indexKolom] = raster[i + 1, indexKolom];
                        if (raster[i, indexKolom].kleur != -1 || raster[i + 1, indexKolom].kleur != -1)
                        {
                            raster[i, indexKolom].plaatje = raster[i + 1, indexKolom].plaatje;
                            raster[i, indexKolom].kleur = raster[i + 1, indexKolom].kleur;
                            F.Refresh();
                        }

                    }
                }
            }
            canceldraw = false;
        }

        private Boolean Controleerlijn(int hulp)
        {
                int lijn = 0;
                foreach (blokje r in raster)
                {

                    if (hulp == r.blok.Y)
                    {
                        if (r.kleur == -1) return false;
                        lijn++;
                    }
                }
                if (lijn == 10)
                {
                    return true;
                }
                return false;
        }

        private bool ControleY(out int hulp)
        {
                foreach (blokje b in huidigeBlok)
                {
                    int indexRij = 14 - (b.blok.Y / groote);
                    int indexKolom = 0 + (b.blok.X / groote);
                    if (b.blok.Y != 12 && raster[indexRij-1, indexKolom].kleur != -1)
                    {
                        hulp = raster[indexRij-1, indexKolom].blok.Y;
                        return true;
                    }
                }
                hulp = 0;
            return false;
        }

        private bool ControleRechts()
        {
            foreach (blokje b in huidigeBlok)
            {
                int indexRij = 14 - (b.blok.Y / groote);
                int indexKolom = 0 + (b.blok.X / groote);
                if (b.blok.X == 12 + (groote * 9)) return true;

                if (raster[indexRij, indexKolom + 1].kleur != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ControleLinks()
        {
            foreach (blokje b in huidigeBlok)
            {
                int indexRij = 14 - (b.blok.Y / groote);
                int indexKolom = 0 + (b.blok.X / groote);
                if (b.blok.X == 12) return true;
                if (raster[indexRij, indexKolom - 1].kleur != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public void setStartBlokken(Graphics g, int niveau)
        {
            int aantalbloks = 2 * (niveau + 2);
            raster = new blokje[15, 10];
            int x = 12;
            int y = 572;
            int di = r.Next(0, 4);
            List<int> leeghokje = new List<int>();
            for (int i = 0; i < aantalbloks; i++)
            {
                
                for(int o=0;o<10;o++)
                {
                    if(o==0)
                    {
                    leeghokje.Clear();
                    for (int a = 0; a <= niveau; a++)
                        leeghokje.Add(r.Next(0, 10));
                    }
                    if(leeghokje.Contains(o))
                    {
                        raster[i,o] = new blokje(new Bitmap(10,10),new Rectangle(x,y,groote,groote),-1);
                    }
                    else
                    {
                        di = r.Next(0, 4);

                        raster[i, o] = new blokje(images[di], new Rectangle(x, y, groote, groote), di);
                        g.DrawImage(raster[i,o].plaatje,raster[i,o].blok);
                    }
                    x += 40;
                }
                y -= 40;
                x = 12;
            }
            for (int e = aantalbloks; e < raster.GetLength(0); e++)
            {
                for (int u = 0; u < 10; u++)
                {
                    raster[e, u] = new blokje(new Bitmap(10, 10), new Rectangle(x, y, groote, groote), -1);
                }
            }

        } //edited

        public void TekenSpeelVeld(Graphics g) 
        {
            #region achtergrond
            Pen p = new Pen(Color.Black);
            Rectangle speelveld = new Rectangle(11, 11, 402, 602);
            g.FillRectangle(Brushes.WhiteSmoke, speelveld);
            g.DrawRectangle(p, speelveld);
            #endregion
            #region startblokken
            if (raster != null)
            {
                foreach(blokje b in raster)
                {
                    if(b.kleur == -1)
                    g.DrawImage(new Bitmap(10,10),b.blok);
                    else
                    g.DrawImage(images[b.kleur], b.blok);
                }
            }
            #endregion
            TekenBlocks(g);
        } //edited

        private void TekenBlocks(Graphics g)
        {
            if (!canceldraw) huidigeBlok = RenderBlocks.RenderBlock(g, x, y, groote, images[kleur], Switched, bloktype, kleur);
            
        }

        public void gaLinks()
        {
            if (!ControleLinks())
            {
                x -= groote;
                F.Refresh();
            }
        }

        public void gaRechts()
        {
            if (!ControleRechts())
            {
                x += groote;
                F.Refresh();
            }
        }

        public void gaOnder()
        {
            int hulp;
            if (!ControleY(out hulp))
            {
                y += groote;
                F.Refresh();
            }
        }

        public void wisselBlok()
        {
            int hulp;
            if (!ControleY(out hulp))
            {
                Switched = !Switched;
                F.Refresh();
            }
        }
    }
}
