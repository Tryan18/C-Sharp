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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PuzzleBattle
{
    public class Blok
    {
        public PictureBox pb;
        public FieldType veldtype;
        public List<Image> overige = new List<Image>();
        public int xPos;
        public int yPos;

        public Blok(object sender, int x, int y, int groote, FieldType veldtype,int xPos,int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            pb = new PictureBox();
            pb.Left = x;
            pb.Top = y;
            pb.Width = groote;
            pb.Height = groote;
            if (veldtype == FieldType.cursor || veldtype == FieldType.oldcursor)
            {
                pb.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pb.BorderStyle = BorderStyle.Fixed3D;
            }
            createPlaatjes();
            setPlaatje(veldtype);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            (sender as BattleField).group_battlefield.Controls.Add(pb);
            pb.Show();
        }

        private void createPlaatjes()
        {
            Bitmap b = new Bitmap(pb.Width, pb.Height);
            Image i = (Image)b;
            Graphics g = Graphics.FromImage(i);
            g.FillRectangle(Brushes.Gold, new Rectangle(0, 0, pb.Width, pb.Height));
            overige.Add((Image)i.Clone());
            g.Clear(Color.Gray);
            g.FillRectangle(Brushes.GreenYellow, new Rectangle(0, 0, pb.Width, pb.Height));
            overige.Add((Image)i.Clone());
            g.Clear(Color.Gray);
            g.FillRectangle(Brushes.Red, new Rectangle(0, 0, pb.Width, pb.Height));
            overige.Add((Image)i.Clone());
            g.Dispose();
        }

        public void setPlaatje(FieldType veldtype)
        {
            switch (veldtype)
            {
                case FieldType.blue:
                    pb.Image = Properties.Resources.blue;
                    break;
                case FieldType.green:
                    pb.Image = Properties.Resources.green;
                    break;
                case FieldType.yellow:
                    pb.Image = Properties.Resources.yellow;
                    break;
                case FieldType.red:
                    pb.Image = Properties.Resources.red;
                    break;
                case FieldType.money:
                    pb.Image = Properties.Resources.money;
                    break;
                case FieldType.star:
                    pb.Image = Properties.Resources.star;
                    break;
                case FieldType.skull:
                    pb.Image = Properties.Resources.skull;
                    break;
                case FieldType.wildcard:
                    pb.Image = Properties.Resources.wildcard;
                    break;
                case FieldType.cursor:
                    pb.Image = overige[0];
                    break;
                case FieldType.oldcursor:
                    pb.Image = overige[1];
                    break;
                case FieldType.fout:
                    pb.Image = overige[2];
                    break;
            }
            this.veldtype = veldtype;
        }

        public void setCursor(Blok cursor)
        {
            if (cursor.veldtype == FieldType.cursor)
            {
                cursor.pb.Left = this.pb.Left;
                cursor.pb.Top = this.pb.Top;
            }
            else
            {
                cursor.pb.Left = this.pb.Left + 30;
                cursor.pb.Top = this.pb.Top;
            }
        }

        public void Animation()
        {   
            this.pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pb.Refresh();
            System.Threading.Thread.Sleep(100);
            this.pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pb.Refresh();
            System.Threading.Thread.Sleep(100);
            this.pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pb.Refresh();
            System.Threading.Thread.Sleep(100);
            this.pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pb.Refresh();
            System.Threading.Thread.Sleep(100);
        }

        public void FakeAnimation()
        {
            Image img = (Image)pb.Image.Clone();
            Bitmap copy=new Bitmap(img.Width,img.Height);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cm=new ColorMatrix();
            cm.Matrix00=
            cm.Matrix11=
            cm.Matrix22=-1;
            ia.SetColorMatrix(cm);
            Graphics g=Graphics.FromImage(copy);
            g.DrawImage(img,new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            pb.Image = (Image)img.Clone();
            img.Dispose();

            //this.pb.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            this.pb.Refresh();
            //System.Threading.Thread.Sleep(100);
            //this.pb.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            this.pb.Refresh();
            System.Threading.Thread.Sleep(100);
        }
    }
}
