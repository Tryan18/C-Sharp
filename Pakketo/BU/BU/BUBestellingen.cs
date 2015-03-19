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
    public class BUBestellingen : ActiveRecordBase<BUBestellingen>
    {

        #region Fields

        private int bestelling_ID;
        private BUKlant klant;
        private IList pakket;
        private DateTime datum_Tijd;
        private int kortingPercent;
        private double prijs;
        private bool betaald;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return bestelling_ID; }
            set { bestelling_ID = value; }
        }

        [BelongsTo("ID", Insert= false, Update=false)]
        public BUKlant Klant
        {
            get { return klant; }
            set { klant = value; }
        }

        [HasAndBelongsToMany(typeof(BUPakket), Table = "BestellingPakket", ColumnKey = "Bestelling", ColumnRef = "Pakket")]
        public IList Pakketten
        {
            get { return pakket; }
            set { pakket = value; }
        }

        [Property]
        public DateTime DatumTijd
        {
            get { return datum_Tijd; }
            set { datum_Tijd = value; }
        }

        [Property]
        public int KortingPercent
        {
            get { return kortingPercent; }
            set { kortingPercent = value; }
        }

        [Property]
        public double Prijs
        {
            get { return prijs; }
            set { prijs = value + ( value * (KortingPercent / 100)); }
        }

        [Property]
        public bool Betaald
        {
            get { return betaald; }
            set { betaald = value; }
        }

        #endregion


        #region Constructor

        public BUBestellingen()
        {
            pakket = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static BUBestellingen[] geefAlleBestellingen()
        {
            return BUBestellingen.FindAll();
        }

        public static BUBestellingen geefBestelling(int id)
        {
            return BUBestellingen.Find(id);
        }

        public static BUBestellingen[] geefOnbetaaldeBestellingen()
        {
            return BUBestellingen.FindAllByProperty("Datum", "Betaald", false);
        }

        #endregion

        
        #region Methodes

        public IList geefAllePakketten()
        {
            return Pakketten;
        }

        public BUKlant geefKlant()
        {
            return Klant;
        }

        #endregion
    }
}
