using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenLibrary
{
    public class CreateStrategy : IStrategy
    {
        private Tekening tekening;
        private Figuur f;

        public CreateStrategy(Tekening tekening)
        {
            this.tekening = tekening;
        }
        public void Start(int x, int y)
        {
            f = new Rechthoek(x, y);
            tekening.Plaatje.Add(f);
        }

        public void Eind(int x, int y)
        {
            f.SetEind(x, y);
        }
    }
}
