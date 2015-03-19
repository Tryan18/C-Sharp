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
using System.Drawing.Drawing2D;

namespace Tetris
{
    class drawImages
    {
        private List<Image> images;
        private Brush[] br;

        public drawImages()
        {
            images = new List<Image>();
            br = new Brush[8] {Brushes.Aquamarine,Brushes.Azure,Brushes.Red,Brushes.Orange,Brushes.Yellow,Brushes.Blue,Brushes.Green,Brushes.GreenYellow};
            int index = 0;
            for (int i = 0; i < br.Length; i+=2)
            {
                images.Add(new Bitmap(10, 10));
                DrawColor(images[index],br[i],br[i+1]);
                index++;
            }
            images.Add(new Bitmap(10, 10));
            CreateFireImage(images[4]);
        }

        private void CreateFireImage(Image plaatje)
        {
            Graphics g = Graphics.FromImage(plaatje);
            int x = 5;
            int y = 9;
            int q = 1;
            Pen p = new Pen(Brushes.Black);
            //Brush B = new LinearGradientBrush(new Point(1, 1), new Point(2, 2), Color.Red, Color.Blue);
            g.FillRectangle(Brushes.Red, new Rectangle(0, 0, 10, 10));
            g.FillRectangle(Brushes.Yellow, new Rectangle(1, 2, 8, 7));
            g.FillRectangle(Brushes.Red, new Rectangle(2, 3, 6, 5));
            //g.DrawRectangle(p, new Rectangle(0, 0, 10, 10));
            GraphicsPath pad = new GraphicsPath(new Point[] { new Point(x, q), new Point(y, x), new Point(x, y), new Point(q, x), new Point(x, q) }, new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
            //g.DrawPath(p, pad);
            g.FillPath(Brushes.Yellow, pad);
            x = 5;
            y = 7;
            q = 3;
            GraphicsPath pad2 = new GraphicsPath(new Point[] { new Point(x, q), new Point(y, x), new Point(x, y), new Point(q, x), new Point(x, q) }, new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
            g.FillPath(Brushes.Red, pad2);
            g.Dispose();
            p.Dispose();
        }

        private void DrawColor(Image plaatje,Brush bru,Brush bru2)
        {
            Graphics g = Graphics.FromImage(plaatje);
            Pen p = new Pen(Brushes.Black);
            g.FillRectangle(bru,new Rectangle(0,0,10,10));
            g.DrawRectangle(p, new Rectangle(0, 0, 10, 10));
            g.FillRectangle(bru2,new Rectangle(2,2,6,6));
            g.DrawRectangle(p, new Rectangle(2, 2, 6, 6));
            g.Dispose();
            p.Dispose();
        }

        public List<Image> GetImages()
        {
            return images;
        }
    }
}
