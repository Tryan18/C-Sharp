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

namespace GUI.UI_Pakket_Beheer
{
    public partial class UI_klant_selecteren : NForm
    {
        private UI_nieuw_wijzig_pakket nieuwpakket;
        private CC_klant_beheer klantbeheer = new CC_klant_beheer();
        private string[,] klanten;

        public UI_klant_selecteren(UI_nieuw_wijzig_pakket nieuwpakket)
        {
            InitializeComponent();
            this.nieuwpakket = nieuwpakket;
            LaadKlanten();
        }

        private void LaadKlanten()
        {
            listbox_klanten.Items.Clear();
            klanten = klantbeheer.getAlleKlanten();
            if (klanten != null)
            {
                for (int i = 0; i < klanten.GetLength(0); i++)
                {
                    string naam = klanten[i,1] + " " + klanten[i,2];
                    listbox_klanten.Items.Add(naam);
                    listbox_klanten.Items[i].Tag = klanten[i, 0];
                }
            }
            else
            {
                MessageBox.Show("Er zijn geen klanten op dit moment geregistreerd!", "Opmerking!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void B_annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            if (listbox_klanten.SelectedItem != null && klanten != null)
            {
                int index = listbox_klanten.SelectedIndex;
                int id = int.Parse(listbox_klanten.SelectedItemTag.ToString());
                nieuwpakket.klantID = id;
                nieuwpakket.T_klant.Text = listbox_klanten.SelectedItem.ToString();
                nieuwpakket.T_opmerking.Text = klanten[index, 11];
                this.Close();
            }
            else
            {
                MessageBox.Show("Je moet wel een klant selecteren!", "Opmerking!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
