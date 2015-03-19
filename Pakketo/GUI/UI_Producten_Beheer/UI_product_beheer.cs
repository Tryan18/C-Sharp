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
    public partial class UI_product_beheer : NForm
    {
        private CC_product_beheer productbeheer;
        private CC_thema_beheer themabeheer;
        private string[,] producten;

        public UI_product_beheer()
        {
            InitializeComponent();
            productbeheer = new CC_product_beheer();
            themabeheer = new CC_thema_beheer();
            laadThemas();
        }

        private void laadThemas()
        {
            string[,] themas = themabeheer.getAlleThemas();
            if (themas != null)
            {
                int lengte = themas.GetLength(0);
                for (int i = 0; i < lengte; i++)
                {
                    combo_thema.Items.Add(themas[i, 1]);
                    combo_thema.Items[i].Tag = themas[i, 0];
                }
            }
            else
            {
                B_producttoevoegen.Enabled = false;
                B_productverwijderen.Enabled = false;
                B_productwijzigen.Enabled = false;
            }
        }

        private void B_sluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combo_thema_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProducten();
        }

        private void refreshProducten()
        {
            int index = combo_thema.SelectedIndex;
            if (index != -1)
            {
                T_beschrijving.Clear();
                pb_afbeelding.Image = new Bitmap(10, 10);
                int themaID = int.Parse(combo_thema.Items[index].Tag.ToString());
                producten = productbeheer.geefProductenMetThema(themaID);
                vulGrid();
            }
        }

        private void vulGrid()
        {
            dataGridView_product.Rows.Clear();
            int lengte = producten.GetLength(0);
            for (int i = 0; i < lengte; i++)
            {
                dataGridView_product.Rows.Add();
                dataGridView_product.Rows[i].Cells[0].Value = producten[i, 0];
                dataGridView_product.Rows[i].Cells[1].Value = producten[i, 1];
            }
        }

        private Image laadAfbeelding(string pad)
        {
            if (pad != "")
            {
                return Image.FromFile(Application.StartupPath + pad);
            }
            else
            {
                
                return (Image)new Bitmap(10, 10);
            }
        }

        private void B_productwijzigen_Click(object sender, EventArgs e)
        {
            if (dataGridView_product.SelectedRows.Count != 0)
            {
                int productID = int.Parse(dataGridView_product.SelectedRows[0].Cells[0].Value.ToString());
                UI_nieuw_wijzig_product product = new UI_nieuw_wijzig_product(productbeheer,productID);
                this.Hide();
                product.Show();
                product.FormClosed += new FormClosedEventHandler(product_FormClosed);
            }
                
        }

        private void B_producttoevoegen_Click(object sender, EventArgs e)
        {
            UI_nieuw_wijzig_product product = new UI_nieuw_wijzig_product(productbeheer);
            this.Hide();
            product.Show();
            product.FormClosed += new FormClosedEventHandler(product_FormClosed);
        }

        void product_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshProducten();
            this.Show();
        }

        private void B_productverwijderen_Click(object sender, EventArgs e)
        {
            if (dataGridView_product.SelectedRows.Count != 0)
            {
                int productID = int.Parse(dataGridView_product.SelectedRows[0].Cells[0].Value.ToString());
                if (productbeheer.verwijderProduct(productID))
                {
                    L_fout.ForeColor = Color.Green;
                    L_fout.Text = "Het Product is Verwijderd!";
                    L_fout.Focus();
                    refreshProducten();
                }
                else
                {
                    L_fout.Text = "Het Product kon niet verwijderd worden!";
                    L_fout.Focus();
                }
            }
        }

        private void L_fout_Leave(object sender, EventArgs e)
        {
            L_fout.ForeColor = Color.Red;
            L_fout.Text = "";
        }

        private void dataGridView_product_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView_product.SelectedRows.Count != 0)
            {
                int index = dataGridView_product.SelectedRows[0].Index;
                T_beschrijving.Text = producten[index, 2];
                pb_afbeelding.Image = laadAfbeelding(producten[index, 9]);
            }
        }
    }
}
