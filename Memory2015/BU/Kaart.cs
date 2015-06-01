using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BU
{
    public class Kaart
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private PictureBox pb;
        private bool omgedraaid = false;
        private plaatje p;
        private int orgPos;

        public PictureBox PB
        {
            get
            {
                return pb;
            }
        }

        public Kaart()
        {

        }

        //Constructor
        public Kaart(int x, int y, int width, int height,plaatje p,int orgPos)
        {
            this.orgPos = orgPos;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.Image = CreateDefaultImage();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += pb_Click;
            this.p = p;
            //SelectPlaatje(p);
        }

        void pb_Click(object sender, EventArgs e)
        {
            if(!omgedraaid)
            { 
                SelectPlaatje(p);
                omgedraaid = true;
            }
        }

        public void SelectPlaatje(plaatje p)
        {
            Bitmap b = null;
            switch(p)
            {
                case plaatje.A:
                    b = Properties.Resources.A;
                    break;
                case plaatje.B:
                    b = Properties.Resources.B;
                    break;
                case plaatje.C:
                    b = Properties.Resources.C;
                    break;
                case plaatje.D:
                    b = Properties.Resources.D;
                    break;
                case plaatje.E:
                    b = Properties.Resources.E;
                    break;
                case plaatje.F:
                    b = Properties.Resources.F;
                    break;
                case plaatje.G:
                    b = Properties.Resources.G;
                    break;
                case plaatje.H:
                    b = Properties.Resources.H;
                    break;
            }
            pb.Image = b;
        }

        private Image CreateDefaultImage()
        {
            Image returnImage = new Bitmap(100,100);
            Graphics g = Graphics.FromImage(returnImage);
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 100, 100));
            g.Dispose();
            return returnImage;
        }
    }
}
