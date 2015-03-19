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
    public class BUKleur : ActiveRecordBase<BUKleur>
    {
        
        #region Fields

        private int kleur_ID;
        private string kleur_Naam;
        private string kleur_HEXID;
        private bool actief;
        private IList themas;
        private IList pakketten;

        #endregion


        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return kleur_ID; }
            set { kleur_ID = value; }
        }

        [Property]
        public string Naam
        {
            get { return kleur_Naam; }
            set { kleur_Naam = value; }
        }

        [Property]
        public string HEXID
        {
            get { return kleur_HEXID; }
            set { kleur_HEXID = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }

        [HasAndBelongsToMany(typeof(BUThema), Table = "KleurThema", ColumnKey = "Kleur", ColumnRef = "Thema")]
        public IList Themas
        {
            get { return themas; }
            set { themas = value; }
        }

        [HasAndBelongsToMany(typeof(BUPakket), Table = "PakketKleur", ColumnKey = "Kleur", ColumnRef = "Pakket")]
        public IList Pakketten
        {
            get { return pakketten; }
            set { pakketten = value; }
        }

        #endregion 


        #region Constructor

        public BUKleur()
        {
            themas = new ArrayList();
            pakketten = new ArrayList();
        }

        #endregion


        #region Static Methodes

        public static BUKleur geefKleur(int id)
        {
            return BUKleur.Find(id);
        }

        public static BUKleur voegKleurToe(string naam, string hexid)
        {
            try
            {
                BUKleur kleur = new BUKleur();
                kleur.Create();
                kleur.Naam = naam;
                kleur.HEXID = hexid;
                kleur.Actief = true;
                kleur.Save();
                return kleur;
            }
            catch
            {
                return null;
            }
        }

        public static List<BUKleur> getAlleKleuren()
        {
            List<BUKleur> kleurenlijst = new List<BUKleur>();
            int totaal = BUKleur.CountAll();
            for (int i = 1; i <= totaal; i++)
            {
                BUKleur kleur = BUKleur.Find(i);
                if (kleur.Actief)
                {
                    kleurenlijst.Add(kleur);
                }
            }
            return kleurenlijst;
        }

        public BUKleur[] zoekMetHEXID(string hexId)
        {
            return BUKleur.FindAllByProperty("HEXID", hexId);
        }

        #endregion



    }
}
