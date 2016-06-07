using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenLibrary
{
    public class Groep: Figuur
    {
        private List<Figuur> figuurtjes;

        public int Aantal
        {
            get
            {
                return figuurtjes.Count;
            }
        }

        public Groep (int beginX, int eindX):
            base(beginX, eindX)
        {
            figuurtjes = new List<Figuur>();
        }

        public override void SetEind(int eindX, int eindY)
        {
            base.SetEind(eindX, eindY);
        }


        public override void Teken(System.Drawing.Graphics graphics)
        {
            foreach (Figuur f in figuurtjes)
            {
                f.Teken(graphics);
            }
        }

        public void Add(Figuur f)
        {
            figuurtjes.Add(f);

        }

        public override string AsTekst()
        {
            string s = "";
            foreach (Figuur f in figuurtjes)
                s += f.AsTekst() + "\r\n";
            return s;
        }

        public Figuur Pos (int i){
            return figuurtjes[i];
        }

        public override bool IsGeselecteerd(int x, int y)
        {
            return false;
        }

        public void Verwijder(int i)
        {
            figuurtjes.RemoveAt(i);
        }
    }
}
