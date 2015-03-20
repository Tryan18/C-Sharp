using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleBobble
{
    public class SpeelBox
    {
        private Random r;
        private List<Bal> ballenLijst;
        private Form1 form;
        private Rectangle raster;
        private Bal cannon;

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
            int formaatBal = 50;
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

        internal void MouseClick(int x, int y)
        {
            //MessageBox.Show("X = " + x + "Y = " + y);

        }
    }
}
