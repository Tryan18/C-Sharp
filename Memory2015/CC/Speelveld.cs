using BU;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC
{
    public class Speelveld
    {
        private int matrixIndex;
        private Size groupbox_size;
        int offset = 15;
        public delegate void AddControlEventHandler(Control c);
        public event AddControlEventHandler aceh;
        private List<Kaart> kaarten;

        //Constructor
        public Speelveld(int matrixIndex, Size groupbox_size)
        {
            this.matrixIndex = matrixIndex;
            this.groupbox_size = groupbox_size;
            kaarten = new List<Kaart>();
        }

        public void Start()
        {
            int x = offset;
            int y = offset;
            int width = CalculatePictureboxWidth();
            int height = CalculatePictureboxHeight();

            for(int i=0;i<matrixIndex;i++)
            {
                for(int j=0;j<matrixIndex;j++)
                {
                    //Kaart Object aanmaken
                    Kaart k = new Kaart(x, y, width, height);
                    kaarten.Add(k);
                    aceh(k.PB);
                    x += offset + width;
                }
                x = offset;
                y += offset + height;
            }

        }

        private int CalculatePictureboxWidth()
        {
            int offsetSpace = offset * (matrixIndex + 1);
            int pictureboxWidth = (groupbox_size.Width - offsetSpace) / matrixIndex;
            return pictureboxWidth;
        }

        private int CalculatePictureboxHeight()
        {
            int offsetSpace = offset * (matrixIndex + 1);
            int pictureboxHeight = (groupbox_size.Height - offsetSpace) / matrixIndex;
            return pictureboxHeight;
        }
    }
}
