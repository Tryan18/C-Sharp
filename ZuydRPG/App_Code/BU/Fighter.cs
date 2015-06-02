using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BU
{
    /// <summary>
    /// Summary description for Fighter
    /// </summary>
    public class Fighter : Character
    {
        public Fighter()
        {
            this.At = 20;
            this.Df = 15;
            this.Hp = 100;
        }
    }
}