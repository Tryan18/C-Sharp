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

namespace Memory2009
{
    public class Kaart
    {
        #region Fields
        private PictureBox pb;
        private readonly int offsetX = 12;
        private readonly int offsetY = 12;
        private int pos;
        private bool show = false;
        private bool gevonden = false;
        private EventHandler isGeklikt;
        #endregion

        #region Properties
        public EventHandler IsGeklikt
        {
            get 
            {
                return isGeklikt;
            }
            set 
            { 
                isGeklikt = value;
            }
        }
        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public bool Gevonden
        {
            get { return gevonden; }
            set { gevonden = value; }
        }
        #endregion

        public Kaart(int pos,int x,int y,int breedte,int lengte,Form1 f)
        {
            this.pos = pos;
            pb = new PictureBox();
            pb.Location = new Point(x + offsetX, y + offsetY);
            pb.Size = new Size(breedte, lengte);
            pb.Image = GetAfbeelding(0);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += new EventHandler(pb_Click);
            f.Controls.Add(pb);
        }

        void pb_Click(object sender, EventArgs e)
        {
            if (show)
            {
                return;
            }
            show = true;
            pb.Image = GetAfbeelding(pos);
            pb.Refresh();
            IsGeklikt(this, null);
        }

        private Image GetAfbeelding(int getal)
        {
            Image b = new Bitmap(1, 1);

            switch (getal)
            {
                case 0:
                    //default afbeelding
                    //b = Properties.Resources.achtergrond;
                    b = Properties.Resources.achtergrond;
                    //b = Image.FromFile("C:\\Memplaatjes\\achtergrond.JPG");
                case 1:
                    //afbeelding 1
                    b = Properties.Resources._3_Bouten;
                    b = Image.FromFile("C:\\Memplaatjes\\3Bouten.JPG");
                    break;
                case 2:
                    //afbeelding 2
                    b = Properties.Resources.cartman;
                    b = Image.FromFile("C:\\Memplaatjes\\cartman.JPG");
                    break;
                case 3:
                    //afbeelding 3
                     b = Properties.Resources.divx;
                    b = Image.FromFile("C:\\Memplaatjes\\divx.JPG");
                    break;
                case 4:
                    //afbeelding 4
                    b = Properties.Resources.fatboyslimz;
                    b = Image.FromFile("C:\\Memplaatjes\\fatboyslimz.JPG");
                    break;
                case 5:
                    //afbeelding 5
                    b = Image.FromFile("C:\\Memplaatjes\\Felix.JPG");
                    break;
                case 6:
                    //afbeelding 6
                    b = Image.FromFile("C:\\Memplaatjes\\hamburger.JPG");
                    break;
                case 7:
                    //afbeelding 7
                    b = Image.FromFile("C:\\Memplaatjes\\Homer.JPG");
                    break;
                case 8:
                    //afbeelding 8
                    b = Image.FromFile("C:\\Memplaatjes\\tweety.JPG");
                    break;
            }
            return b;
        }

        private Bitmap MaakAchtergrond()
        {
            Bitmap b = new Bitmap(110, 110);
            Graphics g = Graphics.FromImage((Image)b);
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, b.Width, b.Height));
            g.Dispose();
            return b;
        }

        public void FlipAchtergrond()
        {
            show = false;
            pb.Image = GetAfbeelding(0);
            pb.Refresh();
        }
    }
}
