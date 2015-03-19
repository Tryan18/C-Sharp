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
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MultiMemory
{
    [Serializable]
    public class Kaartje
    {
        [NonSerialized]
        public PictureBox pb;
        public int nummer,Pos;
        public int x, y, breedte, lengte;
        private readonly int offsetX = 12;
        private readonly int offsetY = 12;
        public Boolean revealed = true;
        public Boolean Weggevaagd = false;

        public Kaartje(int x,int y,int breedte,int lengte,int nummer,int nummer2,object sender)
        {
            this.nummer = nummer;
            Pos = nummer2;
            pb = new PictureBox();
            pb.Left = offsetX + x;
            pb.Top = offsetY + y;
            pb.Width = breedte;
            pb.Height = lengte;
            changePic();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            (sender as Control).Controls.Add(pb);
            pb.Show();
        }

        public void changePic()
        {
            if (!revealed)
            {
                switch (nummer)
                {
                    case 1:
                        pb.Image = Properties.Resources.cartman;
                        break;
                    case 2:
                        pb.Image = Properties.Resources.tweety;
                        break;
                    case 3:
                        pb.Image = Properties.Resources.fatboyslimz;
                        break;
                    case 4:
                        pb.Image = Properties.Resources.Felix;
                        break;
                    case 5:
                        pb.Image = Properties.Resources.Homer;
                        break;
                    case 6:
                        pb.Image = Properties.Resources.divx;
                        break;
                    case 7:
                        pb.Image = Properties.Resources.hamburger;
                        break;
                    case 8:
                        pb.Image = Properties.Resources._3_Bouten;
                        break;
                }
                revealed = true;
                return;
            }
            else if (revealed)
            {
                pb.Image = Properties.Resources.achtergrond;
                revealed = false;
            }
        }
    }
}
