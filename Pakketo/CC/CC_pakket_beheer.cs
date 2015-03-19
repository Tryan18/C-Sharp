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
using BU;

namespace CC
{
    public class CC_pakket_beheer
    {
        private List<BUPakket> pakketten = new List<BUPakket>();
        private List<BUProduct> producten;

        public CC_pakket_beheer()
        {

        }

        public bool voegPakketToe(string naam,string beschrijving,string lengte,string breedte,string hoogte,string gewicht,string prijs,int themaID,List<int[]> productenIDs,string pad,int klantID)
        {

            string afmeting = lengte + "x" + breedte + "x" + hoogte;
            List<BUProduct> Tempproducten = new List<BUProduct>();
            for(int i=0;i<productenIDs.Count;i++)
            {
                int productID = productenIDs[i][0];
                int aantal = productenIDs[i][1];
                Tempproducten.Add(BUProduct.VeranderAantal(productID, aantal));
            }
            BUPakket tempPakket = BUPakket.voegPakketToe(naam,beschrijving,afmeting,gewicht,double.Parse(prijs),pad,BUThema.Find(themaID),Tempproducten,klantID);
            if(tempPakket == null)
            {
                return false;
            }
            else
            {
                pakketten.Add(tempPakket);
                return true;
            }
        }

        public bool wijzigPakket(string naam, string beschrijving, string lengte, string breedte, string hoogte, string gewicht, string prijs, int themaID, List<int[]> productenIDs, string pad, int klantID, int indexpakket,int pakketID)
        {
            string afmeting = lengte + "x" + breedte + "x" + hoogte;
            List<BUProduct> Tempproducten = new List<BUProduct>();
            for (int i = 0; i < productenIDs.Count; i++)
            {
                int productID = productenIDs[i][0];
                int aantal = productenIDs[i][1];
                Tempproducten.Add(BUProduct.VeranderAantal(productID, aantal));
            }
            BUPakket tempPakket = BUPakket.wijzigPakket(naam, beschrijving, afmeting, gewicht, double.Parse(prijs), pad, BUThema.Find(themaID), Tempproducten, klantID,pakketID);
            if (tempPakket == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool verwijderPakket(int pakketID)
        {
            BUPakket pakket = BUPakket.verwijderPakket(pakketID);
            if(pakket != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void getAllePakketen(int laatstepakketID,int lengtepakketlijst)
        {
            pakketten = BUPakket.geefAllePakketten(laatstepakketID,lengtepakketlijst);
        }

        public string[,] refreshPakketen()
        {
            if (pakketten.Count == 0)
            {
                return null;
            }  
            
            string[,] hulp = new string[pakketten.Count, 13];
            for (int i = 0; i < pakketten.Count; i++)
            {
                string[] afmeting;
                if (pakketten[i].Afmeting == null) afmeting = new string[] { " ", " ", " " };
                else
                    afmeting = pakketten[i].Afmeting.Split(new char[] { 'x' });
                
                hulp[i, 0] = pakketten[i].ID.ToString();
                hulp[i, 1] = pakketten[i].Naam;
                hulp[i, 2] = pakketten[i].Beschrijving;
                hulp[i, 3] = afmeting[0];
                hulp[i, 4] = afmeting[1];
                hulp[i, 5] = afmeting[2];
                hulp[i, 6] = pakketten[i].Gewicht;
                hulp[i, 7] = pakketten[i].Prijs.ToString();
                hulp[i, 8] = pakketten[i].Pad;
                BUThema thema = (BUThema)pakketten[i].Themas[0];
                hulp[i, 9] = thema.Naam;
                BUKlant klant = null;
                if (pakketten[i].Klanten.Count != 0)
                {
                    klant = (BUKlant)pakketten[i].Klanten[0];
                }
                if (klant != null)
                {
                    hulp[i, 10] = klant.ID.ToString();
                    hulp[i, 11] = klant.Voornaam + " " + klant.Achternaam;
                    hulp[i, 12] = klant.Opmerking;
                }
                else
                {
                    hulp[i, 10] = "";
                    hulp[i, 11] = "";
                    hulp[i, 12] = "";
                }
            }

            return hulp;
        }

        public string[,] refreshProducten(int index)
        {
            if (pakketten.Count == 0 || index == -1)
            {
                string[,] leeg = new string[1, 8];
                for (int i = 0; i < leeg.GetLength(1); i++)
                {
                    leeg[0, i] = " ";
                }
                return leeg;
            }
            
            int lengte = pakketten[index].Product.Count;
            string[,] temp = new string[lengte, 8];

            for (int i = 0; i < lengte; i++)
            {
                BUProduct product = (pakketten[index].Product[i] as BUProduct);
                temp[i, 0] = product.ID.ToString();
                temp[i, 1] = product.Naam;
                temp[i, 2] = product.Beschrijving;
                temp[i, 3] = product.Afmeting;
                temp[i, 4] = product.Gewicht;
                temp[i, 5] = product.Prijs.ToString();
                temp[i, 6] = product.Aantal.ToString();
                temp[i, 7] = product.Pad;
            }
            return temp;
     
        }

        public void getAlleProducten()
        {
            producten = BUProduct.geefAlleProducten();
        }

        //public string[,] geefProductenDetails()
        //{
        //    getAlleProducten();
        //    int lengte = producten.Count;

        //    if (lengte == 0)
        //    {
        //        string[,] leeg = new string[1, 6];
        //        for (int i = 0; i < leeg.GetLength(1); i++)
        //        {
        //            leeg[0, i] = " ";
        //        }
        //        return leeg;
        //    }

        //    string[,] productnamen = new string[lengte,6];

        //    for(int i=0;i<lengte;i++)
        //    {
        //        productnamen[i, 0] = producten[i].ID.ToString();
        //        productnamen[i, 1] = producten[i].Naam;
        //        productnamen[i, 2] = producten[i].Beschrijving;
        //        productnamen[i, 3] = producten[i].Afmeting;
        //        productnamen[i, 4] = producten[i].Gewicht;
        //        productnamen[i, 5] = producten[i].Prijs.ToString();
        //    }
        //    return productnamen;
        //}

        //public void maakProductenRelatie(int[] productenID,int pakketID)
        //{
        //    foreach (int i in productenID)
        //    {
        //        BUProduct pro = BUProduct.Find(productenID[i]);
        //        BUPakket pak = BUPakket.Find(pakketID);
        //        BUProduct.maakRelatie(pro,pak);

        //        int indexpak = pakketten.LastIndexOf(pak);
        //        int indexpro = producten.LastIndexOf(pro);
        //        pakketten[indexpak].Product.Add((producten[indexpro] as object));
        //    }
        //}

        //public void verbreekProductenRelatie(int[] productenID, int pakketID)
        //{
        //    foreach (int i in productenID)
        //    {
        //        BUProduct pro = BUProduct.Find(productenID[i]);
        //        BUPakket pak = BUPakket.Find(pakketID);
        //        BUProduct.verbreekRelatie(pro, pak);
        //        int indexpak = pakketten.LastIndexOf(pak);
        //        int indexpro = producten.LastIndexOf(pro);
        //        pakketten[indexpak].Product.Remove((producten[indexpro] as object));
        //    }
        //}

        public bool zoekPakketten(string beginletters)
        {
            BUPakket[] hulp = BUPakket.geefPakketten(beginletters);
            if (hulp != null)
            {
                pakketten.Clear();
                foreach (BUPakket pakket in hulp)
                {
                    pakketten.Add(pakket);
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public bool maakVoorstel(double prijs, string lengte,string breedte,string hoogte, int themaID, int gewicht, List<int[]> productenIDs)
        {
            int volume = int.Parse(lengte) * int.Parse(breedte) * int.Parse(hoogte);
            List<BUProduct> Tempproducten = new List<BUProduct>();
            for (int i = 0; i < productenIDs.Count; i++)
            {
                int productID = productenIDs[i][0];
                int aantal = productenIDs[i][1];
                Tempproducten.Add(BUProduct.VeranderAantal(productID, aantal));
            }
            BUVoorstel voorstel = new BUVoorstel();
            pakketten = voorstel.generateVoorstel(prijs, BUThema.Find(themaID), volume, gewicht, Tempproducten);
            if (pakketten[0].Prijs != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> getVoorstellingProductenIDs(int pakketIndex)
        {
            List<int> IDs = new List<int>();
            foreach(BUProduct pro in pakketten[pakketIndex].Product)
            {
                int id = pro.ID;
                IDs.Add(id);
            }
            return IDs;
        }
    }
}
