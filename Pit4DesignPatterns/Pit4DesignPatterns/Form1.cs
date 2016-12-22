using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TekenLibrary;

namespace Pit4DesignPatterns
{
    public partial class Form1 : Form
    {
        private Status status;
        private int teller = 0;
        private Bitmap bmp;
        private Tekening tekening;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(this.Width, this.Height);
            status = Status.Maken;
            tekening = new Tekening();
            tekening.Attach(VerversTekening);
            FormTekstInfo frm = new FormTekstInfo();
            frm.SetTekening(tekening);
            frm.Show();
        }

        Point begPoint;
        Point endPoint;
        bool bezigSelect= false;
        //Figuur f;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (status == Status.Maken)
            //{
            //    teller++;
            //    if (teller % 2 == 0)
            //    {
            //        tekening.SetEind(e.X, e.Y);
            //        //f.SetEind(e.X, e.Y);
            //        //f.Teken(bmp);
            //        //Graphics g = this.CreateGraphics();
            //        //g.DrawImage(bmp, new Point(0, 0));
            //        //g.Dispose();
            //    }
            //    else
            //    {
            //        //if (teller % 5 == 0)
            //        //    f = new Lijn(e.X, e.Y);
            //        //else
            //        //    f = new Rechthoek(e.X, e.Y);
            //        tekening.AddNew(e.X, e.Y);
            //    }
            //}
            //if (status == Status.Selecteren)
            //{
            begPoint = new Point(e.X, e.Y);
            begPoint = PointToScreen(begPoint);
            endPoint = new Point(e.X + 10, e.Y + 10);
            endPoint = PointToScreen(endPoint);
            ControlPaint.DrawReversibleFrame(
                new Rectangle(begPoint.X, begPoint.Y, endPoint.X-begPoint.X, endPoint.Y-begPoint.Y),
                Color.Black, FrameStyle.Dashed);
            bezigSelect = true;
            tekening.StartSelecteren(e.X, e.Y);

                
            //}
        }

        /*
                    bmp = new Bitmap(this.Width, this.Height);
            tekening.Teken(bmp);
            e.Graphics.DrawImage(bmp, new Point(0,0));
        */

        private void btnMaken_Click(object sender, EventArgs e)
        {
            string naam = (sender as Button).Text;
            Enum.TryParse(naam, out status);
            tekening.SetStatus(this.status);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bezigSelect)
            {
                ControlPaint.DrawReversibleFrame(
                    new Rectangle(begPoint.X, begPoint.Y, endPoint.X - begPoint.X, endPoint.Y - begPoint.Y),
                    Color.Black, FrameStyle.Dashed);
                endPoint = new Point(e.X, e.Y);
                endPoint = PointToScreen(endPoint);
                ControlPaint.DrawReversibleFrame(
                    new Rectangle(begPoint.X, begPoint.Y, endPoint.X - begPoint.X, endPoint.Y - begPoint.Y),
                    Color.Black, FrameStyle.Dashed);
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bezigSelect = false;
            tekening.EindeSelecteren(e.X, e.Y);

        }

        private void VerversTekening(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(tekening.Tekenen(), new Point(0, 0));
            g.Dispose();

        }
    }
}
