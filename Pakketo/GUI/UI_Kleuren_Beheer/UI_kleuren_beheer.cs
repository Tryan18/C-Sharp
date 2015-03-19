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

namespace GUI.UI_Kleuren_Beheer
{
    public partial class UI_kleuren_beheer : NForm
    {
        private CC_kleuren_beheer kleurbeheer = new CC_kleuren_beheer();
        string[,] kleuren;

        public UI_kleuren_beheer()
        {
            InitializeComponent();
            laatAlleKleurenZien();
        }

        private void laatAlleKleurenZien()
        {
            kleuren = kleurbeheer.getAlleKleuren();
            if (kleuren != null)
            {
                dataGridView_kleur.Rows.Clear();
                for (int i = 0; i < kleuren.GetLength(0); i++)
                {
                    dataGridView_kleur.Rows.Add();

                    dataGridView_kleur.Rows[i].Cells[0].Value = kleuren[i, 0];
                    dataGridView_kleur.Rows[i].Cells[1].Value = kleuren[i, 1];
                    dataGridView_kleur.Rows[i].Cells[2].Value = kleuren[i, 2];
                    dataGridView_kleur.Rows[i].Cells[3].Value = TekenKleur(kleuren[i, 2]);
                }
            }
        }

        private Bitmap TekenKleur(string HexID)
        {
            Image i = new Bitmap(10,10);
            Graphics g = Graphics.FromImage(i);
            SolidBrush b = new SolidBrush(ColorTranslator.FromHtml(HexID));
            g.FillRectangle(b, 0, 0, 10, 10);
            b.Dispose();
            g.Dispose();
            return (Bitmap)i;
        }

        private void B_kleurtoevoegen_Click(object sender, EventArgs e)
        {
            UI_kleur_toevoegen kleurtoevoegen = new UI_kleur_toevoegen(kleurbeheer);
            kleurtoevoegen.Show();
            kleurtoevoegen.FormClosed += new FormClosedEventHandler(kleurtoevoegen_FormClosed);
        }

        void kleurtoevoegen_FormClosed(object sender, FormClosedEventArgs e)
        {
            laatAlleKleurenZien();
        }

        private void B_sluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
