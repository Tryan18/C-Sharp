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
    public class CC_product_beheer
    {
        private List<BUProduct> producten = new List<BUProduct>();
        private BUProduct product;

        public CC_product_beheer()
        {

        }

        public void getAlleProducten()
        {
            producten = BUProduct.geefAlleProducten();
        }

        public string[,] geefProductenMetThema(int themaID)
        {
             producten = BUProduct.geefProductenMetThema(BUThema.Find(themaID));
             string[,] hulp = new string[producten.Count, 10];
             if (producten != null)
             {
                 for (int i = 0; i < producten.Count; i++)
                 {
                     hulp[i, 0] = producten[i].ID.ToString();
                     hulp[i, 1] = producten[i].Naam;
                     hulp[i, 2] = producten[i].Beschrijving;
                     string[] temp = producten[i].Afmeting.Split('x');
                     hulp[i, 3] = temp[0];//lengte
                     hulp[i, 4] = temp[1];//breedte
                     hulp[i, 5] = temp[2];//hoogte
                     hulp[i, 6] = producten[i].Gewicht;
                     hulp[i, 7] = producten[i].Prijs.ToString();
                     hulp[i, 8] = producten[i].Aantal.ToString();
                     hulp[i, 9] = producten[i].Pad;
                 }
                 return hulp;
             }
             else
                 return null;
        }

        public bool voegProductToe(string naam, string beschrijving, string lengte, string breedte, string hoogte, string gewicht, string prijs, int[] themaIDs, string pad)
        {
            string afmeting = lengte + "x" + breedte + "x" + hoogte;
            BUProduct product = BUProduct.voegProductToe(naam, beschrijving, afmeting, gewicht, double.Parse(prijs),themaIDs,pad);
            if (product != null)
            {
                producten.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool wijzigProduct(int productID, string naam, string beschrijving, string lengte, string breedte, string hoogte, string gewicht, string prijs, int[] themaIDs, string pad)
        {
            string afmeting = lengte + "x" + breedte + "x" + hoogte;
            BUProduct product = BUProduct.wijzigProduct(productID, naam, beschrijving, afmeting, gewicht, double.Parse(prijs), themaIDs, pad);
            if (product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verwijderProduct(int productID)
        {
            BUProduct product = BUProduct.verwijderProduct(productID);
            if(product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] getThemaNamen(int productID)
        {
            BUProduct product = BUProduct.Find(productID);
            int lengte = product.Themas.Count;
            string[] namen = new string[lengte];
            for (int i = 0; i < lengte; i++)
            {
                BUThema thema = (BUThema)product.Themas[i];
                namen[i] = thema.Naam;
            }
            return namen;
        }

        public string[] getProductGegevens(int productID)
        {
            product = BUProduct.Find(productID);
            string[] gegevens = new string[9];
            gegevens[0] = product.ID.ToString();
            gegevens[1] = product.Naam;
            gegevens[2] = product.Beschrijving;
            string[] temp = product.Afmeting.Split('x');
            gegevens[3] = temp[0];//lengte
            gegevens[4] = temp[1];//breedte
            gegevens[5] = temp[2];//hoogte
            gegevens[6] = product.Gewicht;
            gegevens[7] = product.Prijs.ToString();
            gegevens[8] = product.Pad;
            return gegevens;
        }

        public bool ControleerTimeStamp(int productID)
        {
            if (product.TimeStamp == BUProduct.Find(productID).TimeStamp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
