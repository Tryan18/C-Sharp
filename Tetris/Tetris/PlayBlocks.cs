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

namespace Tetris
{
    struct PlayBlocks
    {
        //colors: 0:wit 1:red 2:yellow 3:green
        public static List<Rectangle> SnakeLeft(int x, int y,int groote, Boolean Switched)
        {
            if (!Switched)
            {
                // [r2]
                // [r1][r3]
                //     [r4]
                List<Rectangle> InfoBlok = new List<Rectangle>();
                Rectangle r1 = new Rectangle(x, y, groote, groote);
                InfoBlok.Add(r1);
                if (y > 12)
                {
                    Rectangle r2 = new Rectangle(x, y - groote, groote, groote);
                    InfoBlok.Add(r2);
                }
                Rectangle r3 = new Rectangle(x + groote, y, groote, groote);
                InfoBlok.Add(r3);
                Rectangle r4 = new Rectangle(x + groote, y + groote, groote, groote);
                InfoBlok.Add(r4);

                return InfoBlok;
            }
            else
            {
                //     [r3][r4]
                // [r2][r1]
                //
                List<Rectangle> InfoBlok = new List<Rectangle>();
                Rectangle r1 = new Rectangle(x, y, groote, groote);
                InfoBlok.Add(r1);
                Rectangle r2 = new Rectangle(x - groote, y, groote, groote);
                InfoBlok.Add(r2);
                if (y > 12)
                {
                    Rectangle r3 = new Rectangle(x, y - groote, groote, groote);
                    InfoBlok.Add(r3);
                    Rectangle r4 = new Rectangle(x + groote, y - groote, groote, groote);
                    InfoBlok.Add(r4);
                }
                
                
                return InfoBlok;
            }
        }

        public static List<Rectangle> SnakeRight(int x, int y,int groote, Boolean Switched)
        {
            if (!Switched)
            {
                //     [r3]
                // [r1][r2]
                // [r4]
                List<Rectangle> InfoBlok = new List<Rectangle>();
                Rectangle r1 = new Rectangle(x, y, groote, groote);
                InfoBlok.Add(r1);
                Rectangle r2 = new Rectangle(x + groote, y, groote, groote);
                InfoBlok.Add(r2);
                if (y > 12)
                {
                    Rectangle r3 = new Rectangle(x + groote, y - groote, groote, groote);
                    InfoBlok.Add(r3);
                }
                Rectangle r4 = new Rectangle(x, y + groote, groote, groote);
                InfoBlok.Add(r4);

                return InfoBlok;
            }
            else
            {
                //[r2][r1]
                //    [r3][r4]
                //
                List<Rectangle> InfoBlok = new List<Rectangle>();
                Rectangle r1 = new Rectangle(x, y, groote, groote);
                Rectangle r2 = new Rectangle(x - groote, y, groote, groote);
                Rectangle r3 = new Rectangle(x, y + groote, groote, groote);
                Rectangle r4 = new Rectangle(x + groote, y + groote, groote, groote);

                InfoBlok.Add(r1);
                InfoBlok.Add(r2);
                InfoBlok.Add(r3);
                InfoBlok.Add(r4);
                return InfoBlok;
            }
        }
    }
}
