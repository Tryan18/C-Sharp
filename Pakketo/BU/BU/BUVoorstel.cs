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
    public class BUVoorstel
    {
        private double slaPrijs;
        private int slaVolume;
        private int slaGewicht;
        private List<BUProduct> slaProducten;

        public BUVoorstel()
        { 
            
        }

        public List<BUPakket> generateVoorstel(double prijs, BUThema thema, int volume, int gewicht, List<BUProduct> producten)
        {
            slaPrijs = prijs;
            slaVolume = volume;
            slaGewicht = gewicht;
            slaProducten = producten;

            if (prijs == 0 || volume == 0 || gewicht == 0)
            {
                return new List<BUPakket>();
            }
            else
            {
                List<BUProduct> listProducten = geefProductenMetThemaHoogtePrijs(thema, volume, prijs, gewicht);

                if (producten != null)
                {
                    listProducten = voegProductenToe(producten, listProducten);
                }

                List<BUPakket> pakketten = new List<BUPakket>();
                pakketten.Add(new BUPakket());

                // Algroritme begint hier
                Alg(prijs, volume, gewicht, listProducten, ref pakketten);
                
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
                int gewicht = 0;

                for (int j = 0; j < pakketten[i].Product.Count; j++)
                {
                    pr = (BUProduct) pakketten[i].Product[j];

                    pakketten[i].Prijs += pr.Prijs;
                    pakketten[i].Volume += pr.Volume;
                    gewicht += Convert.ToInt32(pr.Gewicht);
                }
                pakketten[i].Gewicht = gewicht.ToString();
            }
        }

        private List<BUProduct> geefProductenMetThemaHoogtePrijs(BUThema thema, int volume, double prijs, int gewicht)
        {
            return BUProduct.geefProductenMetThemaHoogtePrijs(thema, volume, prijs, gewicht);
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

        private List<BUPakket> Alg(double prijs, int volume, int gewicht, List<BUProduct> producten, ref List<BUPakket> pakketten)
        {
            if (producten.Count != 0)
            {
                if (prijs < 0 || volume < 0 || gewicht < 0)
                {
                    if (pakketten.Count == 20) 
                        return pakketten;

                    pakketten.Add(new BUPakket());
                    prijs = slaPrijs;
                    volume = slaVolume;
                    gewicht = slaGewicht;

                    Alg(prijs, volume, gewicht, producten, ref pakketten);
                }
                else
                {
                    int last = pakketten.Count - 1;

                    for (int i = 0; i < producten.Count; i++)
                    {
                        prijs -= producten[i].Prijs;
                        volume -= producten[i].Volume;
                        gewicht -= Convert.ToInt32(producten[i].Gewicht);

                        if (prijs < 0 || volume < 0 || gewicht < 0)
                        {
                            Alg(prijs, volume, gewicht, producten, ref pakketten);
                        }
                        else
                        {
                            pakketten[last].Product.Add(producten[i]);
                            producten.Remove(producten[i]);
                            Alg(prijs, volume,  gewicht, producten, ref pakketten);
                        }
                    }
                }
            }
            return pakketten;
        }
    }
}
