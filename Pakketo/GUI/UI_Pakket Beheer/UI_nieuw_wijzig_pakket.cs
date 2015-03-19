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
using System.IO;
using CC;
using GUI.UI_Pakket_Beheer;

namespace GUI
{
    public partial class UI_nieuw_wijzig_pakket : NForm
    {
        private CC_thema_beheer themabeheer = new CC_thema_beheer();
        private CC_product_beheer productbeheer = new CC_product_beheer();
        private CC_pakket_beheer pakketbeheer = new CC_pakket_beheer();
        private string[,] producten;
        public int klantID = 0;
        private int pakketID;
        private int indexpakket;
        private bool nieuwpakket = true;

        public UI_nieuw_wijzig_pakket()
        {
            InitializeComponent();
            this.Text = "Nieuw Pakket Toevoegen";
            laadComboGegevens();
        }

        public UI_nieuw_wijzig_pakket(string[,] gegevens,int indexpakket)
        {
            
            InitializeComponent();
            this.Text = "Wijzig Pakket";
            group_voorstel.Visible = false;
            laadComboGegevens();
            vulGegevensIn(gegevens,indexpakket);
            nieuwpakket = false;
        }

        private void vulGegevensIn(string[,] gegevens, int index)
        {
            indexpakket = index;
            pakketID = int.Parse(gegevens[index,0]);
            T_pakketnaam.EntryControl.Text = gegevens[index, 1];
            T_pakketbeschrijving.Text = gegevens[index, 2];
            T_pakketlengte.Text = gegevens[index, 3];
            T_pakketbreedte.Text = gegevens[index, 4];
            T_pakkethoogte.Text = gegevens[index, 5];
            T_pakketgewicht.EntryControl.Text = gegevens[index, 6];
            T_pakketprijs.EntryControl.Text = gegevens[index, 7];

            pb_pakketafbeelding.Tag = gegevens[index, 8];
            pb_pakketafbeelding.Image = laadAfbeelding(gegevens[index, 8]);

            int temp = combo_thema.Items[gegevens[index, 9]].Index;
            combo_thema.SelectedIndex = temp;

            klantID = int.Parse(gegevens[index, 10]);
            T_klant.Text = gegevens[index, 11];
            T_opmerking.Text = gegevens[index, 12];
        }

        private Image laadAfbeelding(string pad)
        {
            return Image.FromFile(Application.StartupPath + pad);
        }

        private void laadComboGegevens()
        {
            string[,] themas = themabeheer.getAlleThemas();
            string[,] paden = leesPakketAfbeeldingen();
            if (themas != null)
            {
                for (int i = 0; i < themas.GetLength(0); i++)
                {
                    combo_thema.Items.Add(themas[i, 1]);
                    combo_thema.Items[i].Tag = themas[i, 0];
                }
            }
            for(int i =0;i<paden.GetLength(0);i++)
            {
                combo_plaatjes.Items.Add(paden[i,1]);
                combo_plaatjes.Items[i].Tag = paden[i, 0];
            }
        }

        private string[,] leesPakketAfbeeldingen()
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\plaatjes\\pakketten");
            FileInfo[] fi = di.GetFiles();
            string[,] paden = new string[fi.Length,2];
            for (int i = 0; i < paden.GetLength(0); i++)
            {

                if (fi[i].Extension == ".jpg" || fi[i].Extension == ".JPG" || fi[i].Extension == ".png" || fi[i].Extension == ".PNG")
                {
                    paden[i, 0] = "\\plaatjes\\pakketten\\" + fi[i].Name;
                    paden[i, 1] = fi[i].Name.Split('.')[0].ToString();
                }
            }
            return paden;
        }

        #region Events


        //maak voorstel clicked
        private void B_maakvoorstel_Click(object sender, EventArgs e)
        {
            maakVoorstel();
        }

        //listbox voorstellen selected index changed
        private void listbox_Voorstellen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //open voorstel clicked
        private void B_openvoorstel_Click(object sender, EventArgs e)
        {
            if (listbox_Voorstellen.SelectedIndex != -1)
            {
                int index = listbox_Voorstellen.SelectedIndex;
                object[] objecten = (object[])listbox_Voorstellen.Items[index].Tag;
                List<int> productenIDs = (List<int>)objecten[0];
                T_pakketprijs.EntryControl.Text = objecten[1].ToString();
                T_pakketgewicht.EntryControl.Text = objecten[2].ToString();
                foreach (NListBoxItem item in listbox_producten.Items)
                {
                    item.Checked = false;
                    int[] hulp = (int[])item.Tag;
                    foreach (int i in productenIDs)
                    {
                        if (hulp[0] == i)
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private void Block_Keys(KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void T_pakketlengte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Block_Keys(e);
        }

        private void T_pakketbreedte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Block_Keys(e);
        }

        private void T_pakkethoogte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Block_Keys(e);
        }

        private void T_pakketlengte_Click(object sender, EventArgs e)
        {
            T_pakketlengte.SelectAll();
        }

        private void T_pakketbreedte_Click(object sender, EventArgs e)
        {
            T_pakketbreedte.SelectAll();
        }

        private void T_pakkethoogte_Click(object sender, EventArgs e)
        {
            T_pakkethoogte.SelectAll();
        }

        private void B_klantselecteren_Click(object sender, EventArgs e)
        {
            UI_klant_selecteren klantselect = new UI_klant_selecteren(this);
            klantselect.Show();
            klantselect.FormClosed += new FormClosedEventHandler(klantselect_FormClosed);
        }

        private void klantselect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Focus();
        }

        private void listbox_producten_CheckedChanged(object sender, NListBoxItemCheckEventArgs e)
        {
            int index = listbox_producten.SelectedIndex;
            if (index != -1)
            {
                int[] id = (int[])listbox_producten.Items[index].Tag;
                int[] id_en_aantal;

                if (listbox_producten.Items[index].Checked)
                {
                    num_aantal.Enabled = false;
                    id_en_aantal = new int[2] { id[0], (int)num_aantal.Value };
                    listbox_producten.Items[index].Tag = id_en_aantal;
                }
                else
                {
                    num_aantal.Enabled = true;
                    num_aantal.Value = 1;
                    id_en_aantal = new int[2] { id[0], 1 };
                    listbox_producten.Items[index].Tag = id_en_aantal;
                }
            }
        }

        private void listbox_producten_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listbox_producten.SelectedIndex;
            if (listbox_producten.Items[index].Checked)
            {
                int[] id_en_aantal = (int[])listbox_producten.Items[index].Tag;
                num_aantal.Enabled = false;
                num_aantal.Value = id_en_aantal[1];
            }
            else
            {
                if (!num_aantal.Enabled)
                {
                    num_aantal.Enabled = true;
                    num_aantal.Value = 1;
                }
            }

            L_productID.Text = producten[index, 0];
            L_productnaam.Text = producten[index, 1];
            T_productbeschrijving.Text = producten[index, 2];
            L_productlengte.Text = producten[index, 3];
            L_productbreedte.Text = producten[index, 4];
            L_producthoogte.Text = producten[index, 5];
            L_productgewicht.Text = producten[index, 6];
            L_productprijs.Text = producten[index, 7];
            Image image = Image.FromFile(Application.StartupPath + producten[index, 9]);
            if (image != null)
                pb_productafbeelding.Image = image;
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            if (nieuwpakket)
            {
                if (Controle())
                {
                    int index = combo_thema.SelectedIndex;
                    int themaID = int.Parse(combo_thema.Items[index].Tag.ToString());
                    List<int[]> productenIDs = new List<int[]>();
                    foreach (NListBoxItem item in listbox_producten.Items.CheckedItems)
                    {
                        productenIDs.Add((int[])item.Tag);
                    }
                    if (pakketbeheer.voegPakketToe(T_pakketnaam.EntryControl.Text, T_pakketbeschrijving.Text, T_pakketlengte.Text, T_pakketbreedte.Text, T_pakkethoogte.Text, T_pakketgewicht.EntryControl.Text, T_pakketprijs.EntryControl.Text, themaID, productenIDs, pb_pakketafbeelding.Tag.ToString(), klantID))
                    {
                        MessageBox.Show("Pakket is toegevoegd!", "Informatie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Er is een fout opgetreden! ,waarschuw de systeembeheerder!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Alle gegevens zijn nog niet ingevuld!", "Opmerking!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (Controle())
                {
                    int index = combo_thema.SelectedIndex;
                    int themaID = int.Parse(combo_thema.Items[index].Tag.ToString());
                    List<int[]> productenIDs = new List<int[]>();
                    foreach (NListBoxItem item in listbox_producten.Items.CheckedItems)
                    {
                        productenIDs.Add((int[])item.Tag);
                    }
                    if (pakketbeheer.wijzigPakket(T_pakketnaam.EntryControl.Text, T_pakketbeschrijving.Text, T_pakketlengte.Text, T_pakketbreedte.Text, T_pakkethoogte.Text, T_pakketgewicht.EntryControl.Text, T_pakketprijs.EntryControl.Text, themaID, productenIDs, pb_pakketafbeelding.Tag.ToString(), klantID, indexpakket, pakketID))
                    {
                        MessageBox.Show("Pakket is gewijzigd!", "Informatie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Er is een fout opgetreden! ,waarschuw de systeembeheerder!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Alle gegevens zijn nog niet ingevuld!", "Opmerking!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void B_plaatjes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Open plaatje (JPG)|*.jpg|Open plaatje (PNG)|*.png|Alle Bestanden|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Zoek het Pakket plaatje!";
            ofd.DefaultExt = ".jpg";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    string pad = Application.StartupPath + "\\plaatjes\\pakketten\\" + fileInfo.Name;
                    fileInfo.CopyTo(pad, true);
                    pb_pakketafbeelding.Image = Image.FromFile(fileInfo.FullName);
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden! Met het kopieren van bestand naar map!", "Fout!");
                }
            }
        }

        private void B_annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combo_plaatjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = combo_plaatjes.SelectedIndex;
            string pad = combo_plaatjes.Items[index].Tag.ToString();
            pb_pakketafbeelding.Image = Image.FromFile(Application.StartupPath + pad);
            pb_pakketafbeelding.Tag = pad;
        }

        private void combo_thema_SelectedIndexChanged(object sender, EventArgs e)
        {
            group_productenoverzicht.Visible = true;
            maakProductenLeeg();
            int index = combo_thema.SelectedIndex;
            int themaID = int.Parse(combo_thema.Items[index].Tag.ToString());
            laadProductenOverzicht(themaID);
        }

        #endregion

        private void laadProductenOverzicht(int themaID)
        {
            producten = productbeheer.geefProductenMetThema(themaID);
            listbox_producten.Items.Clear();
            for (int i = 0; i < producten.GetLength(0); i++)
            {
                listbox_producten.Items.Add(producten[i, 1]);
                listbox_producten.Items[i].Tag = new int[2] { int.Parse(producten[i, 0]), 1 };
            }
        }

        private bool Controle()
        {
            if (T_pakketnaam.EntryControl.Text != "" &&
                combo_thema.SelectedItem != null &&
                combo_plaatjes.SelectedItem != null &&
                T_pakketgewicht.EntryControl.Text != "" &&
                T_pakketprijs.EntryControl.Text != "" &&
                T_pakketlengte.Text != "" &&
                T_pakketbreedte.Text != "" &&
                T_pakkethoogte.Text != "" &&
                klantID != 0)
            {
                return true;
            }
            else
                return false;
        }

        private void maakProductenLeeg()
        {
            num_aantal.Value = 1;
            L_productnaam.Text = "";
            T_productbeschrijving.Text = "";
            L_productID.Text = "";
            L_productlengte.Text = "";
            L_productbreedte.Text = "";
            L_producthoogte.Text = "";
            L_productgewicht.Text = "";
            L_productprijs.Text = "";
            pb_productafbeelding.Image = new Bitmap(10, 10);
        }

        private void maakVoorstel()
        {
            if (T_pakketprijs.EntryControl.Text == "")
            {
                L_fout.Text = "Prijs niet ingevuld!";
                return;
            }

            else if (T_pakketgewicht.EntryControl.Text == "")
            {
                L_fout.Text = "Gewicht niet ingevuld!";
                return;
            }
            else if (T_pakketlengte.Text == "" || T_pakketlengte.Text == "Lengte")
            {
                L_fout.Text = "Lengte niet ingevuld!";
                return;
            }
            else if (T_pakketbreedte.Text == "" || T_pakketbreedte.Text == "Breedte")
            {
                L_fout.Text = "Breedte niet ingevuld!";
                return;
            }
            else if (T_pakkethoogte.Text == "" || T_pakkethoogte.Text == "Hoogte")
            {
                L_fout.Text = "Hoogte niet ingevuld!";
                return;
            }
            else if (combo_thema.SelectedItem == null)
            {
                L_fout.Text = "Thema niet geselecteerd!";
                return;
            }

            int index = combo_thema.SelectedIndex;
            int themaID = int.Parse(combo_thema.Items[index].Tag.ToString());
            List<int[]> productenIDs = new List<int[]>();
            foreach (NListBoxItem item in listbox_producten.Items.CheckedItems)
            {
                productenIDs.Add((int[])item.Tag);
            }

            if (pakketbeheer.maakVoorstel(double.Parse(T_pakketprijs.EntryControl.Text), T_pakketlengte.Text, T_pakketbreedte.Text, T_pakkethoogte.Text, themaID, Convert.ToInt32(T_pakketgewicht.EntryControl.Text), productenIDs))
            {

                vulVoorstelBox();
            }
            else
            {
                L_fout.Text = "Geen voorstel beschikbaar!";
            }
        }

        private void vulVoorstelBox()
        {
            listbox_Voorstellen.Items.Clear();
            string[,] voorstellen = pakketbeheer.refreshPakketen();
            int lengte = voorstellen.GetLength(0);
            int j = 1;
            for (int i = 0; i < lengte; i++)
            {
                List<int> productenIDs = pakketbeheer.getVoorstellingProductenIDs(i);
                object[] objecten = new object[3];
                objecten[0] = productenIDs;
                objecten[1] = voorstellen[i, 7];
                objecten[2] = voorstellen[i, 6];
                listbox_Voorstellen.Items.Add("Pakket " + j.ToString());
                listbox_Voorstellen.Items[i].Tag = objecten;
                j++;
            }
        }

        private void B_maakvoorstel_Leave(object sender, EventArgs e)
        {
            L_fout.Text = "";
        }

    }
}
