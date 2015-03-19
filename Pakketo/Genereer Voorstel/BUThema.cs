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
        private string thema_Naam;
        private string thema_Beschrijving;
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

        public static BUThema[] geefAlleThemas()
        {
            return BUThema.FindAll();
        }

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

        #endregion
    }
}
