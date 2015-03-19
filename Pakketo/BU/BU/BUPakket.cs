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
using System.Collections;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Queries;

namespace BU
{
    [ActiveRecord]
    public class BUPakket : ActiveRecordBase<BUPakket>
    {
        #region Fields

        private int pakket_ID;
        private int volume;
        private string pakket_Naam;
        private string pakket_Beschrijving;
        private string pakket_Afmeting;
        private string pakket_Gewicht;
        private string pad;
        private double pakket_Prijs;
        private IList themas;
        private IList producten;
        private IList kleuren;
        private IList klanten;
        private bool actief;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return pakket_ID; }
            set { pakket_ID = value; }
        }

        [Property]
        public string Pad
        {
            get { return pad; }
            set { pad = value; }
        }

        [Property]
        public string Afmeting
        {
            get { return pakket_Afmeting; }
            set 
            {
                if (value != null)
                {
                    pakket_Afmeting = value;
                    string[] hulp = pakket_Afmeting.Split('x');
                    Volume = int.Parse(hulp[0]) * int.Parse(hulp[1]) * int.Parse(hulp[2]);
                }
            }
        }

        [Property]
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        [Property]
        public string Naam
        {
            get { return pakket_Naam; }
            set { pakket_Naam = value; }
        }

        [Property]
        public string Beschrijving
        {
            get { return pakket_Beschrijving; }
            set { pakket_Beschrijving = value; }
        }

        [Property]
        public string Gewicht
        {
            get { return pakket_Gewicht; }
            set { pakket_Gewicht = value; }
        }

        [Property]
        public double Prijs
        {
            get { return pakket_Prijs; }
            set { pakket_Prijs = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }

        [HasAndBelongsToMany(typeof(BUThema), Table = "PakketThema", ColumnKey = "Pakket", ColumnRef = "Thema")]
        public IList Themas
        {
            get { return themas; }
            set { themas = value; }
        }

        [HasAndBelongsToMany(typeof(BUKleur), Table = "PakketKleur", ColumnKey = "Pakket", ColumnRef = "Kleur")]
        public IList Kleuren
        {
            get { return kleuren; }
            set { kleuren = value; }
        }
        
        [HasAndBelongsToMany(typeof(BUProduct), Table = "PakketProduct", ColumnKey = "Pakket", ColumnRef = "Product")]
        public IList Product
        {
            get { return producten; }
            set { producten = value; }
        }

        [HasAndBelongsToMany(typeof(BUKlant), Table = "KlantPakket", ColumnKey="Pakket", ColumnRef="Klant")]
        public IList Klanten
        {
            get { return klanten; }
            set { klanten = value; }
        }

        #endregion


        #region Constructor

        public BUPakket()
        {
            producten = new ArrayList();
            kleuren = new ArrayList();
            klanten = new ArrayList();
            themas = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static List<BUPakket> geefAllePakketten(int pakketID,int aantalpakketten)
        {
            List<BUPakket> lijstpakketten = new List<BUPakket>();
            int hulp = 0;
            int maxpakketen = BUPakket.CountAll();
            while (hulp != aantalpakketten && pakketID <= maxpakketen)
            {
                BUPakket pakket = BUPakket.Find(pakketID);
                if (pakket.Actief)
                {
                    lijstpakketten.Add(pakket);
                    hulp++;
                }
                pakketID++;
            }
            return lijstpakketten;
        }

        public static BUPakket[] geefPakketten(string likeParameter)
        {
            try
            {
                string hulp = "'" + likeParameter + "%'";
                SimpleQuery<BUPakket> q = new SimpleQuery<BUPakket>(@" from BUPakket p where p.Naam like " + hulp);
                return q.Execute();
            }
            catch
            {
                return null;
            }
        }

        public static BUPakket geefPakket(int id)
        {
            return BUPakket.Find(id);
        }

        public static BUPakket verwijderPakket(int pakketID)
        {
            try
            {
                BUPakket temp = BUPakket.Find(pakketID);
                temp.Actief = false;
                temp.Update();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public static BUPakket voegPakketToe(string naam, string beschrijving, string afmeting, string gewicht, double prijs, string pad,BUThema thema,List<BUProduct> producten,int klantID)
        {
            try
            {
                BUPakket pakket = new BUPakket();
                pakket.Create();
                pakket.Naam = naam;
                pakket.Beschrijving = beschrijving;
                pakket.Afmeting = afmeting;
                pakket.Gewicht = gewicht;
                pakket.Prijs = prijs;
                pakket.Actief = true;
                pakket.Pad = pad;
                pakket.Themas.Add(thema);
                foreach (BUProduct product in producten)
                {
                    pakket.Product.Add(product);
                }
                pakket.Klanten.Add(BUKlant.Find(klantID));
                pakket.Save();
                return pakket;
            }
            catch
            {
                return null;
            }
        }

        public static BUPakket wijzigPakket(string naam, string beschrijving, string afmeting, string gewicht, double prijs, string pad, BUThema thema, List<BUProduct> producten, int klantID, int pakketID)
        {
            try
            {
                BUPakket pakket = BUPakket.Find(pakketID);
                pakket.Naam = naam;
                pakket.Beschrijving = beschrijving;
                pakket.Afmeting = afmeting;
                pakket.Gewicht = gewicht;
                pakket.Prijs = prijs;
                pakket.Actief = true;
                pakket.Pad = pad;
                pakket.Themas.Add(thema);
                pakket.Product.Clear();
                foreach (BUProduct product in producten)
                {
                    pakket.Product.Add(product);
                }
                pakket.Klanten.Clear();
                pakket.Klanten.Add(BUKlant.Find(klantID));
                pakket.Update();
                return pakket;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        #region Methodes

        public IList geefAlleThemasVanHetPakket()
        {
            return Themas;
        }

        public IList geefAlleProductenVanHetPakket()
        {
            return Product;
        }

        public IList geefAlleKleurenVanHetPakket()
        {
            return Kleuren;
        }

        public IList geefAlleKlantenVanHetPakket()
        {
            return Klanten;
        }

        #endregion

        
    }
}
