using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TekenLibrary
{
    public class Tekening: Observable
    {
        private Groep plaatje;
        private Figuur f;
        private int width;
        private int height;
        private IStrategy strategie;
        private Bitmap bmp;
        private Graphics bmpGraphics;


        public Groep Plaatje
        {
            get { return plaatje; }
            set { plaatje = value; }
        }

        public Tekening()
        {
            plaatje = new Groep(0, 0);
            width = 1000;
            height = 800;
            bmp = new Bitmap(this.width, this.height);
            bmpGraphics = Graphics.FromImage(bmp);

            strategie = new CreateStrategy(this);
        }

        private event EventHandler gewijzigd;

        public override void Attach(EventHandler callback)
        {
            gewijzigd += (EventHandler) callback;
        }

        public override void Detach(EventHandler callback)
        {
            gewijzigd -= (EventHandler)callback;
        }

        public override void Notify()
        {
            if (gewijzigd != null)
            {
                gewijzigd(this, new EventArgs());
            }
        }

        public void AddNew(int x, int y)
        {
            f = new Rechthoek(x, y);
            plaatje.Add(f);
            Notify();
        }

        public void SetEind(int p1, int p2)
        {
            f.SetEind(p1, p2);
            Notify();
        }

        public Bitmap Tekenen()
        {
            bmpGraphics.Clear(Color.White);
            plaatje.Teken(bmpGraphics);
            return bmp;

        }

        public string AsText()
        {
            return plaatje.AsTekst();
        }

        public void StartSelecteren(int p1, int p2)
        {
            strategie.Start(p1, p2);
        }

        public void EindeSelecteren(int p1, int p2)
        {
            strategie.Eind(p1, p2);
            Notify();
        }

        public void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Maken:
                    strategie = new CreateStrategy(this);
                    break;
                case Status.Selecteren:
                    break;
                case Status.Verwijderen:
                    strategie = new DeleteStrategy(this);
                    break;
                default:
                    break;
            }
        }
    }
}
