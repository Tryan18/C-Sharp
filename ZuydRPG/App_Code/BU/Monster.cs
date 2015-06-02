using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BU
{
    /// <summary>
    /// Summary description for Monster
    /// </summary>
    public abstract class Monster
    {
        #region Variables
        int level;
        int hp;
        int at;
        int df;
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
        #endregion
        public Monster()
        {
            this.Level = 1;
        }
    }
}