using System;
using System.Collections.Generic;

namespace BU
{
    public abstract class Character
    {
        #region Variables
        int level;
        int hp;
        int at;
        int df;
        string name;
        List<Gear> equipment;
        #endregion

        #region Properties
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int At
        {
            get { return at; }
            set { at = value; }
        }
        public int Df
        {
            get { return df; }
            set { df = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Gear> Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
        #endregion

        public Character()
        {
            this.Level = 1;
        }
    }
}