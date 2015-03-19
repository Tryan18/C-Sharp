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
    public partial class UI_klant_beheer : NForm
    {
        private CC_klant_beheer klantbeheer;
        private string[,] klanten;
        private int selectedItem;

        public UI_klant_beheer()
        {
            InitializeComponent();
            klantbeheer = new CC_klant_beheer();
            refreshKlanten();
            vulLijstKlanten();

        }

        private void vulLijstKlanten()
        {
            if(klanten != null)
            {
                dataGridView_klanten.Rows.Clear();
                for (int i = 0; i < klanten.GetLength(0); i++)
                {
                    dataGridView_klanten.Rows.Add();
                    dataGridView_klanten.Rows[i].Cells[0].Value = klanten[i, 0];
                    dataGridView_klanten.Rows[i].Cells[1].Value = klanten[i, 1];
                    dataGridView_klanten.Rows[i].Cells[2].Value = klanten[i, 2];
                }
            }
        }

        private void refreshKlanten()
        {
            klanten = klantbeheer.getAlleKlanten();
        }

        private void B_klanttoevoegen_Click(object sender, EventArgs e)
        {
            UI_nieuw_wijzig_klant nieuwklant = new UI_nieuw_wijzig_klant(klantbeheer, 0);
            nieuwklant.Show();
            nieuwklant.FormClosed += new FormClosedEventHandler(nieuwklant_FormClosed);
        }

        void nieuwklant_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Focus();
            refreshKlanten();
            vulLijstKlanten();
        }

        private void B_klantenlijst_Click(object sender, EventArgs e)
        {
            refreshKlanten();
            vulLijstKlanten();
        }


        #region Events

        //datagridview selection changed event
        private void dataGridView_klanten_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_klanten.SelectedRows.Count > 0)
            {
                selectedItem = Convert.ToInt32(dataGridView_klanten.SelectedRows[0].Cells[0].Value);
                if (selectedItem > 0)
                {
                    laadKlantGegevens(selectedItem);
                    laadKlantBestellingen(selectedItem);
                    nListBox2.Items.Clear();
                }
            }
        }

        private void laadKlantBestellingen(int ID)
        {
            nListBox1.Items.Clear();

            string[] gegevens = klantbeheer.geefKlantenBestellingen(ID);

            for (int i = 0; i < gegevens.Length; i++)
            {
                nListBox1.Items.Add(gegevens[i]);
            }
        }

        private void laadKlantGegevens(int klantID)
        {
            string[] klantGegevens = klantbeheer.geefKlant(klantID);

            L_klantnr.Text = klantGegevens[0];
            L_klantvoornaam.Text = klantGegevens[1];
            L_klantachternaam.Text = klantGegevens[2];
            L_klantadres.Text = klantGegevens[3];
            L_klantpostcode.Text = klantGegevens[4];
            L_klantplaats.Text = klantGegevens[5];
            L_klantland.Text = klantGegevens[6];
            L_klanttel.Text = klantGegevens[7];
            L_klanttel2.Text = klantGegevens[8];
            L_klantfax.Text = klantGegevens[9];
            L_klantemail.Text = klantGegevens[10];
            T_opmerking.Text = klantGegevens[11];
        }

        #endregion

        private void nListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            laadPakkettenVanBestelling(Convert.ToInt32(nListBox1.SelectedItemTag));

        }

        private void laadPakkettenVanBestelling(int p)
        {
            nListBox2.Items.Clear();

            string[] gegevens = klantbeheer.geefPakkettenVanBestellingen(p);

            for (int i = 0; i < gegevens.Length; i++)
            {
                nListBox2.Items.Add(gegevens[i]);
            }
        }

        private void B_klantverwijderen_Click(object sender, EventArgs e)
        {
            if (selectedItem > 0)
            {
                if(MessageBox.Show("Wilt u verwijderen ?", "Klant Verwijderen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    klantbeheer.verwijderKlant(selectedItem);
                    refreshKlanten();
                    vulLijstKlanten();
                }
            }
        }

        private void B_klantwijzigen_Click(object sender, EventArgs e)
        {
            if (selectedItem > 0)
            {
                UI_nieuw_wijzig_klant nieuwklant = new UI_nieuw_wijzig_klant(klantbeheer, selectedItem);
                nieuwklant.Show();
                nieuwklant.FormClosed += new FormClosedEventHandler(nieuwklant_FormClosed);
            }
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
