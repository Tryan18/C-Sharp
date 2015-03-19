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


namespace BU
{
    public class GenerateVoorstel
    {
        private double slaPrijs;
        private int slaVolume;

        public GenerateVoorstel()
        { 
            
        }

        public List<BUPakket> generateVoorstel(double prijs, BUThema thema, int volume, List<BUProduct> producten)
        {
            slaPrijs = prijs;
            slaVolume = volume;

            if (prijs == 0 || volume == 0)
            {
                return new List<BUPakket>();
            }
            else
            {
                List<BUProduct> listProducten = geefProductenMetThemaHoogtePrijs(thema, volume, prijs);

                if (producten != null)
                {
                    listProducten = voegProductenToe(producten, listProducten);
                }

                List<BUPakket> pakketten = new List<BUPakket>();
                pakketten.Add(new BUPakket());

                // Algroritme begint hier
                Alg(prijs, volume, listProducten, ref pakketten);
                
                vulPakketGegevens(ref pakketten, thema);
                
                return pakketten;
            }
        }

        private void vulPakketGegevens(ref List<BUPakket> pakketten, BUThema thema)
        {
            BUProduct pr = new BUProduct();

            for (int i = 0; i < pakketten.Count; i++)
            {
                pakketten[i].Themas.Add(thema);
                pakketten[i].Actief = true;

                for (int j = 0; j < pakketten[i].Product.Count; j++)
                {
                    pr = (BUProduct) pakketten[i].Product[j];

                    pakketten[i].Prijs += pr.Prijs;
                    // pakketten[i].Volume += pr.Volume;
                }
            }
        }

        private List<BUProduct> geefProductenMetThemaHoogtePrijs(BUThema thema, int volume, double prijs)
        {
            return BUProduct.geefProductenMetThemaHoogtePrijs(thema, volume, prijs);
        }

        private List<BUProduct> voegProductenToe(List<BUProduct> lijst1, List<BUProduct> lijst2)
        {
            for (int i = 0; i < lijst1.Count; i++)
            {
                for (int j = 0; j < lijst2.Count; j++)
                {
                    int count = 0;

                    if (lijst1[i] != lijst2[j])
                    {
                        count++;
                    }

                    else if (count == lijst2.Count)
                    {
                        lijst2.Add(lijst1[i]);
                    }
                }
            }

            return lijst2;
       }

        private List<BUPakket> Alg(double prijs, int volume, List<BUProduct> producten, ref List<BUPakket> pakketten)
        {
            if (producten.Count != 0)
            {
                if (prijs <= 0 || volume <= 0)
                {
                    pakketten.Add(new BUPakket());
                    prijs = slaPrijs;
                    volume = slaVolume;
                    Alg(prijs, volume, producten, ref pakketten);
                }
                else
                {
                    int last = pakketten.Count - 1;

                    for (int i = 0; i < producten.Count; i++)
                    {
                        prijs -= producten[i].Prijs;
                        volume -= producten[i].Volume;

                        if (prijs <= 0 || volume <= 0)
                        {
                            Alg(prijs, volume, producten, ref pakketten);
                        }
                        else
                        {
                            pakketten[last].Product.Add(producten[i]);
                            producten.Remove(producten[i]);
                            Alg(prijs, volume, producten, ref pakketten);
                        }
                    }
                }
            }
            return pakketten;
        }
    }
}
