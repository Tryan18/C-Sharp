using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BU
{
    /// <summary>
    /// Summary description for Goomba
    /// </summary>
    public class Goomba : Monster
    {
        public Goomba()
        {
            this.At = 1;
            this.Df = 3;
            this.Hp = 60;
        }
    }
}