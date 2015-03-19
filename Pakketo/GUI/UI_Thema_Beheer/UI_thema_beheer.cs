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

namespace GUI.UI_Thema_Beheer
{
    public partial class UI_thema_beheer : NForm
    {
        private CC_thema_beheer themabeheer = new CC_thema_beheer();
        private string[,] themas;

        public UI_thema_beheer()
        {
            InitializeComponent();
            laatAlleThemasZien();
        }

        private void B_sluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_thematoevoegen_Click(object sender, EventArgs e)
        {
            UI_thema_toevoegen_wijzigen thematoevoegen = new UI_thema_toevoegen_wijzigen(themabeheer);
            thematoevoegen.Show();
            thematoevoegen.FormClosed += new FormClosedEventHandler(thematoevoegen_FormClosed);
        }

        private void thematoevoegen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Focus();
            laatAlleThemasZien();
        }

        private void laatAlleThemasZien()
        {
            themas = themabeheer.getAlleThemas();
            if (themas != null)
            {
                dataGridView_thema.Rows.Clear();
                for (int i = 0; i < themas.GetLength(0); i++)
                {
                    dataGridView_thema.Rows.Add();
                    dataGridView_thema.Rows[i].Cells[0].Value = themas[i, 0];
                    dataGridView_thema.Rows[i].Cells[1].Value = themas[i, 1];
                }
            }
        }

        private void dataGridView_thema_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshDatagrid();
        }

        private void B_themalijst_Click(object sender, EventArgs e)
        {
            laatAlleThemasZien();
        }

        private void dataGridView_thema_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {
            refreshDatagrid();
        }

        private void refreshDatagrid()
        {
            if (dataGridView_thema.SelectedRows.Count != 0)
            {
                int index = dataGridView_thema.SelectedRows[0].Index;
                T_beschrijving.Text = themas[index, 2];
                pb_plaatje.Image = Image.FromFile(Application.StartupPath + themas[index, 3]);
                string[] hulp;
                string[] hulp2;
                if (themas[index, 4] != "")
                {
                    hulp = themas[index, 4].Split(',');
                    list_kleuren.Items.Clear();
                    foreach (string s in hulp)
                    {
                        if (s != "")
                            list_kleuren.Items.Add(s);
                    }
                }
                if (themas[index, 5] != "")
                {
                    hulp2 = themas[index, 5].Split(',');
                    list_pakketten.Items.Clear();
                    foreach (string s in hulp2)
                    {
                        if (s != "")
                            list_pakketten.Items.Add(s);
                    }
                }
            }
        }

        private void dataGridView_thema_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            refreshDatagrid();
        }
    }
}
