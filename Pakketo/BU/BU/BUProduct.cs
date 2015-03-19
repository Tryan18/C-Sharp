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

namespace BU
{
    [ActiveRecord]
    public class BUProduct : ActiveRecordBase<BUProduct>
    {
        #region Fields

        private int product_ID;
        private int volume;
        private int aantal;
        private string product_Naam;
        private string product_Beschrijving;
        private string product_Afmeting;
        private string product_Gewicht;
        private string pad;
        private double product_Prijs;
        private bool actief;
        private IList pakketten;
        private IList themas;
        private IList kleuren;
        private string timestamp;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return product_ID; }
            set { product_ID = value; }
        }

        [Property]
        public string TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        [Property]
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        [Property]
        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        [Property]
        public string Naam
        {
            get { return product_Naam; }
            set { product_Naam = value; }
        }

        [Property]
        public string Beschrijving
        {
            get { return product_Beschrijving; }
            set { product_Beschrijving = value; }
        }

        [Property]
        public string Afmeting
        {
            get { return product_Afmeting; }
            set 
            {
                if (value != null)
                {
                    product_Afmeting = value;
                    string[] hulp = product_Afmeting.Split('x');
                    Volume = int.Parse(hulp[0]) * int.Parse(hulp[1]) * int.Parse(hulp[2]);
                }
            }
        }

        [Property]
        public string Gewicht
        {
            get { return product_Gewicht; }
            set { product_Gewicht = value; }
        }

        [Property]
        public string Pad
        {
            get { return pad; }
            set { pad = value; }
        }

        [Property]
        public double Prijs
        {
            get { return product_Prijs; }
            set { product_Prijs = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }
        
        [HasAndBelongsToMany(typeof(BUPakket), Table = "PakketProduct", ColumnKey = "Product", ColumnRef = "Pakket")]
        public IList Pakketten
        {
            get { return pakketten; }
            set { pakketten = value; }
        }

        [HasAndBelongsToMany(typeof(BUThema), Table="ProductThema", ColumnKey="Product", ColumnRef="Thema")]
        public IList Themas
        {
            get { return themas; }
            set { themas = value; }
        }

        [HasAndBelongsToMany(typeof(BUKleur), Table="ProductKleur", ColumnKey="Product", ColumnRef="Kleur")]
        public IList Kleuren
        {
            get { return kleuren; }
            set { kleuren = value; }
        }


        #endregion


        #region Constructor

        public BUProduct()
        {
            pakketten = new ArrayList();
            themas = new ArrayList();
            kleuren = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static List<BUProduct> geefAlleProducten()
        {
            BUProduct[] producten = BUProduct.FindAllByProperty("Actief", true);
            List<BUProduct> lijstproducten = new List<BUProduct>();

            foreach (BUProduct product in producten)
            {
                lijstproducten.Add(product);
            }
            return lijstproducten;
        }

        public static BUKlant geefKlant(int id)
        {
            return BUKlant.Find(id);
        }

        public static BUProduct voegProductToe(string naam, string beschrijving, string afmeting, string gewicht, double prijs, int[] themaIDs, string pad)
        {
            try
            {
                BUProduct product = new BUProduct();
                product.Create();
                product.Naam = naam;
                product.Beschrijving = beschrijving;
                product.Afmeting = afmeting;
                product.Gewicht = gewicht;
                product.Prijs = prijs;
                product.Actief = true;
                product.Themas.Clear();
                foreach (int i in themaIDs)
                {
                    product.Themas.Add(BUThema.Find(i));
                }
                product.Pad = pad;
                product.TimeStamp = DateTime.Now.ToLongTimeString();
                product.Save();
                return product;
            }
            catch
            {
                return null;
            }
        }

        public static BUProduct wijzigProduct(int productID, string naam, string beschrijving, string afmeting, string gewicht, double prijs, int[] themaIDs, string pad)
        {
            try
            {
                BUProduct product = BUProduct.Find(productID);
                product.Naam = naam;
                product.Beschrijving = beschrijving;
                product.Afmeting = afmeting;
                product.Gewicht = gewicht;
                product.Prijs = prijs;
                product.Actief = true;
                product.Themas.Clear();
                foreach (int i in themaIDs)
                {
                    product.Themas.Add(BUThema.Find(i));
                }
                product.Pad = pad;
                product.TimeStamp = DateTime.Now.ToLongTimeString();
                product.Update();
                return product;
            }
            catch
            {
                return null;
            }
        }

        public static BUProduct VeranderAantal(int productID, int aantal)
        {
            BUProduct pro = BUProduct.Find(productID);
            pro.Aantal = aantal;
            pro.Save();
            return pro;
        }

        public static BUProduct verwijderProduct(int productID)
        {
            try
            {
                BUProduct pro = BUProduct.Find(productID);
                pro.Actief = false;
                pro.Update();
                return pro;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        #region Methodes

        public IList geefPassendeKleuren()
        {
            return Kleuren;
        }
        public static List<BUProduct> geefProductenMetThema(BUThema thema)
        {
            IList producten = BUThema.Find(thema.ID).Producten;
            List<BUProduct> lijstproducten = new List<BUProduct>();
            foreach (BUProduct pro in producten)
            {
                if (pro.Actief)
                {
                    lijstproducten.Add(pro);
                }
            }
            return lijstproducten;
        }

        public IList geefPassendeThemas()
        {
            return Themas;
        }

        public IList geefAllePakkettenMetDieProduct()
        {
            return Pakketten;
        }

        public static List<BUProduct> geefProductenMetThemaHoogtePrijs(BUThema thema, int volume, double prijs, int gewicht)
        {
            List<BUProduct> lijst = new List<BUProduct>();
            BUProduct pr = new BUProduct();

            IList producten = BUThema.Find(thema.ID).Producten;


            for (int i = 0; i < producten.Count; i++)
            {
                pr = (BUProduct)producten[i];

                if (pr.Prijs <= prijs && pr.Volume <= volume &&  Convert.ToInt32(pr.Gewicht) <= gewicht)
                {
                    lijst.Add(pr);
                }
            }

            return lijst;
        }

        #endregion

    }
}
