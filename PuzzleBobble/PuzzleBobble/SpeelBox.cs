using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleBobble
{
    public enum Richting
    {
        rechts,
        links
    }
    public class SpeelBox
    {
        private Random r;
        private List<Bal> ballenLijst;
        private Form1 form;
        private Rectangle raster;
        private Bal cannon;
        private Point oldLocationCannon;
        private const int formaatBal = 50;

        //Constructor
        public SpeelBox(Form1 form)
        {
            this.form = form;
            r = Program.r;
        }

        public void Start()
        {
            ballenLijst = new List<Bal>();
            int x,y,width,height;
            int aantalBallen = 10;
            int rijen = 4;
            int maxRijen = 8;
            int offset = 5;
            x = offset;
            y = offset;
            raster = new Rectangle(offset, offset, formaatBal * aantalBallen, formaatBal * maxRijen);
            maakAchtergrond();
            width = formaatBal;
            height = formaatBal;
            //Bal b = new Bal(form, x, y, width, height, ColorBall.Blue);
            //rijen
            int getal = r.Next();
            for(int i=0;i<rijen;i++)
            {
                //kollommen
                for (int j = 0; j < aantalBallen; j++)
                {
                    Bal b = new Bal(form,x,y,width,height,(ColorBall)r.Next(0,4),this,false);
                    ballenLijst.Add(b);
                    x += width;
                }
                x = 5;
                y += height;
            }
            cannon = new Bal(form, 227, 360, formaatBal, formaatBal, (ColorBall)r.Next(0, 4), this,true);
        }

        private void maakAchtergrond()
        {
            Graphics g = form.CreateGraphics();
            Brush grijzePen = Brushes.LightGray;
            Pen zwartePen = new Pen(Brushes.Black);
            Rectangle mooieRec = new Rectangle(raster.X - 4, raster.Y-4,
                raster.Width +10, raster.Height+10);
            //g.FillRectangle(grijzePen, raster);
            g.DrawRectangle(zwartePen, raster);
            grijzePen.Dispose();
            zwartePen.Dispose();
            g.Dispose();
        }

        public void Stop()
        {
            if(ballenLijst != null)
            { 
                foreach(Bal b in ballenLijst)
                {
                    b.KillBal();
                }
                cannon.KillBal();
            }
        }

        internal void MouseClick(int mouseX, int mouseY)
        {
            //MessageBox.Show("X = " + x + "Y = " + y);
            oldLocationCannon = new Point(cannon.rand.Location.X, cannon.rand.Location.Y);
            int currentX = cannon.rand.Location.X;
            int currentY = cannon.rand.Location.Y;
            //cannon bal moet altijd hoger zijn
            if (mouseY < currentY)
            {
                //links geklikt ten opzichte van de cannon bal
                //rechts geklikt ten opzichte van de cannon bal dan is mouseX groter
                if (mouseX < currentX)
                {
                    MoveCannonBal(currentX, currentY, Richting.links);
                }
                else
                {
                    MoveCannonBal(currentX, currentY, Richting.rechts);
                }
            }
        }

        private void MoveCannonBal(int x, int y, Richting rt)
        {
            Richting richting = rt;
            switch(richting)
            {
                case Richting.links:
                    x -= formaatBal;
                    break;
                case Richting.rechts:
                    x += formaatBal;
                    break;
            }
            y -= formaatBal;
            if(CheckBal(x, y))
            {
                return;
            }
            //Links eruit gevlogen
            if(x < raster.X)
            {
                richting = Richting.rechts;
            }
            //Rechts eruit gevlogen
            else if(x > raster.X + raster.Size.Width)
            {
                richting = Richting.links;
            }
            MoveCannonBal(x, y, richting);
        }

        //return true als de bal een andere bal geraakt heeft
        private bool CheckBal(int x, int y)
        {
            Rectangle checkRect = new Rectangle(x, y, formaatBal, formaatBal);
            foreach(Bal b in ballenLijst)
            {
                //contact gemaakt met een andere bal
                if(checkRect.IntersectsWith(b.rand))
                {
                    MessageBox.Show("Nummer bal: " + (ballenLijst.IndexOf(b) + 1).ToString());
                    return true;
                }
            }
            return false;
        }
    }
}
