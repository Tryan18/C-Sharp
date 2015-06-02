using BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC
{
    /// <summary>
    /// Summary description for CCNewCharacter
    /// </summary>
    public class CharacterModification
    {
        private Character mainHero;

        public Character MainHero
        {
            get { return mainHero; }
            set { mainHero = value; }
        }

        public CharacterModification()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void CreateCharacter(string name, int indexJob)
        {
            //Fighter f = new Fighter();
            Character c;
            switch(indexJob)
            {
                case 0:
                    c = new Fighter();
                    break;
                case 1:
                    c = new Mage();
                    break;
                default:
                    c = new Fighter();
                    break;
            }
            mainHero = c;
        }
    }
}