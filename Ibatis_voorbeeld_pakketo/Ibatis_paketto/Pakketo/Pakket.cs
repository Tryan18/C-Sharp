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
using IBatisNet.Common;
using IBatisNet.DataMapper;

namespace Pakketo
{
    public class Pakket
    {
        #region Fields
        private int pakket_id;
        private string pakket_naam;
        private int pakket_breedte;
        private int pakket_hoogte;
        private int pakket_lengte;
        private decimal pakket_prijs;
        private Kleur pakket_kleur;
        private Thema pakket_thema;
        private List<Product> pakket_producten;
        #endregion

        #region Prop
        public int ID
        {
            get { return pakket_id; }
            set { pakket_id = value; }
        }

        public string Naam
        {
            get { return pakket_naam; }
            set { pakket_naam = value; }
        }

        public int Breedte
        {
            get { return pakket_breedte; }
            set { pakket_breedte = value; }
        }

        public int Hoogte
        {
            get { return pakket_hoogte; }
            set { pakket_hoogte = value; }
        }

        public int Lengte
        {
            get { return pakket_lengte; }
            set { pakket_lengte = value; }
        }

        public decimal Prijs
        {
            get { return pakket_prijs; }
            set { pakket_prijs = value; }
        }

        public Kleur Kleur
        {
            get { return pakket_kleur; }
            set { pakket_kleur = value; }
        }

        public Thema Thema
        {
            get { return pakket_thema; }
            set { pakket_thema = value; }
        }

        public List<Product> Producten
        {
            get { return pakket_producten; }
            set { pakket_producten = value; }
        }

        #endregion

        public Pakket()
        {
            pakket_producten = new List<Product>();
        }

        public static List<Pakket> getPakkets()
        {   
            List<Pakket> list = (List<Pakket>)Mapper.Instance().QueryForList<Pakket>("Pakket.SelectPakket", null);

            for (int i = 0; i < list.Count; i++)
			{
                list[i].Producten = Product.getProducts(list[i].ID);
			}
            
            return list;
        }

        public void savePakket()
        {
            this.ID = (int)Mapper.Instance().Insert("Pakket.insertPakket", this);

            IList<int> list = new List<int>();
            list.Add(this.ID);

            for (int i = 0; i < this.Producten.Count; i++)
            {
                list.Add(this.Producten[i].ID);
                Mapper.Instance().Insert("Pakket.insertProductsToPakket", list);
                list.RemoveAt(1);
            }
        }
    }
}
