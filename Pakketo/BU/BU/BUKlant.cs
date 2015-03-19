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
using System.Collections;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;

namespace BU
{
    [ActiveRecord]
    public class BUKlant : ActiveRecordBase<BUKlant>
    {

        #region Fields

        private int klant_ID;
        private bool actief;
        private string klant_Voornaam;
        private string klant_Achternaam;
        private string klant_Adres;
        private string klant_PostCode;
        private string klant_Plaats;
        private string klant_Land;
        private string klant_Tel;
        private string klant_Tel2;
        private string klant_Fax;
        private string klant_Email;
        private string opmerking;
        private IList bestelling;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return klant_ID; }
            set{ klant_ID = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }

        [Property]
        public string Voornaam
        {
            get { return klant_Voornaam; }
            set { klant_Voornaam = value; }
        }

        [Property]
        public string Achternaam
        {
            get { return klant_Achternaam; }
            set { klant_Achternaam = value; }
        }

        [Property]
        public string Adres
        {
            get { return klant_Adres; }
            set { klant_Adres = value; }
        }

        [Property]
        public string PostCode
        {
            get { return klant_PostCode; }
            set { klant_PostCode = value; }
        }
        [Property]
        public string Plaats
        {
            get { return klant_Plaats; }
            set { klant_Plaats = value; }
        }

        [Property]
        public string Land
        {
            get { return klant_Land; }
            set { klant_Land = value; }
        }

        [Property]
        public string Tel
        {
            get { return klant_Tel; }
            set { klant_Tel = value; }
        }
        
        [Property]
        public string Tel2
        {
            get { return klant_Tel2; }
            set { klant_Tel2 = value; }
        }

        [Property]
        public string Fax
        {
            get { return klant_Fax; }
            set { klant_Fax = value; }
        }

        [Property]
        public string Email
        {
            get { return klant_Email; }
            set { klant_Email = value; }
        }

        [Property]
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }

        [HasMany(typeof(BUBestellingen))]
        public IList Bestellingen
        {
            get { return bestelling; }
            set { bestelling = value; }
        }

        #endregion


        #region Constructor

        public BUKlant()
        {
            bestelling = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static List<BUKlant> geefAlleKlanten()
        {
            int max = BUKlant.CountAll();
            List<BUKlant> listklanten = new List<BUKlant>();
            for(int i=1;i<=max;i++)
            {
                BUKlant klant = BUKlant.Find(i);
                if (klant.Actief)
                {
                    listklanten.Add(klant);
                }
            }
            return listklanten;
        }

        public static bool bestaatKlant(string vnaam, string anaam)
        {
            bool gevonden = false;

            BUKlant[] klanten = BUKlant.FindAllByProperty("Achternaam", anaam);

            for (int i = 0; i < klanten.Length; i++)
            {
                if (klanten[i].Voornaam == vnaam)
                    gevonden = true;
            }

            return gevonden;
        }

        public static BUKlant geefKlant(int id)
        {
            return BUKlant.Find(id);
        }

        #endregion


        #region Methodes

        public IList geefBestellingenVanKlant()
        {
            return Bestellingen;
        }

        #endregion

        public static void voegKlantToe(string[] gegevens)
        {
            BUKlant klant = new BUKlant();
            klant.Create();
            klant.Voornaam = gegevens[0];
            klant.Achternaam = gegevens[1];
            klant.Adres = gegevens[2];
            klant.PostCode = gegevens[3];
            klant.Plaats = gegevens[4];
            klant.Land = gegevens[5];
            klant.Tel = gegevens[6];
            klant.Tel2 = gegevens[7];
            klant.Fax = gegevens[8];
            klant.Email = gegevens[9];
            klant.Opmerking = gegevens[10];
            klant.Actief = true;
            klant.Save();
        }

        public static void wijzigGegevens(int klantID, string[] gegevens)
        {
            BUKlant klant = BUKlant.Find(klantID);

            klant.Voornaam = gegevens[0];
            klant.Achternaam = gegevens[1];
            klant.Adres = gegevens[2];
            klant.PostCode = gegevens[3];
            klant.Plaats = gegevens[4];
            klant.Land = gegevens[5];
            klant.Tel = gegevens[6];
            klant.Tel2 = gegevens[7];
            klant.Fax = gegevens[8];
            klant.Email = gegevens[9];
            klant.Opmerking = gegevens[10];

            klant.Update();
        }
    }
}
