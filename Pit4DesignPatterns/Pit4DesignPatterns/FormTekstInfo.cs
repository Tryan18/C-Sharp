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
    public partial class FormTekstInfo : Form
    {
        private Tekening tekening;
        public FormTekstInfo()
        {
            InitializeComponent();
        }

        public void SetTekening(Tekening t)
        {
            this.tekening = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tekening.Attach(VerversTekst);
        }

        private void VerversTekst (object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = tekening.AsText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tekening.Detach(VerversTekst);

        }
    }
}
