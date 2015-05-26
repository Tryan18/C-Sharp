using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory2015
{
    public partial class Form1 : Form
    {
        private Speelveld sv;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            sv = new Speelveld(Convert.ToInt32(num_matrixIndex.Value),gb_speeldveld.Size);
            sv.aceh += AddControlEvent;
            sv.Start();
            //private public verhaal
            //Console.WriteLine(sv.matrixIndex.ToString());
        }

        public void AddControlEvent(Control c)
        {
            this.gb_speeldveld.Controls.Add(c);
        }
    }
}
