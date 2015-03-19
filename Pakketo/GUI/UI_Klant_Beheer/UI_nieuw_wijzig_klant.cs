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
using Nevron.UI.WinForm.Controls;
using CC;

namespace GUI.UI_Klant_Beheer
{
    public partial class UI_nieuw_wijzig_klant : NForm
    {
        private CC_klant_beheer klantbeheer;
        private bool wijzig;
        private int klantID;

        public UI_nieuw_wijzig_klant(CC_klant_beheer klantbeheer, int ID)
        {
            InitializeComponent();
            this.klantbeheer = klantbeheer;

            if (ID != 0)
            {
                this.Text = "Wijzig Klant";
                wijzig = true;
                this.klantID = ID;
                laadGegevens(klantID);
            }
        }

        private void B_annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            string[] gegevens = laadGegevensToString();

            if (!wijzig)
            {
                if (klantbeheer.voegKlantToe(gegevens))
                {
                    MessageBox.Show("Klant Opgeslagen!", "Nieuwe Klant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Er is een fout opgetreden!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            { 
                klantbeheer.wijzigKlantGegevens(klantID, gegevens);
                this.Close();
            }
        }

        private string[] laadGegevensToString()
        {
            string[] gegevens = new string[11];
            gegevens[0] = T_klantvoornaam.Text;
            gegevens[1] = T_klantachternaam.Text;
            gegevens[2] = T_klantadres.Text;
            gegevens[3] = T_klantpostcode.Text;
            gegevens[4] = T_klantplaats.Text;
            gegevens[5] = T_klantland.Text;
            gegevens[6] = T_klanttel.Text;
            gegevens[7] = T_klanttel2.Text;
            gegevens[8] = T_klantfax.Text;
            gegevens[9] = T_klantemail.Text;
            gegevens[10] = T_opmerking.Text;
            return gegevens;
        }

        private void laadGegevens(int klantID)
        {
            string[] gegevens = klantbeheer.geefKlant(klantID);

            T_klantvoornaam.Text = gegevens[1];
            T_klantachternaam.Text = gegevens[2];
            T_klantadres.Text = gegevens[3];
            T_klantpostcode.Text = gegevens[4];
            T_klantplaats.Text = gegevens[5];
            T_klantland.Text = gegevens[6];
            T_klanttel.Text = gegevens[7];
            T_klanttel2.Text = gegevens[8];
            T_klantfax.Text = gegevens[9];
            T_klantemail.Text = gegevens[10];
            T_opmerking.Text = gegevens[11];
        }
    }
}
