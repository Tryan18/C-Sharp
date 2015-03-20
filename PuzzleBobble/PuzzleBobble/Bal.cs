using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleBobble
{
    public enum ColorBall : int
    {
        Red,
        Blue,
        Green,
        Purple,
        Orange
    }
    public class Bal
    {
        private PictureBox pb;
        private SpeelBox sb;

        public Bal(Form1 form,int x,int y,int width,int height,ColorBall kleur,SpeelBox sb)
        {
            this.sb = sb;
            pb = new PictureBox();
            pb.Location = new Point(x, y);
            pb.Size = new Size(width, height);
            pb.MouseClick += pb_MouseClick;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (kleur)
            {
                case ColorBall.Blue:
                    pb.Image = Properties.Resources.bubble_blue_gradient_md;
                    break;
                case ColorBall.Green:
                    pb.Image = Properties.Resources.bubble_green_md;
                    break;
                case ColorBall.Orange:
                    pb.Image = Properties.Resources.yellow_orange_bubble_hi;
                    break;
                case ColorBall.Purple:
                    pb.Image = Properties.Resources.purple_pink_bubble_hi;
                    break;
                case ColorBall.Red:
                    pb.Image = Properties.Resources.bubble_red_md;
                    break;
            }
            //GroupBox gb;
            //foreach (Control c in form.Controls)
            //{
            //    if (c is GroupBox && c.Name == "groupBox1")
            //    {
            //        gb = (GroupBox)c;
            //        gb.Controls.Add(pb);
            //        break;
            //    }
            //}
            form.Controls.Add(pb);
        }

        void pb_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X + pb.Location.X;
            int y = e.Y + pb.Location.Y;
            sb.MouseClick(x, y);
        }

        public void KillBal()
        {
            if(pb != null)
                pb.Dispose();
        }
    }
}
