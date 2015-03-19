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
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using CC;

namespace GUI
{
    public partial class UI_nieuw_wijzig_product : NForm
    {
        private CC_product_beheer productbeheer;
        private CC_thema_beheer themabeheer = new CC_thema_beheer();
        private string[,] themas;
        private bool nieuw = true;
        private bool clicked = false;
        private int productID;
        private int[] tijd = new int[2] { 1, 1 };
        private Timer foutTimer = new Timer();

        public UI_nieuw_wijzig_product(CC_product_beheer productbeheer)
        {
            InitializeComponent();
            this.Text = "Nieuw Product Toevoegen";
            this.productbeheer = productbeheer;
            laadAfbeeldingen();
            foutTimer.Interval = 1000;
            foutTimer.Tick += new EventHandler(foutTimer_Tick);
        }

        void foutTimer_Tick(object sender, EventArgs e)
        {
            if (tijd[1] == 3)
            {
                L_fout.ForeColor = Color.Red;
                L_fout.Text = "";
                tijd[1] = 1;
                foutTimer.Stop();
            }
            tijd[1]++;
        }

        public UI_nieuw_wijzig_product(CC_product_beheer productbeheer,int productID)
        {
            InitializeComponent();
            this.Text = "Product Wijzigen";
            this.productbeheer = productbeheer;
            this.productID = productID;
            laadAfbeeldingen();
            vulAlleGegevensIn();
            nieuw = false;
        }

        private void vulAlleGegevensIn()
        {
            listbox_themas.Items.Clear();
            string[] Productgegevens = productbeheer.getProductGegevens(productID);
            string[] themaNamen = productbeheer.getThemaNamen(productID);
            for (int i = 0; i < themaNamen.Length; i++)
            {
                for(int j=0;j<combo_thema.Items.Count;j++)
                {
                    if (themaNamen[i] == combo_thema.Items[j].Text)
                    {
                        listbox_themas.Items.Add(themaNamen[i]);
                        listbox_themas.Items[i].Tag = combo_thema.Items[themaNamen[i]].Tag;
                    }
                }
            }
            T_naam.Text = Productgegevens[1];
            T_beschrijving.Text = Productgegevens[2];
            T_lengte.Text = Productgegevens[3];
            T_breedte.Text = Productgegevens[4];
            T_hoogte.Text = Productgegevens[5];
            T_gewicht.Text = Productgegevens[6];
            T_prijs.Text = Productgegevens[7];
            pb_product.Image = laadAfbeelding(Productgegevens[8]);
            pb_product.Tag = Productgegevens[8];
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

        private void laadAfbeeldingen()
        {
            string productpad = Application.StartupPath + "\\plaatjes\\producten\\";
            string pad = productpad + "geenafbeelding.jpg";
            pb_product.Image = Image.FromFile(pad);
            pb_product.Tag = "\\plaatjes\\producten\\geenafbeelding.jpg";
            DirectoryInfo di = new DirectoryInfo(productpad);
            FileInfo[] files = di.GetFiles();
            combo_afbeelding.Items.Clear();
            foreach (FileInfo f in files)
            {
                if (f.Extension == ".jpg" || f.Extension == ".JPG" || f.Extension == ".png" || f.Extension == ".PNG")
                {
                    string naam = f.Name.Split('.')[0];
                    combo_afbeelding.Items.Add(naam);
                    combo_afbeelding.Items[naam].Tag = "\\plaatjes\\producten\\" + f.Name;
                }
            }
            pb_thema.Image = Image.FromFile(pad);
            themas = themabeheer.getAlleThemas();
            for (int i = 0; i < themas.GetLength(0); i++)
            {
                combo_thema.Items.Add(themas[i, 1]);
                    //pad
                combo_thema.Items[i].Tag = themas[i, 0];
            }
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            if (nieuw && !clicked)
            {
                if (HCI_Controle())
                {
                    clicked = true;
                    int index = combo_thema.SelectedIndex;
                    int[] themaIDs = new int[listbox_themas.Items.Count];
                    for (int i = 0; i < themaIDs.Length; i++)
                    {
                        themaIDs[i] = int.Parse(listbox_themas.Items[i].Tag.ToString());
                    }
                    if (productbeheer.voegProductToe(T_naam.Text, T_beschrijving.Text, T_lengte.Text, T_breedte.Text, T_hoogte.Text, T_gewicht.Text, T_prijs.Text, themaIDs, pb_product.Tag.ToString()))
                    {
                        L_fout.ForeColor = Color.Green;
                        L_fout.Text = "Het Product is toegevoegd!";
                        timer.Start();
                    }
                    else
                    {
                        L_fout.ForeColor = Color.Red;
                        L_fout.Text = "Er is een fout opgetreden met het product opslaan in de database!";
                        timer.Start();
                    }
                }
            }
            else if(!clicked)
            {
                if (HCI_Controle())
                {
                    if (TimeStamp_Controle())
                    {
                        clicked = true;
                        int index = combo_thema.SelectedIndex;
                        int[] themaIDs = new int[listbox_themas.Items.Count];
                        for (int i = 0; i < themaIDs.Length; i++)
                        {
                            themaIDs[i] = int.Parse(listbox_themas.Items[i].Tag.ToString());
                        }
                        if (productbeheer.wijzigProduct(productID, T_naam.Text, T_beschrijving.Text, T_lengte.Text, T_breedte.Text, T_hoogte.Text, T_gewicht.Text, T_prijs.Text, themaIDs, pb_product.Tag.ToString()))
                        {
                            L_fout.ForeColor = Color.Green;
                            L_fout.Text = "Het Product is gewijzigd!";
                            timer.Start();
                        }
                        else
                        {
                            L_fout.ForeColor = Color.Red;
                            L_fout.Text = "Er is een fout opgetreden met het product wijzigen in de database!";
                            timer.Start();
                        }
                    }
                }
            }
        }

        private bool TimeStamp_Controle()
        {
            if (productbeheer.ControleerTimeStamp(productID))
            {
                return true;
            }
            else
            {
                if (MessageBox.Show("Een andere gebruiker heeft tussentijds een record gewijzigd! \n\n Wilt u de wijzigingen zien? \n\n (als u nee klikt zullen uw wijzigingen doorgaan en overschrijven dat van een ander!) \n\n (als u ja klikt worden uw wijzigingen niet uitgevoerd!)", "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    laatGewijzigdeGegevensZien();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void laatGewijzigdeGegevensZien()
        {
            string[] Productgegevens = productbeheer.getProductGegevens(productID);
            string[] themaNamen = productbeheer.getThemaNamen(productID);
            string hulp = "";

            hulp += "Naam: " + Productgegevens[1] + "\r\n\r\n";
            hulp += "Lengte: " + Productgegevens[3] + "\r\n\r\n";
            hulp += "Breedte: " + Productgegevens[4] + "\r\n\r\n";
            hulp += "Hoogte: " + Productgegevens[5] + "\r\n\r\n";
            hulp += "Gewicht: " + Productgegevens[6] + "\r\n\r\n";
            hulp += "Prijs: " + Productgegevens[7] + "\r\n\r\n";
            hulp += "Themas: ";
            foreach (string s in themaNamen)
            {
                hulp += s + ",";
            }
            hulp = hulp.Remove(hulp.Length - 1) + "\r\n\r\n";
            hulp += "Beschrijving: \r\n" + Productgegevens[2];
            pb_wijzigafbeelding.Image = laadAfbeelding(Productgegevens[8]);

            T_wijziging.Text = hulp;
            group_wijziging.Visible = true;
        }

        private bool HCI_Controle()
        {
            if(T_naam.Text == "")
            {
                L_fout.Text = "Product naam niet ingevuld!";
                T_naam.Focus();
                return false;
            }
            if (T_gewicht.Text == "")
            {
                L_fout.Text = "Product gewicht niet ingevuld!";
                T_gewicht.Focus();
                return false;
            }
            if (T_prijs.Text == "")
            {
                L_fout.Text = "Product prijs niet ingevuld!";
                T_prijs.Focus();
                return false;
            }
            if (T_lengte.Text == "")
            {
                L_fout.Text = "Product lengte niet ingevuld!";
                T_lengte.Focus();
                return false;
            }
            if (T_breedte.Text == "")
            {
                L_fout.Text = "Product breedte niet ingevuld!";
                T_breedte.Focus();
                return false;
            }
            if (T_hoogte.Text == "")
            {
                L_fout.Text = "Product hoogte niet ingevuld!";
                T_hoogte.Focus();
                return false;
            }
            if (listbox_themas.Items.Count == 0)
            {
                L_fout.Text = "Geen thema toegevoegd!";
                combo_thema.Focus();
                return false;
            }
            return true;
        }

        private void B_annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_plaatjes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Open plaatje (JPG)|*.jpg|Open plaatje (PNG)|*.png|Alle Bestanden|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Zoek het Product plaatje!";
            ofd.DefaultExt = ".jpg";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    string pad = "\\plaatjes\\producten\\" + fi.Name;
                    try
                    {
                        fi.CopyTo(Application.StartupPath + pad);
                    }
                    catch
                    {
                        pb_product.Image = Image.FromFile(fi.FullName);
                        return;
                    }
                    string naam = fi.Name.Split('.')[0];
                    combo_afbeelding.Items.Add(naam);
                    combo_afbeelding.Items[naam].Tag = pad;
                    pb_product.Image = Image.FromFile(fi.FullName);
                    combo_afbeelding.SelectedIndex = combo_afbeelding.Items.Count - 1;
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden! Met het kopieren van bestand naar map!", "Fout!");
                }
            }
        }

        private void Block_Letters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 | e.KeyChar > 57 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void T_prijs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void combo_thema_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = combo_thema.SelectedIndex;
            string pad = themas[index, 3];
            pb_thema.Image = Image.FromFile(Application.StartupPath + pad);
        }

        private void combo_afbeelding_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = combo_afbeelding.SelectedIndex;
            string pad = combo_afbeelding.Items[index].Tag.ToString();
            pb_product.Image = Image.FromFile(Application.StartupPath + pad);
            pb_product.Tag = pad;
        }

        private void B_toevoegen_Click(object sender, EventArgs e)
        {
            if (combo_thema.SelectedIndex != -1)
            {
                int index = combo_thema.SelectedIndex;
                int themaID = int.Parse(themas[index, 0]);
                if (!listbox_themas.Items.Contains(themaID))
                {
                    string themaNaam = themas[index, 1];
                    listbox_themas.Items.Add(themaNaam);
                    int lengte = listbox_themas.Items.Count;
                    listbox_themas.Items[lengte-1].Tag = themaID;
                }
            }
        }

        private void B_verwijderen_Click(object sender, EventArgs e)
        {
            if (listbox_themas.SelectedIndex != -1)
            {
                int index = listbox_themas.SelectedIndex;
                listbox_themas.Items.RemoveAt(index);
            }
        }

        private void listbox_themas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_themas.SelectedIndex != -1)
            {
                string naam = listbox_themas.Items[listbox_themas.SelectedIndex].Text;
                int index = combo_thema.Items[naam].Index;
                string pad = themas[index, 3];
                pb_thema.Image = Image.FromFile(Application.StartupPath + pad);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tijd[0] == 2)
            {
                this.Close();
                timer.Stop();
            }
            tijd[0]++;
        }

        private void T_wijziging_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void L_fout_TextChanged(object sender, EventArgs e)
        {
            foutTimer.Start();
        }

        private void Allow_gewicht_komma(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' && (T_gewicht.Text.Contains(",") || T_gewicht.SelectionStart == 0))
            {
                e.Handled = true;
            }
            //cijfers +backspace en ','
            else if (e.KeyChar < 48 | e.KeyChar > 57 && e.KeyChar != '\b' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void Allow_prijs_komma(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' && (T_prijs.Text.Contains(",") || T_prijs.SelectionStart == 0))
            {
                e.Handled = true;
            }
            //cijfers +backspace en ','
            else if (e.KeyChar < 48 | e.KeyChar > 57 && e.KeyChar != '\b' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
