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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BU;

namespace CC
{
    public class CC_klant_beheer
    {
        private List<BUKlant> klanten;

        public CC_klant_beheer()
        {
            klanten = new List<BUKlant>();
        }

        public bool voegKlantToe(string[] gegevens)
        {
            try
            {
                BUKlant.voegKlantToe(gegevens);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool wijzigKlantGegevens(int klantID, string[] gegevens)
        {
            try
            {
                BUKlant.wijzigGegevens(klantID, gegevens);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[,] getAlleKlanten()
        {
            klanten = BUKlant.geefAlleKlanten();
            if (klanten != null)
            {
                string[,] lijstklanten = new string[klanten.Count, 12];
                for (int i = 0; i < klanten.Count; i++)
                {
                    lijstklanten[i, 0] = klanten[i].ID.ToString();
                    lijstklanten[i, 1] = klanten[i].Voornaam;
                    lijstklanten[i, 2] = klanten[i].Achternaam;
                    lijstklanten[i, 3] = klanten[i].Adres;
                    lijstklanten[i, 4] = klanten[i].PostCode;
                    lijstklanten[i, 5] = klanten[i].Plaats;
                    lijstklanten[i, 6] = klanten[i].Land;
                    lijstklanten[i, 7] = klanten[i].Tel;
                    lijstklanten[i, 8] = klanten[i].Tel2;
                    lijstklanten[i, 9] = klanten[i].Fax;
                    lijstklanten[i, 10] = klanten[i].Email;
                    lijstklanten[i, 11] = klanten[i].Opmerking;
                }
                return lijstklanten;
            }
            else
                return null;
        }

        public string[] geefKlant(int klantID)
        {
            BUKlant klant = BUKlant.geefKlant(klantID);

            string[] klantGegevens = new string[12];

            klantGegevens[0] = klant.ID.ToString();
            klantGegevens[1] = klant.Voornaam;
            klantGegevens[2] = klant.Achternaam;
            klantGegevens[3] = klant.Adres;
            klantGegevens[4] = klant.PostCode;
            klantGegevens[5] = klant.Plaats;
            klantGegevens[6] = klant.Land;
            klantGegevens[7] = klant.Tel;
            klantGegevens[8] = klant.Tel2;
            klantGegevens[9] = klant.Fax;
            klantGegevens[10] = klant.Email;
            klantGegevens[11] = klant.Opmerking;

            return klantGegevens;
        }

        public string[,] geefKlantPakketten(int klantID)
        { 
            BUKlant kl = BUKlant.geefKlant(klantID);
            BUPakket[] pakketen = BUPakket.FindAllByProperty("Klanten", kl);
            
            string[,] values = new string[pakketen.Length,2];

            for (int i = 0; i < values.Length; i++)
            {
                values[i, 0] = pakketen[i].ID.ToString();
                values[i, 1] = pakketen[i].Naam;
            }

            return values;
        }

        public void verwijderKlant(int klantID)
        {
            BUKlant klant = BUKlant.Find(klantID);
            klant.Actief = false;
            klant.Update();
        }

        public string[] geefKlantenBestellingen(int klantID)
        {
            BUKlant kl = BUKlant.Find(klantID);
            BUBestellingen bes = new BUBestellingen();

            IList bestellingen = kl.geefBestellingenVanKlant();

            string[] gegevens = new string[bestellingen.Count];

            for (int i = 0; i < gegevens.Length; i++)
            {
                bes = (BUBestellingen) bestellingen[i];
                gegevens[i] = bes.ID.ToString();
            }

            return gegevens;
        }

        public string[] geefPakkettenVanBestellingen(int ID)
        {
            BUBestellingen bes = BUBestellingen.Find(ID);
            BUPakket pak = new BUPakket();

            IList pakketten = bes.Pakketten;

            string[] gegevens = new string[pakketten.Count];

            for (int i = 0; i < gegevens.Length; i++)
            {
                pak = (BUPakket)pakketten[i];
                gegevens[i] = pak.Naam;
            }

            return gegevens;
        }
    }
}
