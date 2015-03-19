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
    public class CC_thema_beheer
    {
        private List<BUThema> themalijst = new List<BUThema>();

        public CC_thema_beheer()
        {
            
        }

        public bool voegThemaToe(string naam, string beschrijving, string plaatjepad, int[] kleurenIDs)
        {
            BUThema thema = BUThema.voegThemaToe(naam, beschrijving, plaatjepad, kleurenIDs);
            if (thema != null)
            {
                themalijst.Add(thema);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[,] getAlleThemas()
        {
            themalijst = BUThema.getAlleThemas();
            string[,] themas = new string[themalijst.Count, 6];
            if (themalijst.Count != 0)
            {
                for (int i = 0; i < themalijst.Count; i++)
                {
                    themas[i, 0] = themalijst[i].ID.ToString();
                    themas[i, 1] = themalijst[i].Naam;
                    themas[i, 2] = themalijst[i].Beschrijving;
                    themas[i, 3] = themalijst[i].Pad;
                    string hulp = "";
                    string hulp2 = "";
                    foreach(BUKleur kleur in themalijst[i].Kleuren)
                    {
                        hulp += kleur.Naam + ",";
                    }
                    themas[i, 4] = hulp;
                    foreach (BUPakket pakket in themalijst[i].Pakketten)
                    {
                        hulp2 += pakket.Naam + ",";
                    }
                    themas[i, 5] = hulp2;
                }
                return themas;
            }
            else
            {
                return null;
            }
        }
    }
}
