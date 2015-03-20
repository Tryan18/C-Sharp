using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleBobble
{
    public partial class Form1 : Form
    {
        //Globale variabel
        private SpeelBox sb;

        public Form1()
        {
            InitializeComponent();
            sb = new SpeelBox(this);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            sb.Stop();
            sb.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(sb != null)
            {
                sb.MouseClick(e.X, e.Y);
            }
        }
    }
}
