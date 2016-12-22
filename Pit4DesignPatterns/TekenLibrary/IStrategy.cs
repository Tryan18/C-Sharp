using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenLibrary
{
    interface IStrategy
    {
        void Start(int x, int y);
        void Eind(int x, int y);
    }
}
