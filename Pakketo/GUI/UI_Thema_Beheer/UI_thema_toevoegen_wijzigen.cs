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
using System.IO;
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
    public partial class UI_thema_toevoegen_wijzigen : NForm
    {
        private CC_thema_beheer themabeheer;
        private CC_kleuren_beheer kleurenbeheer = new CC_kleuren_beheer();
        private string[,] kleuren;
        private List<int> kleurenIDs = new List<int>();
        string plaatjepad;

        public UI_thema_toevoegen_wijzigen(CC_thema_beheer themabeheer)
        {
            InitializeComponent();
            this.themabeheer = themabeheer;
            LaadAllePlaatjes();
            LaadAlleKleuren();
        }

        private void LaadAlleKleuren()
        {
            kleuren = kleurenbeheer.getAlleKleuren();
            if (kleuren.GetLength(0) != 0)
            {
                int max = kleuren.GetLength(0);
                combo_kleuren.Items.Clear();
                for (int i = 0; i < max; i++)
                {
                    combo_kleuren.Items.Add(ColorTranslator.FromHtml(kleuren[i, 2]));
                    combo_kleuren.Items[i].Text = kleuren[i, 1];
                }
            }
        }

        private void LaadAllePlaatjes()
        {
            string themapad = Application.StartupPath + "\\plaatjes\\themas\\";
            string pad = themapad + "geenafbeelding.jpg";
            pb_plaatje.Image = Image.FromFile(pad);
            plaatjepad = "\\plaatjes\\themas\\geenafbeelding.jpg";
            DirectoryInfo di = new DirectoryInfo(themapad);
            FileInfo[] files = di.GetFiles();
            combo_plaatjes.Items.Clear();
            foreach (FileInfo f in files)
            {
                if (f.Extension == ".jpg" || f.Extension == ".JPG" || f.Extension == ".png" || f.Extension == ".PNG")
                {
                    string naam = f.Name.Split('.')[0];
                    combo_plaatjes.Items.Add(naam);
                    combo_plaatjes.Items[naam].Tag = (object)f.Name;
                }
            }
        }

        private void B_plaatjes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Open plaatje (JPG)|*.jpg|Open plaatje (PNG)|*.png|Alle Bestanden|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Zoek het Thema plaatje!";
            ofd.DefaultExt = ".jpg";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    string pad = "\\plaatjes\\themas\\" + fi.Name;
                    try
                    {
                        fi.CopyTo(Application.StartupPath + pad);
                    }
                    catch
                    {
                        pb_plaatje.Image = Image.FromFile(fi.FullName);
                        this.plaatjepad = pad;
                        return;
                    }
                    string naam = fi.Name.Split('.')[0];
                    combo_plaatjes.Items.Add(naam);
                    combo_plaatjes.Items[naam].Tag = (object)fi.Name;
                    pb_plaatje.Image = Image.FromFile(fi.FullName);
                    this.plaatjepad = pad;
                    
                }
                catch
                {
                    MessageBox.Show("Er is een fout opgetreden! Met het kopieren van bestand naar map!", "Fout!");
                }
            }
        }

        private void combo_plaatjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string naam = combo_plaatjes.Items[combo_plaatjes.SelectedIndex].Tag.ToString();
            string pad2 = "\\plaatjes\\themas\\";
            pb_plaatje.Image = Image.FromFile(Application.StartupPath + pad2 + naam);
            this.plaatjepad = pad2 + naam;
        }

        private void B_annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_kleurtoevoegen_Click(object sender, EventArgs e)
        {
            if (combo_kleuren.SelectedItem != null && !list_kleuren.Items.Contains(combo_kleuren.SelectedItem))
            {
                int indexcombo = combo_kleuren.Items.IndexOf(combo_kleuren.SelectedItem);
                Color c = ColorTranslator.FromHtml(kleuren[indexcombo, 2]);
                list_kleuren.Items.Add(c);
                int indexlist = list_kleuren.Items.IndexOf(combo_kleuren.SelectedItem);
                list_kleuren.Items[indexlist].Text = combo_kleuren.Items[indexcombo].Text;
                list_kleuren.Items[indexlist].Tag = combo_kleuren.Items[indexcombo].Tag;
                kleurenIDs.Add(int.Parse(kleuren[indexcombo, 0]));
            }
        }

        private void B_kleurverwijderen_Click(object sender, EventArgs e)
        {
            if (list_kleuren.SelectedItem != null)
            {
                kleurenIDs.RemoveAt(list_kleuren.SelectedIndex);
                list_kleuren.Items.Remove(list_kleuren.SelectedItem);
            }
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            if (list_kleuren.Items.Count != 0 && plaatjepad != "" && T_themanaam.Text != "")
            {
                int[] hulp = new int[kleurenIDs.Count];
                for(int i=0;i<hulp.Length;i++)
                {
                    hulp[i] = this.kleurenIDs[i];
                }
                if (themabeheer.voegThemaToe(T_themanaam.Text, T_beschrijving.Text, plaatjepad, hulp))
                {
                    MessageBox.Show("Thema Toegevoegd!", "Thema");
                }
                else
                {
                    MessageBox.Show("Er is un fout opgetreden! Thema niet toegevoegd!", "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Alle gegevens zijn nog niet ingevuld!", "Opmerking!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
