using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZuydRPG_EF.BU;
using ZuydRPG_EF.HelperClasses;

namespace ZuydRPG_EF.CC
{
    public class CC_CharacterModifcation
    {
        internal bool CreateCharacter(string name)
        {
            Character c = Character.FindCharacterName(name);
            if (c == null)
            {
                Character.CreateCharacter(name);
                return true;
            }
            else
                return false;
        }

        internal List<string> GetCharacterNames()
        {
            List<string> names = new List<string>();
            List<Character> characters = Character.GetAllCharacters();
            foreach(Character c in characters)
            {
                names.Add(c.Name);
            }
            return names;
        }
    }
}