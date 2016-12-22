using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenLibrary
{
    public abstract class Observable
    {
        public abstract void Attach(EventHandler callback);

        public abstract void Detach(EventHandler callback);

        public abstract void Notify();
    }
}
