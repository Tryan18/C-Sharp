using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZuydRPG_EF.BU
{
    public partial class Character
    {
        public static Character FindCharacterID(int Id)
        {
            using (ZuydRPGEntities context = new ZuydRPGEntities())
            {
                //Methode 1
                return context.CharacterSet.Find(Id);
                //Methode 2
                /*var character = (from c in context.CharacterSet
                                     where c.Id == Id
                                     select c);*/
                //Methode 3
                //var character2 = context.CharacterSet.Where(c => c.Id == Id).FirstOrDefault();
            }
        }

        public static void CreateCharacter(string name)
        {
            //Location moet persé toegevoegd worden, vanwege afhankelijkheid foreign key
            //Daarom moet ook een nieuw location record worden toegevoegd aan de database.
            using(ZuydRPGEntities context = new ZuydRPGEntities())
            {
                Character c = new Character();
                Location l = new Location();
                c.Location = l;
                c.Name = name;
                context.LocationSet.Add(l);
                context.CharacterSet.Add(c);
                context.SaveChanges();
            }
        }

        public static List<Character> GetAllCharacters()
        {
            using (ZuydRPGEntities context = new ZuydRPGEntities())
            {
                List<Character> characters = context.CharacterSet.ToList();
                return characters;
            }
        }
    }
}