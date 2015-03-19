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

namespace GUI
{
    public partial class UI_pakket_beheer : NForm
    {
        private CC_pakket_beheer pakketbeheer;
        private string[,] pakketten;
        private int lengtepakketlijst = 7;
        private List<int> pakketIDs = new List<int>();
        private int paginaNR = 0;
        private bool zoeken = false;

        public UI_pakket_beheer()
        {
            InitializeComponent();
            pakketbeheer = new CC_pakket_beheer();
            pakketIDs.Add(1);
            haalPakkettenOp();
            //maakVoorbeeld();
        }

        #region Methodes



        private void haalPakkettenOp()
        {
            int laatstepakketID = 1;
            if (dataGridView_Pakketten.Rows.Count != 0 && dataGridView_Pakketten.Rows[dataGridView_Pakketten.Rows.Count - 1].Cells[0].Value != null)
            {
                int temp = Convert.ToInt32(dataGridView_Pakketten.Rows[dataGridView_Pakketten.Rows.Count - 1].Cells[0].Value);
                if (!pakketIDs.Contains(temp))
                {
                    pakketIDs.Add(temp);
                }

                laatstepakketID = pakketIDs[paginaNR];

                laadSchermVenster(dataGridView_Pakketten.Rows.Count);
            }

            pakketbeheer.getAllePakketen(laatstepakketID, lengtepakketlijst);

            ToonPakketten();

        }

        private void ToonPakketten()
        {
            pakketten = pakketbeheer.refreshPakketen();

            if (pakketten != null)
            {
                dataGridView_Pakketten.Rows.Clear();
                for (int i = 0; i < pakketten.GetLength(0); i++)
                {
                    voegPakketAanLijst(pakketten[i, 0], pakketten[i, 1], laadAfbeelding(pakketten[i, 8]));
                }
            }
            else
            {
                dataGridView_Pakketten.Rows.Clear();
                dataGridView_Producten.Rows.Clear();
            }
        }

        private void laadSchermVenster(int index)
        {
            dataGridView_Producten.Rows.Clear();
            for (int i = 0; i < index; i++)
            {
                dataGridView_Pakketten.Rows[i].Cells[0].Value = null;
                dataGridView_Pakketten.Rows[i].Cells[1].Value = "Bezig met Pakketten laden!";
                dataGridView_Pakketten.Rows[i].Cells[2].Value = new Bitmap(10, 10);
            }
            this.Refresh();
        }

        private void haalProductenOp()
        {
            dataGridView_Producten.Rows.Clear();
            string[,] producten = pakketbeheer.refreshProducten(dataGridView_Pakketten.CurrentCell.RowIndex);

            for (int i = 0; i < producten.GetLength(0); i++)
            {
                voegProductAanLijst(producten[i, 0], producten[i, 1], producten[i, 6], laadAfbeelding(producten[i,7]));
            }
            if (dataGridView_Producten.Rows.Count != 0)
            {
                dataGridView_Producten.Rows[0].Selected = false;
            }
        }

        private Bitmap laadAfbeelding(string pad)
        {
            if (pad == " ")
            {
                return new Bitmap(10, 10);
            }
            else
            return (Bitmap)Image.FromFile(Application.StartupPath + pad);
        }

        //pakket toevoegen datagridview
        private void voegPakketAanLijst(string Nummer, string Naam, Bitmap Afbeelding)
        {
            object[] values = new object[3];

            values[0] = Nummer;
            values[1] = Naam;
            values[2] = Afbeelding;

            dataGridView_Pakketten.Rows.Add(values);
        }

        //product toevoegen aan lijst
        private void voegProductAanLijst(string Nummer, string Naam, string Aantal, Bitmap Afbeelding)
        {
            object[] values = new object[4];

            values[0] = Nummer;
            values[1] = Naam;
            values[2] = Aantal;
            values[3] = Afbeelding;

            dataGridView_Producten.Rows.Add(values);
        }


        #endregion


        #region Events

        //Expander keydown event
        private void nExpander1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                if (nExpander1.State == ExpanderState.Collapsed)
                    nExpander1.State = ExpanderState.Expanded;
                else
                    nExpander1.State = ExpanderState.Collapsed;
            }
        }

        // datagridview pakketten selection changed event
        private void dataGridView_Pakketten_SelectionChanged(object sender, EventArgs e)
        {
            //laad de pakket gegevens
            if (pakketten != null && dataGridView_Pakketten.CurrentCell.RowIndex < pakketten.GetLength(0))
            {
                int index = dataGridView_Pakketten.CurrentCell.RowIndex;
                L_pakketnr.Text = pakketten[index, 0];
                L_pakketnaam.Text = pakketten[index, 1];
                T_pakketbeschrijving.Text = pakketten[index, 2];
                L_pakketlengte.Text = pakketten[index, 3];
                L_pakketbreedte.Text = pakketten[index, 4];
                L_pakkethoogte.Text = pakketten[index, 5];
                L_pakketgewicht.Text = pakketten[index, 6];
                L_pakketprijs.Text = pakketten[index, 7];
                pb_overzicht.Image = laadAfbeelding(pakketten[index, 8]);
                L_pakketthema.Text = pakketten[index, 9];
                L_klantNR.Text = pakketten[index, 10];
                L_klantnaam.Text = pakketten[index, 11];
                T_opmerking.Text = pakketten[index, 12];

                haalProductenOp();
            }
        }

        //pakket toevoegen button  mouseclick event
        private void B_pakkettoevoegen_Click(object sender, EventArgs e)
        {
            UI_nieuw_wijzig_pakket pakkettoe = new UI_nieuw_wijzig_pakket();
            this.Hide();
            pakkettoe.Show();
            pakkettoe.FormClosed += new FormClosedEventHandler(pakkettoe_FormClosed);
        }

        void pakkettoe_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Focus();
            this.Show();
            haalPakkettenOp();
            dataGridView_Pakketten.Focus();
        }

        //pakket wijzigen button mouseclick event
        private void B_pakketwijzigen_Click(object sender, EventArgs e)
        {
            if (dataGridView_Pakketten.SelectedRows.Count != 0 && dataGridView_Pakketten.SelectedRows[0].Cells[0].Value != null)
            {
                int indexpakket = dataGridView_Pakketten.SelectedRows[0].Index;
                UI_nieuw_wijzig_pakket pakketwijz = new UI_nieuw_wijzig_pakket(pakketten, indexpakket);
                this.Hide();
                pakketwijz.Show();
                pakketwijz.FormClosed += new FormClosedEventHandler(pakketwijz_FormClosed);
            }
        }

        void pakketwijz_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Focus();
            this.Show();
            haalPakkettenOp();
            dataGridView_Pakketten.Focus();
        }

        //pakket verwijderen button mouseclick event
        private void B_pakketverwijderen_Click(object sender, EventArgs e)
        {
            if (dataGridView_Pakketten.SelectedRows.Count != 0 && dataGridView_Pakketten.SelectedRows[0].Cells[0].Value != null)
            {
                int pakketID = int.Parse(dataGridView_Pakketten.SelectedRows[0].Cells[0].Value.ToString());
                if (pakketbeheer.verwijderPakket(pakketID))
                {
                    haalPakkettenOp();
                    MessageBox.Show("Pakket is verwijderd!", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Pakket kon niet verwijderd worden!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataGridView_Pakketten.Focus();
            }
        }

        //annuleren button mouseclick event
        private void B_Sluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_Pakketten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (dataGridView_Producten.Rows.Count != 0)
                {
                    dataGridView_Pakketten.CurrentCell.Selected = false;
                    dataGridView_Producten.Rows[0].Selected = true;
                }
                dataGridView_Producten.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                volgendeSeriePakketten();
            }
            else if (e.KeyCode == Keys.Up)
            {
                vorigeSeriePakketten();
            }
        }

        private void dataGridView_Producten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                dataGridView_Pakketten.CurrentCell.Selected = true;
                if(dataGridView_Producten.CurrentCell != null)
                dataGridView_Producten.CurrentCell.Selected = false;
                dataGridView_Pakketten.Focus();
            }
        }

        #endregion

        private void nExpander1_MouseEnter(object sender, EventArgs e)
        {
            nExpander1.State = ExpanderState.Expanded;
        }

        private void nExpander1_MouseLeave(object sender, EventArgs e)
        {
            nExpander1.State = ExpanderState.Collapsed;
        }

        private void volgendeSeriePakketten()
        {
            if (!zoeken && dataGridView_Pakketten.Rows.Count >= lengtepakketlijst && dataGridView_Pakketten.Rows[lengtepakketlijst - 1].Selected)
            {
                dataGridView_Pakketten.Rows[0].Selected = true;
                dataGridView_Pakketten.CurrentCell = dataGridView_Pakketten.Rows[0].Cells[0];
                paginaNR++;
                veranderPaginaLabel();
                haalPakkettenOp();
            }
        }

        private void veranderPaginaLabel()
        {
            int hulp = paginaNR;
            hulp++;
            L_pagina.Text = "Pagina = " + hulp;
        }

        private void vorigeSeriePakketten()
        {
            if (!zoeken && dataGridView_Pakketten.Rows[0].Selected && paginaNR != 0)
            {
                paginaNR--;
                veranderPaginaLabel();
                haalPakkettenOp();
            }
        }

        private void B_verder_Click(object sender, EventArgs e)
        {
            if (dataGridView_Pakketten.Rows.Count == lengtepakketlijst)
            {
                dataGridView_Pakketten.Rows[lengtepakketlijst - 1].Selected = true;
            }
            volgendeSeriePakketten();
            dataGridView_Pakketten.Focus();
        }

        private void B_terug_Click(object sender, EventArgs e)
        {
            if (dataGridView_Pakketten.SelectedRows.Count != 0)
            {
                dataGridView_Pakketten.Rows[0].Selected = true;
                vorigeSeriePakketten();
                dataGridView_Pakketten.Focus();
            }
        }

        private void T_zoek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                B_X.Visible = true;
                zoeken = true;
                B_terug.Visible = false;
                B_verder.Visible = false;
                L_pagina.Visible = false;
                if (pakketbeheer.zoekPakketten(T_zoek.Text) && T_zoek.Text != "")
                {
                    ToonPakketten();
                }
                else
                {
                    geenPakketGevonden();
                }
                T_zoek.Clear();
            }
        }

        private void geenPakketGevonden()
        {
            pakketten = null;
            dataGridView_Pakketten.Rows.Clear();
            dataGridView_Producten.Rows.Clear();
            dataGridView_Pakketten.Rows.Add();
            dataGridView_Pakketten.Rows[0].Cells[1].Value = "Geen Resultaten Gevonden!";
            dataGridView_Pakketten.Rows[0].Cells[2].Value = new Bitmap(10,10);
        }

        private void B_X_Click(object sender, EventArgs e)
        {
            B_X.Visible = false;
            zoeken = false;
            B_terug.Visible = true;
            B_verder.Visible = true;
            L_pagina.Visible = true;
            T_zoek.Clear();
            haalPakkettenOp();
        }
    }
}
