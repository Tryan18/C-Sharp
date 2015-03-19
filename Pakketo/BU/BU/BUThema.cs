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
    public class BUThema : ActiveRecordBase<BUThema>
    {

        #region Fields

        private int thema_ID;
        private bool actief;
        private string thema_Naam;
        private string thema_Beschrijving;
        private string thema_pad;
        private IList kleuren;
        private IList pakketten;
        private IList producten;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return thema_ID; }
            set { thema_ID = value; }
        }

        [Property]
        public string Naam
        {
            get { return thema_Naam; }
            set { thema_Naam = value; }
        }

        [Property]
        public string Beschrijving
        {
            get { return thema_Beschrijving; }
            set { thema_Beschrijving = value; }
        }

        [Property]
        public string Pad
        {
            get { return thema_pad; }
            set { thema_pad = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }

        [HasAndBelongsToMany(typeof(BUKleur),Table="KleurThema", ColumnKey = "Thema", ColumnRef="Kleur")]
        public IList Kleuren
        {
            get { return kleuren; }
            set { kleuren = value; }
        }
        
        [HasAndBelongsToMany(typeof(BUPakket), Table = "PakketThema", ColumnKey = "Thema", ColumnRef = "Pakket") ]
        public IList Pakketten
        {
            get { return pakketten; }
            set { pakketten = value; }
        }

        [HasAndBelongsToMany(typeof(BUProduct), Table = "ProductThema", ColumnKey = "Thema", ColumnRef = "Product")]
        public IList Producten
        {
            get { return producten; }
            set { producten = value; }
        }

        #endregion


        #region Constructor

        public BUThema()
        {
            kleuren = new ArrayList();
            pakketten = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static BUThema geefThema(int id)
        { 
            return BUThema.Find(id);
        }

        #endregion

        
        #region Methodes

        public IList geefAlleKleurenVanDieThema()
        {
            return Kleuren;
        }

        public static BUThema voegThemaToe(string naam, string beschrijving, string plaatjepad, int[] kleurenIDs)
        {
            try
            {
                BUThema thema = new BUThema();
                thema.Create();
                thema.Naam = naam;
                thema.Beschrijving = beschrijving;
                thema.Pad = plaatjepad;
                foreach (int i in kleurenIDs)
                {
                    thema.Kleuren.Add(BUKleur.Find(i));
                }
                thema.Actief = true;
                thema.Save();
                return thema;
            }
            catch
            {
                return null;
            }

        }

        public static List<BUThema> getAlleThemas()
        {
            List<BUThema> themalijst = new List<BUThema>();
            int totaal = BUThema.CountAll();
            for (int i = 1; i <= totaal; i++)
            {
                BUThema thema = BUThema.Find(i);
                if (thema.Actief)
                {
                    themalijst.Add(thema);
                }
            }
            return themalijst;
        }

        #endregion
    }
}
