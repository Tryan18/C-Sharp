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
using BU;

namespace CC
{
    public class CC_kleuren_beheer
    {
        public List<BUKleur> kleurenlijst = new List<BUKleur>();

        public CC_kleuren_beheer()
        {
            kleurenlijst = BUKleur.getAlleKleuren();
        }

        public bool voegKleurToe(string naam, string hexid)
        {
            BUKleur kleur = BUKleur.voegKleurToe(naam, hexid);
            if (kleur == null)
            {
                return false;
            }
            else
            {
                kleurenlijst.Add(kleur);
                return true;
            }
        }

        public string[,] getAlleKleuren()
        {
            int max = kleurenlijst.Count;
            string[,] kleuren = new string[max, 3];
            for (int i = 0; i < max; i++)
            {
                kleuren[i, 0] = kleurenlijst[i].ID.ToString();
                kleuren[i, 1] = kleurenlijst[i].Naam;
                kleuren[i, 2] = kleurenlijst[i].HEXID;
            }
            return kleuren;
        }
    }
}
