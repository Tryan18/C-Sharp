using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TekenLibrary
{
    public class Rechthoek : Figuur
    {
        public Rechthoek() { }

        public Rechthoek(int beginX, int beginY):
            base(beginX, beginY)
        { }

        public override void SetEind(int eindX, int eindY){
            base.SetEind(eindX, eindY);
        }

        public override void Teken(Graphics graphics)
        {
            Pen p = new Pen(this.kleur, this.dikte);
            graphics.DrawRectangle(p, new Rectangle( new Point(beginX, beginY), new Size(eindX-beginX, eindY-beginY)));
            p.Dispose();
        }

        public override string AsTekst()
        {
            return "Rechthoek; " + beginX.ToString() + "; " + beginY.ToString() + " eind : "
                + eindX.ToString() + "; " + eindY.ToString();
        }

        public override bool IsGeselecteerd(int x, int y)
        {
            return x >= this.beginX && x <= this.eindX &&
                y >= this.beginY && y <= this.eindY;
        }
    }
}
