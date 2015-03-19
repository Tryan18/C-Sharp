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

namespace Spazer
{
    public class Block
    {
        public Image plaatje;
        public Rectangle rec;
        private BlockType bt;
        public Tools ts;

        public BlockType BT
        {
            get { return bt; }
            set
            {
                if (value == BlockType.Leeg)
                {
                    plaatje = null;
                }
                else
                {
                    bt = value;
                }
            }
        }

        public Block(int x,int y,int breedte,int lengte,BlockType bt,Tools ts)
        {
            rec = new Rectangle(x, y, breedte, lengte);
            this.ts = ts;
            this.bt = bt;
            switch(bt)
            {
                case BlockType.Leeg:
                    plaatje = new Bitmap(10, 10);
                    break;
                case BlockType.Blue:
                    plaatje = Properties.Resources.blauw;
                    break;
                case BlockType.Green:
                    plaatje = Properties.Resources.groen;
                    break;
                case BlockType.Red:
                    plaatje = Properties.Resources.rood;
                    break;
                case BlockType.Yellow:
                    plaatje = Properties.Resources.geel;
                    break;
            }
            Bitmap b = new Bitmap(rec.Width,rec.Height);
            Graphics g = Graphics.FromImage((Image)b);
            g.DrawImage(plaatje,new Rectangle(0,0,b.Width,b.Height),new Rectangle(0,0,plaatje.Width,plaatje.Height),GraphicsUnit.Pixel);
            plaatje = b;
            g.Dispose();
        }
    }

    public enum BlockType : int
    {
        Leeg,
        Red,
        Blue,
        Green,
        Yellow
    }
}
