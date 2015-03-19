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

namespace Sudoku
{
    class DrawImages
    {
        private Image[,] images;
        private Font lettertype;
        private Brush br;

        public DrawImages()
        {
            images = new Image[3, 17];
            lettertype = new Font("Arial", 7, FontStyle.Regular);
            br = Brushes.Black;

            images[0, 0] = new Bitmap(13, 10);
            DrawEmpty(images[0, 0]);
            for (int i = 1; i < images.GetLength(1); i++)
            {
                images[0, i] = new Bitmap(13, 10);
                DrawNumber(images[0, i],i);
            }

            br = Brushes.Red;
            images[1, 0] = new Bitmap(13, 10);
            DrawEmpty(images[1, 0]);
            for (int o = 1; o < images.GetLength(1); o++)
            {
                images[1, o] = new Bitmap(13, 10);
                DrawNumber(images[1, o],o);
            }

            br = Brushes.Green;
            images[2, 0] = new Bitmap(13, 10);
            DrawEmpty(images[2, 0]);
            for (int o = 1; o < images.GetLength(1); o++)
            {
                images[2, o] = new Bitmap(13, 10);
                DrawNumber(images[2, o], o);
            }
        }

        private void DrawNumber(Image plaatje,int getal)
        {
            Graphics g = Graphics.FromImage(plaatje);
            g.FillRectangle(Brushes.White,new Rectangle(0,0,13,10));
            g.DrawString(getal.ToString(), lettertype, br, new PointF(0, 0));
            g.Dispose();
        }

        private void DrawEmpty(Image plaatje)
        {
            Graphics g = Graphics.FromImage(plaatje);
            g.FillRectangle(Brushes.Azure, new Rectangle(0, 0, 13, 10));
            g.Dispose();
        }

        public Image[,] GetImages()
        {
            return images;
        }
    }
}
