using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TekenLibrary
{
    public class Lijn : Figuur
    {
        public Lijn ()
        {
            this.beginX = 10;
            this.beginY = 10;
            this.eindX = 30;
            this.eindY = 30;
            this.kleur = Color.Red;
        }

        public Lijn (int beginX, int beginY) :
            base(beginX, beginY)
        {
        }

        public void SetEind(int eindX, int eindY) 
        {
            base.SetEind(eindX, eindY);
        }

        public override void Teken(Graphics graphics)
        {
            Pen p = new Pen(this.kleur, this.dikte);
            graphics.DrawLine(p, new Point(beginX, beginY), new Point(eindX, eindY));
            p.Dispose();
        }

        public override string AsTekst()
        {
            throw new NotImplementedException();
        }

        public override bool IsGeselecteerd(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
