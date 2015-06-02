using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BU
{
    /// <summary>
    /// Summary description for Location
    /// </summary>
    /// 
    public enum Environment
    {
        Forest, City, Space, Sky, Ocean
    }
    public class Location
    {
        private List<Character> characters;
        private List<Monster> monsters;
        private Environment locationType;

        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
        public List<Monster> Monsters
        {
            get { return monsters; }
            set { monsters = value; }
        }
        public Environment LocationType
        {
            get { return locationType; }
            set { locationType = value; }
        }

        public Location()
        {
            characters = new List<Character>();
            monsters = new List<Monster>();
        }
    }
}