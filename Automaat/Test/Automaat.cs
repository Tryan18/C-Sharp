/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Test
{
    public partial class Automaat : Form
    {
        private String[] automaatje;
        private double[] prijs;
        private double geld;
        private int aantalBlikjes;

        public Automaat()
        {
            InitializeComponent();
            geld = 0;
            aantalBlikjes = 5;

            automaatje = new String[100];
            automaatje[0] = "Coca Cola";
            automaatje[1] = "Cola Light";
            automaatje[2] = "Fanta";
            automaatje[3] = "Cassis";
            automaatje[4] = "Redbull";

            prijs = new double[100];
            prijs[0] = 0.75;
            prijs[1] = 1.25;
            prijs[2] = 1.75;
            prijs[3] = 2.25;
            prijs[4] = 3.75;
            ToonAutomaat();
        }

        public void werpGeldIn(double x)
        {
            if (automaatje[0] == "Fout!")
            {
                MessageBox.Show("Sorry ,maar de blikjes automaat is kapot", "Fout!");
            }
            else if (!(automaatje[0] == "Fout!"))
            {
                geld += x;
                ToonAutomaat();
            }
            
        }

        private void ToonAutomaat()
        {
            textBlik.Clear();
            textBlik.Text += "Dit is de Blikjes Automaat van Terence" + Environment.NewLine;
            textBlik.Text += "@#@#@#@#@#@#@#@#@#@#@#@#@" + Environment.NewLine + Environment.NewLine;
            textBlik.Text += "Cash = " + geld + Environment.NewLine;
            textBlik.Text += Environment.NewLine;
            int z=0;
                for(int x=1;x<=aantalBlikjes;x++)
                {
                    textBlik.Text += "Blikje " + x + " = " + automaatje[z] + Environment.NewLine;
                    textBlik.Text += "Prijs = " + prijs[z] + Environment.NewLine + Environment.NewLine;
                    z++;
                }
            textBlik.Text += Environment.NewLine;
            textBlik.Text += "@#@#@#@#@#@#@#@#@#@#@#@#@" + Environment.NewLine;
        }

        public void KiesBlikje(int x)
        {
            x--;
            if(automaatje[x]==null)
            {
                MessageBox.Show("Hey je kunt geen blikje kiezen wat niet bestaat :P");
            }
            else if(geld>prijs[x])
            {
                geld -= prijs[x];
                ToonAutomaat();
                MessageBox.Show("Blikje "+automaatje[x]+" wordt uitgeworpen!");
            }
            else if(geld<prijs[x])
            {
                ToonAutomaat();
                MessageBox.Show("Hey je hebt niet genoeg Cash:P");
            }
        }

        private void koopKnop_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt16(koopList.Value);
            if (automaatje[0] == "Fout!")
            {
                MessageBox.Show("Sorry ,maar de blikjes automaat is kapot", "Fout!");
            }
            else if (!(automaatje[0] == "Fout!"))
            {
                KiesBlikje(y);
            }
        }

        private void geldIn_Click(object sender, EventArgs e)
        {

            Double y = Convert.ToDouble(geldBox.Text);
            if (y < 10000000 && geld < 10000000)
            {
                werpGeldIn(y);
            }
            else
            {
                MessageBox.Show("jaaaaa dat gaat un beetje te ver");
            }
        }

        public void VoegBlikjeToe(String merk, double prijs2)
        {
            Boolean gevonden = false;
            for (int i = 0; !gevonden; i++)
            {
                if (automaatje[i] == null)
                {
                    automaatje[i] = merk;
                    prijs[i] = prijs2;
                    gevonden = true;
                    aantalBlikjes++;
                }
            }
            ToonAutomaat();
        }

        private void maakBlikje_Click(object sender, EventArgs e)
        {
            if (automaatje[0] == "Fout!")
            {
                MessageBox.Show("Sorry ,maar de blikjes automaat is kapot", "Fout!");
            }
            else if (!(automaatje[0] == "Fout!"))
            {
                double y = Convert.ToInt32(maakPrijs.Text);
                VoegBlikjeToe(maakNaam.Text, y);
            }
        }

        private void geldBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void maakPrijs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public void VerwijderLaatsteBlikje()
        {
            Boolean gevonden = false;
            for (int i = 0; !gevonden && aantalBlikjes != 0; i++)
            {
                if (automaatje[i] == null)
                {
                    prijs[i - 1] = 0;
                    automaatje[i - 1] = null;
                    gevonden = true;
                    aantalBlikjes--;
                }
            }
            if (aantalBlikjes == 0)
            {
                ToonAutomaat();
                MessageBox.Show("De Blikjes Automaat is Woest en heeft dringend un sigaret nodig", "Woest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ToonAutomaat();
        }

        private void verwijderBlikje_Click(object sender, EventArgs e)
        {
            if (automaatje[0] == "Fout!")
            {
                MessageBox.Show("Sorry ,maar de blikjes automaat is kapot", "Fout!");
            }
            else if (!(automaatje[0] == "Fout!"))
            {
                VerwijderLaatsteBlikje();
            }
            
        }

        private void UnAbleToRestore()
        {
            for (int i = 0; i < 99; i++)
            {
                automaatje[i] = "Fout!";
                prijs[i] = 666;
            }
        }

        public void BlaasDeBlikjesAutomaatOp()
        {
            if (automaatje[0] == "Fout!")
            {
                MessageBox.Show("Ja je kunt maar 1x de boel kapot maken!", "Fout!");
            }
            else if (!(automaatje[0] == "Fout!"))
            {
                UnAbleToRestore();
                ToonAutomaat();
                MessageBox.Show("De Blikjes Automaat is Opgeblazen en kan niet meer worden hersteld!", "Boem!");
            }
        }

        private void boem_Click(object sender, EventArgs e)
        {
            BlaasDeBlikjesAutomaatOp();
        }

        private void Stick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@!@!@!@!@!@!@!@!@!@!@!@!@!@######Roken######@!@!@!@!@!@!@!@!@!@!@!@!@!@");
            MessageBox.Show("@!@!@!@!@!@!@!@!@!@!@!@!@!@######Is#######@!@!@!@!@!@!@!@!@!@!@!@!@!@");
            MessageBox.Show("@!@!@!@!@!@!@!@!@!@!@!@!@!@######Dodelijk#######@!@!@!@!@!@!@!@!@!@!@!@!@!@");
            if (automaatje[0] == null && prijs[0] == 0)
            {
                automaatje[0] = "Coca Cola";
                automaatje[1] = "Cola Light";
                automaatje[2] = "Fanta";
                automaatje[3] = "Cassis";
                automaatje[4] = "Redbull";
                prijs[0] = 0.75;
                prijs[1] = 1.25;
                prijs[2] = 1.75;
                prijs[3] = 2.25;
                prijs[4] = 3.75;
                maakBlikje_Click(sender, e);
                maakBlikje_Click(sender, e);
                maakBlikje_Click(sender, e);
                maakBlikje_Click(sender, e);
                maakBlikje_Click(sender, e);
            }
            ToonAutomaat();
        }
    

    }
}
