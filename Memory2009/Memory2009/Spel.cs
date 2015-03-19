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

namespace Memory2009
{
    public class Spel
    {
        private Form1 f;
        private List<Kaart> kaarten = new List<Kaart>();
        private Kaart eersteKaartje;

        public Spel(Form1 f)
        {
            this.f = f;
            
            int pos = 1;
            int x = 0;
            int y = 0;
            int breedte = 100;
            int lengte = 100;

            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    Kaart k = new Kaart(pos, x, y, breedte, lengte, f);
                    k.IsGeklikt += new EventHandler(Geklikt);
                    kaarten.Add(k);
                    x += breedte + 5;
                    pos++;
                }
                y += lengte + 5;
                x = 0;
                if (i == 1)
                {
                    pos = 1;
                }
            }
        }

        private void Geklikt(object sender, EventArgs e)
        {
            Kaart k = (sender as Kaart);
            if (eersteKaartje == null)
            {
                eersteKaartje = k;
            }
            else if (eersteKaartje.Pos != k.Pos)
            {
                //geen paartje gevonden
                System.Threading.Thread.Sleep(200);
                eersteKaartje.FlipAchtergrond();
                k.FlipAchtergrond();
                eersteKaartje = null;
            }
            else if (eersteKaartje.Pos == k.Pos)
            {
                //paartje gevonden
                eersteKaartje.Gevonden = true;
                k.Gevonden = true;
                eersteKaartje = null;
            }
        }
    }
}
