using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenLibrary
{
    public class DeleteStrategy:IStrategy
    {
        private Tekening t;
        public DeleteStrategy(Tekening t)
        {
            this.t = t; 
        }



        public void Start(int x, int y)
        {
        }

        public void Eind(int x, int y)
        {
            int i = 0;
            bool gevonden = false;
            while (! gevonden && i < t.Plaatje.Aantal)
            {
                if (t.Plaatje.Pos(i).IsGeselecteerd(x,y))
                {
                    gevonden = true;
                }
                else
                {
                    i = i + 1;
                }
            }
            if (gevonden)
            {
                t.Plaatje.Verwijder(i);
            }
        }
    }
}
