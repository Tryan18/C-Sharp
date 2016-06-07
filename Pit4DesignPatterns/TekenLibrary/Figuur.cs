using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TekenLibrary
{

    public enum Status
    {
        Maken,
        Selecteren,
        Verwijderen,
    }
    public abstract class Figuur
    {
        protected int beginX;
        protected int beginY;
        protected int eindX;
        protected int eindY;
        protected int dikte;
        protected Color kleur;

        public Figuur()
        { }
        public Figuur(int beginX, int beginY)
        {
            this.beginX = beginX;
            this.beginY = beginY;
            this.kleur = Color.Black;
            this.dikte = 3;
        }
        public virtual void SetEind(int eindX, int eindY)
        {
            this.eindX = eindX;
            this.eindY = eindY;
        }

        public abstract void Teken(Graphics graphics);

        public abstract string AsTekst();

        public abstract bool IsGeselecteerd(int x, int y);
    }
}
