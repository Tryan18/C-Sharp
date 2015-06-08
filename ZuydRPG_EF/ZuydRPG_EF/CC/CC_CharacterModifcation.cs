using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZuydRPG_EF.BU;

namespace ZuydRPG_EF.CC
{
    public class CC_CharacterModifcation
    {
        internal void CreateCharacter(string name)
        {
            Character.CreateCharacter(name);
        }
    }
}