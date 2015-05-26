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

        public Kaart(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.Image = CreateDefaultImage();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
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
