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

namespace Spazer
{
    public class Level
    {
        public static List<Block> StartLevel(int level,Panel speelveld,Niveau niveau)
        {
            List<Block> blokken = new List<Block>();
            Random r = new Random();
            List<int> aantalItems = new List<int>();
            int aantal = 0;
            switch (niveau)
            {
                case Niveau.Easy:
                    aantal = 3;
                    break;
                case Niveau.Normal:
                    aantal = 2;
                    break;
                case Niveau.Hard:
                    aantal = 1;
                    break;
            }
            switch (level)
            {
                case 1:
                    int x = 0;
                    int y = 0;
                    int breedte = speelveld.Width / 10;
                    int lengte = 30;
                    Tools ts = Tools.Leeg;

                    for (int i = 0; i < 3; i++)
                    {
                        aantalItems.Clear();
                        for (int k = 0; k < aantal; k++)
                        {
                            aantalItems.Add(r.Next(0, 10));
                        }
                        for (int j = 0; j < 10; j++)
                        {
                            ts = Tools.Leeg;
                            foreach (int l in aantalItems)
                            {
                                if (l == j)
                                {
                                    ts = (Tools)r.Next(0, 5);
                                }
                            }
                            blokken.Add(new Block(x, y, breedte, lengte, (BlockType)r.Next(1, 5),ts));
                            x += breedte;
                        }
                        x = 0;
                        y += lengte;
                    }
                    break;
                case 2:

                    break;
            }
            return blokken;
        }
    }
}
